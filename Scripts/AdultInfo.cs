using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdultInfo : MonoBehaviour
{
    public void AddToGarden(){
        PlayerPrefs.SetInt("Tomato", 1);
        SceneManager.LoadScene("Garden");
    }

    public void ReturnToGarden(){
        SceneManager.LoadScene("Garden");
    }

}
