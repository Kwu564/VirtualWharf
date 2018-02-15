using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData{
    static public int score = 0;
    static public GameObject [] players = new GameObject[2];
    static public GameObject camera;
    static public GameObject markers;
    static public bool created = false;
    static public int turn = 1;
}
