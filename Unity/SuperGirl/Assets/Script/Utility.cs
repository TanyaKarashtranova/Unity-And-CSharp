using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    public abstract class Utility
    {
        public const string IsJumping = "isJumping";
        public const string IsWalking = "isWalking";
        public const string IsSwimming = "isSwimming";
        public const string IsBlinking = "isBlinking";
        public const string IsClimbing = "isClimbing";
        public const string DyingTrigger = "Dying";
        public const string ShootingTrigger = "Shooting";


        public const string PlatformLayer = "Platform";
        public const string WaterLayer = "Water";
        public const string LadderLayer = "Ladder";
        public const string EnemyLayer = "Enemy";
        public const string PlayerLayer = "Player";
        public const string HazardLayer = "Hazard";
        public const string BulletLayer = "Bullet";
        public const string BouncingLayer = "Bounce";

        public const string IsBee = "isBee";
        public const string DyingBeeTrigger = "BeeDying";
        public const string DyingHedgehogTrigger = "HedgehogDying";

        public const string PlayerTag = "Player";
        public const string EnemyTag = "Enemy";
        public const string BulletTag = "Bullet";
        

    }
}
