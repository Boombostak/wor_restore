using UnityEngine;
using System.Collections;

public class ExperienceTable : MonoBehaviour {

    public static int[] xp_for_level_i = new int[20];//level is index, xp is value.

    void Awake()
    {
        xp_for_level_i[0] = 0;
        xp_for_level_i[1] = 2000;
        xp_for_level_i[2] = 4620;
        xp_for_level_i[3] = 8040;
        xp_for_level_i[4] = 12489;
        xp_for_level_i[5] = 18258;
        xp_for_level_i[6] = 25712;
        xp_for_level_i[7] = 35309;
        xp_for_level_i[8] = 47622;
        xp_for_level_i[9] = 63364;
        xp_for_level_i[10] = 83419;
        xp_for_level_i[11] = 108879;
        xp_for_level_i[12] = 141086;
        xp_for_level_i[13] = 181683;
        xp_for_level_i[14] = 231075;
        xp_for_level_i[15] = 313656;
        xp_for_level_i[16] = 424067;
        xp_for_level_i[17] = 571190;
        xp_for_level_i[18] = 766569;
        xp_for_level_i[19] = 1025154;
    }
}
