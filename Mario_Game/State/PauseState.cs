using Microsoft.Xna.Framework;
using NewStartMenu.States;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using NewStartMenu;
using System.Collections.Generic;
using NewStartMenu.Controls;
using System;
using System.IO;
using System.Collections;

namespace Mario_Game
{
    internal class PauseState : Structure
    {
        private List<Components> _components;


        public PauseState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            Texture2D buttonTexture = content.Load<Texture2D>("Controls/Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("Fonts/Fonts");

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Button playGameButton = new(buttonTexture, buttonFont)
                {
                    Position = new Vector2(750, 250),
                    Text = "Continue Game",
                };
                playGameButton.Click += PlayGameButton_Click;


                Button saveGameButton = new(buttonTexture, buttonFont)
                {
                    Position = new Vector2(750, 500),
                    Text = "Save Game",
                };
                saveGameButton.Click += SaveGameButton_Click;

                Button loadMenuButton = new Button(buttonTexture, buttonFont)
                {
                    Position = new Vector2(750, 750),
                    Text = "Menu",
                };
                loadMenuButton.Click += LoadMenuButton_Click;

                _components = new List<Components>()
                {
                    playGameButton,
                    saveGameButton,
                    loadMenuButton
                };
            }
        }
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {       
            foreach (Components component in _components)
                component.Draw(gameTime, spriteBatch);
        }

        private void LoadMenuButton_Click(object sender, EventArgs e)
        {
            Game.ChangeState(new MenuState(Game, graphicsDevice,_content));

            TextReader tr = new StreamReader("Saved.txt");

            string xCoordinate = tr.ReadLine();
            string yCoordinate = tr.ReadLine();
            string ve = tr.ReadLine();

            tr.Close();
        }

        private void PlayGameButton_Click(object sender, EventArgs e)
        {
            Game.ChangeState(new GameState(Game, graphicsDevice, _content));
        }

        private void SaveGameButton_Click(object sender, EventArgs e)
        {

            Game.ChangeState(new PauseState(Game, graphicsDevice, _content));
            
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

    }
}
