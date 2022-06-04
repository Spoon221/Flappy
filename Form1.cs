using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        Enemy enemy;
        Player bird;
        TheWall wall1;
        TheWall wall2;
        float gravity;

        public Form1()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            InitializeComponent();
            timer.Interval = 10;
            timer.Tick += new EventHandler(Update);
            Init();
            Invalidate();
        }

        public void Init()
        {
            enemy = new Enemy(340, 140);
            bird = new Player(200, 200);
            wall1 = new TheWall(500, -100, true);
            wall2 = new TheWall(500, 300);
            gravity = -0.7f;
            this.Text = "Flappy Bird Score: 0";
            timer.Start();
        }

       

        private void Update(object sender, EventArgs e)
        {
            if (bird.y > 600)
            {
                bird.Live = false;
                timer.Stop();
                Init();
            }

            if (Collide(bird, wall1) || Collide(bird, wall2) || Collision(bird, enemy))
            {
                bird.Live = false;
                timer.Stop();
                Init();
            }

            if (bird.gravityValue != 0.1f)
            {
                bird.gravityValue += 0.005f;
                enemy.y += gravity;
            }
            gravity += bird.gravityValue;
            bird.y += gravity;

            if (bird.Live)
                MoveLet();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 0;
                bird.gravityValue = -0.125f;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bird.Live)
            {
                gravity = 0;
                bird.gravityValue = -0.125f;
            }
        }

        private void CreateNewLet()
        {
            var random = new Random();
            int y;
            y = random.Next(-200, 000);
            if (wall1.x + 300 < bird.x - 50)
            {
                wall1 = new TheWall(720, y, true);
                wall2 = new TheWall(720, y + 400);
                this.Text = "Flappy Bird Score: " + ++bird.score;
            }
            if (enemy.x + 200 < bird.x - 25)
                enemy = new Enemy(720, y + 270);
        }

        private void MoveLet()
        {
            enemy.x -= 3;
            wall1.x -= 2;
            wall2.x -= 2;
            CreateNewLet();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);
            graphics.DrawImage(wall1.wallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);
            graphics.DrawImage(wall2.wallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);
            graphics.DrawImage(enemy.enemyImg, enemy.x, enemy.y, enemy.sizeX, enemy.sizeY);
        }
        private bool Collide(Player bird, TheWall wall1)
        {
            var delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (wall1.x + wall1.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (wall1.y + wall1.sizeY / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + wall1.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + wall1.sizeY / 2)
                    return true;
            }
            return false;
        }

        private bool Collision(Player bird, Enemy enemy)
        {
            var delta = new PointF();
            delta.X = (bird.x + bird.size / 3) - (enemy.x + enemy.sizeX / 3);
            delta.Y = (bird.y + bird.size / 3) - (enemy.y + enemy.sizeY / 3);
            if (Math.Abs(delta.X) <= bird.size / 3 + enemy.sizeX / 3)
            {
                if (Math.Abs(delta.Y) <= bird.size / 3 + enemy.sizeY / 3)
                    return true;
            }
            return false;
        }
        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}