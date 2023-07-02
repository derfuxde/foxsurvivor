using UnityEngine;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
{
    public float FillAmount = 1f; // Menge, um die die Leiste aufgefüllt wird
    public Transform player;
    public PlayerController playerController;
    public GameObject gplayer;
    public GameObject c;
    public Slider levelbar;

    private void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Den Spieler finden
        gplayer = player.gameObject;
        playerController = gplayer.GetComponent<PlayerController>();
        //c = GameObject.FindGameObjectWithTag("1");
        levelbar = GameObject.FindGameObjectWithTag("lvb").GetComponent<Slider>();
    }

    public void Update()
    {
        FillAmount = 1f;
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.5)
        {
            //if (playerController != null)
            //{
                // Füge die Menge zur Leiste des Spielers hinzu
                //playerController.AddToFillAmount(FillAmount);
            //}
            levelbar.value += FillAmount;
            Destroy(gameObject);
        }
    }
}
