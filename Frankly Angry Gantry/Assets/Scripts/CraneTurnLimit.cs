using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneTurnLimit : MonoBehaviour
{
    public GameObject playerRightEnd, AIRightEnd;
    public GameObject playerLeftEnd, AILeftEnd;
    public CraneMove craneMove;
    public AImovement AIMove;

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "PlayerArmCollider")
        {
            if (other.gameObject.name == "PlayerRightEnd")
            {
                craneMove.turnLeft = false;
            }
            if (other.gameObject.name == "PlayerLeftEnd")
            {
                craneMove.turnRight = false;
            }
        }


        if (this.gameObject.name == "AIArmCollider")
        {
            if (other.gameObject.name == "AIRightEnd")
            {
                AIMove.turnRight = false;
            }
            if (other.gameObject.name == "AILeftEnd")
            {
                AIMove.turnLeft = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(this.gameObject.name == "PlayerArmCollider")
        {
            if (other.gameObject.name == "PlayerRightEnd")
            {
                craneMove.turnLeft = true;
            }
            if (other.gameObject.name == "PlayerLeftEnd")
            {
                craneMove.turnRight = true;
            }
        }


        if (this.gameObject.name == "AIArmCollider")
        {
            if (other.gameObject.name == "AIRightEnd")
            {
                AIMove.turnRight = true;
            }
            if (other.gameObject.name == "AILeftEnd")
            {
                AIMove.turnLeft = true;
            }
        }
    }
}
