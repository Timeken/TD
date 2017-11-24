using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade2 : Tower
{

    public Transform target;
    public List<GameObject> enemiesInRange;
    public GameObject projectile;

    public GameObject enemyToShoot;
    public GameObject click;
    public GameObject changeTexture1;
    public GameObject changeTexture2;
    public GameObject changeTexture3;

    public Transform rotatingPart;
    public Transform barrelPoint1;
    public Transform barrelPoint2;

    public Texture[] textures;

    public AudioSource shootingSound2;

    private float nextActionTime = 0.0f;
    public float period = 1;
    public float ammo;

    IngameButtons ingameButtons;

    Enemy enemy;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();

        Rotation = 4;
        DMG = 10.0f;
        Firerate = 0.5f;
        ammo = 20;

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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == click.transform) //check if turret is clicked and show upgrade menu.
                {
                    GameObject button = GameObject.FindGameObjectWithTag("UI");
                    ingameButtons = button.GetComponent<IngameButtons>();
                    ingameButtons.TurretUpgrade(transform.parent.gameObject, "turretUpgrade2");
                    ammo = 15;
                }
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
    }

    private void TimeToShoot()
    {
        if (enemiesInRange.Count != 0 && ammo > 0)
        {
            shootingSound2.Play();
            ammo--;
            GameObject gameObject1 = Instantiate(projectile, barrelPoint1.position, Quaternion.identity);
            GameObject gameObject2 = Instantiate(projectile, barrelPoint2.position, Quaternion.identity);
            //TODO? add greater speed for projectile?
            gameObject1.GetComponent<Projectile>().target = target;
            gameObject1.GetComponent<Projectile>().DMG = DMG;
            gameObject2.GetComponent<Projectile>().target = target;
            gameObject2.GetComponent<Projectile>().DMG = DMG;
        }
        else if (ammo <= 0)
        {
            changeTexture1.GetComponent<Renderer>().material.mainTexture = textures[1];
            changeTexture2.GetComponent<Renderer>().material.mainTexture = textures[1];
            changeTexture3.GetComponent<Renderer>().material.mainTexture = textures[1];
        }
    }

    public void setMyVolume(float volume)
    {
        shootingSound2.volume = volume;
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
