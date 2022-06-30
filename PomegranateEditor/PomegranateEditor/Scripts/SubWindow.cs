using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PomegranateEditor
{
    public struct Rect
    {
        public int xa;
        public int ya;
        public int xb;
        public int yb;
        public Rect(int xa, int ya, int xb, int yb)
        {
            this.xa = xa;
            this.xb = xb;
            this.ya = ya;
            this.yb = yb;
        }
    }
    public interface SubWindowScript
    {
        public virtual void _Init() { }
        public virtual void _Process() { }
        public virtual void _Draw(SpriteBatch sb) { }
        public virtual void _Destroy() { }
    }
    public class SubWindow
    {
        static SubWindow CurrentSubWindow;
        public static SubWindow CurrentSelectedWindow;
        public static SubWindow GetWindow() { return CurrentSubWindow; }
        static int ClampToWindow(int value)
        {
            if (value > CurrentSubWindow.MyRect.xb)
                value = CurrentSubWindow.MyRect.xb;
            if (value > CurrentSubWindow.MyRect.xa)
                value = CurrentSubWindow.MyRect.xa;
            if (value > CurrentSubWindow.MyRect.yb)
                value = CurrentSubWindow.MyRect.yb;
            if (value > CurrentSubWindow.MyRect.ya)
                value = CurrentSubWindow.MyRect.ya;
            return value;
        }
        public static void DrawRect(SpriteBatch sb, float xa, float ya, float xb, float yb, Color color)
        {
            int width = CurrentSubWindow.MyRect.xb - CurrentSubWindow.MyRect.xa;
            int height = CurrentSubWindow.MyRect.yb - CurrentSubWindow.MyRect.ya;
            sb.Draw(Globals.rect, new Rectangle(CurrentSubWindow.MyRect.xa + (int)(xa * width), CurrentSubWindow.MyRect.ya + (int)(ya * height), (int)(xb * width - xa * width), (int)(yb * height - ya * height)), color);
        }

        public static void DrawRect(SpriteBatch sb, float xa, int ya, float xb, int yb, Color color)
        {
            int width = CurrentSubWindow.MyRect.xb - CurrentSubWindow.MyRect.xa;
            int height = CurrentSubWindow.MyRect.yb - CurrentSubWindow.MyRect.ya;
            sb.Draw(Globals.rect, new Rectangle(CurrentSubWindow.MyRect.xa + (int)(xa * width), CurrentSubWindow.MyRect.ya+ya, (int)(xb * width - xa * width), yb), color);
        }
        public static void DrawResource(SpriteBatch sb, Texture2D t ,int xa, int ya, int xb, int yb, Color color)
        {
            int width = CurrentSubWindow.MyRect.xb - CurrentSubWindow.MyRect.xa;
            int height = CurrentSubWindow.MyRect.yb - CurrentSubWindow.MyRect.ya;
            sb.Draw(t, new Rectangle(CurrentSubWindow.MyRect.xa + (int)xa, CurrentSubWindow.MyRect.ya + (int)ya, xb, yb), color);
        }
        public static void DrawText(SpriteBatch sb, string Text, float xa, float ya, Color color)
        {
            if (Text == null)
                return;
            int width = CurrentSubWindow.MyRect.xb - CurrentSubWindow.MyRect.xa;
            int height = CurrentSubWindow.MyRect.yb - CurrentSubWindow.MyRect.ya;
            sb.DrawString(sf, Text, new Vector2(CurrentSubWindow.MyRect.xa + (int)(xa * width), CurrentSubWindow.MyRect.ya + (int)(ya * height)), color);
        }
        public static void DrawText(SpriteBatch sb, string Text, float xa, int ya, Color color)
        {
            if (Text == null)
                return;
            int width = CurrentSubWindow.MyRect.xb - CurrentSubWindow.MyRect.xa;
            int height = CurrentSubWindow.MyRect.yb - CurrentSubWindow.MyRect.ya;
            sb.DrawString(sf, Text, new Vector2(CurrentSubWindow.MyRect.xa + (int)(xa * width), CurrentSubWindow.MyRect.ya + ya), color);
        }
        public static SpriteFont sf;
        public string Name;
        public Rect MyRect;
        bool DraggingRight;
        bool DraggingLeft;
        bool DraggingBottom;
        bool DraggingTop;
        bool Resizable;
        
        public SubWindowScript MyScript;

        public SubWindow(string Name,SubWindowScript Runner,Rect DefaultRect,bool Resizable = true)
        {
            this.MyScript = Runner;
            this.Name = Name;
            this.Resizable = Resizable;
            MyRect = DefaultRect;
            MyScript._Init();
        }
        public void _Destroy()
        {
            CurrentSubWindow = this;
            MyScript._Destroy();
            CurrentSubWindow = null;
        }
        public static Rectangle ConvertFloatRectToPixelRect(float xa, int ya, float xb,  int yb)
        {
            int width = SubWindow.GetWindow().MyRect.xb - SubWindow.GetWindow().MyRect.xa;
            int height = SubWindow.GetWindow().MyRect.yb - SubWindow.GetWindow().MyRect.ya;
            return new Rectangle(SubWindow.GetWindow().MyRect.xa + (int)(xa * width), SubWindow.GetWindow().MyRect.ya + ya, (int)(xb * width - xa * width), yb);
        }
        public void _Process(int x, int y, bool Pressed, int WindowWidth, int WindowHeight)
        {
            CurrentSubWindow = this;
            MyScript._Process();
            CurrentSubWindow = null;
            if (Resizable)
            {
                if (Pressed)
                {
                    if (System.Math.Abs(x - (MyRect.xb)) < 4 && MyRect.ya - 4 < y && MyRect.yb + 4 > y)
                    {
                        DraggingRight = true;
                    }
                    if (System.Math.Abs(y - (MyRect.yb)) < 4 && MyRect.xa - 4 < x && MyRect.xb + 4 > x)
                    {
                        DraggingBottom = true;
                    }
                    if (System.Math.Abs(x - (MyRect.xa)) < 4 && MyRect.ya - 4 < y && MyRect.yb + 4 > y)
                    {
                        DraggingLeft = true;
                    }
                    if (System.Math.Abs(y - (MyRect.ya)) < 4 && MyRect.xa - 4 < x && MyRect.xb + 4 > x)
                    {
                        DraggingTop = true;
                    }
                    if(Pressed)
                    {
                        if(x > MyRect.xa && x < MyRect.xb)
                        {
                            if(y > MyRect.ya && y < MyRect.yb)
                            {
                                CurrentSelectedWindow = this;
                            }
                        }
                    }
                    if (DraggingRight)
                    {
                        if (System.Math.Abs(MyRect.xa - x) > 64)
                            MyRect.xb = x;
                    }
                    if (DraggingBottom)
                    {
                        if (System.Math.Abs(MyRect.ya - y) > 64)
                            MyRect.yb = y;
                    }
                    if (DraggingLeft)
                    {
                        if (System.Math.Abs(MyRect.xb - x) > 64)
                            MyRect.xa = x;
                    }
                    if (DraggingTop)
                    {
                        if (System.Math.Abs(MyRect.yb - y) > 64)
                            MyRect.ya = y;
                    }
                    if (MyRect.xa < 0)
                        MyRect.xa = 0;
                    if (MyRect.ya < 0)
                        MyRect.ya = 0;
                    if (MyRect.xb > WindowWidth)
                        MyRect.xb = WindowWidth;
                    if (MyRect.yb > WindowHeight)
                        MyRect.yb = WindowHeight;
                }
                else
                {
                    DraggingBottom = false;
                    DraggingRight = false;
                    DraggingLeft = false;
                    DraggingTop = false;
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            if (sb != null)
            {
                sb.Draw(Globals.rect, new Rectangle(MyRect.xa, MyRect.ya, MyRect.xb - MyRect.xa, MyRect.yb - MyRect.ya), new Color(200, 200, 200));
                sb.Draw(Globals.rect, new Rectangle(MyRect.xa + 4, MyRect.ya + 4, (MyRect.xb - MyRect.xa) - 8, (MyRect.yb - MyRect.ya) - 8), new Color(238, 238, 238));
                CurrentSubWindow = this;
                MyScript._Draw(sb);
                CurrentSubWindow = null;
            }
        }
    }
}
