using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Bullet : MonoBehaviour
{
    
    float DestroyTime = 2f;
    public float moveSpeed;
    public float bulletForce = 100;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        StartCoroutine(destroyBullet());
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);

    }
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody playerrb = collision.gameObject.GetComponent<Rigidbody>();
        var direction = (EnemyShooter.shooter.transform.position - EnemyShooter.shooter.target.transform.position).normalized;
        playerrb.AddForce(direction * bulletForce, ForceMode.Impulse);
    }

}
