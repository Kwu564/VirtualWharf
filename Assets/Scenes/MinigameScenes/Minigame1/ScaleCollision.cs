using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCollision : MonoBehaviour {
    private BoxCollider2D scale;
    private int HP;
	// Use this for initialization
	void Start () {
        scale = gameObject.GetComponent<BoxCollider2D>();
        HP = (int)Random.Range(2, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Scaler>().on)
        {
            other.gameObject.GetComponent<Scaler>().rumble();
            HP--;
            if (HP <= 0)
            {
                print("Dead scale");
                other.gameObject.GetComponent<Scaler>().HP--;
                Destroy(gameObject);
            }
            print("I'm hit" + gameObject.ToString());
        }
    }

}
