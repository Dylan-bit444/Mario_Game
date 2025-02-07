using Mario_Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStartMenu.States
{
    public abstract class Structure
    {
        #region Fields

        protected ContentManager _content;

        protected GraphicsDeviceManager _graphicsDevice;

        protected Game1 Game;

        private GraphicsDeviceManager graphicsDevice;

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public Structure(Game1 game, GraphicsDeviceManager _graphicsDevice, ContentManager content)
        {
            Game = game;
            graphicsDevice = _graphicsDevice;
            _content = content;
        }

        public abstract void Update(GameTime gameTime);
        #endregion
    }
}
