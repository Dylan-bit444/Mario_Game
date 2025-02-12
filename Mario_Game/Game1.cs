using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;



namespace Mario_Game
{//Added branch - 
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private SimonHero _hero;
        private Dictionary<Vector2, int> tilemap;
        private List<Rectangle> textureStore;
        private int tileSize = 80;
        private Texture2D Spritesheet;
        private int[,] tileValuesArray;
        private Texture2D spriteSheet;
        private Tile[,] tiles;
        
 

        private Structure _currentState;

        private Structure _nextState;

        public void ChangeState(Structure state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;
            IsFixedTimeStep = false;
            _graphics.PreferredBackBufferWidth = 1950;
            _graphics.PreferredBackBufferHeight = 1100;
            _graphics.ApplyChanges();

        }
        private Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();
            StreamReader reader = new(filepath);

            int y = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        if (value > 0)
                        {
                            result[new Vector2(x, y)] = value;
                        }
                    }

                }
                y++;
            }
            return result;
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
            _hero.Update(_graphics, Time);
            foreach (Tile tile in tiles)
            {
                tile.CheckCollided(_hero);
                _hero.UpdateVelocity(_graphics, tile);
            }

           


            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime,this,Content,_graphics);
            // TODO: Add your update logic here
            //_gameManager.Update();

            base.Update(gameTime);
        }
        private Matrix Follow(SimonHero target, GraphicsDeviceManager graphics)
        {
            Matrix position = Matrix.CreateTranslation(
              -target.Position.X - (target.BoundingBox.Width / 2),
              0,
              0);

            Matrix offset = Matrix.CreateTranslation(
                graphics.PreferredBackBufferWidth / 2,
                0,
                0);


            return (position * offset);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: Follow(_hero, _graphics));
            _hero.Draw(_graphics);
            foreach (Tile t in tiles)
            {
                t.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            _currentState.Draw(gameTime, _spriteBatch, _graphics);

            base.Draw(gameTime);
        }
    }
    //Bru
}
