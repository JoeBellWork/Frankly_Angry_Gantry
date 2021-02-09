using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookMoveAndGrab : MonoBehaviour
{
    public CraneMove craneMove;
    public AImovement AI;
    public GameObject container;
    private GameObject hook;

    public Image scope;

    [Range(0f, 0.2f)]
    public float smoothSpeed;

    private void Start()
    {
        if(this.gameObject.name == "PlayerGantryHook")
        {
            hook = this.gameObject;
        }
        else if(this.gameObject.name == "AIGantryHook")
        {
            hook = this.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "PlayerGantryHook")
        {
            if (other.tag == "Ground" || other.tag == "BoxGreen" && other.gameObject.name != "Taken" || other.tag == "BoxRed" && other.gameObject.name != "Taken" || other.tag == "Score")
            {
                craneMove.hookHasHit = true;

                if (other.tag == "BoxGreen" && container == null && other.gameObject.name != "Taken" || other.tag == "BoxRed" && container == null && other.gameObject.name != "Taken")
                {
                    other.gameObject.name = "Taken";
                    AI.boxList.Remove(other.gameObject);
                    container = other.gameObject;
                }
            }
        }



        if(this.gameObject.name == "AIGantryHook")
        {
            if (other.tag == "Ground" || other.tag == "BoxGreen" && other.gameObject.name != "Taken" || other.tag == "BoxRed" && other.gameObject.name != "Taken" || other.tag == "Score")
            {
                AI.hookHasHit = true;

                if (other.tag == "BoxGreen" && container == null || other.tag == "BoxRed" && container == null)
                {
                    other.gameObject.name = "Taken";
                    AI.boxList.Remove(other.gameObject);
                    container = other.gameObject;
                }
            }
        }

    }

    private void Update()
    {
        scope.transform.position = new Vector3(hook.transform.position.x, hook.transform.position.y -10f, hook.transform.position.z);

        if (container != null)
        {
            Vector3 targetPosition = new Vector3(hook.transform.position.x, hook.transform.position.y - 7.5f, hook.transform.position.z);
            Vector3 smoothPosition = Vector3.Lerp(container.transform.position, targetPosition, smoothSpeed);
            container.transform.position = smoothPosition;
        }
        
    }    
}
