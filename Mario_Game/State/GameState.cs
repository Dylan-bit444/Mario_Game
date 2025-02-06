using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario_Game;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
namespace NewStartMenu.States
{
    public class GameState : Structure
    {
        private Game1 Games;
        private GraphicsDevice graphics;
        private ContentManager contentManager;

        public bool HitLeft { get; set; }
        public bool HitRight { get; set; }

        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public float Velocity { get; set; }
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
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

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Games.ChangeState(new PauseState(Games, graphics, contentManager));
            }
            if (Position.X + Texture.Width >= graphics.PreferredBackBufferWidth)
            {
                HitRight = true;
                HitLeft = false;
            }

            if (Position.X <= 0)
            {
                HitRight = false;
                HitLeft = true;
            }

            if (HitRight)
            {
                Velocity -= 1;
            }
            if (HitLeft)
            {
                Velocity += 1;
            }
        }
    }
}
