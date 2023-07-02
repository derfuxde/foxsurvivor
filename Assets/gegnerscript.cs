using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Geschwindigkeit des Gegners
    public float followDistance = 5f; // Distanz, ab der der Gegner dem Spieler folgt
    public float attackDistance = 1f; // Distanz, ab der der Gegner den Spieler angreift
    public GameObject collectiblePrefab; // Prefab für das sammelbare Objekt
    public Transform dropPoint; // Punkt, an dem das Objekt fallen gelassen wird
    public float fillAmount = 10f; // Menge, um die die Leiste aufgefüllt wird

    private Transform player; // Referenz auf den Spieler

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Den Spieler finden
    }

    private void Update()
    {
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
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        // Erzeuge das sammelbare Objekt
        GameObject collectible = Instantiate(collectiblePrefab, dropPoint.position, Quaternion.identity);

        // Füge die Menge zur Leiste hinzu
        CollectibleController collectibleController = collectible.GetComponent<CollectibleController>();
        if (collectibleController != null)
        {
            collectibleController.FillAmount = fillAmount;
        }

        // Zerstöre den Gegner
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("shoot"))
        {
            // Erzeuge das sammelbare Objekt
            GameObject collectible = Instantiate(collectiblePrefab, dropPoint.position, Quaternion.identity);
            
            // Füge die Menge zur Leiste hinzu
            CollectibleController collectibleController = collectible.GetComponent<CollectibleController>();
            if (collectibleController != null)
            {
                collectibleController.FillAmount = fillAmount;
            }

            // Zerstöre den Gegner
            Destroy(gameObject);
        }
    }
}
