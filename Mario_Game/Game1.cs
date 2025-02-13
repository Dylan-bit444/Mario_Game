using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;



namespace Mario_Game
{//Added branch - 
    public class Game1 : Game
    {
        

        public Game1()
        {
            

        }
        
        
        protected override void Initialize()
        {
            _hero = new SimonHero();
            
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            base.Initialize();
        }
        protected void LoadContent(SpriteBatch SpriteBatch)
        {
            _hero.LoadOwnContent(Content, "Brick");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteBatch = _spriteBatch;

            //load hero
            _hero = new SimonHero(_hero.Texture,
                new Vector2(_graphics.PreferredBackBufferWidth / 2 - _hero.Texture.Width / 2,
                _graphics.PreferredBackBufferHeight/2/* - _hero.Texture.Height*/),
            Color.White, 2.0f, new Rectangle((int)_hero.Position.X, (int)_hero.Position.Y, _hero.Texture.Width, _hero.Texture.Height));

            tileValuesArray = TileManager.ReadFile("../../../Content/Map.txt");
            spriteSheet = Content.Load<Texture2D>("MC");

            tiles = TileManager.ChooseTile(tileValuesArray, spriteSheet, _graphics.GraphicsDevice);

            //_gameManager = new GameManager();
            // TODO: use this.Content to load your game content here
            _currentState = new MenuState(Content);
            
        }
        protected void Update(GameTime gameTime, float Time)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Update(gameTime);
            
            // TODO: Add your update logic here
            //_gameManager.Update();

            base.Update(gameTime);
        }
        private Matrix Follow(SimonHero target, GraphicsDeviceManager graphics)
        {
           
        }


        protected void Draw(GameTime gameTime, SpriteBatch _SpriteBatch)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            _spriteBatch.End();
            _currentState.Draw(gameTime, _spriteBatch, _graphics);

            base.Draw(gameTime);
        }
    }
    //Bru
}
