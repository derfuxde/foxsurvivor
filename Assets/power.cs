using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class power : MonoBehaviour
{
    public Slider slider;
    public List<GameObject> zombielist; 
    public ParticleSystem particleSystem; // Referenz auf die ParticleSystem-Komponente
    public GameObject spawnzo;
    public GameObject gegnerscript2;

    private spawnzombie spawnzombieScript;

    private void Start()
    {
        //spawnzombieScript = spawnzo.GetComponent<spawnzombie>();
        //zombies = spawnzombieScript.gegnerlist;
        zombielist = spawnzo.GetComponent<spawnzombie>().gegnerlist;

        if (particleSystem == null)
        {
            // Falls nicht, versuche sie auf diesem GameObject zu finden
            particleSystem = gegnerscript2.GetComponent<ParticleSystem>();
        }

        // Fügen Sie der Methode OnSliderValueChanged als Listener für den OnValueChanged-Event des Sliders hinzu
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    
    public void Update () {
        if (particleSystem != null && particleSystem.isPlaying)
        {
            Debug.Log("stop ps");
            // Falls nicht, versuche sie auf diesem GameObject zu finden
            particleSystem.Pause();
        }
        StopParticleSystem();
        if (slider.value == slider.maxValue){
            particleSystem.Play();
            //PlayParticles(zombielist);
        }
    }

    public void PlayParticles(List<GameObject> zombielist)
    {
        if (slider.value == slider.maxValue){
            particleSystem.Play();
            PlayParticles(zombielist);
        
        // Überprüfe, ob die ParticleSystem-Komponente vorhanden ist und nicht bereits abgespielt wird
        if (particleSystem != null && !particleSystem.isPlaying)
        {
            // Starte das Partikelsystem
            particleSystem.Play();
        }
        slider.value = 0;

        foreach (GameObject obj in zombielist)
        {
            Destroy(obj);
        }

        zombielist.Clear();
        }
    }

    public void StopParticleSystem()
    {
        // Überprüfe, ob die ParticleSystem-Komponente vorhanden ist und abgespielt wird
        if (particleSystem != null && particleSystem.isPlaying)
        {
            // Stoppe das Partikelsystem
            particleSystem.loop = false;
            particleSystem.Pause();
        }
    }

    private void OnSliderValueChanged(float value)
    {
        // Hier können Sie den Code platzieren, der bei Änderungen des Slider-Werts ausgeführt werden soll
        Debug.Log("Slider-Wert geändert: " + value);
    }
    public void UseList(List<GameObject> list)
    {
        // Hier kannst du die übergebene Liste verwenden
        foreach (GameObject value in list)
        {
            zombielist.Add(value);
            Debug.Log(value);
        }
    }
}
