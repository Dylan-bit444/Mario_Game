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
    public class LoadState : State
    {
        public SaveData saveData;
        public LoadState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content) 
        {
            saveData=new SaveData();
        }
        public override void PostUpdate(GameTime gameTime)
        {

        }
        public override void Update(GameTime gameTime)
        {
            Load();
            Games.ChangeState(new GameState(Games, _graphicsDevice, _content,saveData));
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
                    if (parts.Length == 2 )
                    {
                        float x = float.Parse(parts[0].Trim());
                        float y = float.Parse(parts[1].Trim());
                        saveData.SavedPostion = new(x,y);

                    }
                }
            }
        }
    }
}
