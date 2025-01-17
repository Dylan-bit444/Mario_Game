﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mario_Game
{
    internal class InputManager
    {
        public static bool Mickel;
        private static Vector2 _direction = Vector2.Zero;
        public static Vector2 Direction => _direction;
        public static bool Moving => _direction != Vector2.Zero;

        public void Update(Hero _hero)
        {
            float scale = 2f;
            _direction = Vector2.Zero;
            GamePadCapabilities gamePad = GamePad.GetCapabilities(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();
            if (gamePad.IsConnected)
            {
                GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                if (gamePad.HasLeftXThumbStick || gamePad.HasDPadDownButton)
                {
                    if (gamePadState.ThumbSticks.Left.X < -0.5f || gamePadState.DPad.Left == ButtonState.Pressed)
                    {
                        _direction -= new Vector2(1, 0);
                    }
                    if (gamePadState.ThumbSticks.Left.X > 0.5f || gamePadState.DPad.Right == ButtonState.Pressed)
                    {
                        _direction += new Vector2(1, 0);
                    }
                    if (gamePadState.ThumbSticks.Left.Y < -0.5f || gamePadState.DPad.Down == ButtonState.Pressed)
                    {
                        _direction += new Vector2(0, 1);
                    }
                    if (gamePadState.ThumbSticks.Left.Y > 0.5f || gamePadState.DPad.Up == ButtonState.Pressed)
                    {
                        _direction -= new Vector2(0, 1);
                    }
                    if (gamePadState.Buttons.X == ButtonState.Pressed && _hero.Volocity < 200f * 1.25f)
                    {
                        _hero.Volocity = _hero.Volocity * scale;
                    }
                    else if (gamePadState.Buttons.X != ButtonState.Pressed && _hero.Volocity > 200f)
                    {
                        _hero.Volocity = _hero.Volocity / scale;
                    }
                    if (gamePadState.Buttons.A == ButtonState.Pressed)
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
        public void ControlerMenu(List<Structure> Buttons, GamePadCapabilities gamePad)
        {
            Buttons[1].
        }
    }
}
