using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using Mario_Game;

namespace Mario_Game
{
    public class MenuState : Structure
    {
        private List<Structure> Components;
        public MenuState() : base()
        {
            Texture2D buttonTexture = Globals.Content.Load<Texture2D>("Button");
            SpriteFont buttonFont = Globals.Content.Load<SpriteFont>("File");

            Button newGameButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(661, 150),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            Button loadGameButton = new (buttonTexture, buttonFont)
            {
                Position = new Vector2(661, 450),
                Text = "Load Game",
            };
            loadGameButton.Click += LoadGameButton_Click;

            Button quitGameButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(661, 750),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            Components = new List<Structure>()
      {
        newGameButton,
        loadGameButton,
        quitGameButton,
      };
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Globals.GameOne.ChangeState(new LoadState());
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Globals.GameOne.ChangeState(new GameState(null));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Globals.GameOne.Exit();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (Structure component in Components)
                component.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Structure component in Components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
