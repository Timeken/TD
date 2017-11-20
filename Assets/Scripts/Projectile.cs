using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform target;
    public float DMG;

    Enemy enemy;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * 10;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collidingEnemy)
    {
        if (collidingEnemy.gameObject.tag.Equals("Enemy") && collidingEnemy.transform == target)
        {
            GameObject enemyTarget = collidingEnemy.gameObject;
            enemy = enemyTarget.GetComponent<Enemy>();

            enemy.TakeDamage(DMG, enemyTarget);

            Destroy(gameObject);
        }
    }
}
