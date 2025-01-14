using Mario_Game;
using Mario_Game.modles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Mario_Game
{
    public class GameState : State
    {
        private Texture2D _playerTexture;
        private Texture2D _CoinTexture;
        private Coin _coin;
        private Hero _hero;
        private Button SaveButton;
        private InputManager _inputManager;
        public SaveData Saves;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content,SaveData saves)
            : base(game, graphicsDevice, content)
        {
            Saves = saves;
            Texture2D buttonTexture = _content.Load<Texture2D>("Button");
            SpriteFont buttonFont = _content.Load<SpriteFont>("File");
            SaveButton = new(buttonTexture, buttonFont)
            {
                Position = new Vector2(0, 0),
                Text = "Save",
            };
            SaveButton.Click += SaveButton_Click;
            graphicsDevice.Clear(Color.CornflowerBlue);
            _playerTexture = content.Load<Texture2D>("hero-PlaceHolder");
            _CoinTexture = content.Load<Texture2D>("coin");
            if(Saves != null)
            {
                _hero = new(_playerTexture, Saves.SavedPostion, Color.White, 200f, new Rectangle(), _coin);
            }
            else
            {
                _hero = new(_playerTexture, new Vector2(500, 500), Color.White, 200f, new Rectangle(), _coin);
            }
            _coin = new Coin(_CoinTexture, new Vector2(100, 100), Color.White, 0, new Rectangle());
            _inputManager = new();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            SaveButton.Draw(gameTime, spriteBatch);
            _coin.Draw();
            _hero.Draw();
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            _inputManager.Update();
            _coin.Update();
            SaveButton.Update(gameTime);
            _hero.Update();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            String fileName = "Save_Data.txt";
            using (StreamWriter writer = new(fileName, false))
            {
                writer.WriteLine($"{_hero.Position.X},{_hero.Position.Y}");
            }
        }
    }

}


