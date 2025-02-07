using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario_Game.modles
{
    internal class Power_Block:Sprite
    {
        private PowerUp HeldPower;
        public Power_Block():base(){ }

        public Power_Block(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameLength, int frameRows):base(_texture, _position, _color, _volocity, frameLength, frameRows)
        {
            HeldPower = new PowerUp(null,new Vector2(Position.X,Position.Y+Texture.Height),Color.White,5,1,1);
            HeldPower.IsDraw = false;
        }

        public void Update(Hero _hero,Texture2D Mush,Texture2D Flower)
        {
            if (IsTouchingTop(_hero))
            {
                if(_hero.HitPoints == 1)
                {
                    HeldPower.Texture = Mush;
                }
                else
                {
                    HeldPower.Texture=Flower;
                }
                HeldPower.IsDraw=true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
