﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade1 : Tower {

    public Transform target;
    public List<GameObject> enemiesInRange;
    public GameObject projectile;

    public GameObject enemyToShoot;
    public GameObject click;

    public Transform rotatingPart;
    public Transform barrelPoint;

    IngameButtons ingameButtons;

    Enemy enemy;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();

        Rotation = 4;
        DMG = 50.0f;
        Firerate = 2;
        Ammo = 15;

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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) == click.transform)
            {
                GameObject button = GameObject.FindGameObjectWithTag("UI");
                ingameButtons = button.GetComponent<IngameButtons>();
                ingameButtons.TurretUpgrade(transform.parent.gameObject, "turretUpgrade1");
                Ammo = 10;
            }
        }
    }

    private void TimeToShoot()
    {
        if (enemiesInRange.Count != 0 && Ammo > 0)
        {
            Ammo--;
            GameObject gameObject1 = Instantiate(projectile, barrelPoint.position, Quaternion.identity);
            //TODO? add greater speed for projectile?
            gameObject1.GetComponent<Projectile>().target = target;
            gameObject1.GetComponent<Projectile>().DMG = DMG;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Add enemy when in range
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //Remove enemy when out of range
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(collider.gameObject);
        }
    }
}
