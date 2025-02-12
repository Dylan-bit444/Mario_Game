﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario_Game
{
    internal class PowerUp:Sprite
    {
        public PowerUp(): base() { }
        
        public PowerUp(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameLength, int frameRows) : base(_texture, _position, _color, _volocity, frameLength, frameRows)
        {
            IsDraw = false;
        }
        
        public void Update(Hero hero)
        {
            if (IsDraw)
            {
                if (Collided(hero.HitBox))
                {
                    if(hero.HitPoints < 3)
                    hero.HitPoints++;
                    IsDraw = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDraw) 
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
