using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3Data {
    static public int[,] Scores = new int[2,4];
    static public string Name = "name";
    public void ClearScores()
    {
        for(int x = 0; x < 2; x++)
        {
            for(int y = 0; y < 4; y++)
            {
                Scores[x,y] = 0;
            }
        }
    }
}
