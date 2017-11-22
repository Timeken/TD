using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : Tower {

    public Transform target;
    public List<GameObject> enemiesInRange;
    public GameObject projectile;

    public GameObject enemyToShoot;
    public GameObject click;
    public GameObject changeTexture1;
    public GameObject changeTexture2;
    public GameObject changeTexture3;

    public Transform rotatingPart;
    public Transform barrelPoint;

    public AudioSource shootingSound;

    public Texture[] textures;

    private float nextActionTime = 0.0f;
    public float period = 1;
    public float ammo;

    IngameButtons ingameButtons;

    Enemy enemy;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();

        Rotation = 4;
        DMG = 25.0f;
        Firerate = 2;
        ammo = 10;

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
            if (ammo != 0)
            {
                Vector3 direction = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * Rotation).eulerAngles;
                rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }
        if (ammo > 0 && changeTexture1.GetComponent<Renderer>().material.mainTexture != textures[2] &&
                changeTexture2.GetComponent<Renderer>().material.mainTexture != textures[2] &&
                changeTexture3.GetComponent<Renderer>().material.mainTexture != textures[2]) // if ammo is > 0 and the texture is not changed change it.
        {
            changeTexture1.GetComponent<Renderer>().material.mainTexture = textures[2];
            changeTexture2.GetComponent<Renderer>().material.mainTexture = textures[2];
            changeTexture3.GetComponent<Renderer>().material.mainTexture = textures[2];
        }
        if (Time.time > nextActionTime)// Blink texture every seconed
        {
            nextActionTime += period;
            if (changeTexture1.GetComponent<Renderer>().material.mainTexture == textures[1] && 
                changeTexture2.GetComponent<Renderer>().material.mainTexture == textures[1] && 
                changeTexture3.GetComponent<Renderer>().material.mainTexture == textures[1])
            {
                changeTexture1.GetComponent<Renderer>().material.mainTexture = textures[0];
                changeTexture2.GetComponent<Renderer>().material.mainTexture = textures[0];
                changeTexture3.GetComponent<Renderer>().material.mainTexture = textures[0];
            }
            else if (changeTexture1.GetComponent<Renderer>().material.mainTexture == textures[0] && 
                changeTexture2.GetComponent<Renderer>().material.mainTexture == textures[0] && 
                changeTexture3.GetComponent<Renderer>().material.mainTexture == textures[0])
            {
                changeTexture1.GetComponent<Renderer>().material.mainTexture = textures[1];
                changeTexture2.GetComponent<Renderer>().material.mainTexture = textures[1];
                changeTexture3.GetComponent<Renderer>().material.mainTexture = textures[1];
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform == click.transform)
                {
                    GameObject button = GameObject.FindGameObjectWithTag("UI"); //check if turret is clicked and show upgrade menu.
                    ingameButtons = button.GetComponent<IngameButtons>();
                    ingameButtons.TurretUpgrade(transform.parent.gameObject, "turretBase");
                    ammo = 10;
                }
            }
        }
    }

    private void TimeToShoot()
    {
        if (enemiesInRange.Count != 0 && ammo > 0)
        {
            shootingSound.Play(); // Test test!!
            ammo--;
            GameObject gameObject1 = Instantiate(projectile, barrelPoint.position, Quaternion.identity);
            //TODO? add greater speed for projectile?
            gameObject1.GetComponent<Projectile>().target = target;
            gameObject1.GetComponent<Projectile>().DMG = DMG;
        }
        else if (ammo <= 0)
        {
            changeTexture1.GetComponent<Renderer>().material.mainTexture = textures[1];
            changeTexture2.GetComponent<Renderer>().material.mainTexture = textures[1];
            changeTexture3.GetComponent<Renderer>().material.mainTexture = textures[1];
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
