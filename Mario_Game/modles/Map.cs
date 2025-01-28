using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Mario_Game
{
    internal class Map
    {
        private int[,] map;
        private Animation Tiles;
        public Map(Texture2D texture)
        {
            Tiles = new(texture,6,0,3);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
        }

    }
}
