using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewStartMenu.States;
using System.Windows.Forms;
using System.Text.Json;
using System.Diagnostics;
using System.IO;

namespace Mario_Game
{//Added Branch
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private PlayerStats pStats;

        private State _currentState;

        private State _nextState;

        private const string PATH = "const.Json";
        public void ChangeState(State state)
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
            pStats = new PlayerStats()
            {
                Name = "ALanna",
                Score = 37424,
                LivesLeft = 3,
            };

            // Save(pStats);

            pStats = Load();
            Trace.WriteLine($"{pStats.Name}{pStats.Score}{pStats.LivesLeft}");



            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                ChangeState(new PauseState(this, _graphics.GraphicsDevice, Content));
            }

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
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _currentState.Draw(gameTime, _spriteBatch);


            base.Draw(gameTime);
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
