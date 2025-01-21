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
        private List<Button> Components;
        private Game1 GameOne;
        private InputManager inputManager;
        private ContentManager ContentManagers;
        public MenuState(Game1 game1,ContentManager content) : base()
        {
            ContentManagers = content; 
            GameOne = game1;
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("File");

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

            Components = new List<Button>()
      {
        newGameButton,
        loadGameButton,
        quitGameButton,
      };
            inputManager= new InputManager();
        }
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            GameOne.ChangeState(new LoadState(ContentManagers,GameOne));
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            GameOne.ChangeState(new GameState(null,ContentManagers));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            GameOne.Exit();
        }
        public override void Update(GameTime gameTime)
        {
            inputManager.Update(null,Components);
            foreach (Button component in Components)
                component.Update(gameTime);
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
