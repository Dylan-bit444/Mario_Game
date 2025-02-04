using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Mario_Game
{
    internal class Coin:Sprite
    {
        public static Animation Animations;
        public Coin() : base() { }
        public Coin(Texture2D _texture, Vector2 _position, Color _color, float _volocity,int frameRows,int frameCollums) : base(_texture, _position, _color, _volocity,frameRows,frameCollums)
        {
            Animations = new(Texture, 6, 1, 0.7f);
        }
        public void Update(float time)
        {
            Animations.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsDraw) 
            Animations.Draw(Position,spriteBatch);
        }
    }
}
