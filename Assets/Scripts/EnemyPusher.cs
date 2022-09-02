using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyPusher : MonoBehaviour
{
    public bool InAttackRange;
    public Transform target;
    public float attackDistance;
    public Vector3 directionToEnemy;
    public float rangeToEnemy;
    public float speed = 2;
    float currentSpeed;
    Rigidbody rb;
    
    public float attackRate = 1;
    public Animator weapAnim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rangeToEnemy < 25)
        {
            MoveTo();
        }
        CheckAttackRange();
        
        
    }
    public void CheckAttackRange()
    {
       
        {
            directionToEnemy = target.position - transform.position;
            rangeToEnemy = directionToEnemy.sqrMagnitude;
            if (rangeToEnemy < attackDistance)
            {
                InAttackRange = true;
                weapAnim.SetBool("isAttack", true);
            }
            else
            {
                InAttackRange = false;
                weapAnim.SetBool("isAttack", false);
            }
            
        }

    }
    public void MoveTo()
    {
        transform.LookAt(target);
        currentSpeed = Mathf.Clamp(directionToEnemy.magnitude, 0.0f, 1.0f);
        directionToEnemy.Normalize();
        rb.velocity = directionToEnemy *currentSpeed* speed;

    }
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }

    }

}
