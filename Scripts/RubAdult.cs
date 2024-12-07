using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubAdult : MonoBehaviour
{
    public void AddToGarden(){
        PlayerPrefs.SetInt("Rubber", 1);
        SceneManager.LoadScene("Garden");
    }

    public void ReturnToGarden(){
        SceneManager.LoadScene("Garden");
    }
}
