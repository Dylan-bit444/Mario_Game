using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Numerics;


namespace Mario_Game
{
    public class Hero : Sprite 
    {
        public Hero(Texture2D texture, Vector2 position) : base(texture , position)
        { }

        
    private const float SPEED = 500;
        private Vector2 _minPos, _maxPos;

        public void SetBounds(Point mapSize, Point tileSize)
        {
            _minPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
            _maxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
        }

        public void Update()
        {
            Position += InputManager.Direction * Globals.Time * SPEED;
            //Position = Vector2.Clamp(Position, _minPos, _maxPos);
            if (Position.Y > Globals.WindowSize.Y)
            {
                Position = new Vector2(Globals.WindowSize.X / 2 - 100, Globals.WindowSize.Y - 100);

            }
        }
    }
}

