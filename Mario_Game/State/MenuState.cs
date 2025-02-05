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
    internal class MenuState : Structure
    {
        private List<Button> Components;
        private InputManager inputManager;
        public MenuState(ContentManager content) : base()
        {
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
        private void LoadGameButton_Click(Button sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.ChangeState(new LoadState());
        }
        private void NewGameButton_Click(Button sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.ChangeState(new GameState(null,content));
        }
        private void QuitGameButton_Click(Button sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.Exit();
        }
        public override void Update(GameTime gameTime,Game1 game, ContentManager content, GraphicsDeviceManager graphics)
        {
            inputManager.Update(null,Components,game,content);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Begin();
            foreach (Button component in Components)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}
