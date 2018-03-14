using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allow us to use the NavMeshAgent type
using UnityEngine.AI;
using UnityEngine.UI;
// Allow us to access our key mappings
using Rewired;
using Rewired.ControllerExtensions;
public class MoveTo : MonoBehaviour {

    public Rewired.ControllerExtensions.DualShock4Extension ds4;
    public bool flicked = false;

    /*Animation related information*/
    [SerializeField]
    float m_MovingTurnSpeed = 360;
    [SerializeField]
    float m_StationaryTurnSpeed = 180;
    [SerializeField]
    float m_GravityMultiplier = 2f;
    [SerializeField]
    float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
    [SerializeField]
    float m_MoveSpeedMultiplier = 1f;
    [SerializeField]
    float m_AnimSpeedMultiplier = 1f;
    [SerializeField]
    float m_GroundCheckDistance = 0.1f;

    //public GameObject cam;

    Rigidbody m_Rigidbody;
    Animator m_Animator;
    float m_OrigGroundCheckDistance;
    float m_TurnAmount;
    float m_ForwardAmount;
    Vector3 m_GroundNormal;

    public bool isMoving;
    public bool moved = false;
    public bool clicked = false;
    // Hides the variable below from the Inspector
    [HideInInspector]
    // The cursor's screen position
    public Vector3 cursorPos;

    // Specifies which player the object this script is attached to is
    public int id;

    // The NavMeshAgent component (The component of the object that will be moving around in our scene)
    public NavMeshAgent agent;

    // Stores the point of contact position
    Vector3 wordPos;

    //Marker variables
    private Side map;
    public GameObject wharf;

    //Keep track of steps
    public int current = 0;
    public int end = -1;
    //Switch
    public GameObject Switch;
    private OnSwitch Change;

    //Show dice number
    public GameObject Dice;

    //Keep track of triggers
    public bool triggered = false;

    //Keep track of when we're done moving
    public bool DoneMoving = false;

    //Player turn text
    public Text WhoseTurn;
    // Use this for initialization
    private void Awake()
    {
        map = wharf.GetComponent<Side>();
        Change = Switch.GetComponent<OnSwitch>();
        DontDestroyOnLoad(gameObject);
        if (GlobalData.players[id] == null)
        {
            DontDestroyOnLoad(gameObject);
            GlobalData.players[id] = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
         
        foreach (Joystick joystick in ReInput.players.GetPlayer(id).controllers.Joysticks)
        {
            // Get the Dual Shock 4 Controller Extension from the Joystick
            ds4 = joystick.GetExtension<Rewired.ControllerExtensions.DualShock4Extension>();
            if (ds4 == null) continue; // this is not a DS4, skip it
        }
    }
    void Start() {
        
        // Get the NavMeshAgent component of this game object
        agent = GetComponent<NavMeshAgent>();

        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        m_OrigGroundCheckDistance = m_GroundCheckDistance;
    }
    void OnEnable()
    {
        foreach (Joystick joystick in ReInput.players.GetPlayer(id).controllers.Joysticks)
        {
            // Get the Dual Shock 4 Controller Extension from the Joystick
            ds4 = joystick.GetExtension<Rewired.ControllerExtensions.DualShock4Extension>();
            if (ds4 == null) continue; // this is not a DS4, skip it
        }
        flicked = false;
    }
    void Update()
    {
        
        // Grab the current cursor position
        cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        if (Input.GetKeyDown("n"))
        {
            foreach (GameObject item in GlobalData.P1Inventory)
            {
                print(item);
                GameObject.Instantiate(item);
            }
            print(GlobalData.P1Inventory.Count);
        }
        /*if(ds4 != null)
        {
            if(ds4.GetAccelerometerValue().z > .8f)
            {
                flicked = true;
            }
        }*/
        // Detect key mapped input
        if ((ReInput.players.GetPlayer(id).GetButtonDown("action")||(ds4 != null && ds4.GetAccelerometerValue().z > .8f)) && !moved && isMoving && !clicked)
        {
            flicked = false;
            //GlobalData.FirstLoad = false;
            print(id);
            print(gameObject);
            WhoseTurn.text = "";
            Dice.SetActive(true); 
            agent.isStopped = false;
            int step = (int)Random.Range(1.5f,4.9f);
            end = current + step;
            Dice.transform.GetChild(0).gameObject.GetComponent<Text>().text = step.ToString();
            StartCoroutine("Roll");
            clicked = true;

            //end = current + 2;
            //current = current + steps;
            //print(map.NextTile(current));

        }
        else if (agent.remainingDistance > agent.stoppingDistance)
        {
            Move(agent.desiredVelocity, false, false);

        }
        else
        {

            
            Move(Vector3.zero, false, false);
            if (current < end && moved)
            {
                current++;             
                agent.destination = map.NextTile(current).transform.position;
                print("still running");
                //agent.isStopped = false;
            } else if (moved && current == end)
            {
                //Do all the end of turn stuff in here
                //print(current);
                //print(end);
                //map.NextTile(end).SendMessage("OnTriggerEnter", gameObject.GetComponent<Collider>());
                //map.NextTile(end).SendMessage("OnTriggerEnter",gameObject.GetComponent<Collider>());
                agent.isStopped = true;
                

                //StartCoroutine("SwitchPlayers");
                //clicked = false;
                print("Arrived");
                moved = false;
                DoneMoving = true;
                if (GlobalData.Wharf)
                {
                    Continue();
                }           
                

                // agent.isStopped = true;
            }

        }
    }

    public bool GetDoneMoving()
    {
        return DoneMoving;
    }

    void UpdateAnimator(Vector3 move)
    {
        // update the animator parameters
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);

        // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
        // which affects the movement speed because of the root motion.
        if (move.magnitude > 0)
        {
            m_Animator.speed = m_AnimSpeedMultiplier;
        }
    }

    public void Move(Vector3 move, bool crouch, bool jump)
    {
        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f)
        {
            move.Normalize();
        }
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;

        // send input and other state parameters to the animator
        UpdateAnimator(move);
    }

    public void Continue()
    {
        Change.TaskOnClick();
        //while(agent == null || map==null)
        //{
        //print("waiting");
        //}
        //agent.destination = map.NextTile(current).transform.position;
        //agent.isStopped = false;
    }
    IEnumerator Roll()
    {
        yield return new WaitForSeconds(1.0f);
        //map.NextTile(end).GetComponent<Collider>().enabled = true;
        current = current + 1;
        agent.destination = map.NextTile(current).transform.position;
        
        Dice.SetActive(false);
        moved = true;
    }
    IEnumerator SwitchPlayers()
    {
        yield return new WaitForSeconds(1.0f);
        
    }
}
