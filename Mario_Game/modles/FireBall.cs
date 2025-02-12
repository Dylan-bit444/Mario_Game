using System;
using System.Diagnostics;
using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mario_Game.modles
{
    internal class FireBall:Sprite
    {
        private Vector2 Origin { get { return new Vector2(Texture.Width / 2, Texture.Height / 2); } }
        private float Rotation;
        private float Xpos = 10;
        public bool Sommoned;
        private float RotationVelocity { get; set; }

        public FireBall():base() { }
        public FireBall(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameRows, int frameCollums,float rotstion) : base(_texture, _position, _color, _volocity, frameRows, frameCollums) 
        { 
            RotationVelocity = rotstion;
        }
        public void Update(GraphicsDeviceManager graphics)
        {
            if (InputManager.Fire)
            {
                if (graphics.PreferredBackBufferHeight <= Position.Y + HitBox.Height)
                    Volocity = -10;
                else if (Position.Y < 0)
                    Volocity = 10;
                if (graphics.PreferredBackBufferWidth <= Position.X + HitBox.Width)
                    Xpos = -10;
                else if (Position.X < 0)
                    Xpos = 10;
                Position += new Vector2(Xpos, ((int)Volocity));
            }
            else
            {
                Xpos += 0.5f;
                if (graphics.PreferredBackBufferHeight <= Position.Y + HitBox.Height)
                {
                    Xpos = -7;
                }
                if (graphics.PreferredBackBufferWidth <= Position.X + HitBox.Width)
                    Volocity =-Volocity;
                else if (Position.X < 0)
                    Volocity=-Volocity;
               Position += new Vector2(Volocity,((int)Xpos^2)+(2*Xpos));
            }
            Rotation -= MathHelper.ToRadians(RotationVelocity);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDraw) 
                spriteBatch.Draw(Texture,Position,null,Color.White,Rotation,Origin,1,SpriteEffects.None,1f);
        }
    }
}
