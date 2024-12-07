using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TomatoInfo : MonoBehaviour
{
        public int waterMeter;
    [SerializeField] int waterMax = 30;
    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] WaterTransition waterTransition;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject reached;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {   
        waterMeter = PlayerPrefs.GetInt("TotalWater", 0);
        Debug.Log("Water Meter: " + waterMeter);

        initialScale = new Vector3((float)454.04, (float)254.11, (float)245.45);
        Debug.Log(initialScale);
        
        waterText.text = waterMeter.ToString() + "/30";

        if(waterMeter >= waterMax){
            instructions.SetActive(false);
            reached.SetActive(true);
        }

    }

    public void onButtonClick(){
        PlayerPrefs.SetString("Return", "Tom");
        waterTransition.StartTransition();
        //SceneManager.LoadScene("Water Drop Balance");
    }

    public void growPlant(){
        PlayerPrefs.SetString("Next", "Tom");
        SceneManager.LoadScene("TomatoBabyToTeen");
    }

     void Update()
    {
        PlayerPrefs.SetInt("CurrentWater", waterMeter);
    }
}
