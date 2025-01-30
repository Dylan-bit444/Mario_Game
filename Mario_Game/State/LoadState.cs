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
                    string line = reader.ReadLine();
                    var parts = line.Split(',');
                    saveData.Player.Position = new(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()));
                    saveData.Player.Animations.LastKeyPress = new(float.Parse(parts[2].Trim()), float.Parse(parts[3].Trim()));
                    saveData.Player.CoinsCollected = float.Parse(parts[4].Trim()); 
                }
            }
        }
    }
}
