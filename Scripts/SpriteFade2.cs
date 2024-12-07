using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteFade2 : MonoBehaviour
{
    [SerializeField] GameObject plant;
    private SpriteRenderer spriteRenderer; 
    [SerializeField] Sprite newSprite; // The sprite you want to fade into
    [SerializeField] Sprite teenShadow; // The sprite you want to fade into
    [SerializeField] Sprite teenSprite; // The sprite you want to fade into
    public float fadeDuration = 4f; // Duration of the fade

    [SerializeField] GameObject buttonHolder;
    [SerializeField] GameObject buttonHolder1;
    [SerializeField] GameObject buttonHolder2;
    [SerializeField] TextMeshProUGUI something;

    void Start()
    {
        spriteRenderer = plant.GetComponent<SpriteRenderer>();
        // Start the fade process
        StartCoroutine(FadeToSprite(newSprite, fadeDuration, 0));
    }

    private IEnumerator FadeToSprite(Sprite newSprite, float duration, int time)
    {
        // Cache the original color and scale
        Color originalColor = spriteRenderer.color;
        Vector3 originalScale = spriteRenderer.transform.localScale;

        // Create a temporary object to hold the new sprite
        GameObject tempObject = new GameObject("TempSprite");
        SpriteRenderer tempRenderer = tempObject.AddComponent<SpriteRenderer>();
        tempRenderer.sprite = newSprite;
        tempRenderer.sortingLayerID = spriteRenderer.sortingLayerID;
        tempRenderer.sortingOrder = spriteRenderer.sortingOrder;

        // Position and scale the new sprite to match the old one
        tempObject.transform.position = spriteRenderer.transform.position;
        tempObject.transform.localScale = spriteRenderer.transform.localScale;

        // Set the initial transparency of the new sprite to 0
        Color tempColor = tempRenderer.color;
        tempColor.a = 0;
        tempRenderer.color = tempColor;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // Gradually fade out the original sprite
            Color fadeOutColor = originalColor;
            fadeOutColor.a = Mathf.Lerp(1f, 0f, t);
            spriteRenderer.color = fadeOutColor;

            // Gradually fade in the new sprite
            Color fadeInColor = tempColor;
            fadeInColor.a = Mathf.Lerp(0f, 1f, t);
            tempRenderer.color = fadeInColor;

            yield return null;
        }

        // Finalize the transition
        spriteRenderer.sprite = newSprite; // Set the new sprite
        spriteRenderer.color = originalColor; // Restore full opacity
        spriteRenderer.transform.localScale = originalScale; // Ensure the scale matches
        Destroy(tempObject); // Clean up the temporary object
        if(time == 0){
           buttonHolder.SetActive(true); 
        } else if(time == 1){
            buttonHolder.SetActive(false);
            buttonHolder1.SetActive(true);
        } else if(time == 2){
            buttonHolder1.SetActive(false);
            something.text = "Congrats! Your plant has grown into an adult.";
            buttonHolder2.SetActive(true);
        }
        
    }

    public void Continue(){
        StartCoroutine(FadeToSprite(teenShadow, fadeDuration, 1));
    }

    public void ContinueAgain(){
        StartCoroutine(FadeToSprite(teenSprite, fadeDuration, 2));
    }

    public void ContinueAgainAgain(){

        string next = PlayerPrefs.GetString("Next", "");

        Debug.Log(next);

        if(next == "Tom"){
            SceneManager.LoadScene("TomatoAdult");
        } else if(next == "Pot"){
            SceneManager.LoadScene("PotAdult");
        } else if(next == "Rub"){
            SceneManager.LoadScene("RubAdult");
        }
    }
}
