using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBird
{
    

    class Player
    {
        public float x;
        public float y;
        public int size;
        public int score;
        public float gravityValue;
        public Image birdImg;
        public bool Live;

        public Player(int x,int y)
        {
            birdImg = new Bitmap("C:\\Users\\Евгений\\Desktop\\studio\\FlappyBird\\bird.png");
            this.x = x;
            this.y = y;
            size = 22;
            gravityValue = 0f;
            Live = true;
            score = 0;
        }
    }
}
