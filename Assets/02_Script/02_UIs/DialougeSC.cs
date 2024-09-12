using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeSC
{
    public static List<string> mapNavigatorLog = new List<string>();

    public static string map1String0, map1String1, map1String2, map1String3;
    void Start() { }

    private void SetsTring(sbyte curMap)
    {
        switch (curMap)
        {
            case 0:
                break;
            case 1: //Map 1
                mapNavigatorLog.Add(map1String0);
                mapNavigatorLog.Add(map1String1);
                mapNavigatorLog.Add(map1String2);
                mapNavigatorLog.Add(map1String3);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;

        }
    }
    private void DefineStringEng()
    {
        map1String0 = "Morning Mister, after a long period of training, this day has come, your graduate are waiting";
        map1String1 = "I wish all the best for you";
        map1String2 = "Congratulation Mister, look like you have past you examination and able to rolling out to battlefield";
        map1String3 = "Let’s waiting for next assignment, in the meantime, you can stop by Armory to take a look on your new friend";
    }
}
