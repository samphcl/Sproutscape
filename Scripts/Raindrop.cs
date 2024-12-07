using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeVelocity(){
        GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-10, -4), 0);
        //Do we want it to move?
    }
}
