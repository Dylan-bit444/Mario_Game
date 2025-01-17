//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//namespace Mario_Game
//{
//    public class GameManager
//    {


//        private Hero _hero;

//        public GameManager()
//        {
//            _hero = new Hero(Globals.Content.Load<Texture2D>("Brick"), new(Globals.WindowSize.X / 2, 200), Color.White, 1f,new Rectangle());
//            _hero.BoundingBox= new Rectangle((int)_hero.Position.X,(int) _hero.Position.Y,_hero.Texture.Width,_hero.Texture.Height);

//        }
//        public void Update()
//        {

//            _hero.Update();
//        }
//        public void Draw()
//        {

//            Globals.SpriteBatch.Begin();
//            _hero.Draw();
//            Globals.SpriteBatch.End();

//        }
//    }
//}
//+		Color.White	255  255  255  255	Microsoft.Xna.Framework.Color
