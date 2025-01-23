﻿using Mario_Game;
using Mario_Game.modles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Mario_Game
{
    internal class GameState :Structure
    {
        private Texture2D _playerTexture;
        private Texture2D _CoinTexture;
        private Coin[] _coin = new Coin[10];
        private Hero _hero;
        private InputManager _inputManager;
        public SaveData Saves;
        private SpriteFont hudFont;
        private Game1 GameOne;
        private ContentManager _contentManager;
        public GameState(SaveData saves,ContentManager content,Game1 game)  
        {
            _contentManager = content;
            Saves = saves;
            GameOne = game;
            hudFont = content.Load<SpriteFont>("HudText");
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            SpriteFont buttonFont = content.Load<SpriteFont>("File");
            _playerTexture = content.Load<Texture2D>("hero-PlaceHolder");
            _CoinTexture = content.Load<Texture2D>("coin");
            if(Saves != null)   
            {
                _hero = new(_playerTexture, saves.Hero.Position, Color.White, 200f, new Coin[10]);
                _hero.CoinsCollected = saves.Hero.CoinsCollected;
                _hero.Animations.LastKeyPress = saves.Hero.Animations.LastKeyPress;
            }
            else
            {
                _hero = new(_playerTexture, new Vector2(1000, 1000), Color.White, 200f,new Coin[10]);
            }
            for (int i = 0; i < _coin.Length; i++)
            {
                _coin[i] = new Coin(_CoinTexture, new Vector2(100*(i+1), 100*(i+1)), Color.White, 0);
            }
            _hero.Coins =_coin;
            _inputManager = new();
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(hudFont, $"Coins: {_hero.CoinsCollected}",new Vector2(1000,0),Color.White);
            foreach (Coin coin in _coin) 
            coin.Draw(spriteBatch);
            _hero.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            float time;
            time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _inputManager.Update(_hero, null,GameOne,_contentManager);
            foreach (Coin coin in _coin) 
            coin.Update(time);
            _hero.Update(time);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            String fileName = "Save_Data.txt";
            using (StreamWriter writer = new(fileName, false))
            {
                writer.WriteLine($"{_hero.Position.X},{_hero.Position.Y},{_hero.Animations.LastKeyPress.X},{_hero.Animations.LastKeyPress.Y},{_hero.CoinsCollected}");
            }
        }
    }

}


