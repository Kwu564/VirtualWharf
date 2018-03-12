using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4Anim : MonoBehaviour {
    public int speed;
    private Quaternion original;
    private float max = 60f;
	// Use this for initialization
	void Start () {
        original = transform.rotation;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalData.FirstLoad == false)
        {
            gameObject.SetActive(false);
        }
        if (max > 0)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * speed);
            max -= Time.deltaTime * speed;
        }
        else
        {
            transform.rotation = original;
            max = 60;
        }
       
    }
}
