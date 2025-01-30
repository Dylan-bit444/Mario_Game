using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Mario_Game.modles;
using SharpDX.Direct3D9;

namespace Mario_Game
{
    internal class LoadState : Structure
    {
        public SaveData saveData = new SaveData();
        public LoadState()
            : base()
        {}
        public override void Update(GameTime gameTime, Game1 game, ContentManager content)
        {
            Load();
            game.ChangeState(new GameState(saveData,content));
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch){ }
        public void Load()
        {
            String FileName = "Save_Data.txt";
            if (File.Exists(FileName))
            {
                using (StreamReader reader = new(FileName))
                {
                    string[] line = File.ReadAllLines(FileName);
                    saveData.Player.Position = new(float.Parse(line[0]), float.Parse(line[1]));
                    saveData.Player.Animations.LastKeyPress = new(float.Parse(line[2]), float.Parse(line[3]));
                    saveData.Player.CoinsCollected = float.Parse(line[4]);
                    int i = 5;
                    foreach (Coin coin in saveData.Player.Coins)
                    {
                        i++;
                        coin.IsDraw = bool.Parse(line[i]);
                    }
                }
            }
        }
    }
}
