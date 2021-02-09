using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraneMove : MonoBehaviour
{
    //score varibles
    public int playerScore, AIScore, highscore, redscore, greenScore, playerLives;




    //crane Pieces
    public GameObject gantryBase, gantryCab, gantryTop, gantryArm, gantryHook, hookMover, hookMoverLeftEnd, hookMoverRightEnd, armEndLeft, armEndRight;  
    Vector3 craneAxis;    

    public float speed;
    private bool droppingHook;


    //hook follow mover section    
    [Range(0f, 0.1f)]
    public float smoothSpeed;

    public bool turnLeft, turnRight;
    public bool hookHasHit;

    // access hook grabbing script
    public HookMoveAndGrab hookMoveAndGrab;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        craneAxis = new Vector3(gantryTop.transform.position.x, gantryTop.transform.position.y, gantryTop.transform.position.z);
        turnLeft = true;
        turnRight = true;



        droppingHook = false;
        hookHasHit = false;

        //score
        playerScore = 0;
        AIScore = 0;
        redscore = 100;
        greenScore = 50;
        playerLives = 1;

    }   


    private void Update()
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
                if (Input.GetKey("w"))
                {
                    hookMover.transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
                }
            }

            if (Vector2.Distance(armEndRight.transform.position, hookMoverRightEnd.transform.position) > 1.5f)
            {
                if (Input.GetKey("s"))
                {
                    hookMover.transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                }
            }

            if (Input.GetKey("d") && turnLeft == true)
            {
                gantryCab.transform.RotateAround(craneAxis, Vector3.up, speed * Time.deltaTime);
                gantryArm.transform.RotateAround(craneAxis, Vector3.up, speed * Time.deltaTime);                
                hookMover.transform.RotateAround(craneAxis, Vector3.up, speed * Time.deltaTime);
            }

            if (Input.GetKey("a") && turnRight == true)
            {
                gantryCab.transform.RotateAround(craneAxis, -Vector3.up, speed * Time.deltaTime);
                gantryArm.transform.RotateAround(craneAxis, -Vector3.up, speed * Time.deltaTime);                
                hookMover.transform.RotateAround(craneAxis, -Vector3.up, speed * Time.deltaTime);
            }

            if (Input.GetKey("space"))
            {                
                droppingHook = true;                
            }
        }

        else if(droppingHook == true)
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
