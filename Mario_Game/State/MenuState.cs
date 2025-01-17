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
        private Game1 GameOne;
        private ContentManager ContentManagers;
        private InputManager Input;
        public MenuState(Game1 game1,ContentManager content) : base()
        {
            ContentManagers = content; 
            GameOne = game1;
            Input = new();
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

            Components = new List<Structure>()
      {
        newGameButton,
        loadGameButton,
        quitGameButton,
      };
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
            GamePadCapabilities gamePad = GamePad.GetCapabilities(PlayerIndex.One);
            if (!gamePad.IsConnected)
            {
                foreach (Structure component in Components)
                    component.Update(gameTime);
        }
            else
            {
                Input.ControlerMenu(Components, gamePad);
            }
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
