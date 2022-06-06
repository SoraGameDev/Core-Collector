using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTriggerScript : MonoBehaviour
{
    public GameObject player;
    public bool StopRight;
     void OnTriggerStay(Collider player)
    {
        StopRight = true;
        
    }
    private void OnTriggerExit(Collider player)
    {
        StopRight = false;

    }
}
