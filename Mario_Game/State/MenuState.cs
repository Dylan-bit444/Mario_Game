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
using System.Drawing;
using Microsoft.Xna.Framework.Input;

namespace NewStartMenu.States
{
    internal class MenuState : Structure
    {
        private List<Components> _components;

        public MenuState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Texture2D buttonTexture = content.Load<Texture2D>("Controls/Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("Fonts/Fonts");

            Button newGameButton = new (buttonTexture, buttonFont)
            {
                Position = new Vector2(750, 250),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            Button loadGameButton = new (buttonTexture, buttonFont)
            {
                Position = new Vector2(750, 500),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            Button quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(750, 750),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Components>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };


        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Components component in _components)
                component.Draw(gameTime, spriteBatch);
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
           Game.ChangeState(new GameState(Game, graphicsDevice,_content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            

            foreach (Components component in _components)
                component.Update(gameTime);

            
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Game.Exit();
        }

    }
}
