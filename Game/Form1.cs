using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Player player = new Player(100, 200);
        World world = new World();
        Enemy enemy = new Enemy(400, 528);
        
        public Form1()
        {    
            InitializeComponent();
            pictureBox1.Image = world.Ground;
            timer1.Interval = 70;
            timer1.Tick += (s, e) => UpdateAnimation();
            timer1.Start();
            UpdatePhysics();
            UpdateAttackAnimation();
 
            KeyDown += new KeyEventHandler(player.KeyDown);
            KeyUp += new KeyEventHandler(player.KeyUp);
        }
        
        private void UpdateAnimation()
        {
            if (enemy.curFrame == enemy.GetFrameCount()) enemy.curFrame = 0;
            enemy.curFrame++;
            if (player.CurFrame == 7) player.CurFrame = 0;
            player.CurFrame++;
            player.Animation();
        }

        private void UpdatePhysics()
        {
            timer2.Interval = 1;
            timer2.Tick += (s, e) => 
            {
                enemy.EnemyMovement(player);
                player.Physics();
                Invalidate();
            };
            timer2.Start();
        }
        private void UpdateAttackAnimation()
        {
            timer3.Interval = 100;
            timer3.Tick += (s, e) =>
            {
                if (player.AttackFrame == 2)
                {
                    player.AttackFrame = 0;
                    player.attacking = false;
                }
                player.AttackFrame++;
                Invalidate();
            };
            timer3.Start();
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(world.BackGround, 0, 0, new Rectangle(new Point(0, 0), new Size(1600, 900)), GraphicsUnit.Pixel);
            g.DrawImage(enemy.CurAnimation(), enemy.X, enemy.Y, new Rectangle(new Point(300 * enemy.curFrame, 0), new Size(300, 300)), GraphicsUnit.Pixel);  
            if (player.attacking)
                g.DrawImage(
                    player.PlayerAttack,
                    player.X - 170,
                    player.Y - 70,
                    new Rectangle(new Point(500 * player.AttackFrame, 200 * player.AttackAnimation),
                    new Size(500, 200)),
                    GraphicsUnit.Pixel);
            else g.DrawImage(
                player.Playerimg,
                player.X,
                player.Y,
                new Rectangle(new Point(110 * player.CurFrame, 130 * player.CurAnimation),
                new Size(110, 130)),
                GraphicsUnit.Pixel);
        }
        
    }
    
}