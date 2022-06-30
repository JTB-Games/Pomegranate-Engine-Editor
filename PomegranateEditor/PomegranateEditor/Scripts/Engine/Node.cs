using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PomegranateEditor;
namespace PomegranateMono
{
    public struct Transform
    {
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;
        public Transform(Vector2 Position, Vector2 Scale, float Rotation)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Rotation = Rotation;
        }
    }
    public static class SceneNode
    {
        public static List<Node> nodes = new List<Node>();
        public static Node MyNode;
    }
    public interface Nodescript
    {
        public virtual void _Process(float delta){}
        public virtual void _Init(){}
    }
    public class Node
    {
        public static Node Create(string Name, string Sprite, Vector2 Position, Vector2 Scale, float Rotation)
        {
            SceneNode.nodes.Add(new Node(Name, Sprite, Color.White, new Transform(Position, Scale, Rotation), new string[] { }));
            return SceneNode.nodes[SceneNode.nodes.Count - 1];
        }
        public static Node Instantiate(Node node)
        {
            SceneNode.nodes.Add(new Node(node));
            return SceneNode.nodes[SceneNode.nodes.Count - 1];
        }
        public string Name;
        public Transform transform;
        public Texture2D Sprite;
        public string SpriteSource;
        public Color tint;
        public List<string> Subnodes;
        public Node(Node node)
        {
            Name = node.Name;
            transform = new Transform(node.transform.Position, node.transform.Scale, node.transform.Rotation);
            Sprite = node.Sprite;
            SpriteSource = node.SpriteSource;
            tint = node.tint;
            Subnodes = node.Subnodes;
        }
        public Node(string Name,string Sprite, Color tint,Vector2 Position, Vector2 Scale, float Rotation, string[] Scripts)
        {
            this.Name = Name;
            Subnodes = new List<string>();
            Subnodes.AddRange(Scripts);
            if (Sprite != null)
            {
                this.Sprite = AssetManager.Sprites[Sprite];
                SpriteSource = Sprite;
            }
            transform = new Transform(Position, Scale, Rotation);
            this.tint = tint;
        }
        public Node(string Name, string Sprite, Color tint, Transform transform, string[] Scripts)
        {
            this.Name = Name;
            Subnodes = new List<string>();
            Subnodes.AddRange(Scripts);
            if (Sprite != null)
            {
                this.Sprite = AssetManager.Sprites[Sprite];
                SpriteSource = Sprite;
            }
            this.transform = transform;
            this.tint = tint;
        }
        public void _Process(double t)
        {
            for (int i = 0; i < Subnodes.Count; i++)
            {
                //Subnodes[i]._Process((float)t);
            }
        }
        public void Draw(SpriteBatch sb)
        {
            Vector2 Origin = new Vector2(transform.Position.X, transform.Position.Y);
            Vector2 Center = new Vector2((Sprite.Width / 2), (Sprite.Height / 2));
            Vector2 Scale = new Vector2(Sprite.Width * transform.Scale.X, Sprite.Height * transform.Scale.Y);
            sb.Draw(Sprite, new Rectangle((int)transform.Position.X + (int)Engine.CameraPosition.X, (int)transform.Position.Y + (int)Engine.CameraPosition.Y, (int)Scale.X, (int)Scale.Y), null, tint, transform.Rotation, Center, SpriteEffects.None, 0f);
        }
    }
}
