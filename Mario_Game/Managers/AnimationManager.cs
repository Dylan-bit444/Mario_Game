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
        private Dictionary<object, Animation> Animation = new();
        private object LastKeyPress;

        public void AddAnimation(object key, Animation animation)
        {
            Animation.Add(key, animation);
            LastKeyPress = key;
        }

        public void Update(object key)
        {
            if (Animation.TryGetValue(key, out Animation value))
            {
                value.Start();
                Animation[key].Update();
                LastKeyPress = key;
            }
            else
            {
                Animation[LastKeyPress].Stop();
                Animation[LastKeyPress].Reset();
            }
        }

        public void Draw(Vector2 position)
        {
            Animation[LastKeyPress].Draw(position);
        }
    }
}
