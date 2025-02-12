using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;




namespace Mario_Game
{
    public class SimonHero : SimonSprite
    {
        private const float Speed = 350f;
        private const float Gravity = 3.5f;
        private const float Jump = 5000f;
        private Vector2 _velocity;
        private bool _onGround = true;
        private int gravitytimer = 0;
        private int gravitytiming = 30;
        private Tile noTile;

        public bool CanMoveLeft { get; set; }
        public bool CanMoveRight { get; set; }
        public bool CanMoveDown { get; set; }


        public SimonHero() : base()
        {
        }

        public SimonHero(Texture2D texture, Vector2 position, Color _colour, float _velocity, Rectangle _boundingbox)
            : base(texture, position, _colour, _velocity, _boundingbox)
        {
            noTile = new Tile();
            CanMoveRight = true;
            CanMoveLeft = true;
            CanMoveDown = true;
        }
        public void UpdateVelocity(GraphicsDeviceManager _graphics, Tile inTile)
        {
            Vector2 prevPos = Position;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _velocity.X = -Speed;
                if (CanMoveLeft)
                {
                    _velocity.X = -Speed;
                }
                if (!CanMoveLeft)
                {
                    Position = new Vector2(prevPos.X + 9, Position.Y);
                    CanMoveLeft = true;
                    CanMoveRight = true;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _velocity.X = +Speed;
                if (CanMoveRight)
                {
                    _velocity.X = Speed;
                }
                if (!CanMoveRight)
                {
                    Position = new Vector2(prevPos.X - 9, Position.Y);
                    CanMoveLeft = true;
                    CanMoveRight = true;
                }
            }
            else
            {
                _velocity.X = 0;
            }

            if (!_onGround && gravitytimer == 0)
            {
                _velocity.Y += Gravity;

            }
            gravitytimer = MathHelper.Max(0, gravitytimer - 1);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _onGround)
            {
                _velocity.Y = -Jump;
                _onGround = false;
                gravitytimer = gravitytiming;
            }
            if (Position.Y + Texture.Height > _graphics.PreferredBackBufferHeight)
            {
                Position = new Vector2(Position.X, prevPos.Y+9);
                _onGround = true;
                Position = new Vector2(Position.X, _graphics.PreferredBackBufferHeight - Texture.Height) ;
                _velocity.Y = 0;
            }
          
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Update(GraphicsDeviceManager _graphics)
        {
            Position += _velocity * Globals.Time;
        }
        public void UpdatePosition(GraphicsDeviceManager _graphics)
        {
            _onGround = false;
            var newPos = Position + (_velocity * Globals.Time);
        }
    }

}