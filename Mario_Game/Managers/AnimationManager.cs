using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{
    internal class AnimationManager
    {
        public Dictionary<Vector2, Animation> Animation = new();
        public Vector2 LastKeyPress;

        public void AddAnimation(Vector2 key, Animation animation)
        {
            Animation.Add(key, animation);
            LastKeyPress = key;
        }

        public void Update(Vector2 key,float time)
        {
            if (InputManager.Mickel)
            {
                key = -key;
            }
            if (Animation.TryGetValue(key, out Animation value))
            {
                value.Start();
                Animation[key].Update(time);
                LastKeyPress = key;
            }
            else
            {
                Animation[LastKeyPress].Stop();
                Animation[LastKeyPress].Reset();
            }
        }

        public void Draw(Vector2 position,SpriteBatch spriteBatch)
        {
            Animation[LastKeyPress].Draw(position, spriteBatch);
        }
    }
}
