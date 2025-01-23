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
        public Hero Hero {  get; set; }
        public Vector2 SavedPostion { get; set; }
        public Vector2 SavedAnimation { get; set; }
        public float SavedCoins { get; set; }
    }
}
