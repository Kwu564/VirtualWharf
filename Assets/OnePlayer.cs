using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
public class OnePlayer : MonoBehaviour {

    public Animation Pole1Anim;
    public Player p1;
	public GameObject PressX;
    // Use this for initialization
    void Start()
    {
        p1 = ReInput.players.GetPlayer(0);
		PressX.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        Pole1Anim["Pole1Animation"].speed = 1f;
        Pole1Anim.Play();
		PressX.gameObject.SetActive (true);
        if (p1.GetButton("action"))
        {
            SceneManager.LoadScene("OnePlayer");
        }
    }
    private void OnMouseExit()
    {
		PressX.gameObject.SetActive (false);
        Pole1Anim["Pole1Animation"].time = 0f;
        Pole1Anim.Sample();
        Pole1Anim.Stop();
    }
}
