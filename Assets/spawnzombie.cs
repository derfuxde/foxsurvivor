using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class spawnzombie : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 2f;
    public float spawnRadius = 5f;
    public power power;

    private float spawnTimer = 0f;
    public GameObject hp;
    public List<GameObject> gegnerlist;

    private void Start () {
        power.UseList(gegnerlist);
        gegnerlist = new List<GameObject>();
        for(int i = gegnerlist.Count - 1; i >= 0; i--) {
            GameObject glist = gegnerlist[i];
            Debug.Log(i);
            
            if(gegnerlist[i] == null) {
                Debug.Log(i + "entfernt");
                gegnerlist.RemoveAt(i);   
            }  
        }
    }

    private void Update()
    {
        // Aktualisiere den Spawn-Timer
        spawnTimer += Time.deltaTime;

        // Überprüfe, ob es Zeit ist, einen Gegner zu spawnen
        if (spawnTimer >= spawnDelay)
        {
            SpawnEnemy();
            ResetSpawnTimer();
        }
    }

    private void SpawnEnemy()
    {
        // Berechne eine zufällige Position innerhalb des Spawn-Radius
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0f;

        // Erzeuge den Gegner an der berechneten Position
        GameObject instanz = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        gegnerlist.Add(instanz);
    }

    private void ResetSpawnTimer()
    {
        spawnTimer = 0f;
        spawnDelay = Random.Range(1f, 4f); // Zufällige Verzögerung für den nächsten Spawn
    }
}
