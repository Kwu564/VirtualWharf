using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingCam : MonoBehaviour {
    public Transform target;
    public float smoothing;
    public Vector3 offset;
    private bool zoom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Create a postion the camera is aiming for based on the offset from the target.
        if (zoom) {
            Vector3 targetCamPos = transform.position;
            targetCamPos.z = target.position.z - 10;
            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            transform.LookAt(target);
            if(transform.position == targetCamPos)
            {
                zoom = false;
            }
        }
    }
    public void SetZoom()
    {
        zoom = true;
    }
}
