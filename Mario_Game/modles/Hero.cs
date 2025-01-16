using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Mario_Game
{
    internal class Hero:Sprite
    {
        public AnimationManager Animations = new();
        public int CoinsCollected=0;
        public Coin[] Coins {get; set;}
        public Hero():base() { }
        public Hero(Texture2D texture, Vector2 _position, Color _color, float _volocity, Coin[] coins) : base(texture, _position, _color, _volocity)
        {
            float frameTime = 0.1f;
            Animations.AddAnimation(new Vector2(0, 1), new(Texture, 8, 8, frameTime, 0));
            Animations.AddAnimation(new Vector2(-1, 0), new(Texture, 8, 8, frameTime, 1));
            Animations.AddAnimation(new Vector2(1, 0), new(Texture, 8, 8, frameTime, 2));
            Animations.AddAnimation(new Vector2(0, -1), new(Texture, 8, 8, frameTime, 3));
            Animations.AddAnimation(new Vector2(-1, 1), new(Texture, 8, 8, frameTime, 4));
            Animations.AddAnimation(new Vector2(-1, -1), new(Texture, 8, 8, frameTime, 5));
            Animations.AddAnimation(new Vector2(1, 1), new(Texture, 8, 8, frameTime, 6));
            Animations.AddAnimation(new Vector2(1, -1), new(Texture, 8, 8, frameTime, 7));
            Coins = coins;
        }

        public void Update(float time)
        {
            if (InputManager.Moving)
            {
                Position += Vector2.Normalize(InputManager.Direction) * Volocity * time;
            }
            foreach (Coin coin in Coins)
            {
                if (Collided(coin.HitBox) && coin.IsDraw)
                {
                    coin.IsDraw = false;
                    CoinsCollected++;
                }
            }
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Height/8, Texture.Width/8);
            Animations.Update(InputManager.Direction,time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDraw)
            Animations.Draw(Position,spriteBatch);
        }
    }
}
