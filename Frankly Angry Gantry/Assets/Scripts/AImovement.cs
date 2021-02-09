using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImovement : MonoBehaviour
{
    public CraneMove crane;

    public List<GameObject> boxList;

    Vector3 craneAxis;

    public bool hookHasHit;
    public bool turnLeft, turnRight;
    public float speed;
    private bool droppingHook;
    public GameObject gantryBase, gantryCab, gantryTop, gantryArm, gantryHook, hookMover, hookMoverLeftEnd, hookMoverRightEnd, armEndLeft, armEndRight;


    [Range(0f, 0.1f)]
    public float smoothSpeed;

    private GameObject targetContainer;


    private void Awake()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("BoxGreen"))
        {
            boxList.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("BoxRed"))
        {
            boxList.Add(go);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        turnLeft = true;
        turnRight = true;
        hookHasHit = false;
        droppingHook = false;
        craneAxis = new Vector3(gantryTop.transform.position.x, gantryTop.transform.position.y, gantryTop.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(hookMover.transform.position.x, gantryHook.transform.position.y, hookMover.transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(gantryHook.transform.position, targetPosition, smoothSpeed);
        gantryHook.transform.position = smoothPosition;
    }



    private void FixedUpdate()
    {
        if (droppingHook == false)
        {
            if (Vector2.Distance(armEndLeft.transform.position, hookMoverLeftEnd.transform.position) > 1.5f)
            {
                if (Input.GetKey("up"))
                {
                    hookMover.transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
                }
            }

            if (Vector2.Distance(armEndRight.transform.position, hookMoverRightEnd.transform.position) > 1.5f)
            {
                if (Input.GetKey("down"))
                {
                    hookMover.transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                }
            }

            if (Input.GetKey("right") && turnLeft == true)//Player2/AI perspective
            {
                gantryCab.transform.RotateAround(craneAxis, Vector3.up, speed * Time.deltaTime);
                gantryArm.transform.RotateAround(craneAxis, Vector3.up, speed * Time.deltaTime);
                hookMover.transform.RotateAround(craneAxis, Vector3.up, speed * Time.deltaTime);
            }

            if (Input.GetKey("left") && turnRight == true) //Player2/AI perspective
            {
                gantryCab.transform.RotateAround(craneAxis, -Vector3.up, speed * Time.deltaTime);
                gantryArm.transform.RotateAround(craneAxis, -Vector3.up, speed * Time.deltaTime);
                hookMover.transform.RotateAround(craneAxis, -Vector3.up, speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightControl))
            {
                droppingHook = true;
            }
        }

        else if (droppingHook == true)
        {
            if (hookHasHit == false)
            {
                gantryHook.transform.Translate(-Vector3.up * (speed - 1) * Time.fixedDeltaTime);
            }
            else if (hookHasHit == true && gantryHook.transform.position.y <= (hookMover.transform.position.y - 10f))
            {
                gantryHook.transform.Translate(Vector3.up * (speed - 1) * Time.fixedDeltaTime);
            }
            else
            {
                droppingHook = false;
                hookHasHit = false;
            }
        }
    }
}
