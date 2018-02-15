using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    private float x;
    float y = 0f;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        //Start the object moving.
        x = -.25f;
        rb2d.velocity = new Vector2(x, 0);
        InvokeRepeating("move",0f,.25f);
    }

    // Update is called once per frame
    void move () {
        float y = Mathf.PerlinNoise(gameObject.transform.position.x, 0f);
        y = (y * 2.0f) - 1;
        rb2d.velocity = new Vector2(x, y);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
