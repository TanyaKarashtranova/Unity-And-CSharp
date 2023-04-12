using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    public class Result
    {
        public int FirstPlayerResult;
        public int SecondPlayerResult;
        public int PositionX;
        public int PositionY;

        public Result(int positionX, int positionY)
        {
            this.FirstPlayerResult = 0;
            this.SecondPlayerResult = 0;
            this.PositionX = positionX;
            this.PositionY =positionY;
        }

        public void IncrementSecondPlayerResult()
        {
            this.SecondPlayerResult++;
        }

        public void IncrementFirstPlayerResult()
        {
            this.FirstPlayerResult++;
        }

        public override string ToString()
        {
            return $"{this.FirstPlayerResult} | {this.SecondPlayerResult}";
        }
    }
}
