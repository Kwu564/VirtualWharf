using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData{
    static public int[] GlobalScore = { 0, 0 };
    static public GameObject [] players = new GameObject[2];
    static public GameObject camera;
    static public GameObject markers;
    static public bool[] moved = { false, false };
    static public bool created = false;
    static public int turn = 1;
    static public bool Wharf = true;
    static public bool CamMoving = false;
    static public List<GameObject> P1Inventory = new List<GameObject> ();
    static public int MinigameWinner = -1;
    static public List<GameObject> P2Inventory = new List<GameObject>();
    static public List<List<GameObject>> Inventory = new List<List<GameObject>> {P1Inventory,P2Inventory};
    public static bool getWharf()
    {
        return Wharf;
    }
    public static bool GetCamMoving()
    {
        return CamMoving;
    }
}
