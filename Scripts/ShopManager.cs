using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{   
    public AudioSource click;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public int Tom = 0;
    public int Pot = 0;
    public int Rub = 0;
    // Start is called before the first frame update
    void Start()
    {   

        click = GetComponent<AudioSource>();

        Tom = PlayerPrefs.GetInt("Tomato", 0);
        Pot = PlayerPrefs.GetInt("Pothos", 0);
        Rub = PlayerPrefs.GetInt("Rub", 0);

        Debug.Log(Tom + Pot + Rub);

        if(Tom == 0){
            btn1.SetActive(false);
        } 
        if(Rub == 0){
            btn2.SetActive(false);
        }
        if(Pot == 0){
            btn3.SetActive(false);
        }
    }

    public void getTomPlant(){
        click.Play();
        PlayerPrefs.SetInt("Tomato", 1);
        SceneManager.LoadScene("TomatoSeedling");
    }

    public void getRubPlant(){
        click.Play();
        PlayerPrefs.SetInt("Rubber", 1);
        SceneManager.LoadScene("RubSeedling");
    }

    public void getPotPlant(){
        click.Play();
        PlayerPrefs.SetInt("Pothos", 1);
        SceneManager.LoadScene("PotSeedling");
    }

    public void ReturnToGarden(){
        click.Play();
        SceneManager.LoadScene("Garden");
    }

}
