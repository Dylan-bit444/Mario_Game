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
    internal class PauseState:Structure
    {
        private List<Button> Components;
        private InputManager inputManager;
        private ContentManager ContentManagers;
        private Game1 GameOne;
        private Hero _hero;

        public PauseState(Game1 game, ContentManager content, Hero hero)
        {
            ContentManagers = content;
            GameOne = game;
            inputManager = new();
            Components = new List<Button>();
            _hero = hero;
            SpriteFont hudFont = content.Load<SpriteFont>("HudText");
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("File");
            Button SaveButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(0, 0),
                Text = "Save",
            };
            SaveButton.Click += SaveButton_Click;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            String fileName = "Save_Data.txt";
            using (StreamWriter writer = new(fileName, false))
            {
                writer.WriteLine($"{_hero.Position.X},{_hero.Position.Y},{_hero.Animations.LastKeyPress.X},{_hero.Animations.LastKeyPress.Y},{_hero.CoinsCollected}");
            }
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            GameOne.ChangeState(new MenuState( GameOne, ContentManagers));
        }
        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
