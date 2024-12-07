using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GardenManager : MonoBehaviour
{
    // Start is called before the first frame update
    int Tomato; 
    int Pothos; 
    int Rubber;
    public GameObject tom;
    public GameObject pot;
    public GameObject rub;


    void Start()
    {
        Tomato = PlayerPrefs.GetInt("Tomato", 0);
        Pothos = PlayerPrefs.GetInt("Pothos", 0);
        Rubber = PlayerPrefs.GetInt("Rubber", 0);

        if(Rubber == 1){
            rub.SetActive(true);
        }
        if(Tomato == 1){
            tom.SetActive(true);
        }
        if(Pothos == 1){
            pot.SetActive(true);
        }
    }

    public void GetTom(){
        SceneManager.LoadScene("TomProfile");
    }

    public void GetPot(){
        SceneManager.LoadScene("PotProfile");
    }

    public void GetRub(){
        SceneManager.LoadScene("RubProfile");
    }

    public void ExitGame(){
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenShop(){
        SceneManager.LoadScene("Shop");
    }

}

