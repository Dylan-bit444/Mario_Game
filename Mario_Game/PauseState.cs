using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game
{
    internal class PauseState
    {
        class Button
        {
            Texture2D texture;
            Vector2 position;
            Rectangle rectangle;

            Color Colour = new Color(255,255,255,255);

            bool down;
            public bool isClicked;

            public Button()
            {

            }

            public void load(Texture2D newTexture, Vector2 newPosition)
            {
                texture = newTexture;
                position = newPosition;

            }

            public void Update(MouseState mouse)
            {
                mouse = Mouse.GetState();
                rectangle = new Rectangle ((int)position.X, (int)position.Y, texture.Width, texture.Height);
                Rectangle MouseRectangle = new Rectangle (mouse.X, mouse.Y, 1,1);

                if (MouseRectangle.IntersectsWith(rectangle))
                {
                    if (Colour.A == 255) down = false;
                    if (Colour.A == 0) down = true;
                    if (down) Colour.A += 3; else Colour.A -= 3;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        isClicked = true;
                        Colour.A = 255;
                    }
                }
                else if (Colour.A < 255)
                    Colour.A += 3; 

            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(texture, rectangle, colour);

            }
        }
    }
}
