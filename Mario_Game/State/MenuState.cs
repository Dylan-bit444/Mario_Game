using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using NewStartMenu.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Mario_Game;

namespace NewStartMenu.States
{
    internal class MenuState : State
    {
        private List<Components> _components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D buttonTexture = content.Load<Texture2D>("Controls/Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("Fonts/Fonts");

            Button newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            Button loadGameButton = new Button (buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Game",
            };

            loadGameButton.Click += loadGameButton_Click;

            Button quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit",
            };

            quitGameButton.Click += quitGameButton_Click;

            _components = new List<Components>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton
            };


        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Components component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void loadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
           _game.ChangeState(new GameState(_game,_graphicsDevice,_content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Components component in _components)
                component.Update(gameTime);
        }
        private void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
