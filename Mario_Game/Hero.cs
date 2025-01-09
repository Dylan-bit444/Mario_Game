using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;


namespace Mario_Game
{
    public class Hero : Sprite
    {
        private const float Speed = 1f;
        private const float Gravity = 1f;
        private const float Jump = 1f;
        private Vector2 _velocity;
        private bool _onGround = true;

        public Hero() : base()
        {
        }

        public Hero(Texture2D texture, Vector2 position, Color _colour, float _velocity, Rectangle _boundingbox)
            : base(texture, position, _colour, _velocity, _boundingbox)
        {
        }
        private void UpdateVelocity()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _velocity.X = +Speed;
            }
            else _velocity.X = 0;

            if (!_onGround)
            {
                _velocity.Y += Gravity * Globals.Time;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _onGround)
            {
                _velocity.Y = -Jump;
                _onGround = false;
            }
        }
        public void Update()
        {
            UpdateVelocity();
            Position += _velocity * Globals.Time;
        }
        private void UpdatePosition()
        {
            _onGround = false;
            var newPos = Position + (_velocity * Globals.Time);
        }
    }

}