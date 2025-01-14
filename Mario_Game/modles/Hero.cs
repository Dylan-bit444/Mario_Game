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
            Animations.AddAnimation(new Vector2(0, 1), new(Texture, 8, 8, 0.1f, 0));
            Animations.AddAnimation(new Vector2(-1, 0), new(Texture, 8, 8, 0.1f, 1));
            Animations.AddAnimation(new Vector2(1, 0), new(Texture, 8, 8, 0.1f, 2));
            Animations.AddAnimation(new Vector2(0, -1), new(Texture, 8, 8, 0.1f, 3));
            Animations.AddAnimation(new Vector2(-1, 1), new(Texture, 8, 8, 0.1f, 4));
            Animations.AddAnimation(new Vector2(-1, -1), new(Texture, 8, 8, 0.1f, 5));
            Animations.AddAnimation(new Vector2(1, 1), new(Texture, 8, 8, 0.1f, 6));
            Animations.AddAnimation(new Vector2(1, -1), new(Texture, 8, 8, 0.1f, 7));
            Coins = coins;
        }

        public void Update()
        {
            if (InputManager.Moving)
            {
                Position += Vector2.Normalize(InputManager.Direction) * Volocity * Globals.TotalSeconds;
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
            Animations.Update(InputManager.Direction);
        }

        public void Draw()
        {
            if(IsDraw)
            Animations.Draw(Position);
        }
    }
}
