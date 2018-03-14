using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroCamera : MonoBehaviour {
    public Transform Target;
    private Transform Origin;
    public Text IntroText;
    public float speed;
    private bool StartZoom = false;
	// Use this for initialization
	void Start () {
        Origin = gameObject.transform;
        StartCoroutine("Intro");
	}
	
	// Update is called once per frame
	void Update () {
        if (StartZoom)
        {
            transform.position = Vector3.Lerp(Origin.position, Target.position, speed * Time.deltaTime);
        }
    }
    private bool NearTarget()
    {
        return Vector3.Distance(transform.position,Target.position)<1f;
    }
    IEnumerator Intro()
    {
        yield return new WaitForSecondsRealtime(2f);
        IntroText.text = "Visit each attraction to earn trophies!";
        yield return new WaitForSecondsRealtime(2f);
        IntroText.text = "The player with the most trophies at the end wins.";
        yield return new WaitForSecondsRealtime(1.5f);
        StartZoom = true;
        yield return new WaitForSecondsRealtime(1.25f);
        IntroText.text = "";
        yield return new WaitUntil(NearTarget);
        SceneManager.LoadSceneAsync("sceneOne");
        yield return null;
    }
}
