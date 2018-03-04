using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3Data {
    static public int[,] Scores = new int[2,4];
    static public string Name = "name";
    static public int[,] Checked = new int[2,4];
    static public int round = 0;
    //static public int round = 0;
    static public bool[,] perfect = new bool[2,4];
    public void clear()
    {
        for(int x = 0; x < 2; x++)
        {
            for(int y = 0; y < 4; y++)
            {
                Scores[x,y] = 0;
                Checked[x, y] = 0;
                perfect[x, y] = false;
            }
        }
        //round = 0;
    }
}
