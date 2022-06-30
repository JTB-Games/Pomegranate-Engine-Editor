using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PomegranateMono;

namespace PomegranateEditor
{
    static class KeyboardTyping
    {
        public static bool TryConvertKeyboardInput(KeyboardState keyboard, KeyboardState oldKeyboard, out char key)
        {
            Keys[] keys = keyboard.GetPressedKeys();
            bool shift = keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift);

            if (keys.Length > 0 && !oldKeyboard.IsKeyDown(keys[0]))
            {
                switch (keys[0])
                {
                    //Alphabet keys
                    case Keys.A: if (shift) { key = 'A'; } else { key = 'a'; } return true;
                    case Keys.B: if (shift) { key = 'B'; } else { key = 'b'; } return true;
                    case Keys.C: if (shift) { key = 'C'; } else { key = 'c'; } return true;
                    case Keys.D: if (shift) { key = 'D'; } else { key = 'd'; } return true;
                    case Keys.E: if (shift) { key = 'E'; } else { key = 'e'; } return true;
                    case Keys.F: if (shift) { key = 'F'; } else { key = 'f'; } return true;
                    case Keys.G: if (shift) { key = 'G'; } else { key = 'g'; } return true;
                    case Keys.H: if (shift) { key = 'H'; } else { key = 'h'; } return true;
                    case Keys.I: if (shift) { key = 'I'; } else { key = 'i'; } return true;
                    case Keys.J: if (shift) { key = 'J'; } else { key = 'j'; } return true;
                    case Keys.K: if (shift) { key = 'K'; } else { key = 'k'; } return true;
                    case Keys.L: if (shift) { key = 'L'; } else { key = 'l'; } return true;
                    case Keys.M: if (shift) { key = 'M'; } else { key = 'm'; } return true;
                    case Keys.N: if (shift) { key = 'N'; } else { key = 'n'; } return true;
                    case Keys.O: if (shift) { key = 'O'; } else { key = 'o'; } return true;
                    case Keys.P: if (shift) { key = 'P'; } else { key = 'p'; } return true;
                    case Keys.Q: if (shift) { key = 'Q'; } else { key = 'q'; } return true;
                    case Keys.R: if (shift) { key = 'R'; } else { key = 'r'; } return true;
                    case Keys.S: if (shift) { key = 'S'; } else { key = 's'; } return true;
                    case Keys.T: if (shift) { key = 'T'; } else { key = 't'; } return true;
                    case Keys.U: if (shift) { key = 'U'; } else { key = 'u'; } return true;
                    case Keys.V: if (shift) { key = 'V'; } else { key = 'v'; } return true;
                    case Keys.W: if (shift) { key = 'W'; } else { key = 'w'; } return true;
                    case Keys.X: if (shift) { key = 'X'; } else { key = 'x'; } return true;
                    case Keys.Y: if (shift) { key = 'Y'; } else { key = 'y'; } return true;
                    case Keys.Z: if (shift) { key = 'Z'; } else { key = 'z'; } return true;

                    //Decimal keys
                    case Keys.D0:{ key = '0'; } return true;
                    case Keys.D1:{ key = '1'; } return true;
                    case Keys.D2:{ key = '2'; } return true;
                    case Keys.D3:{ key = '3'; } return true;
                    case Keys.D4:{ key = '4'; } return true;
                    case Keys.D5:{ key = '5'; } return true;
                    case Keys.D6:{ key = '6'; } return true;
                    case Keys.D7:{ key = '7'; } return true;
                    case Keys.D8:{ key = '8'; } return true;
                    case Keys.D9:{ key = '9'; } return true;

                    //Decimal numpad keys
                    case Keys.NumPad0: key = '0'; return true;
                    case Keys.NumPad1: key = '1'; return true;
                    case Keys.NumPad2: key = '2'; return true;
                    case Keys.NumPad3: key = '3'; return true;
                    case Keys.NumPad4: key = '4'; return true;
                    case Keys.NumPad5: key = '5'; return true;
                    case Keys.NumPad6: key = '6'; return true;
                    case Keys.NumPad7: key = '7'; return true;
                    case Keys.NumPad8: key = '8'; return true;
                    case Keys.NumPad9: key = '9'; return true;

                    //Special keys
                    case Keys.OemTilde: if (shift) { key = '~'; } else { key = '`'; } return true;
                    case Keys.OemSemicolon: if (shift) { key = ':'; } else { key = ';'; } return true;
                    case Keys.OemQuotes: if (shift) { key = '"'; } else { key = '\''; } return true;
                    case Keys.OemQuestion: if (shift) { key = '?'; } else { key = '/'; } return true;
                    case Keys.OemPlus: if (shift) { key = '+'; } else { key = '='; } return true;
                    case Keys.OemPipe: if (shift) { key = '|'; } else { key = '\\'; } return true;
                    case Keys.OemPeriod: if (shift) { key = '>'; } else { key = '.'; } return true;
                    case Keys.OemOpenBrackets: if (shift) { key = '{'; } else { key = '['; } return true;
                    case Keys.OemCloseBrackets: if (shift) { key = '}'; } else { key = ']'; } return true;
                    case Keys.OemMinus: if (shift) { key = '_'; } else { key = '-'; } return true;
                    case Keys.OemComma: if (shift) { key = '<'; } else { key = ','; } return true;
                    case Keys.Space: key = ' '; return true;
                    case Keys.Back: key = '\b'; return true;
                }
            }

