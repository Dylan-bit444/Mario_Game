using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario_Game;
using Microsoft.Xna.Framework.Input;
namespace NewStartMenu.States
{
    public class GameState : Structure
    {
        private Game1 Games;
        private GraphicsDeviceManager graphics;
        private ContentManager contentManager;

        public GameState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Games = game;
            graphics = graphicsDevice;
            contentManager = content;
        }
           
            public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            { 
            }

            public override void PostUpdate(GameTime gameTime)
            { 
            }
            public override void Update(GameTime gameTime)
            {

            
        }
    }
}
