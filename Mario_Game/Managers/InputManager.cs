﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{
    public class InputManager
    {
        private static Vector2 _direction = Vector2.Zero;
        public static Vector2 Direction => _direction;
        public static bool Moving => _direction != Vector2.Zero;

        public void Update()
        {
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
                    if (gamePadState.Buttons.X == ButtonState.Pressed)
                    {
                        _direction -= new Vector2(1, 0);
                    }
                    if (gamePadState.Buttons.B == ButtonState.Pressed)
                    {
                        _direction += new Vector2(1, 0);
                    }
                    if (gamePadState.Buttons.Y == ButtonState.Pressed)
                    {
                        _direction -= new Vector2(0, 1);
                    }
                    if (gamePadState.Buttons.A == ButtonState.Pressed)
                    {
                        _direction += new Vector2(0, 1);
                    }
                }
            }
            if (keyboardState.IsKeyDown(Keys.A) ||keyboardState.IsKeyDown(Keys.Left))
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
        }
    }
}

