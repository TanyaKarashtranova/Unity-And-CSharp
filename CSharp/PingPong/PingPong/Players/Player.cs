using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    public abstract class Player
    {
        public static int Lenght = 7;
        public int RocketLenght;
        public char Sign;
        public int PositionY;
        public int PositionX;

        public Player(int positionX, int positionY)
        {
            this.RocketLenght = Lenght;
            this.Sign = '|';
            this.PositionX = positionX;
            this.PositionY = positionY;
        }
    }
}