            key = (char)0;
            return false;
        }
        public static bool TryConvertKeyboardInputNumber(KeyboardState keyboard, KeyboardState oldKeyboard, out char key)
        {
            Keys[] keys = keyboard.GetPressedKeys();
            bool shift = keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift);

            if (keys.Length > 0 && !oldKeyboard.IsKeyDown(keys[0]))
            {
                switch (keys[0])
                {
                    //Decimal keys
                    case Keys.D0: if (shift) { key = ')'; } else { key = '0'; } return true;
                    case Keys.D1: if (shift) { key = '!'; } else { key = '1'; } return true;
                    case Keys.D2: if (shift) { key = '@'; } else { key = '2'; } return true;
                    case Keys.D3: if (shift) { key = '#'; } else { key = '3'; } return true;
                    case Keys.D4: if (shift) { key = '$'; } else { key = '4'; } return true;
                    case Keys.D5: if (shift) { key = '%'; } else { key = '5'; } return true;
                    case Keys.D6: if (shift) { key = '^'; } else { key = '6'; } return true;
                    case Keys.D7: if (shift) { key = '&'; } else { key = '7'; } return true;
                    case Keys.D8: if (shift) { key = '*'; } else { key = '8'; } return true;
                    case Keys.D9: if (shift) { key = '('; } else { key = '9'; } return true;

                    //Decimal numpad keys
                    case Keys.NumPad0: key = '0'; return true;
                    case Keys.NumPad1: key = '1'; return true;
                    case Keys.NumPad2: key = '2'; return true;
                    case Keys.NumPad3: key = '3'; return true;
                    case Keys.NumPad4: key = '4'; return true;
                    case Keys.NumPad5: key = '5'; return true;
                    case Keys.NumPad6: key = '6'; return true;
                    case Keys.NumPad7: key = '7'; return true;
                    case Keys.NumPad8: key = '8'; return true;
                    case Keys.NumPad9: key = '9'; return true;

                    //Special keys
                    case Keys.OemPeriod: key = '.'; return true;
                    case Keys.OemMinus: key = '-'; return true;
                    case Keys.Back: key = '\b'; return true;
                }
            }

