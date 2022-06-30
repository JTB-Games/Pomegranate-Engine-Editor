using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using PomegranateMono;

namespace PomegranateEditor
{
    class ResourceViewer:SubWindowScript
    {
        int f;
        public void _Process()
        {
            f++;
            if(f > 60)
            {
                f = 0;
                AssetManager.Sprites.Clear();
                AssetManager.LoadAllSprites();
            }
        }
        public void _Draw(SpriteBatch sb)
        {
            int i = 0;
            foreach (KeyValuePair<string, Texture2D> asset in AssetManager.Sprites)
            {
                // do something with entry.Value or entry.Key
                SubWindow.DrawText(sb, asset.Key,0,i+32,Color.Black);
                SubWindow.DrawResource(sb, asset.Value, 256, i + 32, 16, 16, Color.White);
                i += 16;
            }
            i = 0;
            foreach (KeyValuePair<string, SoundEffect> asset in AssetManager.Sounds)
            {
                // do something with entry.Value or entry.Key
                SubWindow.DrawText(sb, asset.Key, 0.33f, i + 32, Color.Black);
                i += 16;
            }
        }
    }
}
