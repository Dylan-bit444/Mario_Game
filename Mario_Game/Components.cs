using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NewStartMenu
{
    public abstract class Components
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
