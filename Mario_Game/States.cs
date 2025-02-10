using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game
{
    public class States
    {
        protected ContentManager content;

        protected GraphicsDeviceManager graphicsDevice;

        protected Game1 Game;
        public States(Game1 _game,GraphicsDeviceManager _graphicsDevice,ContentManager _content)
        {
            Game = _game;
            graphicsDevice = _graphicsDevice;
            content = _content;
        }
        static void GameState()
        {
            

        }

        static void PauseState()
        {

        }

        static void MenuState()
        {

        }
    }
}
