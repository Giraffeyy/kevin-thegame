using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public bool wavingOne = false;
    public bool wavingTwo = false;
    public bool wavingThree = false;
    public GameObject player;
    private GameObject door;
    public GameObject gunmanPrefab;
    private GameObject door2;
    public GameObject kevin;
    public GameObject talk1;
    public GameObject talk2;
    public GameObject talk3;
    public GameObject talk4;
    public GameObject bossPrefab;
    public GameObject bossBar;
    public bool bossKilled;
    private bool bossSpawned;
    public GameObject juice;
    public TextMeshProUGUI o1;
    public TextMeshProUGUI o2;
    public TextMeshProUGUI o3;
    public TextMeshProUGUI o4;
    public TextMeshProUGUI oK;
    private bool oSpawned;

    // Start is called before the first frame update
    void Start()
    {
        juice.SetActive(false); // initialize variables
        
        bossBar = GameObject.Find("BossSlider");
        bossBar.SetActive(false);
        door = GameObject.Find("door");
        door2 = GameObject.Find("door2");
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (enemyCount == 0 & wavingOne == true)
        {
            
            // change objective text

            oK.gameObject.SetActive(true);
            o1.gameObject.SetActive(false);
            o2.gameObject.SetActive(false);
            o3.gameObject.SetActive(false);
            o4.gameObject.SetActive(false);
            door.SetActive(false); // remove door and spawnw new wave
            wavingOne = false;
            wavingTwo = true;
            SpawnGunman();
        } else if (enemyCount == 0 & wavingTwo == true & bossKilled == false)
        {
            if(oSpawned == false)
            {

                // change objective text

                oK.gameObject.SetActive(true);
                o2.gameObject.SetActive(false);
                o1.gameObject.SetActive(false);
                o3.gameObject.SetActive(false);
                o4.gameObject.SetActive(false);
                oSpawned = true;
            }
            door2.SetActive(false); // move kevin
            talk3.SetActive(true);
            talk2.SetActive(false);
            kevin.transform.position = new Vector3(talk3.transform.position.x, kevin.transform.position.y, talk3.transform.position.z);
        }
    }

    private Vector3 GenerateSpawnPosition(int spawnType) // get a random X and Z value to spawn the enemies at 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(player.transform.position.x + spawnPosX, player.transform.position.y, player.transform.position.z + spawnPosZ);
        return randomPos;
    }

    public void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) // add the normal enemies with random spawn positions
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(2), enemyPrefab.transform.rotation);
        }
    }

    public void SpawnGunman() // spawn the gunman enemies and move kevin
    {
        talk1.SetActive(false);
        talk2.SetActive(true);
        kevin.transform.position = new Vector3(talk2.transform.position.x, kevin.transform.position.y, talk2.transform.position.z);
        Instantiate(gunmanPrefab, GameObject.Find("spawn1").transform.position, gunmanPrefab.transform.rotation);
        Instantiate(gunmanPrefab, GameObject.Find("spawn2").transform.position, gunmanPrefab.transform.rotation);
        Instantiate(gunmanPrefab, GameObject.Find("spawn3").transform.position, gunmanPrefab.transform.rotation);
        Instantiate(gunmanPrefab, GameObject.Find("spawn4").transform.position, gunmanPrefab.transform.rotation);
    }

    public void SpawnBoss()
    {
        if(bossSpawned == false)
        {

            // change objective text

            oK.gameObject.SetActive(false);
            o3.gameObject.SetActive(true);
            o1.gameObject.SetActive(false);
            o2.gameObject.SetActive(false);
            o4.gameObject.SetActive(false);
            bossBar.gameObject.SetActive(true); // spawn the boss and add the bar, alert other scripts
            bossSpawned = true;
            wavingThree = true;
            Instantiate(bossPrefab, GameObject.Find("BossSpawn").transform.position, bossPrefab.transform.rotation);
        }
        
    }
}