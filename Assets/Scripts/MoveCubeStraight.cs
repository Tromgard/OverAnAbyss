using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveCubeStraight: MonoBehaviour
{
    bool point;
    public Transform point1;
    public Transform point2;
    Transform targetpoint;
    public float moveSpeed;

    private void Start()
    {
        targetpoint = point1;
        point = true;
    }

    private void Update()
    {
      
        if (point)
        {
            targetpoint = point2;
        }
        else
        {
            targetpoint = point1;
        }
            transform.position = Vector3.MoveTowards(transform.position, targetpoint.position, moveSpeed * Time.deltaTime);
        if (transform.position == targetpoint.position)
        {
            point = !point;
        }
        
    }
    
}
