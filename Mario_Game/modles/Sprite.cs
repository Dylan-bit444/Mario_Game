using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Mario_Game
{
    internal class Sprite
    {
        public Sprite()
        { }
        public Sprite(Texture2D _texture, Vector2 _position, Color _color, float _volocity, int frameLength,int frameRows)
        {
            Texture = _texture;
            Position = _position;
            Color = _color;
            Volocity = _volocity;
            FrameHight = Texture.Height/ frameRows;
            FrameWidth = Texture.Width/ frameLength;
        }
        public Rectangle HitBox { get {  return new Rectangle((int)Position.X, (int)Position.Y, FrameWidth, FrameHight); } }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Volocity { get; set; }
        public Texture2D Texture { get; set; }
        public bool IsDraw = true;
        private int FrameHight = 0;
        private int FrameWidth = 0;
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
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.HitBox.Bottom + this.Position.Y > sprite.HitBox.Top &&
              this.HitBox.Top < sprite.HitBox.Top &&
              this.HitBox.Right > sprite.HitBox.Left &&
              this.HitBox.Left < sprite.HitBox.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.HitBox.Top + this.Position.Y < sprite.HitBox.Bottom &&
              this.HitBox.Bottom > sprite.HitBox.Bottom &&
              this.HitBox.Right > sprite.HitBox.Left &&
              this.HitBox.Left < sprite.HitBox.Right;
        }
    }
}
