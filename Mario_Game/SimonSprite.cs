using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{
    public class SimonSprite
    {
        public Vector2 Position { get; set; }
        public Color Colour { get; set; }
        public float Velocity { get; set; }
        public Texture2D Texture { get; set; }
        public bool IsVisible { get; set; }
        public Rectangle BoundingBox { get; set; }

        public SimonSprite()
        {
        }

        public SimonSprite(Texture2D _texture, Vector2 _position, Color _colour, float _velocity, Rectangle _boundingbox)
        {
            Texture = _texture;
            Position = _position;
            Colour = _colour;
            Velocity = _velocity;
            IsVisible = true;
            BoundingBox = _boundingbox;
        }

        public void LoadOwnContent(ContentManager myContent, string contentFilename)
        {
            myContent.RootDirectory = "Content";
            Texture = myContent.Load<Texture2D>(contentFilename);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, Colour);
        }
        public bool CheckCollided(Rectangle inBox)
        {
            if (BoundingBox.Intersects(inBox))
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
