using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Game
{
    public abstract class State
    {


        protected ContentManager _content;

        protected GraphicsDevice _graphicsDevice;

        protected Game1 Games;



        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State()
        {}

        public abstract void Update(GameTime gameTime);
    }

}
