using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{   public class GameState : State
    {
        private Texture2D _playerTexture;
        private Texture2D _CoinTexture;
        private Coin _coin;
        private Hero _hero;
        private InputManager _inputManager;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);
            _playerTexture = content.Load<Texture2D>("hero-PlaceHolder");
            _CoinTexture = content.Load<Texture2D>("coin");
            _coin = new Coin(_CoinTexture, new Vector2(100, 100), Color.White, 0, new Rectangle());
            _hero = new(_playerTexture, new Vector2(500, 500), Color.White, 200f, new Rectangle(), _coin);
            _inputManager = new();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
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
            _hero.Update();
        }
    }

}


