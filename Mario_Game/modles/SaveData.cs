using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game.modles
{
    internal class SaveData
    {
        public SaveData()
        {
            Player.Volocity = 200f;
            Player.Color = Color.White;
        }
        public Hero Player = new();
        
    }
}
