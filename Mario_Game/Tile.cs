using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario_Game
{
    internal class Tile
    {
        public Texture2D TileTexture { get; set; }
        public int TileSize { get; set; }
        public Vector2 Position { get; set; }

        public Tile(Texture2D inTexture, int inTileSize, Vector2 inPosition)
        {
            TileTexture = inTexture;
            TileSize = inTileSize;
            Position = inPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TileTexture, Position, Color.White);
        }
    }
}
