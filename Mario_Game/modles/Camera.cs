using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game.modles
{
    internal class Camera:Sprite
    {
        private Camera() : base() { }
        private Camera(Texture2D texture, Vector2 position, Color color, float volocity,int frameLength,int frameRows) : base(texture, position, color, volocity, frameLength, frameRows)
        {

        }
        public void Update(Hero hero)
        {
            if(Position.Y != hero.Position.Y)
            {
             
            }
        }
    }
}
