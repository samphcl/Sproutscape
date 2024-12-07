using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeedlingManager : MonoBehaviour
{
    public GameObject[] objectsToPop;
    public AudioSource[] sources;
    public AudioSource whoosh;
    public AudioSource click;
    public float delayBetweenPops = 1f;
    [SerializeField] GameObject hello;
    [SerializeField] GameObject pick;
    [SerializeField] GameObject cont;

    public void StartPopSequence(){
        StartCoroutine(PopPopPop());
        click.Play();
    }

    void Start(){
        sources = GetComponents<AudioSource>();
        whoosh = sources[0];
        click = sources[2];

        PlayerPrefs.SetInt("Tomato", 0);
        PlayerPrefs.SetInt("Pothos", 0);
        PlayerPrefs.SetInt("Ruber", 0);
    }

    private IEnumerator PopPopPop(){
        hello.SetActive(false);
        cont.SetActive(false);
        for(int i = 0; i < objectsToPop.Length; i++){
            if(objectsToPop[i] != null){
                objectsToPop[i].SetActive(true); //Activate object
                whoosh.Play();
                Debug.Log("Popped object: " + objectsToPop[i].name);
                yield return new WaitForSeconds(delayBetweenPops); // Wait for the delay
            }
        }
    }

    public void StartTomato(){
        PlayerPrefs.SetInt("TotalWater", 0);
        PlayerPrefs.SetString("Next", "Tom");
        SceneManager.LoadScene("TomatoSeedling");
    }

    public void startPothos(){
        PlayerPrefs.SetInt("TotalWater", 0);
        PlayerPrefs.SetString("Next", "Pot");
        SceneManager.LoadScene("PotSeedling");
    }

    public void StartRubber(){
        PlayerPrefs.SetInt("TotalWater", 0);
        PlayerPrefs.SetString("Next", "Rub");
        SceneManager.LoadScene("RubSeedling");
    }

}
