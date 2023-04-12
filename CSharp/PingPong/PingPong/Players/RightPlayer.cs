using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Players
{
    public class RightPlayer : Player
    {
        public static Random r = new Random();
        public const int BaseChanceToFollowTheBall = 1;
        public bool ShouldFollowTheBall { get; private set; }
        public int Difficulty;
        public bool IsGoingDown;

        public RightPlayer(int positionX, int positionY, int difficulty) : base(positionX, positionY)
        {
            this.Difficulty = difficulty;
            SetIsFollowTheBall();
        }

        public void SetIsFollowTheBall()
        {
            int chance = r.Next(BaseChanceToFollowTheBall, this.Difficulty);
            if (chance > BaseChanceToFollowTheBall)
            {
                this.ShouldFollowTheBall = true;
            }
            else
            {
                this.ShouldFollowTheBall = false;
            }
        }
    }
}
