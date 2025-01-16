﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Mario_Game
{
    internal class Coin:Sprite
    {
        public static Animation Animations;
        public Coin() : base() { }
        public Coin(Texture2D _texture, Vector2 _position, Color _color, float _volocity) : base(_texture, _position, _color, _volocity)
        {
            Animations = new(Texture, 6, 1, 0.7f);
        }
        public void Update(float time)
        {
            Animations.Update(time);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Height/6, Texture.Width/6);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDraw) 
            Animations.Draw(Position,spriteBatch);
        }
    }
}
