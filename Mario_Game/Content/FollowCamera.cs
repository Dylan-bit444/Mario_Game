using Microsoft.Xna.Framework;
namespace Mario_Game

{
    public class FollowCamera
    {
        public Vector2 position;
        public FollowCamera(Vector2 position)
        {
            this.position = position;
        }
        public void Follow(Rectangle target, Vector2 screensize)
        {
            position = new Vector2(
                -target.X + (screensize.X/2 - target.Width /2),
                -target.Y + (screensize.Y/2 - target.Height /2)
                );
        }
            

    }
}
