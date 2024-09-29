using System;


namespace LittleAdventurer.Scripts.Helper;
/// <summary>
/// Hold the names of the various in-game animations
/// </summary>
public static class AnimationConsts
{
    /// <summary>
    /// Hold the names for the player animation clips
    /// </summary>
    public static class Player
    {
        /// <summary>
        /// Reference to the player attack 01 animation
        /// </summary>
        public const string ATTACK_01 = "LittleAdventurerAndie_ATTACK_01";


        /// <summary>
        /// Reference to the player attack 02 animation
        /// </summary>
        public const string ATTACK_02 = "LittleAdventurerAndie_ATTACK_02";


        /// <summary>
        /// Reference to the player attack 03 animation
        /// </summary>
        public const string ATTACK_03 = "LittleAdventurerAndie_ATTACK_03";


        /// <summary>
        /// Reference to the player airborne animation
        /// </summary>
        public const string AIR_BORNE = "LittleAdventurerAndie_Airborne";


        /// <summary>
        /// Reference to the player dead animation
        /// </summary>
        public const string DEAD = "LittleAdventurerAndie_Dead";


        /// <summary>
        /// Reference to the player hurt animation
        /// </summary>
        public const string HURT = "LittleAdventurerAndie_Hurt";


        /// <summary>
        /// Reference to the player idle animation
        /// </summary>
        public const string IDLE = "LittleAdventurerAndie_Idel";


        /// <summary>
        /// Reference to the player roll animation
        /// </summary>
        public const string ROLL = "LittleAdventurerAndie_Roll";


        /// <summary>
        /// Reference to the player running animation
        /// </summary>
        public const string RUN = "LittleAdventurerAndie_Run";


        /// <summary>
        /// Reference to the player walk animation
        /// </summary>
        public const string WALK = "LittleAdventurerAndie_Walk";
    }


    /// <summary>
    /// Hold the names for the coin animation clips
    /// </summary>
    public static class Coin
    {
        /// <summary>
        /// Reference to the coin collected animation
        /// </summary>
        public const string COLLECTED = "Collected";
    }


    /// <summary>
    /// Hold the names for the enemy animation clips
    /// </summary>
    public static class Enemy
    {
        /// <summary>
        /// Reference to the enemy <c>NPC_01_ATTACK</c> animation
        /// </summary>
        public const string ATTACK = "NPC_01_ATTACK";


        /// <summary>
        /// Reference to the enemy <c>NPC_01_DEAD</c> animation
        /// </summary>
        public const string DEAD = "NPC_01_DEAD";


        /// <summary>
        /// Reference to the enemy <c>NPC_01_HURT</c> animation
        /// </summary>
        public const string HURT = "NPC_01_HURT";


        /// <summary>
        /// Reference to the enemy <c>NPC_01_IDEL</c> animation
        /// </summary>
        public const string IDLE = "NPC_01_IDEL";


        /// <summary>
        /// Reference to the enemy <c>NPC_01_WALK</c> animation
        /// </summary>
        public const string WALK = "NPC_01_WALK";
    }
}
