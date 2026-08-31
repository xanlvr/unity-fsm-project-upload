using Unity.VisualScripting;
using UnityEngine;

public class TeamA_Manager : Team_Base
{

    //Variáveis relativas ao Spawn de Unidades
    public GameObject spawnerLocation;
    public GameObject fighterPrefab;
    public GameObject destroyerPrefab;

    private float spawnerTimer = 0f;
    private int lastSpawned = 0;


    private void Start()
    {

        //Inicialização do Spawner
        spawnerTimer = unitSpawnTimer;
    }

    private void Update()
    {
        //O LetsPlay é uma variável estática do Game_Manager que define se o jogo continua.
        if (Game_Manager.LetsPlay)
        {
            //Comportamento do Spawner
            spawnerTimer = spawnerTimer - Time.deltaTime;

            if (spawnerTimer <= 0)
            {
                SpawnUnit();
                spawnerTimer = unitSpawnTimer;
            }
        }
    }

    //Método de gerenciamento de Spawn
    public void SpawnUnit()
    {

        GameObject prefabToSpawn;

        Vector3 spawnPosition = new Vector3(spawnerLocation.transform.position.x, spawnerLocation.transform.position.y, spawnerLocation.transform.position.z);
        Quaternion spawnRotation = spawnerLocation.transform.rotation;

        if (lastSpawned == 0)
        {
            prefabToSpawn = destroyerPrefab;
            lastSpawned = 1;
            //Debug.Log("Instanciei Destroyer A!!");
        }
        else
        {
            prefabToSpawn = fighterPrefab;
            lastSpawned = 0;
            //Debug.Log("Instanciei Fighter A!!");
        }

        var newUnit = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        newUnit.SetActive(true);

    }



}
