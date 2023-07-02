using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class gegnerscript2 : MonoBehaviour
{
    public float attackCooldown = 2f; // Zeit zwischen den Angriffen
    public float moveSpeed = 3f; // Geschwindigkeit des Gegners
    public float followDistance = 5f; // Distanz, ab der der Gegner dem Spieler folgt
    public float attackDistance = 1f; // Distanz, ab der der Gegner den Spieler angreift
    public GameObject collectiblePrefab; // Prefab für das sammelbare Objekt
    public Transform dropPoint; // Punkt, an dem das Objekt fallen gelassen wird
    public float fillAmount = 10f; // Menge, um die die Leiste aufgefüllt wird
    public Transform shoot;
    public float attackDamage = 1f;
    //public Transform shoott;
    public Slider hp;
    //private bool isWaitingForObject = true;
    public Transform c;

    public string targetTag = "shoot";
    private GameObject ntplayer;
    public List<GameObject> slist;
    private bool canAttack = true;
    public ParticleSystem particleSystem;
    //public List projectile;

    //private List<GameObject> objectsList = new List<GameObject>(); // Liste zur Speicherung der gefundenen Objekte
    

    private Transform player; // Referenz auf den Spieler

    private void Start()
    {
        //particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Pause();
        //StartCoroutine(FindShootObject());
        player = GameObject.FindGameObjectWithTag("Player").transform; // Den Spieler finden
        ntplayer = GameObject.FindGameObjectWithTag("Player");
        c = GameObject.FindGameObjectWithTag("c").transform;
        shoots listScript = FindObjectOfType<shoots>();
        if (listScript != null)
        {
            // Die Liste aus dem anderen Skript abrufen
            slist = listScript.projectiles;
        }
        else
        {
            Debug.LogError("ListScript nicht gefunden!");
        }
        //projectile = GetComponent<projectile>();
        //GameObject[] shoot = GameObject.FindGameObjectsWithTag(targetTag);
        //objectsList.AddRange(shoot);

        //Debug.Log("Anzahl der Objekte mit Tag '" + targetTag + "': " + objectsList.Count);

        // Beispielhafte Verwendung der Liste:
        // Iteriere über die Liste und gib den Namen jedes Objekts aus
    }

    private void Update()
    {
        hp = c.Find("Slider").GetComponent<Slider>();
        //shoot = FindShootObject();
        // Überprüfe die Distanz zum Spieler
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        

        // Wenn der Spieler sich in der Follow-Distanz befindet, dem Spieler folgen
        if (distanceToPlayer <= followDistance)
        {
            // Bewege dich in Richtung des Spielers
            Vector2 direction = player.position - transform.position;
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

            // Wenn der Spieler sich in der Angriffs-Distanz befindet, den Spieler angreifen
            if (distanceToPlayer <= attackDistance)
            {
                if (canAttack = true){
                    AttackPlayer();
                    StartCoroutine(StartAttackCooldown());
                }
            }
        }
            //float distanceToshoot = Vector2.Distance(transform.position, shoot.position);
            foreach (GameObject obj in slist){
                if (obj != null){
                    if (Vector2.Distance(transform.position, obj.transform.position) <= 0.5){
                        Debug.Log(obj.name + " hat " + gameObject.name + " getötet");
                        Destroy(gameObject);
                        hitbyshoot();
                        slist.Remove(obj);
                        Destroy(obj);
                        break;
                    }
                }
            }
    }

    private void AttackPlayer()
    {
        hp.value =- attackDamage;
    }

    private void hitbyshoot()
    {
        // Erzeuge das sammelbare Objekt
        GameObject collectible = Instantiate(collectiblePrefab, dropPoint.position, Quaternion.identity);

        // Füge die Menge zur Leiste hinzu
        CollectibleController collectibleController = collectible.GetComponent<CollectibleController>();
        if (collectibleController != null)
        {
            collectibleController.FillAmount += fillAmount;
        }

        // Zerstöre den Gegner
        //Destroy(gameObject);
    }

    private IEnumerator FindShootObject()
    {
        while (shoot == null)
        {
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("shoot");
            if (foundObjects.Length > 0)
            {
                shoot = foundObjects[0].transform;
                // Weitere Aktionen oder Code hier ausführen
            }

            yield return null;
        }
    }

    private IEnumerator StartAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void kill()
    {
        // Erzeuge das sammelbare Objekt
        GameObject collectible = Instantiate(collectiblePrefab, dropPoint.position, Quaternion.identity);

        // Füge die Menge zur Leiste hinzu
        CollectibleController collectibleController = collectible.GetComponent<CollectibleController>();
        if (collectibleController != null)
        {
            collectibleController.FillAmount += fillAmount;
        }

        // Zerstöre den Gegner
        Destroy(gameObject);
    }
}
