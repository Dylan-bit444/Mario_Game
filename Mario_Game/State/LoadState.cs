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
    public class LoadState : Structure
    {
        public SaveData saveData;
        private ContentManager ContentManagers;
        private Game1 GameOne;
        public LoadState(ContentManager content, Game1 gameOne)
            : base()
        {
            saveData = new SaveData();
            ContentManagers = content;
            GameOne = gameOne;
        }
        public override void Update(GameTime gameTime)
        {
            Load();
            GameOne.ChangeState(new GameState(saveData,ContentManagers));
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        public void Load()
        {
            String FileName = "Save_Data.txt";
            if (File.Exists(FileName))
            {
                using (StreamReader reader = new(FileName))
                {
                    string line = reader.ReadLine();
                    var parts = line.Split(',');
                    saveData.SavedPostion = new(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()));
                    saveData.SavedAnimation = new(float.Parse(parts[2].Trim()), float.Parse(parts[3].Trim()));
                    saveData.SavedCoins = float.Parse(parts[4].Trim()); 
                }
            }
        }
    }//Done
}
