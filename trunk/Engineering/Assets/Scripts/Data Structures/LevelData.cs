using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelData
{
    public enum LEVEL_NUM
    {
        INVALID_LVL = 0,

        LV_01 = 1 << 1,
        LV_02 = 1 << 2,
        LV_03 = 1 << 3,
        LV_04 = 1 << 4,
        LV_05 = 1 << 5,
        LV_06 = 1 << 6,
        LV_07 = 1 << 7,
        LV_08 = 1 << 8,
        LV_09 = 1 << 9,
        LV_10 = 1 << 10,
        LV_11 = 1 << 11,
        LV_12 = 1 << 12,
        LV_13 = 1 << 13,
        LV_14 = 1 << 14,
        LV_15 = 1 << 15,

        NUM_LEVELS = 1 << 16
        //uint32 will do for this
    };

    public enum Weapon
    {
        None,
        Sniper,
        Assualt,

        Num_Weapons
    };


    public class Level
    {
        public float speed = 0f;
        public string name = string.Empty;
        public short noOfCharacters = 0;
        public string pathOfLandmark = string.Empty;
        public Weapon weapon = Weapon.None;

        public Level()
        {

        }
    }
}
