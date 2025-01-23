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
        private InputManager inputManager;
        private ContentManager ContentManagers;
        private SaveData SaveData;
        private Game1 GameOne;

        public PauseState(Game1 game, ContentManager content,Hero _hero)
        {
            SaveData = new SaveData();
            SaveData.Hero = _hero;
            ContentManagers = content;
            GameOne = game;
            inputManager = new();
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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            String fileName = "Save_Data.txt";
            using (StreamWriter writer = new(fileName, false))
            {
                writer.WriteLine($"{SaveData.Hero.Position.X},{SaveData.Hero.Position.Y},{SaveData.Hero.Animations.LastKeyPress.X},{SaveData.Hero.Animations.LastKeyPress.Y},{SaveData.Hero.CoinsCollected}");
            }
        }
        private void MenuButton_Click(object sender, EventArgs e)
        {
            GameOne.ChangeState(new MenuState( GameOne, ContentManagers));
        }
        private void ResumeButton_Click(object sender, EventArgs e)
        {
            GameOne.ChangeState(new GameState(SaveData,ContentManagers,GameOne));
        }
        public override void Update(GameTime gameTime)
        {
            inputManager.Update(null, Components, GameOne, ContentManagers);
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
