using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using System;
using SharpDX.MediaFoundation;
using Microsoft.Xna.Framework.Content;

namespace Mario_Game
{
    internal class Button
    {
        #region Fields

        private MouseState CurrentMouse;

        private SpriteFont Font;

        private MouseState PreviousMouse;

        private Texture2D Texture;

        #endregion

        #region Properties
        public delegate void Clicked(Button? sender, Game1? game, ContentManager? content, EventArgs e);

        public event Clicked Click;

        public bool Selected = false;

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

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { 
            Color colour = Color.White;
            if (Selected)
                colour = Color.Gray;

            spriteBatch.Draw(Texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                Vector2 Vec = new((Rectangle.X + (Rectangle.Width / 2)) - (Font.MeasureString(Text).X / 2),
                    (Rectangle.Y + (Rectangle.Height / 2)) - (Font.MeasureString(Text).Y / 2)+5);
                spriteBatch.DrawString(Font, Text, Vec, PenColour);
            }
        }

        public void Update(Game1 game,ContentManager? content,Hero? hero)
        {
            GamePadCapabilities gamePad = GamePad.GetCapabilities(PlayerIndex.One);
            Rectangle mouseRectangle = new(CurrentMouse.X, CurrentMouse.Y, 1, 1);
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();
            if (gamePad.IsConnected)
            {
                Click.Invoke(this, game,content,new EventArgs());
            }
            else if (mouseRectangle.Intersects(Rectangle))
            {
                Selected=true;
                if (CurrentMouse.LeftButton == ButtonState.Released && PreviousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click.Invoke(this, game, content, new EventArgs());
                }
            }
            else
            {
                Selected = false;
            }
        }

        #endregion
    }
}

