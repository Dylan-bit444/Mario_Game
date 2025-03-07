﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Mario_Game
{
    public class States
    {
        protected Game Game;
        protected GraphicsDeviceManager GraphicsDevice;
        protected ContentManager ContentManager;
        private StateType _state;
        private List<Button> _components;


        public enum StateType 
        { 
            playGame,
            pauseGame,
            gameOver, 
            menuState
        }

        

        public void SetState(StateType inState)
        {
            if (inState == StateType.playGame)
            {
                GameState(ContentManager);   
            }

        }

        public void MenuState(ContentManager content)
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
        public States(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Button component in _components)
                component.Draw(gameTime, spriteBatch);
        }

        private void LoadGameButton_Click(object sender, Game1 game, ContentManager content, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, Game1 game, ContentManager content, EventArgs e)
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
        private void QuitGameButton_Click(object sender, Game1 game, ContentManager content, EventArgs e)
        {
            game.Exit();
        }

        public void PauseState (ContentManager content)
        {

        }

        public void EndGame (ContentManager content)
        {

        }

        public void GameState (ContentManager content)
        {

        }
    }
            
}
