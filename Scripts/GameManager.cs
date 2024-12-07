using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject weedPrefab; 
    public Transform[] holes; // Array of hole positions
    public bool[] holeOccupied;
    public int weedsToWin = 5;
    public int weedsCaught = 0;
    public int score = 0;
    public float spawnTime = 2f;
    public float hideTime = 2f;
    [SerializeField] TextMeshProUGUI weedCounter;
    [SerializeField] TextMeshProUGUI timer;
    public float timeLeft = 18f;
    public float maxTime = 18f;

    public float startTime;
    private GameObject[] weeds = new GameObject[5];



    void Start(){
        startTime = Time.time;
        timeLeft = Mathf.Max(0, timeLeft);

        weedsCaught = PlayerPrefs.GetInt("CurrentWeeds", 0);

        holeOccupied = new bool[5];
        holeOccupied[0] = false;
        holeOccupied[1] = false;
        holeOccupied[2] = false;
        holeOccupied[3] = false;
        holeOccupied[4] = false;

        GrowWeed(0);
        GrowWeed(1);
        GrowWeed(2);
        GrowWeed(3);
        GrowWeed(4);
    }
    

    void FixedUpdate()
    {   
        timeLeft = maxTime - Mathf.Round(Time.time - startTime);
        timer.text = timeLeft.ToString();

        weedCounter.text = score.ToString();

        if(timeLeft <= 0f ){
            GameDone();
        }

        spawnTime -= Time.deltaTime;
        hideTime -= Time.deltaTime;

        int i = UnityEngine.Random.Range(0,3);
        int j = UnityEngine.Random.Range(3,5);
        

        if(holeOccupied[i] == false && spawnTime <= 0f){
            GrowWeed(i);
            spawnTime = 1f;
        }else if(holeOccupied[i] == true && hideTime <= 0f){
            hideTime = 2f;
            HideWeed(i);
        }

        if(holeOccupied[j] == false && spawnTime <= 0f){
            GrowWeed(j);
            spawnTime = 1f;
        }else if(holeOccupied[j] == true && hideTime <= 0f){
            hideTime = 2f;
            HideWeed(j);
        }
        

    }

    public void GrowWeed(int i){
        Vector3 spawnPosition = holes[i].position;
        spawnPosition.y += 1f;  // Increase the y value by 1 unit (or any value you want)
        GameObject newWeed = Instantiate(weedPrefab, spawnPosition, Quaternion.identity);
        weeds[i] = newWeed;
        Debug.Log("New Weed!");
        holeOccupied[i] = true;
    }

    public void HideWeed(int i){
        if(weeds[i] != null){
            holeOccupied[i] = false;
            GameObject newWeed = weeds[i];
            weeds[i] = null;
            Destroy(newWeed);
        }
        
    }

    public void WhackAWeed(){
        score++;
    }

    public void GameDone(){
        int weedsWhacked = weedsCaught + score;
        Debug.Log("Total weeds whacked: " + weedsWhacked);
        PlayerPrefs.SetInt("TotalWeedsCaught", weedsWhacked );

        string next = PlayerPrefs.GetString("Next", "");
        if(next == "Tom"){
            SceneManager.LoadScene("TomatoTeen");
        } else if(next == "Pot"){
            SceneManager.LoadScene("PotTeen");
        } else if(next == "Rub"){
            SceneManager.LoadScene("RubTeen");
        }
        
        Debug.Log("Time's up!");
    }

    public Transform[] ReturnHoles(){
        return this.holes;
    }
    

}
