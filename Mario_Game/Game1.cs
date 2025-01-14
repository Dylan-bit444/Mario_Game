using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NewStartMenu.States;
using System.Windows.Forms;

namespace Mario_Game
{//Added Branch
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        bool paused = false;
        Texture2D pausedTexture;
        Rectangle pausedRectangle;
        Button btnPlay, btnQuit;


        private State _currentState;

        private State _nextState;

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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pausedTexture = Content.Load<Texture2D>("Paused");
            pausedRectangle = new Rectangle (0,0, pausedTexture.Width, pausedTexture.Height);
            btnPlay = new Button();
            btnPlay.Load(Content.Load<Texture2D>("Play"), new Vector2(350, 225));
            btnQuit = new Button();
            btnQuit.Load (Content.Load<Texture2D>("Quit"), new Vector2(350, 275));

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                PauseState();
            }

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }
            _currentState.Update(gameTime);

            MouseState mouse = Mouse.GetState();

            if(!paused)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

       
            _currentState.Draw(gameTime, _spriteBatch);

            SpriteBatch.Begin();
            if (paused)
            {
                SpriteBatch.Draw(pausedTexture, pausedRectangle, Color.White);
                btnPlay.Draw(spriteBatch);
                btnQuit.Draw(SpriteBatch);
            }


            base.Draw(gameTime);
        }
    }
}
