using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaterTransition : MonoBehaviour
{
    [SerializeField] private GameObject waterObject; // Reference to the water image UI component
    [SerializeField] private float slideSpeed = 500f; // Speed at which the water image slides down
    [SerializeField] private string targetScene = "WaterDropBalance";
    [SerializeField] Camera MainCamera;

    private bool isTransitioning = false;
    public Vector3 cameraPosition;

    public void Start(){
        cameraPosition = MainCamera.transform.position;
        // Set the GameObject's position directly above the camera
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y + 10f, cameraPosition.z);

    }
    // Method to start the water slide transition
    public void StartTransition()
    {
        Debug.Log("Wave Incoming");
        if (!isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(SlideWaterDown());
        }
    }

    // Coroutine to slide the water image down and load the next scene
    private IEnumerator SlideWaterDown()
    {
        Debug.Log("Water transition starting...");
        // Get the current position of the water GameObject
        Vector3 startPosition = waterObject.transform.position;
        
        // Calculate the target position (below the camera)
        //Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 targetPosition = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z);

        Debug.Log(waterObject.transform.position.y);
        Debug.Log(cameraPosition.y);

        // Move the water GameObject down to reveal the next scene
        while (waterObject.transform.position.y > cameraPosition.y)
        {
            //Debug.Log("Water falling...");
            waterObject.transform.position += Vector3.down * slideSpeed * Time.deltaTime;
            yield return null; // Wait until the next frame
        }


        Debug.Log("Transition finished");
        // Load the target scene once the transition is complete
        SceneManager.LoadScene(targetScene);
    }
}

