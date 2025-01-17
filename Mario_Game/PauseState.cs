using Microsoft.Xna.Framework;
using NewStartMenu.States;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using NewStartMenu;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using NewStartMenu.Controls;
using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace Mario_Game
{
    internal class PauseState : State
    {
        private List<Components> _components;

        private string savedData;
        private int xCoordinate, yCoordinate;
        public PauseState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
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
            spriteBatch.Begin();

            foreach (Components component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void LoadMenuButton_Click(object sender, EventArgs e)
        {
            Game.ChangeState(new MenuState(Game,_graphicsDevice,_content));
        }

        private void PlayGameButton_Click(object sender, EventArgs e)
        {
            Game.ChangeState(new GameState(Game, _graphicsDevice, _content));
        }

        private void SaveGameButton_Click(object sender, EventArgs e)
        {

            TextWriter tw = new StreamWriter("Saved");

            tw.WriteLine(xCoordinate);
            tw.WriteLine(yCoordinate);
            

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
