using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBase : Tower {

    public Transform target;
    public List<GameObject> enemiesInRange;
    public GameObject projectile;

    GameObject enemyToShoot;

    public Transform rotatingPart;

    Enemy enemy;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();

        Rotation = 4;
        DMG = 25;
        Firerate = 2;

        InvokeRepeating("TimeToShoot", Firerate, Firerate);
    }

    void Update()
    {

        if (enemiesInRange.Count != 0)
        {
            enemyToShoot = enemiesInRange[0];
            if (enemyToShoot != null)
            {
                target = enemyToShoot.transform;
            }
            else
            {
                enemiesInRange.Remove(enemyToShoot);
            }

            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * Rotation).eulerAngles;
            rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    private void TimeToShoot()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Enemy");
        enemy = gameObject.GetComponent<Enemy>();

        GameObject gameObject1 = Instantiate(projectile, transform.position, Quaternion.identity);
        gameObject1.GetComponent<Projectile>().target = target;

        Debug.Log("Fire!");
        bool enemyDead;

        enemyDead = enemy.TakeDamage(DMG, enemyToShoot);
        if (enemyDead)
        {
            enemiesInRange.Remove(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(collider.gameObject);
        }
    }
}
