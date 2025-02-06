using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewStartMenu.States;
using System.Text.Json;
using System.Diagnostics;
using System.IO;



namespace Mario_Game
{//Added Branch
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private Structure _currentState;

        private Structure _nextState;

        private Texture2D _objectTexture;

        private Object _object;

        private const string PATH = "const.Json";
        public void ChangeState(Structure state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 2000;
            _graphics.PreferredBackBufferHeight = 2000;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {

            IsMouseVisible = true; 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _objectTexture = Content.Load<Texture2D>("Ball");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);

            _object = new Object(_objectTexture, new Vector2 (_graphics.PreferredBackBufferWidth / 2 - _objectTexture.Width / 2, _graphics.PreferredBackBufferHeight / 2 - _objectTexture.Height), Color.White, 2f, new Rectangle());
        }
        
        protected override void Update(GameTime gameTime)
        {
            

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }
            _currentState.Update(gameTime);

            MouseState mouse = Mouse.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);


            _currentState.Draw(gameTime, _spriteBatch);

            _object.Draw(_spriteBatch);


            base.Draw(gameTime);

            _spriteBatch.End();
        }

        private void Save(PlayerStats stats)
        {
            string serializedText = JsonSerializer.Serialize<PlayerStats>(stats);
            Trace.WriteLine(serializedText);
            File.WriteAllText(PATH , serializedText);
        }

        private PlayerStats Load()
        {
            var fileContents = File.ReadAllText(PATH);
            return JsonSerializer.Deserialize<PlayerStats>(fileContents);

        }
        TextWriter tw = new StreamWriter("SavedGame");
    }
}
