using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelingScript : MonoBehaviour {
    public GameObject aim;
    public GameObject Fish;
    private Rigidbody rgbd;
    public float tolerence;
    private float y;
    public bool ReadyToReel = false;
    public float speed;
    // Use this for initialization
    private void OnEnable()
    {
        //gameObject.transform.position = aim.transform.position;
    }
    void Start () {
        rgbd = Fish.GetComponent<Rigidbody>();
        y = Random.Range(0f, 5f);
        StartCoroutine("move");
    }
	
	// Update is called once per frame
	void Update () {
        if(Fish.transform.localPosition.x - aim.transform.localPosition.x > 0)
        {
            print("Right");
        }else if(Fish.transform.localPosition.x - aim.transform.localPosition.x < 0)
        {
            print("Left");
        } 
        if(Mathf.Abs(Fish.transform.localPosition.x - aim.transform.localPosition.x) > tolerence)
        {
            print("The fish got away");
        }

        if (ReadyToReel)
        {

        }
    }
    IEnumerator move()
    {
        int currCountdownValue = 15;
        while (currCountdownValue >= 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            float x = Random.Range(-1f,1f);
            print(x);
            Vector3 move = new Vector3(x, 0, 0);
            rgbd.velocity = move * speed * Time.deltaTime;
            if (move == Vector3.zero)
            {
                rgbd.velocity = Vector3.zero;
            }
            //CountText.gameObject.GetComponent<Text>().text = ((int)currCountdownValue).ToString();
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        rgbd.velocity = Vector3.zero;
        ReadyToReel = true;

    }
}
