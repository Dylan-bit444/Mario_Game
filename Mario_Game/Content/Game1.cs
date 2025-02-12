using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mario_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<Vector2, int> tilemap;
        private List<Rectangle> textureStore;
        private Texture2D mapSheet;
        private Hero _hero;
        private Texture2D heroTexture;
        private int tilesize = 80;
        private Tile[,] tiles;
        private int[,] tileValuesArray;
        private Matrix _translaton;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            

        }
       


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.WindowSize = new(1024, 768);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();

            Globals.Content = Content;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            mapSheet = Content.Load<Texture2D>("Spritesheet");
            tileValuesArray = TileManager.ReadFile("tileMap.txt");
            Globals.SpriteBatch = _spriteBatch;
            heroTexture = Content.Load<Texture2D>("hero");

            // TODO: use this.Content to load your game content here
            _hero = new Hero(heroTexture, Vector2.Zero);
            tiles = TileManager.ChooseTile(tileValuesArray, mapSheet, _graphics.GraphicsDevice);
        }
        private void CalculateTranslation()
        {
            var dy = (Globals.WindowSize.X / 2) - _hero.Position.X;
            _translaton = Matrix.CreateTranslation(dy, 0,0f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Globals.Update(gameTime);
            InputManager.Update();

            // TODO: Add your update logic here
            _hero.Update();
            CalculateTranslation();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            _spriteBatch.Begin(transformMatrix: _translaton);
            foreach (Tile t in tiles)
            {
                t.Draw(_spriteBatch);
            }



            _hero.Draw();
            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
