using Microsoft.Xna.Framework;
using NewStartMenu.States;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Mario_Game
{
    internal class PauseState : State
    {
        public PauseState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) :base(game, graphicsDevice, content)
        { 
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Game.Exit();
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
