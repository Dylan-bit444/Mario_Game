using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Mario_Game
{
    public abstract class Structure
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics);

        public abstract void Update(GameTime gameTime,Game1 game, ContentManager content, GraphicsDeviceManager graphics);
    }
}
