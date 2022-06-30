using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PomegranateMono;

namespace PomegranateEditor
{
    class Hierarchy : SubWindowScript
    {
        public int Selected = 0;
        bool Deleting;
        bool duping;
        public void _Init()
        {
            
        }
        public void _Draw(SpriteBatch sb)
        {
            for (int i = 0; i < SceneNode.nodes.Count; i++)
            {
                int width = SubWindow.GetWindow().MyRect.xb - SubWindow.GetWindow().MyRect.xa;
                int height = SubWindow.GetWindow().MyRect.yb - SubWindow.GetWindow().MyRect.ya;
                if (i != Selected)
                {
                    SubWindow.ConvertFloatRectToPixelRect(0.1f, 8 + i * 26, 0.9f, 24);
                    if (SubWindow.ConvertFloatRectToPixelRect(0.1f, 8 + i * 26, 0.9f, 24).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                    {
                        SubWindow.DrawRect(sb, 0.1f, 8 + i * 26, 0.95f, 24, new Color(0xffeeffff));
                        if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            Selected = i;
                        }
                    }
                    else
                        SubWindow.DrawRect(sb, 0.1f, 8 + i * 26, 0.95f, 24, new Color(0xeeeeeeff));
                }
                else
                {
                    Globals.selectednodeindex = i;
                    Globals.selectednode = SceneNode.nodes[i];
                    SubWindow.DrawRect(sb, 0.1f, 8 + i * 26, 0.95f, 24, new Color(0xaaaaaaff));
                }
                SubWindow.DrawText(sb, SceneNode.nodes[i].Name, 0.15f, (8 + i * 26) + 2, Color.Black);
            }
        }
        public void _Process()
        {
            if (SubWindow.CurrentSelectedWindow == SubWindow.GetWindow())
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Back) && !Deleting)
                {
                    Deleting = true;
                    if (SceneNode.nodes.Count > 0 && Globals.selectednodeindex < SceneNode.nodes.Count && Globals.selectednodeindex > -1)
                        SceneNode.nodes.RemoveAt(Globals.selectednodeindex);
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Back))
                {
                    Deleting = false;
                }
                if(Keyboard.GetState().IsKeyDown(Keys.LeftControl) && Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (!duping)
                    {
                        duping = true;
                        if(Globals.selectednode != null)
                            SceneNode.nodes.Add(new Node(Globals.selectednode));
                    }
                }
                else
                {
                    duping = false;
                }
            }
        }
    }
}
