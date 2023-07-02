using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Spielerbewegungsgeschwindigkeit
    public Animator animator; // Animator-Komponente des Spielers
    public Slider levelbar;
    private shoots shoots;

    private CharacterController controller;
    public bool isFacingRight = true; // Gibt an, ob der Spieler nach rechts schaut

    private void Start()
    {
        shoots = GetComponent<shoots>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Spielerbewegung
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed;

        controller.Move(movement * Time.deltaTime);

        // Animationen abspielen
        if (movement.magnitude > 0)
        {
            animator.SetBool("IsRunning", true);
            Flip(moveHorizontal);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void Flip(float moveHorizontal)
    {
        if (moveHorizontal > 0 && !isFacingRight)
        {
            // Spieler läuft nach rechts, Blickrichtung nach rechts drehen
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
            shoots.projectileSpeed = 20f;
        }
        else if (moveHorizontal < 0 && isFacingRight)
        {
            // Spieler läuft nach links, Blickrichtung nach links drehen
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
            shoots.projectileSpeed = -20F;
        }
    }

    public void AddToFillAmount (float FillAmount) {
        levelbar.value += FillAmount;
        FillAmount = 0f;
    }
}