            key = (char)0;
            return false;
        }
    }
    class Inspector:SubWindowScript
    {
        enum SelectedProperty
        {
            none,
            xpos,
            ypos,
            xsize,
            ysize,
            rot,
            sprite,
            name,
            script1,
            script2,
            script3,
            script4,
            script5,
            script6,
            script7,
            script8,
            script9,
        }
        string PosX;
        string PosY;
        string SizeX;
        string SizeY;
        string rot;
        SelectedProperty selprop;
        KeyboardState oldstate;
        string script1 = "";
        string script2 = "";
        string script3 = "";
        public void _Draw(SpriteBatch sb)
        {
             if (Globals.selectednode != null)
             {
                if(Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    selprop = SelectedProperty.none;
                }
                if(Keyboard.GetState().IsKeyDown(Keys.Tab))
                {
                    selprop = (SelectedProperty)((int)selprop + 1);
                }
                #region Name
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 8, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.name;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 8, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 8, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, Globals.selectednode.Name, 0.1f, 10, Color.Black);
                #endregion
                #region PosX
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 40, 0.48f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.xpos;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 40, 0.48f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 40, 0.48f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, PosX, 0.1f, 42, Color.Black);
                #endregion
                #region PosY
                if (SubWindow.ConvertFloatRectToPixelRect(0.52f, 40, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.ypos;
                    }
                    SubWindow.DrawRect(sb, 0.52f, 40, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.52f, 40, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, PosY, 0.57f, 42, Color.Black);
                #endregion
                #region SizeX
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 72, 0.48f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.xsize;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 72, 0.48f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 72, 0.48f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, SizeX, 0.1f, 74, Color.Black);
                #endregion
                #region SizeY
                if (SubWindow.ConvertFloatRectToPixelRect(0.52f, 72, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.ysize;
                    }
                    SubWindow.DrawRect(sb, 0.52f, 72, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.52f, 72, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, SizeY, 0.57f, 74, Color.Black);
                #endregion
                #region Rot
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 104, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.rot;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 104, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 104, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, rot, 0.1f, 104, Color.Black);
                #endregion
                #region SpriteSource
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 136, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.sprite;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 136, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 136, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, Globals.selectednode.SpriteSource, 0.1f, 136, Color.Black);
                #endregion
                #region Script1
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 168, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.script1;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 168, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 168, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, script1, 0.1f, 168, Color.Black);
                #endregion
                #region Script2
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 200, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.script2;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 200, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 200, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, script2, 0.1f, 200, Color.Black);
                #endregion
                #region Script3
                if (SubWindow.ConvertFloatRectToPixelRect(0.05f, 232, 0.95f, 24).Intersects(new Rectangle(Mouse.GetState().Position, new Vector2(1, 1).ToPoint())))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        selprop = SelectedProperty.script3;
                    }
                    SubWindow.DrawRect(sb, 0.05f, 232, 0.95f, 24, new Color(0xffeeffff));
                }
                else
                {
                    SubWindow.DrawRect(sb, 0.05f, 232, 0.95f, 24, new Color(0xeeeeeeff));
                }
                SubWindow.DrawText(sb, script3, 0.1f, 232, Color.Black);
                #endregion
                if (SubWindow.CurrentSelectedWindow == SubWindow.GetWindow())
                {
                    var keyboardState = Keyboard.GetState();
                    if (selprop == SelectedProperty.sprite)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInput(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (Globals.selectednode.SpriteSource.Length > 0)
                                    Globals.selectednode.SpriteSource = Globals.selectednode.SpriteSource.Remove(Globals.selectednode.SpriteSource.Length - 1, 1);
                            }
                            else
                            {
                                Globals.selectednode.SpriteSource += c;
                            }
                        }
                    }
                    if (selprop == SelectedProperty.name)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInput(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (Globals.selectednode.Name.Length > 0)
                                    Globals.selectednode.Name = Globals.selectednode.Name.Remove(Globals.selectednode.Name.Length - 1, 1);
                            }
                            else
                            {
                                Globals.selectednode.Name += c;
                            }
                        }
                    }
                    #region xposType
                    if (selprop == SelectedProperty.xpos)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInputNumber(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (PosX.Length > 0)
                                    PosX = PosX.Remove(PosX.Length - 1, 1);
                            }
                            else
                            {
                                PosX += c;
                            }
                            if(float.TryParse(PosX,out float x))
                            {
                                Globals.selectednode.transform.Position.X = x;
                            }

                        }
                    }
                    #endregion
                    #region xposType
                    if (selprop == SelectedProperty.ypos)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInputNumber(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (PosY.Length > 0)
                                    PosY = PosY.Remove(PosY.Length - 1, 1);
                            }
                            else
                            {
                                PosY += c;
                            }
                            if (float.TryParse(PosY, out float x))
                            {
                                Globals.selectednode.transform.Position.Y = x;
                            }

                        }
                    }
                    #endregion
                    #region xposType
                    if (selprop == SelectedProperty.xsize)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInputNumber(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (SizeX.Length > 0)
                                    SizeX = SizeX.Remove(SizeX.Length - 1, 1);
                            }
                            else
                            {
                                SizeX += c;
                            }
                            if (float.TryParse(SizeX, out float x))
                            {
                                Globals.selectednode.transform.Scale.X = x;
                            }

                        }
                    }
                    #endregion
                    #region xposType
                    if (selprop == SelectedProperty.ysize)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInputNumber(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (SizeY.Length > 0)
                                    SizeY = SizeY.Remove(SizeY.Length - 1, 1);
                            }
                            else
                            {
                                SizeY += c;
                            }
                            if (float.TryParse(SizeY, out float x))
                            {
                                Globals.selectednode.transform.Scale.Y = x;
                            }

                        }
                    }
                    #endregion
                    #region xposType
                    if (selprop == SelectedProperty.rot)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInputNumber(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (rot.Length > 0)
                                    rot = rot.Remove(rot.Length - 1, 1);
                            }
                            else
                            {
                                rot += c;
                            }
                            if (float.TryParse(rot, out float x))
                            {
                                x *= 0.0174532925f;
                                Globals.selectednode.transform.Rotation = x;
                            }

                        }
                    }
                    #endregion
                    #region xposType
                    if (selprop == SelectedProperty.script1)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInput(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (script1.Length > 0)
                                    script1 = script1.Remove(script1.Length - 1, 1);
                            }
                            else
                            {
                                script1 += c;
                            }
                        }
                    }
                    if (selprop == SelectedProperty.script3)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInput(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (script3.Length > 0)
                                    script3 = script3.Remove(script3.Length - 1, 1);
                            }
                            else
                            {
                                script3 += c;
                            }
                        }
                    }
                    if (selprop == SelectedProperty.script2)
                    {
                        char c;
                        if (KeyboardTyping.TryConvertKeyboardInput(keyboardState, oldstate, out c))
                        {
                            if (c == '\b')
                            {
                                if (script2.Length > 0)
                                    script2 = script2.Remove(script2.Length - 1, 1);
                            }
                            else
                            {
                                script2 += c;
                            }
                        }
                    }
                    #endregion
                    oldstate = keyboardState;
                }
                else
                {
                    PosX = Globals.selectednode.transform.Position.X.ToString();
                    PosY = Globals.selectednode.transform.Position.Y.ToString();
                    SizeX = Globals.selectednode.transform.Scale.X.ToString();
                    SizeY = Globals.selectednode.transform.Scale.Y.ToString();
                    Globals.selectednode.Subnodes = new List<string>();
                    Globals.selectednode.Subnodes.Add(script1);
                    Globals.selectednode.Subnodes.Add(script2);
                    Globals.selectednode.Subnodes.Add(script3);
                    rot = (Globals.selectednode.transform.Rotation * 57.296f).ToString();
                }
                if (AssetManager.Sprites.ContainsKey(Globals.selectednode.SpriteSource))
                {
                    Globals.selectednode.Sprite = AssetManager.Sprites[Globals.selectednode.SpriteSource];
                }
            }
        }
        public void _Process()
        {

        }
    }
}
