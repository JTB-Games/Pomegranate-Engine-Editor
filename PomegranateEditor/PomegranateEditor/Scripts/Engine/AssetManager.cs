using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace PomegranateMono
{
    public static class AssetManager
    {
        public static Dictionary<string,Texture2D> Sprites;
        public static Dictionary<string, SoundEffect> Sounds;
        static GraphicsDevice g;
        static public void InitAssetManager(GraphicsDevice gd)
        {
            g = gd;
            Sprites = new Dictionary<string, Texture2D>();
            Sounds = new Dictionary<string, SoundEffect>();
        }
        static public void LoadSprite(string Name)
        {
            Sprites.Add(Name,Texture2D.FromFile(g, $"Resources/Sprites/{Name}"));
        }
        static public void LoadAllSprites()
        {
            string[] files = Directory.GetFiles("Resources/Sprites/");
            for (int i = 0; i < files.Length; i++)
            {
                LoadSprite(files[i].Replace("Resources/Sprites/", ""));
            }
        }
        static public void LoadAllSounds()
        {
            string[] files = Directory.GetFiles("Resources/Sounds/");
            for (int i = 0; i < files.Length; i++)
            {
                LoadAudio(files[i].Replace("Resources/Sounds/", ""));
            }
        }
        static public void LoadAll()
        {
            LoadAllSprites();
            LoadAllSounds();
        }
        static public void LoadAudio(string Name)
        {
            Sounds.Add(Name,SoundEffect.FromFile($"Resources/Sounds/{Name}"));
        }
    }
}
