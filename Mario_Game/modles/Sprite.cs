using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Mario_Game
{
    internal class Sprite
    {
        public Sprite()
        { }
        public Sprite(Texture2D _texture, Vector2 _position, Color _color, float _volocity,Rectangle _box)
        {
            Texture = _texture;
            Position = _position;
            Color = _color;
            Volocity = _volocity;
            _box= new Rectangle((int)Position.X,(int)Position.Y,Texture.Height,Texture.Width);
            HitBox=_box;
        }
        public Rectangle HitBox {  get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Volocity { get; set; }
        public Texture2D Texture { get; set; }
        public bool IsDraw = true;
        public bool Collided(Rectangle box)
        {
            if (HitBox.Intersects(box))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
