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
    public class MenuState : State
    {
        private List<Structure> Components;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D buttonTexture = _content.Load<Texture2D>("Button");
            SpriteFont buttonFont = _content.Load<SpriteFont>("File");

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
            Console.WriteLine("Load Game");
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Games.ChangeState(new GameState(Games, _graphicsDevice, _content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Games.Exit();
        }


        public override void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
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
