using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Mario_Game
{
    public class Tile
    {
        public Texture2D TileTexture { get; set; }
        public int TileSize { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool Collidable {  get; set; }

        public Tile()
        { }

        public Tile(Texture2D inTexture, int inTileSize, Vector2 inPosition, bool isCollidable)
        {
            TileTexture = inTexture;
            TileSize = inTileSize;
            Collidable = isCollidable;
            Position = inPosition;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, inTexture.Width, inTexture.Height);
        }
        public bool CheckCollided(Hero inHero)
        {
            
            if (Collidable && BoundingBox.Intersects(inHero.BoundingBox))
            {
                Debug.WriteLine("BANG");
                Collidable = true;
                inHero.CanMoveLeft = false;
                inHero.CanMoveRight = false;
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TileTexture, Position, Color.White);
        }
    }
}
