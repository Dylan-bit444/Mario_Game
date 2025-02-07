using Mario_Game;
using Mario_Game.modles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.IO;

namespace Mario_Game
{
    internal class GameState : Structure
    {
        private Texture2D _playerTexture;
        private Texture2D _CoinTexture, flagTex;
        private Coin[] _coin = new Coin[10];
        private Hero _hero;
        private InputManager _inputManager;
        public SaveData Saves;
        private SpriteFont hudFont;
        private FireBall _fireBall;
        private Flag _flag;
        public GameState(SaveData saves,ContentManager content)  
        {
            Saves = saves;
            hudFont = content.Load<SpriteFont>("HudText");
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            Texture2D FireBallTex = content.Load<Texture2D>("fire");
            SpriteFont buttonFont = content.Load<SpriteFont>("File");
            _playerTexture = content.Load<Texture2D>("hero-PlaceHolder");
            _CoinTexture = content.Load<Texture2D>("coin");
            flagTex = content.Load<Texture2D>("Flag");
            _flag = new(flagTex, new Vector2(110, 100), Color.White, 1, 1, 1);

            _fireBall = new(FireBallTex, new Vector2(100, 1000), Color.White, 8, 1, 1, 5f);
            _fireBall.IsDraw =false;
            if (Saves != null)
            {
                _hero = new(_playerTexture, saves.Player.Position, Color.White, 200f, 8, 8, new Coin[10],_fireBall);
                _hero.CoinsCollected = saves.Player.CoinsCollected;
                _hero.Animations.LastKeyPress = saves.Player.Animations.LastKeyPress;
                for (int i = 0; i < _coin.Length; i++)
                {
                    _coin[i] = new Coin(_CoinTexture, new Vector2(100 * (i + 1), 100 * (i + 1)), Color.White, 0, 6, 1);
                    _coin[i].IsDraw = saves.Drawed[i];
                }
            }
            else
            {
                _hero = new(_playerTexture, new Vector2(1000, 1000), Color.White, 200f, 8, 8, new Coin[10],_fireBall);

                for (int i = 0; i < _coin.Length; i++)
                {
                    _coin[i] = new Coin(_CoinTexture, new Vector2(100 * (i + 1), 100 * (i + 1)), Color.White, 0, 6,1);
                }
            }
            _hero.Coins =_coin;
            _inputManager = new();
            
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Begin(transformMatrix: Follow(_hero, graphics));
            spriteBatch.DrawString(hudFont, $"Coins: {_hero.CoinsCollected}",new Vector2(1000,0),Color.White);
            foreach (Coin coin in _coin) 
            coin.Draw(spriteBatch);
            _hero.Draw(spriteBatch);
            _flag.Draw(spriteBatch);
            _fireBall.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game, ContentManager content, GraphicsDeviceManager graphics)
        {
            float time;
            time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _inputManager.Update(_hero, null,game,content);
            foreach (Coin coin in _coin) 
            coin.Update(time);
            _hero.Update(time,graphics);
            _flag.Update(game, _hero, new MenuState(content));
        }
        private Matrix Follow(Hero target, GraphicsDeviceManager graphics)
        {
            Matrix position = Matrix.CreateTranslation(
              -target.Position.X - (target.HitBox.Width / 2),
              0,
              0);

            Matrix offset = Matrix.CreateTranslation(
                graphics.PreferredBackBufferWidth / 2,
                0,
                0);


            return (position * offset );
        }
    }

}


