using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;
public class TwoPlayer : MonoBehaviour {
    public Animation Pole1Anim;
    public Animation Pole2Anim;
    public Player p1;
    // Use this for initialization
    void Start () {
        p1 = ReInput.players.GetPlayer(0);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnMouseOver()
    {
        Pole1Anim["Pole1Animation"].speed = 1f;
        Pole1Anim.Play();
        Pole2Anim["Pole1Animation"].speed = 1f;
        Pole2Anim.Play();
        if (p1.GetButton("action"))
        {
            SceneManager.LoadScene("PlayerJoiningScreen");
        }
    }
    private void OnMouseExit()
    {
        Pole1Anim["Pole1Animation"].time = 0f;
        Pole1Anim.Sample();
        Pole1Anim.Stop();
        Pole2Anim["Pole1Animation"].time = 0f;
        Pole2Anim.Sample();
        Pole2Anim.Stop();
    }
}
