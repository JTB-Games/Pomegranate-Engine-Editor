using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PomegranateMono
{
    public class Renderer
    {
        GraphicsDevice gd;
        SpriteBatch sb;
        public Renderer(GraphicsDevice gd, SpriteBatch sb)
        {
            this.gd = gd;
            this.sb = sb;
        }
        public void ClearScreen(Color color)
        {
            gd.Clear(color);
        }
        public void Draw(string sprite, Color tint, int x, int y, int w=64, int h=64)
        {
            sb.Draw(AssetManager.Sprites[sprite], new Rectangle(x,y, w, h),tint);
        }
    }
}
