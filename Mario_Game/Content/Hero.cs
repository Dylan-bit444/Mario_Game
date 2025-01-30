using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using tile;

namespace Mario_Game
{
    public class Hero : Sprite
    {
        public Hero(Texture2D texture, Vector2 position) : base(texture , position)
        { }

        
    private const float SPEED = 500;
        public void Update()
        {
            Debug.WriteLine(Globals.Time);
            Position += InputManager.Direction  * Globals.Time *  SPEED;
            //Position = Vector2.Clamp(Position, _minPos, _maxPos);
            if (Position.Y > Globals.WindowSize.Y)
            {
                Position = new Vector2(Globals.WindowSize.X / 5 , Globals.WindowSize.Y / 2 - 250);

            }
        }

    }
}

