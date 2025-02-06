using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario_Game;
using System.Drawing;
using Microsoft.VisualBasic.Devices;

namespace NewStartMenu.States
{
    public class GameState : Structure
    {

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                Game.ChangeState(new PauseState(game, graphicsDevice, content));
            }
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
