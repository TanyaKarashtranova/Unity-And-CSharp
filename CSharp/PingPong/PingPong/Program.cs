using System;
using System.Threading;
using PingPong.Players;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select difficulty from 1 to 5 : ");
            string text = Console.ReadLine();
            int difficulty = Int32.TryParse(text, out difficulty) ? Convert.ToInt32(text) : 1;
            Field field = new Field(Console.WindowHeight, Console.WindowWidth);
            LeftPlayer firstPlayer = new LeftPlayer(0, field.Height / 2);
            RightPlayer secondPlayer = new RightPlayer(field.Width - 1, field.Height / 2, difficulty);
            Ball ball = new Ball(field.Width / 2, field.Height / 2);
            Result result = new Result(field.Width / 2, 0);
            Game game = new Game();
            game.Ball = ball;
            game.Result = result;
            game.SecondPlayer = secondPlayer;
            game.FirstPlayer = firstPlayer;
            game.Field = field;
            game.StartGame();
        }
    }
}
