using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using System;
using SharpDX.MediaFoundation;

namespace Mario_Game
{
    public class Button : Structure
    {
        #region Fields

        private MouseState CurrentMouse;

        private SpriteFont Font;

        private MouseState PreviousMouse;

        private Texture2D Texture;

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            Texture = texture;

            Font = font;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            CurrentMouse = Mouse.GetState();
            Rectangle mouseRectangle = new(CurrentMouse.X, CurrentMouse.Y, 1, 1);
            Color colour = Color.White;
            if (mouseRectangle.Intersects(Rectangle))
                colour = Color.Gray;

            spriteBatch.Draw(Texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                Vector2 Vec = new((Rectangle.X + (Rectangle.Width / 2)) - (Font.MeasureString(Text).X / 2),
                    (Rectangle.Y + (Rectangle.Height / 2)) - (Font.MeasureString(Text).Y / 2)+5);
                spriteBatch.DrawString(Font, Text, Vec, PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle mouseRectangle = new(CurrentMouse.X, CurrentMouse.Y, 1, 1);
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();
            if (mouseRectangle.Intersects(Rectangle))
            {
                if (CurrentMouse.LeftButton == ButtonState.Released && PreviousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}

