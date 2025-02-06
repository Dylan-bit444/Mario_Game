using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario_Game
{
    internal class Animation
    {
        private  Texture2D Texture;
        public Rectangle []Rectangles= new Rectangle[64];
        private int Frames;
        private int CurrentFrame;
        private float FramTime;
        private float FrameTimeLeft;
        private bool Active = true;

        public Animation(Texture2D texture, int framesX, int framesY, float frameTime, int row = 0)
        {
            Texture = texture;
            FramTime = frameTime;
            FrameTimeLeft = FramTime;
            Frames = framesX;
            var frameWidth = Texture.Width / framesX;
            var frameHeight = Texture.Height / framesY;
            for (int i = 0; i < Frames; i++)
            {
                Rectangles[i] = new Rectangle(i * frameWidth, (row) * frameHeight, frameWidth, frameHeight);
            }

            
        }

        public void Start()
        {
            Active = true;
        }

        public void Reset()
        {
            Active = false;
            CurrentFrame = 0;
            FrameTimeLeft = FramTime;
        }

        public void Update(float time)
        {
            if (Active)
            {
                FrameTimeLeft -= time;
                if (FrameTimeLeft <= 0)
                {
                    FrameTimeLeft += FramTime;
                    CurrentFrame = (CurrentFrame + 1) % Frames;
                }
            }
        }

        public void Draw(Vector2 pos,SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, pos, Rectangles[CurrentFrame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
