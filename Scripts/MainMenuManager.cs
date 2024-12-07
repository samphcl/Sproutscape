using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{   
    public AudioSource[] sources;
    public AudioSource click;

    void Start(){
        sources = GetComponents<AudioSource>();
        click = sources[0];
    }
    public void startGame(){
        click.Play();
        SceneManager.LoadScene("Seedling");
    }

    public void exitGame(){
        click.Play();
        Application.Quit();
    }
}
