using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Minigame : MonoBehaviour {
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        
    }
    public void enterGame()
    {
        int turn = GlobalData.turn;
        //print((turn+1)% 2);
        print( (turn%2));
        GlobalData.camera.GetComponent<CameraFollow>().target = GlobalData.players[(turn+1)% 2].transform;
        GlobalData.players[(turn+1) % 2].GetComponent<TileMove>().enabled = true;
        GlobalData.players[turn % 2].GetComponent<TileMove>().enabled = false;
        GlobalData.players[0].SetActive(false);
        GlobalData.players[1].SetActive(false);
        GlobalData.camera.SetActive(false);
        SceneManager.LoadScene("MPGame1");

    }
}
