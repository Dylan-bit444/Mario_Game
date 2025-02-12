using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace Mario_Game.modles
{
    internal class Flag:Sprite
    {
        public Flag() : base() { }

        public Flag(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameLength, int frameRows) : base(_texture,_position,_color,_volocity,frameLength,frameRows)
        { 
        }
        public void Update(Game1 game, Hero hero, Structure Win)
        {
            if(Collided(hero.HitBox))
            {
                game.ChangeState(Win);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,Position,Color.White);   
        }
    }
}
