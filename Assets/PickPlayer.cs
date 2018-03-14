using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
public class PickPlayer : MonoBehaviour {
    public Player p1, p2;
    public bool PlayerOneIsReady, PlayerTwoIsReady;
    public GameObject card1, card2;
    // Use this for initialization
    void Start () {
        PlayerOneIsReady = false;
        PlayerTwoIsReady = false;
        p1 = ReInput.players.GetPlayer(0);
        p2 = ReInput.players.GetPlayer(1);
    }
	void check()
    {
        if (PlayerOneIsReady)
        {
            card1.SetActive(true);
            print("Player One is Ready!");
        }
        else if (!PlayerOneIsReady)
        {
            card1.SetActive(false);
            print("Player One is Not Ready!");
        }

        if (PlayerTwoIsReady)
        {
            card2.SetActive(true);
            print("Player One is Ready!");
        }
        else if (!PlayerTwoIsReady)
        {
            card2.SetActive(false);
            print("Player One is Not Ready!");
        }
        if (PlayerTwoIsReady && PlayerOneIsReady)
        {
            SceneManager.LoadScene("Intro");
        }
    }
	// Update is called once per frame
	void Update () {
        if (p1.GetButtonDown("ready"))
        {
            PlayerOneIsReady = !PlayerOneIsReady;
        }
        if (p2.GetButtonDown("ready"))
        {
            PlayerTwoIsReady = !PlayerTwoIsReady;
        }
        check();
    }
}
