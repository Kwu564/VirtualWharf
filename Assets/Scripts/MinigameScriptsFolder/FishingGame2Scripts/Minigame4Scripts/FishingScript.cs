using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class FishingScript : MonoBehaviour {
	public bool casted;
	public bool FishIsOnLine;
	public bool CatchingOneFishAtATime;
	public bool FishIsCaught;
	public bool StillFishing;
    public GameObject aim;
    public int id;
    public Rewired.Player player;
    private Rigidbody rgbd;
    public float speed,zMod;
    public GameObject cam;
    public Vector3 lastPosition;
    public int BaitTime = 5;
    public float minScreenBoundsx, maxScreenBoundsy, minScreenBoundsy, maxScreenBoundsx;
    public GameObject fish;
    // Use this for initialization
    void Start () {
        Random.seed = System.Environment.TickCount;
        BaitTime = Random.Range(3, 6);
        print(BaitTime);
        player = ReInput.players.GetPlayer(id);
        rgbd = aim.GetComponent<Rigidbody>();
        casted = false;
		CatchingOneFishAtATime = false;
		FishIsOnLine = false;
		FishIsCaught = false;
		StillFishing = false;
        lastPosition = aim.transform.position;

	}
	IEnumerator WaitForFishToBeCaughtOnLine(){
		//FishIsOnLine = true;
		print ("Wait for it...");
		yield return new WaitForSeconds (BaitTime);
        float motorLevel = 1.00f; // full motor speed
        float duration = 1.1f; // 2 seconds
        if (casted)
        {
            print("Fish is on the line!");
            FishIsOnLine = true;
            player.SetVibration(0, motorLevel, duration);
            player.SetVibration(1, motorLevel, duration);
        }
		
        yield return new WaitForSeconds(1.5f);
        if (!FishIsCaught && casted)
        {
            FishIsOnLine = false;
            casted = false;
            print("Fish got away");
        }
        
	}
	void CheckIfMousePressed(){
		if (Input.GetMouseButtonDown (0)) {
			casted = !casted;
			FishIsOnLine = false;
			FishIsCaught = false;
			if (casted) {
				print ("Casted");
				//FishIsOnLine = false;
				StartCoroutine ("WaitForFishToBeCaughtOnLine");
				FishIsCaught = false;
			} else if (!casted) {
				print ("Not casted");
				StopCoroutine ("WaitForFishToBeCaughtOnLine");
				StillFishing = false;
				FishIsOnLine = false;
				FishIsCaught = false;
			}
		}
		if (Input.GetKeyDown("space") && casted && FishIsOnLine && !FishIsCaught) {
			FishIsCaught = true;
			print ("Fish caught");
			casted = false;
		}
	}
	// Update is called once per frame
	void Update () {
        if (casted == false)
        {
            float x = player.GetAxis("AimX");
            float z = player.GetAxis("AimY") * zMod;
            Vector3 move = new Vector3(x,0,z);
            rgbd.velocity = move * speed * Time.deltaTime;
            if (move == Vector3.zero )
            {
                rgbd.velocity = Vector3.zero;
            }
            
            Vector3 pos = cam.GetComponent<Camera>().WorldToViewportPoint(aim.transform.position);
            lastPosition = pos;
            pos.x = Mathf.Clamp01(pos.x);
            //pos.y = Mathf.Clamp01(pos.y);
            //pos.y = 0.529551f;
            pos.z = Mathf.Clamp(pos.z, 8f, 50f);
            aim.transform.position = cam.GetComponent<Camera>().ViewportToWorldPoint(pos);
            //Vector3 minScreenBounds = cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, 0));
            //Vector3 maxScreenBounds = cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            //aim.transform.position = new Vector3(Mathf.Clamp(aim.transform.position.x, minScreenBoundsx, maxScreenBoundsx),aim.transform.position.y,aim.transform.position.z);
        }
        if (player.GetButtonDown("Cast"))
        {
            if (!casted)
            {
                rgbd.velocity = Vector3.zero;
                casted = true;
                StartCoroutine("WaitForFishToBeCaughtOnLine");
            }else if (FishIsOnLine)
            {
                cam.GetComponent<FishingCam>().SetZoom();
                FishIsCaught = true;
                fish.SetActive(true);
                this.enabled = false;
            }
            else if(!FishIsOnLine)
            {
                casted = false;
            }
           
        }
       
        //CheckIfMousePressed ();
	}
}
