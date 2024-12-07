using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    [SerializeField] Color defaultColor = Color.white; 
    [SerializeField] Color hoverColor = new Color(81f, 135f, 86f);
    [SerializeField] Color clickColor = Color.blue; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor; 

    }

    // Called when the mouse enters the collider area
    void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor;
    }

    // Called when the mouse leaves the collider area
    void OnMouseExit()
    {
        spriteRenderer.color = defaultColor;
    }

    // Called when the mouse button is pressed down on the object
    void OnMouseDown()
    {
        spriteRenderer.color = clickColor;
        SceneManager.LoadScene("NewScene");
        // Look into having it for each plant?
        // Maybe the scene for the Plant Info is just an overlay of the PLant scene so it doesn't have to keep 
        // passing redundant information
    }

    // Called when the mouse button is released
    void OnMouseUp()
    {
        spriteRenderer.color = hoverColor;
    }
}
