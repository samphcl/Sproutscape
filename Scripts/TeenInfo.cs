using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeenInfo : MonoBehaviour
{
    public int weedLevel;
    [SerializeField] int weedMax = 30;
    [SerializeField] TextMeshProUGUI weedText;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject reached;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {   

        weedLevel = PlayerPrefs.GetInt("CurrentWeeds", 0);
        weedLevel += PlayerPrefs.GetInt("TotalWeedsCaught", 0);

        Debug.Log("You collected : " + weedLevel + " weeds.");

        initialScale = new Vector3((float)454.04, (float)254.11, (float)245.45);
        Debug.Log(initialScale);
        
        weedText.text = weedLevel.ToString() + "/" + weedMax.ToString();

        if(weedLevel >= weedMax){
            instructions.SetActive(false);
            reached.SetActive(true);
        }

    }

    public void onButtonClick(){

        SceneManager.LoadScene("WhackAWeed");
    }

    public void growPlant(){

        string next = PlayerPrefs.GetString("Next", "");

        if(next == "Tom"){
            SceneManager.LoadScene("TomatoTeenToAdult");
        } else if(next == "Pot"){
            SceneManager.LoadScene("PotTeenToAdult");
        } else if(next == "Rub"){
            SceneManager.LoadScene("RubTeenToAdult");
        }
        

    }

     void Update()
    {
        PlayerPrefs.SetInt("CurrentWeeds", weedLevel);
    }

}
