using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Mario_Game.modles
{
    internal class Flag:Sprite
    {
        public Flag() : base() { }

        public Flag(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameLength, int frameRows) : base()
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
            spriteBatch.Draw(Texture,Position,HitBox,Color.White);   
        }
    }
}
