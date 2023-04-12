using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PingPong.Players;

namespace PingPong
{
    public class Game
    {
        public Ball Ball;
        public Field Field;
        public Result Result;
        public LeftPlayer FirstPlayer;
        public RightPlayer SecondPlayer;

        public Game()
        {
        }

        public void StartGame()
        {
            DrawField(Field.Height, Field.Width, Field.Marker);
            PlacePlayerOnTheField(FirstPlayer.PositionX, FirstPlayer.PositionY, FirstPlayer.RocketLenght, FirstPlayer.Sign);
            PlacePlayerOnTheField(SecondPlayer.PositionX, SecondPlayer.PositionY, SecondPlayer.RocketLenght, SecondPlayer.Sign);
            while (true)
            {
                ClearPlayerOldPosition(FirstPlayer.PositionX, Field.Height);
                PlacePlayerOnTheField(FirstPlayer.PositionX, FirstPlayer.PositionY, FirstPlayer.RocketLenght, FirstPlayer.Sign);
                while (!Console.KeyAvailable)
                {
                    PlacePlayerOnTheField(SecondPlayer.PositionX, SecondPlayer.PositionY, SecondPlayer.RocketLenght, SecondPlayer.Sign);
                    SetBallOnTheField(Ball);
                    Thread.Sleep(50);
                    ClearBallOldPosition(Ball);
                    ClearPlayerOldPosition(SecondPlayer.PositionX, Field.Height);
                    MoveBall(Ball, Field);
                    bool needNewBall = false;
                    if (Ball.PositionX == 1)
                    {
                        if (!CheckIfTheBallReachedPlayerRocket(Ball, FirstPlayer))
                        {
                            Result.IncrementSecondPlayerResult();
                            ScoredPoint(message: "Second player win!");
                            needNewBall = true;
                            ClearMessage();
                        }
                        SwitchBallDirection(Ball);
                    }
                    if (Ball.PositionX == Field.Width - 1)
                    {
                        if (!CheckIfTheBallReachedPlayerRocket(Ball, SecondPlayer))
                        {
                            needNewBall = true;
                            ScoredPoint(message: "First player win!");
                            Result.IncrementFirstPlayerResult();
                            ClearMessage();
                        }
                        SwitchBallDirection(Ball);
                    }
                    if (needNewBall)
                    {
                        ClearBallOldPosition(Ball);
                        Ball.SetTheBallBackInTheGame(Field.Width / 2, Field.Height / 2);
                    }
                    DisplayResult(Result);
                    SecondPlayer.IsGoingDown = DefineSecondPlayerDirection();
                    MoveSecondPlayer();
                }
                MoveFirstPlayer(FirstPlayer, Field);
            }
        }

        public static void PlacePlayerOnTheField(int positionX, int positionY, int lenght, char sign)
        {
            for (int i = 0; i < lenght; i++)
            {
                Console.SetCursorPosition(positionX, (i + 1 + positionY));
                Console.Write(sign);
            }
        }

        public static void DrawField(int height, int width, char marker)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < width; i++)
            {
                Console.Write(marker);
            }
            Console.SetCursorPosition(0, height - 1);
            for (int i = 0; i < width; i++)
            {
                Console.Write(marker);
            }
        }

        public static void SetBallOnTheField(Ball ball)
        {
            Console.SetCursorPosition(ball.PositionX, ball.PositionY);
            Console.Write(ball.Sign);
        }

        public static void ClearBallOldPosition(Ball ball)
        {
            Console.SetCursorPosition(ball.PositionX, ball.PositionY);
            Console.Write(" ");
        }
      
        public static void MoveBall(Ball ball, Field field)
        {
            if (ball.IsGoingDown)
            {
                ball.PositionY++;
            }
            else
            {
                ball.PositionY--;
            }
            if (ball.IsGoingRight)
            {
                ball.PositionX++;
            }
            else
            {
                 ball.PositionX--;
            }
            if (ball.PositionY == 1 || ball.PositionY == field.Height - 1)
            {
                ball.IsGoingDown = !ball.IsGoingDown;
            }
        }

        public static void DisplayResult(Result result)
        {
            Console.SetCursorPosition(result.PositionX, result.PositionY);
            Console.Write(result.ToString());
        }

        public static bool CheckIfTheBallReachedPlayerRocket(Ball ball, Player player)
        {
            if (ball.PositionY >= (player.PositionY + 1) && ball.PositionY <= player.PositionY + player.RocketLenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SwitchBallDirection(Ball ball)
        { 
            ball.IsGoingRight = !ball.IsGoingRight;
        }

        public static void ClearPlayerOldPosition(int x, int fieldHeight)
        {
            for (int i = 1; i < fieldHeight; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(" ");
            }
        }

        public static void MoveFirstPlayer(LeftPlayer player, Field field)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (player.PositionY > 0)
                    {
                        --player.PositionY;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (player.PositionY < field.Height - player.RocketLenght - 1)
                    {
                        ++player.PositionY;
                    }
                    break;
            }
        }

        public void MoveSecondPlayer()
        {
            int limitMoves = DefineLimitPositionsForMove();
            if (Ball.IsGoingRight)
            { 
                if (SecondPlayer.IsGoingDown)
                {
                    if (SecondPlayer.PositionY < Field.Height - SecondPlayer.RocketLenght - 1)
                    {
                        ++SecondPlayer.PositionY;
                    }
                }
                else
                {
                   if (SecondPlayer.PositionY > 0 + limitMoves)
                   {
                       --SecondPlayer.PositionY;
                   }
                }
                if ((SecondPlayer.PositionY == 1 + limitMoves) || (SecondPlayer.PositionY == Field.Height - 1 - SecondPlayer.RocketLenght))
                {
                    SecondPlayer.IsGoingDown = !SecondPlayer.IsGoingDown;
                }
            }
        }

        public bool DefineSecondPlayerDirection()
        {
            if (SecondPlayer.ShouldFollowTheBall)
            {
                return Ball.IsGoingDown;
            }
            else
            {
                return !Ball.IsGoingDown;
            }
        }

        public void ScoredPoint(string message)
        {
            Console.SetCursorPosition(Field.Width / 2, Field.Height / 2);
            Console.Write(message);
            Console.ReadKey();
        }

        public void ClearMessage()
        {
            Console.SetCursorPosition(Field.Width / 2, Field.Height / 2);
            for (int i = 0; i < Field.Width; i++)
            {
                Console.Write(" ");
            }
        }

        public int DefineLimitPositionsForMove()
        {
            int maxDifficulty = 5;
            int currentDifficulty = SecondPlayer.Difficulty;
            return 2 * (maxDifficulty -currentDifficulty);
        }
    }
}
