using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{
    internal class Animation
    {
        private  Texture2D Texture;
        private Rectangle []Rectangles= new Rectangle[64];
        private int Frames;
        private int FrameSection;
        private int CurrentFrame;
        private float FramTime;
        private float FrameTimeLeft;
        private bool Active = true;

        public Animation(Texture2D texture, int framesX, int framesY, float frameTime, int row = 0, int frameSection = 0)
        {
            Texture = texture;
            FramTime = frameTime;
            FrameTimeLeft = FramTime;
            Frames = framesX;
            var frameWidth = Texture.Width / framesX;
            var frameHeight = Texture.Height / framesY;
            FrameSection = frameSection;
            for (int i = 0; i < Frames; i++)
            {
                Rectangles[i] = new Rectangle(i * frameWidth, (row) * frameHeight, frameWidth, frameHeight);
            }

            
        }

        public void Stop()
        {
            Active = false;
        }

        public void Start()
        {
            Active = true;
        }

        public void Reset()
        {
            CurrentFrame = 0;
            FrameTimeLeft = FramTime;
        }

        public void Update()
        {
            if (!Active) return;

            FrameTimeLeft -= Globals.TotalSeconds;

            if (FrameTimeLeft <= 0)
            {
                FrameTimeLeft += FramTime;
                CurrentFrame = (CurrentFrame + 1) % Frames;
            }
        }

        public void Draw(Vector2 pos)
        {
            Globals.SpriteBatch.Draw(Texture, pos, Rectangles[CurrentFrame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
