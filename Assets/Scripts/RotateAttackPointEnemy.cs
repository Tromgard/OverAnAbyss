using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class RotateAttackPointEnemy : MonoBehaviour
    {
        public Transform attackPoint;
        public EnemyPusher enemy;
        public float angle;

        private void Update()
        {
        attackPoint.LookAt(enemy.target);
        }
    }

