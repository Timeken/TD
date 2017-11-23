using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    public List<GameObject> enemyList;

    public float interval = 2;
    //public float time = 2;
    [SerializeField]
    Text currentWaveText;

    Wave wave = new Wave();
    Enemy enemy = new Enemy();

    int[] spawningEnemy;
    int currentEnemy = 0;
    int currentWave = 1;
    int maxWave = 5;

    IngameButtons ingameButtons;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnNext", interval, interval);
        spawningEnemy = wave.GetWave(currentWave);
    }
	
	void SpawnNext () {
        if (spawningEnemy[currentEnemy] != 0)
        {
            Instantiate(enemyList[currentEnemy], transform.position, Quaternion.identity);
            if (enemyList[currentEnemy].GetComponent<Minion1>() == null)
            {
                enemyList[currentEnemy].GetComponent<Minion2>().SetValues(300, 10, 10); // HP, damage, value
            } else
            {
                enemyList[currentEnemy].GetComponent<Minion1>().SetValues(100, 5, 5); // HP, damage, value
            }
        }
        if (--spawningEnemy[currentEnemy] <= 0)
        {

            currentEnemy++;

            if (spawningEnemy.Length == currentEnemy && currentWave != maxWave)
            {
                currentWave++;
                spawningEnemy = wave.GetWave(currentWave);
                currentEnemy = 0;
            }
        }
        
    }
    private void Update()
    {
        currentWaveText.text = "Wave: " + currentWave.ToString();
        if (currentWave == maxWave && GameObject.FindGameObjectWithTag("Enemy") == null) // Check if there is no enemy left in the final wave.
        {
            GameObject button = GameObject.FindGameObjectWithTag("UI");
            ingameButtons = button.GetComponent<IngameButtons>();

            ingameButtons.winScreen.SetActive(true);
        }
    }
}
