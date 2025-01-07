using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Mario_Game
{
    internal class Coin:Sprite
    {
        public Animation Animations;
        public Coin() : base() { }
        public Coin(Texture2D _texture, Vector2 _position, Color _color, float _volocity, Rectangle _box) : base(_texture, _position, _color, _volocity,_box)
        {
            Animations = new(Texture, 6, 1, 0.1f);
        }
        public void Update()
        {
            Animations.Update();
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Height, Texture.Width);
        }

        public void Draw()
        {
            if(IsDraw) 
            Animations.Draw(Position);
        }
    }
}
