using System.Drawing;
using WinFormsApp1;

namespace Game
{
    public class Enemy
    {
        public Image IdleR = new Bitmap("C:\\Game001\\Enemy\\Idle.png");
        public Image IdleL = new Bitmap("C:\\Game001\\Enemy\\Idle.png");
        public Image AttackR = new Bitmap("C:\\Game001\\Enemy\\Attack.png");
        public Image AttackL = new Bitmap("C:\\Game001\\Enemy\\Attack.png");
        public Image WalkR = new Bitmap("C:\\Game001\\Enemy\\Walk.png");
        public Image WalkL = new Bitmap("C:\\Game001\\Enemy\\Walk.png");
        public int X, Y;
        public int curFrame;
        public float playerX;
        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
            IdleL.RotateFlip(RotateFlipType.Rotate180FlipY);
            AttackL.RotateFlip(RotateFlipType.Rotate180FlipY);
            WalkL.RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        public void EnemyMovement(Player player)
        {
            playerX = player.X;
            if (X - player.X > 0) X -= 3;
            else if (X - player.X < -200) X += 3;
        }
        public Image CurAnimation()
        {
            if (X - playerX > -70) return IdleL;
            if (X - playerX > -80) return AttackL;
            return IdleL;
        }

        public int GetFrameCount()
        {
            if ()
        }
    }
}
