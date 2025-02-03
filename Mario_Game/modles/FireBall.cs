using System;
using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game.modles
{
    internal class FireBall:Sprite
    {
        private Vector2 Origin { get { return new Vector2(Texture.Width / 2, Texture.Height / 2); } }
        private float Ratation = MathHelper.ToRadians(4f);

        public FireBall():base() { }
        public FireBall(Texture2D _texture, Vector2 _position, Color _color, float _volocity) : base(_texture, _position, _color, _volocity) { }
        public void Update()
        {     
            Position = new((float)Math.Cos(Ratation) * Volocity, (float)Math.Sin(Ratation) * Volocity);
        }
        public void Draws(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,HitBox,Color.White,Ratation,Origin,1,SpriteEffects.None,1f);
        }
    }
}
