using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Stick");
        other.gameObject.transform.SetParent(gameObject.transform, true);
    }







    private void OnTriggerExit(Collider other)
    {
        Debug.Log("UnStick");
        other.gameObject.transform.parent = null;
    }
      



    }
