using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;


namespace Mario_Game
{
    internal class GameManager
    {
        private Hero _hero;
        private Coin _coin;
        private Texture2D _playerTexture;
        private Texture2D _CoinTexture;
        private InputManager _inputManager;
        public void Init(ContentManager content)
        {
            _playerTexture = content.Load<Texture2D>("hero-PlaceHolder");
            _CoinTexture = content.Load<Texture2D>("coin");
            _hero = new(_playerTexture,new Vector2(500,500),Color.White,200f,new Rectangle(),_coin);
            _coin = new Coin(_CoinTexture,new Vector2(100,100),Color.White,0,new Rectangle());
            _inputManager = new();
        }
        public void Update()
        {
            _inputManager.Update();
            _coin.Update();
            _hero.Update();
        }
        public void Draw()
        {
            _coin.Draw();
            _hero.Draw();
        }
    }
}
