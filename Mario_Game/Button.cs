using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_Game
{
    internal class Button
        {
            #region Fields

            private MouseState _currentMouse;

            private SpriteFont _font;

            private bool _isHovering;

            private MouseState _previousMouse;

            private Texture2D _texture;

            #endregion
            #region Properties

            public delegate void Clickes(object sender, Game1 game, ContentManager content, EventArgs e);
            public event Clickes Click;

            public bool Clicked { get; private set; }

            public Color PenColour { get; set; }

            public Vector2 Position { get; set; }

            public Rectangle Rectangle
            {
                get
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
                }
            }
            public string Text { get; set; }

            #endregion

            #region Methods

            public Button(Texture2D texture, SpriteFont font)
            {
                _texture = texture;
                _font = font;
                PenColour = Color.Black;

            }

            public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                var colour = Color.White;

                if (_isHovering)
                    colour = Color.Gray;

                spriteBatch.Draw(_texture, Rectangle, colour);
                Vector2 vec = new((Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2), (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2));

                spriteBatch.DrawString(_font, Text, vec, PenColour);
            }

            public void Update(GameTime gameTime, Game1 game, ContentManager content)
            {
                _previousMouse = _currentMouse;
                _currentMouse = Mouse.GetState();

                _isHovering = false;
                Rectangle mouseRectangle = new(_currentMouse.X, _currentMouse.Y, 1, 1);

                if (mouseRectangle.Intersects(Rectangle))
                {
                    _isHovering = true;
                    if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                    {
                        Click?.Invoke(this, game, content, new EventArgs());
                    }
                }


            }
            #endregion
        }
    }
