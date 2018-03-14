using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using Rewired;
public class SelectMode : MonoBehaviour {
	public Button OnePlayer;
	public Button TwoPlayer;
    public Player p1;
    [SerializeField] private float scrollSpeed;
    private int x = 0;
    public GameObject[] Buttons;
    // Use this for initialization
    void Awake()
    {
        p1 = ReInput.players.GetPlayer(0);
    }
    void Start () {
		OnePlayer.onClick.AddListener (ToOnePlayerMode);
		TwoPlayer.onClick.AddListener (ToTwoPlayerMode);
        InvokeRepeating("getInput", 0, scrollSpeed);
    }
	void ToOnePlayerMode(){
        SceneManager.LoadScene("OnePlayer");
    }
	void ToTwoPlayerMode(){
        SceneManager.LoadScene("PlayerJoiningScreen");
    }
	// Update is called once per frame
	void Update () {
        if (p1.controllers.joystickCount > 0)
        {
            Buttons[x].SendMessage("OnMouseOver");
        }
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i != x)
            {
                Buttons[i].SendMessage("OnMouseExit");
            }
        }
    }
    void getInput()
    {
        //float horizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
        float vertical = p1.GetAxis("Vertical");
        //print (vertical);
        if (vertical < 0f || vertical > 0f)
        {
            x = (x + 1) % Buttons.Length;
        }
        //print (x);
    }
}
