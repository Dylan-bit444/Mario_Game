using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{//Added branch - 
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;
        //private GameManager _gameManager;
        private Hero _hero;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
        }

        protected override void Initialize()
        {
            _hero = new Hero();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _hero.LoadOwnContent(Content, "Brick");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;

            //load hero
            //_spriteBatch = new SpriteBatch(GraphicsDevice);
            _hero = new Hero(_hero.Texture,
                new Vector2(_graphics.PreferredBackBufferWidth / 2 - _hero.Texture.Width / 2,
                _graphics.PreferredBackBufferHeight - _hero.Texture.Height),
            Color.White, 2.0f, new Rectangle((int)_hero.Position.X, (int)_hero.Position.Y, _hero.Texture.Width, _hero.Texture.Height));

            //_gameManager = new GameManager();
            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Globals.Update(gameTime);
            _hero.Update(_graphics);

            // TODO: Add your update logic here
            //_gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
             //_gameManager.Draw();
            _hero.Draw();
           
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
