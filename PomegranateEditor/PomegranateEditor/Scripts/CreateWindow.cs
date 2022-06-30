using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PomegranateMono;

namespace PomegranateEditor
{
    struct NodeObjectCreate
    {
        public string Name;
        public NodeObjectCreate(string Name)
        {
            this.Name = Name;
        }
    }
    class CreateWindow : SubWindowScript
    {
        public List<NodeObjectCreate> NodeTemplate = new List<NodeObjectCreate>();
        Vector2 StartPoint;
        public void _Init()
        {
            NodeTemplate.Add(new NodeObjectCreate("Rectangle"));
            NodeTemplate.Add(new NodeObjectCreate("Triangle"));
            NodeTemplate.Add(new NodeObjectCreate("Circle"));
            NodeTemplate.Add(new NodeObjectCreate("Pomegranate"));
            StartPoint = Mouse.GetState().Position.ToVector2();
        }
        public void _Draw(SpriteBatch sb)
        {
            for (int i = 0; i < NodeTemplate.Count; i++)
            {
                int width = SubWindow.GetWindow().MyRect.xb - SubWindow.GetWindow().MyRect.xa;
                int height = SubWindow.GetWindow().MyRect.yb - SubWindow.GetWindow().MyRect.ya;
                if(new Rectangle(SubWindow.GetWindow().MyRect.xa + (int)(0.05f * width), SubWindow.GetWindow().MyRect.ya + 8 + i * 26, (int)(0.95f * width - 0.05f * width), 24).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                    SubWindow.DrawRect(sb, 0.05f, 8 + i * 26, 0.95f, 24, new Color(0xffeeffff));
                else
                    SubWindow.DrawRect(sb, 0.05f, 8+i*26, 0.95f, 24, new Color(0xeeeeeeff));
                SubWindow.DrawText(sb, NodeTemplate[i].Name, 0.1f, (8 + i * 26) + 2, Color.Black);
            }
        }
        public void _Process()
        {
            
        }
        public void _Destroy()
        {
            for (int i = 0; i < NodeTemplate.Count; i++)
            {
                int width = SubWindow.GetWindow().MyRect.xb - SubWindow.GetWindow().MyRect.xa;
                int height = SubWindow.GetWindow().MyRect.yb - SubWindow.GetWindow().MyRect.ya;
                if (new Rectangle(SubWindow.GetWindow().MyRect.xa + (int)(0.05f * width), SubWindow.GetWindow().MyRect.ya + 8 + i * 26, (int)(0.95f * width - 0.05f * width), 24).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                    SceneNode.nodes.Add(new Node(NodeTemplate[i].Name, "Rect.png",Color.White,new Transform(new Vector2(System.MathF.Floor((StartPoint.X-Engine.CameraPosition.X) / 64)*64, System.MathF.Floor((StartPoint.Y- Engine.CameraPosition.Y) / 64) * 64), new Vector2(1,1),0),new string[] { }));
            }
        }
    }
    class NullWindow : SubWindowScript
    {

    }
}
