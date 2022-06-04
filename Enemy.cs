using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBird
{

    class Enemy
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image enemyImg;
        public Enemy(int x, int y)
        {
            enemyImg = new Bitmap("C:\\Users\\Евгений\\Desktop\\studio\\FlappyBird\\enemy.png");
            enemyImg.RotateFlip(RotateFlipType.Rotate180FlipY);
            this.x = x;
            this.y = y;
            sizeX = 27;
            sizeY = 27;
        }
    }
}
