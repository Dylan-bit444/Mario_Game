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
            : base(game, graphicsDevice, content) { }
        public override void PostUpdate(GameTime gameTime)
        {
        }
        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        public static void Load()
        {
            String FileName = "Save_Data.txt";
            if (File.Exists(FileName))
            {
                using (StreamReader reader = new(FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out var scoreValue))
                        {

                        }
                    }
                }
            }
        }
    }
}
