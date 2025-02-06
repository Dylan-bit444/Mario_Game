using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;



namespace Mario_Game
{
    public class Hero : Sprite
    {
        private const float Speed = 250f;
        private const float Gravity = 30f;
        private const float Jump = 500f;
        private Vector2 _velocity;
        private bool _onGround = true;
        private int gravitytimer = 0;
        private int gravitytiming = 30;
        private Tile noTile;

        public bool CanMoveLeft { get; set; }
        public bool CanMoveRight { get; set; }

        public Hero() : base()
        {
        }

        public Hero(Texture2D texture, Vector2 position, Color _colour, float _velocity, Rectangle _boundingbox)
            : base(texture, position, _colour, _velocity, _boundingbox)
        {
            noTile = new Tile();
            CanMoveRight = true;
            CanMoveLeft = true;
        }
        public void UpdateVelocity(GraphicsDeviceManager _graphics, Tile inTile)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (CanMoveLeft)
                {
                    _velocity.X = -Speed;
                }
                if (!CanMoveLeft)
                {
                    _velocity.X = 0;
                }
                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (CanMoveRight)
                {
                    _velocity.X = +Speed;
                }
                if(!CanMoveRight)
                {
                    _velocity.X = 0;
                }
            }
            else _velocity.X = 0;

            if (!_onGround && gravitytimer==0)
            {
                _velocity.Y += Gravity;
           
            }
            gravitytimer = MathHelper.Max(0, gravitytimer-1);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _onGround)
            {
                _velocity.Y = -Jump;
                _onGround = false;
                gravitytimer = gravitytiming; 
            }
            if (Position.Y + Texture.Height > _graphics.PreferredBackBufferHeight)
            {
          
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