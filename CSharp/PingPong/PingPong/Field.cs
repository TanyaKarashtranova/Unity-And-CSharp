using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong
{
    public class Field
    {
        public int Height;
        public int Width;
        public char Marker;

        public Field(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.Marker = '-';
        }
    }
}
