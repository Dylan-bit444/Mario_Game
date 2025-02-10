using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mario_Game.Button;

namespace Mario_Game
{
    public class States
    {
        protected Game Game;
        protected GraphicsDeviceManager GraphicsDevice;
        protected ContentManager ContentManager;

        public States(Game _game, GraphicsDeviceManager _graphicsDevice, ContentManager _content)
        {

        }
        static void GameState()
        {

        }

        static void PauseState()
        {

        }

        static void MenuState()
        { }
            private List<Button> _components;
        public States(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            Texture2D buttonTexture = content.Load<Texture2D>("Controls/Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("Fonts/Fonts");

            Button newGameButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(750, 250),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            Button loadGameButton = new(buttonTexture, buttonFont)
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

            _components = new List<Button>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Button component in _components)
                component.Draw(gameTime, spriteBatch);
        }

        private void LoadGameButton_Click(object? sender, Game1 game, ContentManager content, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object? sender, Game1 game, ContentManager content, EventArgs e)
        {
        }

        public void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, Game1 game, ContentManager content)
        {


            foreach (Button component in _components)
                component.Update(gameTime, game, content);


        }
        private void QuitGameButton_Click(object? sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.Exit();
        }
    }

    }
