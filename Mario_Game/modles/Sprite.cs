using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
            IsVisible = true;
        }
        public Rectangle HitBox { get {  return new Rectangle((int)Position.X, (int)Position.Y, FrameWidth, FrameHight); } }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Volocity { get; set; }
        public Texture2D Texture { get; set; }
        public bool IsVisible { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool IsDraw = true;
        private int FrameHight;
        private int FrameWidth;

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
        public void LoadOwnContent(ContentManager myContent, string contentFilename)
        {
            myContent.RootDirectory = "Content";
            Texture = myContent.Load<Texture2D>(contentFilename);
        }
        public void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, Color);
        }
    }
}
