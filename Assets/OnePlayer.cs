using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
public class OnePlayer : MonoBehaviour {

    public Animation Pole1Anim;
    public Player p1;
    // Use this for initialization
    void Start()
    {
        p1 = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        Pole1Anim["Pole1Animation"].speed = 1f;
        Pole1Anim.Play();
        if (p1.GetButton("action"))
        {
            SceneManager.LoadScene("OnePlayer");
        }
    }
    private void OnMouseExit()
    {
        Pole1Anim["Pole1Animation"].time = 0f;
        Pole1Anim.Sample();
        Pole1Anim.Stop();
    }
}
