using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario_Game;
using Microsoft.Xna.Framework.Input;
namespace NewStartMenu.States
{
    public class GameState : Structure
    {
        private ContentManager contentManager;

        public GameState(Game1 game, GraphicsDeviceManager _graphicsDevice, ContentManager content) : base(game, _graphicsDevice, content)
        {
            Game = game;
            graphicsDevice = _graphicsDevice;
            _content = content;
        }
           
            public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            { 
            }

            public override void PostUpdate(GameTime gameTime)
            { 
                
            }
            public override void Update(GameTime gameTime)
            {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game.ChangeState(new PauseState(Game, graphicsDevice, contentManager));
            }


        }
    }
}
