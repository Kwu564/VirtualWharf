using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FishingTimer : MonoBehaviour {
    public float countdownValue;
    public RandomPole game;
    public GameObject CountText;

	// Use this for initialization
	void Start () {
        StartCoroutine("StartCountdown");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float currCountdownValue;
    public IEnumerator StartCountdown()
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            CountText.gameObject.GetComponent<Text>().text = ((int)currCountdownValue).ToString();
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        game.enabled = false;
        Time.timeScale = 0f;
        //yield return new WaitForSeconds(2.0f);
        //SceneManager.LoadScene("sceneOne");
        // WinnerText.SetActive(true);

    }
}
