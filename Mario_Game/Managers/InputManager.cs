using Mario_Game.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Reflection.Metadata;

namespace Mario_Game
{
    internal class InputManager
    {
        public static bool Mickel;
        public static bool Fire;
        private static Vector2 _direction = Vector2.Zero;
        public static Vector2 Direction => _direction;
        public static bool Moving => _direction != Vector2.Zero;

        private GamePadState PreviousControler;

        private GamePadState CurrentControler;
        private int selectedInList = 0;

        public void Update(Hero? _hero, List<Button>? menu,Game1 game,ContentManager content)
        {
            GamePadCapabilities gamePad = GamePad.GetCapabilities(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();
            if (_hero != null)
            {
                float scale = 2f;
                _direction = Vector2.Zero;
                if (gamePad.IsConnected)
                {
                    PreviousControler = CurrentControler;
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
                        if (CurrentControler.Buttons.X == ButtonState.Pressed && _hero.Volocity < 200f * 1.25f  || CurrentControler.Buttons.Y == ButtonState.Pressed && _hero.Volocity < 200f * 1.25f )
                        {
                            if (!_hero.Ball.IsDraw)
                            {
                                _hero.Ball.Sommoned = true;
                            }
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
                        if (CurrentControler.Buttons.Start == ButtonState.Released && PreviousControler.Buttons.Start == ButtonState.Pressed)
                        {
                            game.ChangeState(new PauseState(content, _hero));
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
                    if (keyboardState.IsKeyDown(Keys.C) && !_hero.Ball.IsDraw)
                    {
                        _hero.Ball.Sommoned = true;
                    }
                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        game.ChangeState(new PauseState(content, _hero));
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
                if(keyboardState.IsKeyDown(Keys.F)) 
                    Fire = true;
                else if(keyboardState.IsKeyDown(Keys.E))
                    Fire = false;
            }
            else if (menu != null && gamePad.IsConnected)
            {

                PreviousControler = CurrentControler;
                CurrentControler = GamePad.GetState(PlayerIndex.One);
                if (gamePad.HasLeftXThumbStick || gamePad.HasDPadDownButton)
                {
                    if (PreviousControler.ThumbSticks.Left.Y > -0.5f && CurrentControler.ThumbSticks.Left.Y < -0.5f || CurrentControler.DPad.Down == ButtonState.Released && PreviousControler.DPad.Down == ButtonState.Pressed)
                    {
                        menu[selectedInList].Selected = false;
                        if (selectedInList == menu.Count -1)
                        {
                            selectedInList = 0;
                        }
                        else
                        selectedInList++;
                    }
                    if (PreviousControler.ThumbSticks.Left.Y > 0.5f && CurrentControler.ThumbSticks.Left.Y < 0.5f || CurrentControler.DPad.Up == ButtonState.Released && PreviousControler.DPad.Up == ButtonState.Pressed)
                    {
                        menu[selectedInList].Selected = false;
                        if (selectedInList == 0)
                        {
                            selectedInList = menu.Count - 1;
                        }
                        else
                        selectedInList--;
                    }

                    menu[selectedInList].Selected = true;
                    if(PreviousControler.Buttons.A == ButtonState.Pressed && CurrentControler.Buttons.A == ButtonState.Released)
                    {
                        menu[selectedInList].Update(game,content,_hero);
                    } 
                }
                
            }
            else
            {
                foreach (Button component in menu)
                    component.Update(game, content, _hero);
            }
        }
    }
}

