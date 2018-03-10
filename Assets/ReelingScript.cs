using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class ReelingScript : MonoBehaviour {
    public GameObject aim;
    public GameObject Fish;
    private Rigidbody rgbd,AimBody;
    public float tolerence;
    private float y;
    public bool ReadyToReel = false;
    public float speed;
    public Rewired.Player player;
    public int id;
    // Use this for initialization
    private void OnEnable()
    {
        //gameObject.transform.position = aim.transform.position;
    }
    private void Awake()
    {
        gameObject.transform.position = aim.transform.position;
    }
    void Start () {
        player = ReInput.players.GetPlayer(id);
        rgbd = Fish.GetComponent<Rigidbody>();
        AimBody = aim.GetComponent<Rigidbody>();
        y = Random.Range(0f, 5f);
        StartCoroutine("move");
    }
	
	// Update is called once per frame
	void Update () {
        float x = player.GetAxis("AimX");
        Vector3 move = new Vector3(x, 0, 0);
        AimBody.velocity = move * (speed*1.5f) * Time.deltaTime;
        if (move == Vector3.zero)
        {
            AimBody.velocity = Vector3.zero;
        }
        if (Fish.transform.localPosition.x - aim.transform.localPosition.x > 0 && Mathf.Abs(Fish.transform.localPosition.x - aim.transform.localPosition.x)>.25f*tolerence)
        {
            print("Right");
            //float motorLevel = 1.00f; // full motor speed
            float motorLevel = 2.00f * Mathf.Abs(Fish.transform.localPosition.x - aim.transform.localPosition.x) / tolerence;
            //float duration = .05f; // 2 seconds
            player.SetVibration(1, motorLevel);
            player.SetVibration(0, 0);

        }
        else if(Fish.transform.localPosition.x - aim.transform.localPosition.x < 0 && Mathf.Abs(Fish.transform.localPosition.x - aim.transform.localPosition.x) > .25f * tolerence)
        {
            print("Left");
            float motorLevel = 2.00f * Mathf.Abs(Fish.transform.localPosition.x - aim.transform.localPosition.x)/tolerence;
            player.SetVibration(1, 0);
            player.SetVibration(0, motorLevel);
            /*float motorLevel = 1.00f; // full motor speed
            float duration = .05f; // 2 seconds
            player.SetVibration(1, motorLevel, duration);*/
        }
        else
        {
            player.SetVibration(0, 0);
            player.SetVibration(1, 0);
        }
        if(Mathf.Abs(Fish.transform.localPosition.x - aim.transform.localPosition.x) > tolerence)
        {
            print("The fish got away");
        }

        
    }
    IEnumerator move()
    {
        int currCountdownValue = 30;
        while (currCountdownValue >= 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            float x = Random.Range(-.75f,.75f);
            print(x);
            Vector3 move = new Vector3(x, 0, 0);
            rgbd.velocity = move * speed * Time.deltaTime;
            if (move == Vector3.zero)
            {
                rgbd.velocity = Vector3.zero;
            }
            if (Fish.transform.localPosition.x - aim.transform.localPosition.x > 0)
            {
                print("Right");
                float motorLevel = 1.00f; // full motor speed
                //float duration = .05f; // 2 seconds
                //player.SetVibration(0, motorLevel);

            }
            else if (Fish.transform.localPosition.x - aim.transform.localPosition.x < 0)
            {
                print("Left");
                /*float motorLevel = 1.00f; // full motor speed
                float duration = .05f; // 2 seconds
                player.SetVibration(1, motorLevel, duration);*/
            }
            //CountText.gameObject.GetComponent<Text>().text = ((int)currCountdownValue).ToString();
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        rgbd.velocity = Vector3.zero;
        ReadyToReel = true;
        yield return null;
    }
}
