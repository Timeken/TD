using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBase : Tower {

    public Transform target;
    public List<GameObject> enemiesInRange;
    GameObject enemyToShoot;

    public Transform rotatingPart;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();
    }

    void Update()
    {
        Rotation = 20;
        if (enemiesInRange.Count != 0)
        {
            enemyToShoot = enemiesInRange[0];
            target = enemyToShoot.transform;

            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * Rotation).eulerAngles;
            rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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
