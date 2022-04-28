using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Player
    {
        public Image Playerimg = new Bitmap("C:\\Game001\\Player\\player.png");
        public Image PlayerAttack = new Bitmap("C:\\Game001\\Player\\PlayerAttack.png");
        public float X, Y;
        public int CurFrame;
        public int AttackFrame;
        public int AttackAnimation;
        public int CurAnimation;
        public bool goRight, goLeft, jumping, attacking, watchingRight = true, isPressedAnyKey;
        public Keys lastPressedKey;
        float gravity;
        float a = 0.4f;

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Physics()
        {
            if (goRight) X += 5;
            if (goLeft) X -= 5;
            if (Y < 600 || jumping)
            {
                Y += gravity;
                gravity += a;
                if (Y > 600)
                {
                    Y = 600;
                    jumping = false;
                    if (!jumping && isPressedAnyKey == true && lastPressedKey == Keys.Space)
                    {
                        gravity = -10;
                        jumping = true;
                    }
                }
            }
        }   
        public void KeyDown(object sender, KeyEventArgs e)
        {
            isPressedAnyKey = true;
            switch (e.KeyCode)
            {
                case Keys.D:
                    goRight = true;
                    lastPressedKey = Keys.D;
                    watchingRight = true;
                    break;
                case Keys.A:
                    goLeft = true;
                    lastPressedKey = Keys.A;
                    watchingRight = false;
                    break;
                case Keys.Space:
                    jumping = true;
                    lastPressedKey = Keys.Space;
                    break;
                case Keys.E:
                    AttackFrame = 0;
                    if (!jumping) attacking = true;
                    lastPressedKey = Keys.E;
                    break;
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            isPressedAnyKey = false;
            switch (e.KeyCode)
            {
                case Keys.D:
                    goRight = false;
                    break;
                case Keys.A:
                    goLeft = false;
                    break;
            }
        }

        public void Animation()
        {
           
            if (goRight) CurAnimation = 0;
            if (goLeft) CurAnimation = 1;
            if (jumping)
            {
                if (watchingRight) CurAnimation = 4;
                else CurAnimation = 5;
                if (gravity <= 0) CurFrame = 0;
                if (gravity > 0) CurFrame = 7;    
            }
            if (!jumping && !goRight && !goLeft) CurAnimation = 2;
            if (!watchingRight && !jumping && !goLeft) CurAnimation = 3;
            
            if (attacking)
            {
                goRight = false;
                goLeft = false;
                if (!watchingRight && attacking) AttackAnimation = 1;
                else AttackAnimation = 0;
            }
        }
    }
}
