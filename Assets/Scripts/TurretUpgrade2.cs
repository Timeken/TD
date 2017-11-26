using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgrade2 : Tower
{

    public Transform target;
    public List<GameObject> enemiesInRange;
    public GameObject projectile;

    public GameObject enemyToShoot;
    public GameObject click;
    public GameObject changeTexture;

    public Transform rotatingPart;
    public Transform barrelPoint1;
    public Transform barrelPoint2;

    public Texture[] textures;//0 and 1 for blinking and 2 default.

    public AudioSource shootingSound2;

    private float nextActionTime = 0.0f;
    public float period = 1;
    public float ammo;
    public float ammoMax = 20;

    IngameButtons ingameButtons;

    Enemy enemy;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();

        Rotation = 4;
        DMG = 10.0f;
        Firerate = 0.5f;
        ammo = ammoMax;

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
                try
                {
                    //Smooth rotation
                    Vector3 direction = target.position - transform.position;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    Vector3 rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * Rotation).eulerAngles;
                    rotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                }
                catch (MissingReferenceException) { }
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
                    ammo = ammoMax;
                }
            }
        }
        if (ammo > 0 && changeTexture.GetComponent<Renderer>().material.mainTexture != textures[2]) // if ammo is > 0 and the texture is not changed change it.
        {
            ChangeTexture(textures[2]);
        }

        if (ammo == 0 && Time.time > nextActionTime)// Blink texture every seconed
        {
            nextActionTime += period;
            if (changeTexture.GetComponent<Renderer>().material.mainTexture != textures[1])
            {
                ChangeTexture(textures[1]);
            }
            else if (changeTexture.GetComponent<Renderer>().material.mainTexture == textures[1])
            {
                ChangeTexture(textures[0]);
            }
        }
    }

    public void ChangeTexture(Texture texture)
    {
        changeTexture.GetComponent<Renderer>().material.mainTexture = texture;
    }

    private void TimeToShoot()
    {
        if (enemiesInRange.Count != 0 && ammo > 0)
        {
            shootingSound2.Play();
            ammo--;
            GameObject gameObject1 = Instantiate(projectile, barrelPoint1.position, Quaternion.identity);
            GameObject gameObject2 = Instantiate(projectile, barrelPoint2.position, Quaternion.identity);
            gameObject1.GetComponent<Projectile>().target = target;
            gameObject1.GetComponent<Projectile>().DMG = DMG;
            gameObject2.GetComponent<Projectile>().target = target;
            gameObject2.GetComponent<Projectile>().DMG = DMG;
        }
        else if (ammo <= 0)
        {
            changeTexture.GetComponent<Renderer>().material.mainTexture = textures[1];
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
