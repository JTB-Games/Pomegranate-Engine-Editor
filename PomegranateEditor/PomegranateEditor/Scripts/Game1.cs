using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PomegranateMono;
using System.Windows.Input;
using System.IO;
namespace PomegranateEditor
{
    public static class Globals
    {
        public static Texture2D rect;
        public static Node selectednode;
        public static int selectednodeindex;
    }
    public class Engine : Game
    {
        public static Vector2 CameraPosition;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<SubWindow> windows = new List<SubWindow>();
        bool CreateWindowOpen;
        bool Dragging;
        Vector2 StartDrag;
        Vector2 camStartPos;
        bool Saving;
        public Engine()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            CameraPosition = new Vector2(256-64+8, 0);
            Globals.rect = new Texture2D(GraphicsDevice, 1, 1);
            Globals.rect.SetData(new Color[] { Color.White });
            _graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
            _graphics.PreferredBackBufferWidth = 1080;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            AssetManager.InitAssetManager(GraphicsDevice);
            AssetManager.LoadAll();
            SubWindow.sf = Content.Load<SpriteFont>("DefaultFont");
            windows.Add(new SubWindow("Hierarchy", new Hierarchy(), new Rect(0,0,200,500)));
            windows.Add(new SubWindow("Resources", new ResourceViewer(),new Rect(0, 500, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height)));
            windows.Add(new SubWindow("Inspector", new Inspector(),new Rect(GraphicsDevice.Viewport.Bounds.Width-256, 0, GraphicsDevice.Viewport.Bounds.Width, 500)));
            base.Initialize();
        }
        public void DeleteWindow(string Name)
        {
            for (int i = 0; i < windows.Count; i++)
            {
                if(windows[i].Name == Name)
                {
                    windows[i]._Destroy();
                    windows.RemoveAt(i);
                }
            }
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            for (int i = 0; i < windows.Count; i++)
            {
                windows[i]._Process(Mouse.GetState().X, Mouse.GetState().Y, Mouse.GetState().LeftButton == ButtonState.Pressed, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height);
            }
            if(Mouse.GetState().RightButton == ButtonState.Pressed && !CreateWindowOpen)
            {
                CreateWindowOpen = true;
                windows.Add(new SubWindow("Create", new CreateWindow(), new Rect(Mouse.GetState().X-64, Mouse.GetState().Y, Mouse.GetState().X + 64, Mouse.GetState().Y + 256),false));
            }
            if(Mouse.GetState().RightButton == ButtonState.Released && CreateWindowOpen)
            {
                CreateWindowOpen = false;
                DeleteWindow("Create");
            }
            if(!Dragging && Mouse.GetState().MiddleButton == ButtonState.Pressed)
            {
                StartDrag = Mouse.GetState().Position.ToVector2();
                camStartPos = CameraPosition;
                Dragging = true;
            }
            if(Dragging && Mouse.GetState().MiddleButton == ButtonState.Pressed)
            {
                CameraPosition = camStartPos + Mouse.GetState().Position.ToVector2() - StartDrag;
            }
            if(Dragging && Mouse.GetState().MiddleButton == ButtonState.Released)
            {
                Dragging = false;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.LeftControl) && Keyboard.GetState().IsKeyDown(Keys.S) && !Saving)
            {
                Saving = true;
                File.Create("Resources/Scenes/" + "main.pom").Close();
                string Save = "";
                List<string> RequiredSpriteAssets = new List<string>();
                for (int i = 0; i < SceneNode.nodes.Count; i++)
                {
                    if(!RequiredSpriteAssets.Contains(SceneNode.nodes[i].SpriteSource))
                    {
                        RequiredSpriteAssets.Add(SceneNode.nodes[i].SpriteSource);
                    }
                }
                Save += "[\n";
                for (int i = 0; i < RequiredSpriteAssets.Count; i++)
                {
                    Save += $"Sprite:{RequiredSpriteAssets[i]}\n";
                }
                Save += "]\n";
                for (int i = 0; i < SceneNode.nodes.Count; i++)
                {
                    Node node = SceneNode.nodes[i];
                    Save += "{\n";
                    Save += "Name:" + node.Name + "\n";
                    Save += "Sprite:" + node.SpriteSource + "\n";
                    Save += "Position:" + node.transform.Position.X + "," + node.transform.Position.Y + "\n";
                    Save += "Scale:" + node.transform.Scale.X + "," + node.transform.Scale.Y + "\n";
                    Save += "Rotation:" + node.transform.Rotation + "\n";
                    Save += "Tint:" + node.tint.R + "," + node.tint.G + "," + node.tint.B + "," + node.tint.A + "\n";
                    for (int y = 0; y < SceneNode.nodes[i].Subnodes.Count; y++)
                    {
                        if(SceneNode.nodes[i].Subnodes[y] != "")
                        Save += "Script:" + SceneNode.nodes[i].Subnodes[y] + "\n";
                    }
                    Save += "}\n";
                }
                File.WriteAllText("Resources/Scenes/" + "main.pom", Save);
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.LeftControl) || !Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Saving = false;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointClamp);
            Vector2 Offset = new Vector2(System.MathF.Floor(CameraPosition.X / 64) * 64, System.MathF.Floor(CameraPosition.Y / 64) * 64);
            for (int y = -64-(int)Offset.Y; y < _graphics.PreferredBackBufferHeight + 64 - Offset.Y; y += 64)
            {
                for (int x = -64-(int)Offset.X; x < _graphics.PreferredBackBufferWidth + 64 - Offset.X; x += 64)
                {
                    if((x+y)%128 == 0)
                        _spriteBatch.Draw(Globals.rect, new Rectangle(x+(int)CameraPosition.X, y+(int)CameraPosition.Y, 64, 64), new Color(0x111111));
                    _spriteBatch.DrawString(SubWindow.sf, x / 64 + ":" + y / 64, new Vector2(x, y)+CameraPosition, new Color(0xeeeeeeff));
                }
            }
            
            for (int i = 0; i < SceneNode.nodes.Count; i++)
            {
                SceneNode.nodes[i].Draw(_spriteBatch);
            }

            for (int i = 0; i < windows.Count; i++)
            {
                windows[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
