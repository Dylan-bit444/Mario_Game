using Mario_Game.modles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game.State
{
    internal class PauseState: Structure
    {
        private List<Button> Components;
        private InputManager inputManager = new();
        private SaveData SaveData = new SaveData();

        public PauseState(ContentManager content,Hero _hero)
        {
            SaveData.Player = _hero;
            SpriteFont hudFont = content.Load<SpriteFont>("HudText");
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("File");
            Button SaveButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(661, 150),
                Text = "Save",
            };
            SaveButton.Click += SaveButton_Click;
            Button MenuButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(661, 750),
                Text = "Main Menu",
            };
            MenuButton.Click += MenuButton_Click;
            Button ResumeButtom = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(661, 450),
                Text = "Resume"
            };
            ResumeButtom.Click += ResumeButton_Click;
            Components = new List<Button>()
            {
                SaveButton,
                ResumeButtom,
                MenuButton
                
            };
        }
        private void SaveButton_Click(Button sender, Game1 game, ContentManager content, EventArgs e)
        {
            String fileName = "Save_Data.txt";
            using (StreamWriter writer = new(fileName, false))
            {
                writer.WriteLine($"{SaveData.Player.Position.X},{SaveData.Player.Position.Y},{SaveData.Player.Animations.LastKeyPress.X},{SaveData.Player.Animations.LastKeyPress.Y},{SaveData.Player.CoinsCollected}");
                foreach(Coin coin in SaveData.Player.Coins)
                {
                    writer.WriteLine($"{coin.IsDraw}");
                }
            }
        }
        private void MenuButton_Click(Button sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.ChangeState(new MenuState( content));
        }
        private void ResumeButton_Click(Button sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.ChangeState(new GameState(SaveData,content));
        }
        public override void Update(GameTime gameTime,Game1 game,ContentManager content)
        {
            inputManager.Update(null, Components, game, content);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Button component in Components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
