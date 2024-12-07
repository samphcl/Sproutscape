using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gardener : MonoBehaviour
{
    [SerializeField] float speed = 5.0f; 
    [SerializeField] TextMeshProUGUI waterLvl;
    [SerializeField] TextMeshProUGUI time;
    public AudioSource[] sources;
    public AudioSource drop;
    public int waterLevel = 0;
    private float startTime;
    private int currWater = 0;
    private String ret;
    [SerializeField] WaterTransitionDown waterDown;

    void Start(){
        sources = GetComponents<AudioSource>();
        drop = sources[1];
        waterDown.StartTransition();
        startTime = Time.time;
        currWater = PlayerPrefs.GetInt("CurrentWater", 0);
        ret = PlayerPrefs.GetString("Return", "");
    }

    // Update is called once per frame
    void Update()
    {
        waterLvl.text = waterLevel.ToString();
        float timeLeft = 18f - Mathf.Round(Time.time - startTime);
        time.text = timeLeft.ToString();
        if((Time.time - startTime) >= 18f){
            currWater += waterLevel;
            PlayerPrefs.SetInt("TotalWater", currWater);
            waterLevel = 0;

            if(ret == "Tom"){
                SceneManager.LoadScene("TomatoSeedling");
            } else if(ret == "Pot"){
                SceneManager.LoadScene("PotSeedling");
            } else if(ret == "Rub"){
                SceneManager.LoadScene("RubSeedling");
            }

            
        }
    }

    public void Move(Vector3 movement){
        transform.position += speed * Time.deltaTime * movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Raindrop")){
            drop.Play();
            waterLevel++;
            Destroy(other.gameObject);
        }

    }

    public int returnWaterLevel (){
        return waterLevel;
    }

}
