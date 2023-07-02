using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    public Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        // Position der HP-Leiste an die Position des Spielers anpassen
        transform.position = target.position + offset;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
