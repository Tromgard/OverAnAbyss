using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class EnemyShooter : MonoBehaviour
{
    
    public Transform target;
    public Vector3 directionToEnemy;
    public float rangeToEnemy;
    public GameObject ammoPrefab;
   public Transform weapon;
    float timeUntilNextAttack;
    public static EnemyShooter shooter;

    public float attackSpeed = 2;

    private void Awake()
    {
        shooter = this; 
    }



    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextAttack < Time.time && rangeToEnemy <30)
        {

            Shoot();
            timeUntilNextAttack = Time.time + attackSpeed;
        }
        transform.LookAt(target);
        CheckAttackRange();


    }
    public void CheckAttackRange()
    {

        {
            directionToEnemy = target.position - transform.position;
            rangeToEnemy = directionToEnemy.sqrMagnitude;
            

        }

    }
    void Shoot()
    {

        var projectile = Instantiate(ammoPrefab, weapon.position, weapon.rotation);
        

    }
    private void OnCollisionEnter(Collision collision)
    {

       
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }

    }

}
