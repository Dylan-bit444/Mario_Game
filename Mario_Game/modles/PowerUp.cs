using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario_Game
{
    internal class PowerUp:Sprite
    {
        public PowerUp(): base() { }
        
        public PowerUp(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameLength, int frameRows) : base(_texture, _position, _color, _volocity, frameLength, frameRows) { }
        
        public void Update(Hero hero)
        {
            if(Collided(hero.HitBox))
            {
                hero.HitPoints++;
            }
        }
    }
}
