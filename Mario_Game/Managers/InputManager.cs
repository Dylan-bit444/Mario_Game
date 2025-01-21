using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Mario_Game
{
    internal class InputManager
    {
        public static bool Mickel;
        private static Vector2 _direction = Vector2.Zero;
        public static Vector2 Direction => _direction;
        public static bool Moving => _direction != Vector2.Zero;

        private GamePadState PreviousControler;

        private GamePadState CurrentControler;
        private int selectedInList;

        public void Update(Hero? _hero, List<Button>? menu)
        {
            GamePadCapabilities gamePad = GamePad.GetCapabilities(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();
            if (_hero != null)
            {
                float scale = 10f;
                _direction = Vector2.Zero;
                if (gamePad.IsConnected)
                {
                    PreviousControler=CurrentControler;
                    CurrentControler = GamePad.GetState(PlayerIndex.One);
                    if (gamePad.HasLeftXThumbStick || gamePad.HasDPadDownButton)
                    {
                        if (CurrentControler.ThumbSticks.Left.X < -0.5f || CurrentControler.DPad.Left == ButtonState.Pressed)
                        {
                            _direction -= new Vector2(1, 0);
                        }
                        if (CurrentControler.ThumbSticks.Left.X > 0.5f || CurrentControler.DPad.Right == ButtonState.Pressed)
                        {
                            _direction += new Vector2(1, 0);
                        }
                        if (CurrentControler.ThumbSticks.Left.Y < -0.5f || CurrentControler.DPad.Down == ButtonState.Pressed)
                        {
                            _direction += new Vector2(0, 1);
                        }
                        if (CurrentControler.ThumbSticks.Left.Y > 0.5f || CurrentControler.DPad.Up == ButtonState.Pressed)
                        {
                            _direction -= new Vector2(0, 1);
                        }
                        if (CurrentControler.Buttons.X == ButtonState.Pressed && _hero.Volocity < 200f * 1.25f || CurrentControler.Buttons.Y == ButtonState.Pressed && _hero.Volocity < 200f * 1.25f)
                        {
                            _hero.Volocity = _hero.Volocity * scale;
                        }
                        else if ((CurrentControler.Buttons.Y != ButtonState.Pressed && _hero.Volocity > 200f) && (CurrentControler.Buttons.X != ButtonState.Pressed && _hero.Volocity > 200f))
                        {
                            _hero.Volocity = _hero.Volocity / scale;
                        }
                        if (CurrentControler.Buttons.B == ButtonState.Pressed)
                        {
                            _direction += new Vector2(1, 0);
                        }
                        if (CurrentControler.Buttons.A == ButtonState.Pressed)
                        {
                            _direction += new Vector2(0, 1);
                        }
                    }
                }
                else
                {
                    if ((keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left)))
                    {
                        _direction -= new Vector2(1, 0);
                    }
                    if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                    {
                        _direction += new Vector2(1, 0);
                    }
                    if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
                    {
                        _direction -= new Vector2(0, 1);
                    }
                    if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
                    {
                        _direction += new Vector2(0, 1);
                    }
                    if (keyboardState.IsKeyDown(Keys.LeftShift) && _hero.Volocity < 200f * 1.25f)
                    {
                        _hero.Volocity = _hero.Volocity * scale;
                    }
                    else if (keyboardState.IsKeyUp(Keys.LeftShift) && _hero.Volocity > 200f)
                    {
                        _hero.Volocity = _hero.Volocity / scale;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.M) && keyboardState.IsKeyDown(Keys.J))
                {
                    Mickel = true;
                }
                else if (keyboardState.IsKeyDown(Keys.N))
                {
                    Mickel = false;
                }
            }
            else if (menu != null && gamePad.IsConnected)
            {
                int count = 0;
                for (int i = 0; i < menu.Count-1; i++)
                {
                    if (!menu[i].Selected)
                    {
                        count++;
                    }
                    else
                    {
                        selectedInList = i;
                    }
                    if (count == menu.Count - 1)
                    {
                        menu[0].Selected = true;
                    }
                }
                PreviousControler = CurrentControler;
                CurrentControler = GamePad.GetState(PlayerIndex.One);
                if (gamePad.HasLeftXThumbStick || gamePad.HasDPadDownButton)
                {
                    if (CurrentControler.ThumbSticks.Left.Y < -0.5f || CurrentControler.DPad.Down == ButtonState.Released && PreviousControler.DPad.Down == ButtonState.Pressed)
                    {
                        menu[selectedInList].Selected = false;
                        selectedInList++;
                    }
                    if (CurrentControler.ThumbSticks.Left.Y > 0.5f || CurrentControler.DPad.Up == ButtonState.Released && PreviousControler.DPad.Up == ButtonState.Pressed)
                    {
                        menu[selectedInList].Selected = false;
                        selectedInList--;
                    }
                    if(selectedInList < 0)
                    {
                        menu[0].Selected = false;
                        selectedInList = menu.Count-1;
                    }
                    if(selectedInList > menu.Count-1)
                    {
                        menu[2].Selected = false;
                        selectedInList = 0;
                    }
                    menu[selectedInList].Selected = true;
                    foreach (Button component in menu)
                        component.Update();
                }
                
            }
            else
            {
                foreach (Button component in menu)
                    component.Update();
            }
        }
    }
}

