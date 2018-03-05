using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelingScript : MonoBehaviour {
    public GameObject aim;
    private Rigidbody rgbd;
    private float y;
    public float speed;
    // Use this for initialization
    private void OnEnable()
    {
        //gameObject.transform.position = aim.transform.position;
    }
    void Start () {
        rgbd = aim.GetComponent<Rigidbody>();
        y = Random.Range(0f, 5f);
        StartCoroutine("move");
    }
	
	// Update is called once per frame
	void Update () {
        
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

    }
}
