using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotAdult : MonoBehaviour
{
    public void AddToGarden(){
        PlayerPrefs.SetInt("Pothos", 1);
        SceneManager.LoadScene("Garden");
    }
}
