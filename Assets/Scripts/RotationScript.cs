using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 1, 0 * Time.deltaTime);
    }
    
}
