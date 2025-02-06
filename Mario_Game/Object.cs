using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario_Game
{
    internal class Object
    {
        public Vector2 Position { get; set; }
        public Color Colour { get; set; }
        public float Velocity { get; set; }

        public bool IsVisible { get; set; }

        public Rectangle Boundingbox { get; set; }
        public Texture2D Texture { get; set; }

        public bool HitLeft { get; set; }
        public bool HitRight { get; set; }

        public Object(Texture2D _texture, Vector2 _position, Color _colour, float _velocity, Rectangle _box)
        {
            IsVisible = true;
            Texture = _texture;
            Position = _position;
            Colour = _colour;
            Velocity = _velocity;
            Boundingbox = _box;
        }

        public void LoadOwnContent(ContentManager myContent, string contentFilename)
        {
            myContent.RootDirectory = "Content";
            Texture = myContent.Load<Texture2D>(contentFilename);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Colour);

        }

        public void Move(GraphicsDeviceManager _graphics, Object _object)
        {
            IsVisible = true;
            HitLeft = true;

            Boundingbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);


            if (IsVisible && Position.X + Texture.Width >= _graphics.PreferredBackBufferWidth)
            {
                HitRight = true;
                HitLeft = false;
            }

            if (IsVisible && Position.X <= 0)
            {
                HitRight = false;
                HitLeft = true;
            }

            if (HitRight)
            {
                Velocity -= 1;
            }
            if (HitLeft)
            {
                Velocity += 1;
            }
        }
    }
}
