using UnityEngine;
using System.Collections.Generic;

public class shoots : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab für den Wurfstern
    public Transform projectileSpawnPoint; // Spawn-Punkt des Wurfsterns
    public float projectileSpeed = 20f; // Geschwindigkeit des Wurfsterns
    public float fireRate = 0.5f; // Feuerrate des Spielers
    public float projectileLifetime = 2f; // Lebensdauer des Wurfstern

    private float nextFireTime;
    public List<GameObject> projectiles;

    private void Start()
    {
        nextFireTime = Time.time + fireRate; // Startzeit für das automatische Schießen setzen
        projectiles = new List<GameObject>();
    }

    private void Update()
    {
        // Überprüfe, ob der Spieler feuern kann
        if (Time.time >= nextFireTime)
        {
            FireProjectile(); // Wurfstern abfeuern
            nextFireTime = Time.time + fireRate; // Aktualisiere die nächste Feuerzeit für das automatische Schießen
        }
    }

    private void FireProjectile()
    {
        // Erzeuge den Wurfstern
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        projectiles.Add(projectile);

        
        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            GameObject projectiler = projectiles[i];
            Debug.Log(i);
            
            if(projectiler == null) {
                Debug.Log(i + "entfernt");
                projectiles.RemoveAt(i);   
            }
        }


        // Bestimme die Richtung des Wurfsterns
        Vector3 direction = Vector3.right; // Zum Beispiel nach rechts schießen



        // Setze die Geschwindigkeit des Wurfsterns
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        // Zerstöre das Projektil nach der angegebenen Lebensdauer
        Destroy(projectile, projectileLifetime);
    }

}