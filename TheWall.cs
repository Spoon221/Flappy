using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBird
{
    class TheWall
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public Image wallImg;

        public TheWall(int x, int y, bool rotatedImage = false)
        {
            wallImg = new Bitmap("C:\\Users\\Евгений\\Desktop\\studio\\FlappyBird\\wall.png");
            this.x = x;
            this.y = y;
            sizeX = 120;
            sizeY = 300;
            if (rotatedImage)
                wallImg.RotateFlip(RotateFlipType.Rotate180FlipX);
        }
    }
}
