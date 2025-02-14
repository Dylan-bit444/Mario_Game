using Mario_Game.modles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Mario_Game
{
    internal class Hero:Sprite
    {
        public AnimationManager Animations = new();
        public float CoinsCollected=0;
        public FireBall Ball;
        public Coin[] Coins {get; set;}
        public int HitPoints = 1;


        public const float Speed = 350f;
        public const float Gravity = 3.5f;
        public  const float Jump = 5000f;
        public Vector2 _velocity;
        public bool _onGround = true;
        public int gravitytimer = 0;
        public int gravitytiming = 30;


        public Hero():base() { }
        public Hero(Texture2D texture, Vector2 _position, Color _color, float _volocity, int frameRows, int frameCollums, Coin[] coins,FireBall fire) : base(texture, _position, _color, _volocity, frameRows, frameCollums)
        { 
            Ball = fire;
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

        public void Update(float time, GraphicsDeviceManager graphics, bool fire, Vector2 Direction, bool Moving)
        {
            if (Ball.Sommoned && HitPoints == 3)
            {
                Ball.IsDraw = true;
                Ball.Sommoned = false;
                if (Direction.X == 1 || Animations.LastKeyPress.X == 1 &&Direction.X == 0)
                {
                    Ball.Position = new Vector2(10 + Position.X + Texture.Width / 8, Position.Y + (Texture.Height / 8) / 2);
                    if(Ball.Volocity < 0)
                    {
                        Ball.Volocity = -Ball.Volocity;
                    }
                }
                else if (Direction.X == -1 || Animations.LastKeyPress.X == -1 &&Direction.X == 0)
                {
                    Ball.Position = new Vector2(Position.X- 40, Position.Y + (Texture.Height / 8) / 2);
                    if (Ball.Volocity > 0)
                    {
                        Ball.Volocity = -Ball.Volocity;
                    }
                }
            }
            if (Collided(Ball.HitBox))
            {
                Ball.IsDraw = false;
            }
            if (Moving)
            {
                Position += Vector2.Normalize(Direction) * Volocity * time;
            }
            foreach (Coin coin in Coins)
            {
                if (Collided(coin.HitBox) && coin.IsDraw)
                {
                    coin.IsDraw = false;
                    CoinsCollected++;
                }
            }
            if(Ball.IsDraw)
                Ball.Update(graphics,fire);
            Animations.Update(Direction,time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDraw)
            Animations.Draw(Position,spriteBatch);
        }
    }
}
