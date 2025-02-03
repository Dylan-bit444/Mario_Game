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
        private float Rotation;
        private float RotationVelocity { get; set; }

        public FireBall():base() { }
        public FireBall(Texture2D _texture, Vector2 _position, Color _color, float _volocity,float rotstion) : base(_texture, _position, _color, _volocity) 
        { 
            RotationVelocity = rotstion;
        }
        public void Update()
        {
            Rotation -= MathHelper.ToRadians(RotationVelocity);
            Position += new Vector2(Volocity, 1);
        }
        public void Draws(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,null,Color.White,Rotation,Origin,1,SpriteEffects.None,1f);
        }
    }
}
