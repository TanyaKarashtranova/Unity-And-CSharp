using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PingPong
{
   public class Ball
    {
        public int PositionX;
        public int PositionY;
        public char Sign;
        public bool IsGoingDown;
        public bool IsGoingRight;

        public Ball(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY =positionY;
            this.Sign = '0';
            this.IsGoingDown = false;
            this.IsGoingRight = false;
        }
      
        public void SetTheBallBackInTheGame(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }
   }
}
