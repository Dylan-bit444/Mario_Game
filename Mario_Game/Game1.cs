using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System;
using Mario_Game.State;



namespace Mario_Game
{//Added branch - 
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
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
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tileValuesArray = TileManager.ReadFile("../../../Content/Map.txt");
            spriteSheet = Content.Load<Texture2D>("MC");

            tiles = TileManager.ChooseTile(tileValuesArray, spriteSheet, _graphics.GraphicsDevice);

            //_gameManager = new GameManager();
            // TODO: use this.Content to load your game content here
            _currentState = new MenuState(Content);
            
        }
        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime,this,Content,_graphics);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (Tile t in tiles)
            {
                t.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            _currentState.Draw(gameTime, _spriteBatch, _graphics);

            base.Draw(gameTime);
        }
    }
}
