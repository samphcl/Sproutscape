using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Gardener gardener;
    
    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.A)){
            movement += new Vector3(-1, 0, 0);
        }if (Input.GetKey(KeyCode.LeftArrow)){
            movement += new Vector3(-1, 0, 0);
        }if (Input.GetKey(KeyCode.D)){
            movement += new Vector3(1, 0, 0);
        }if (Input.GetKey(KeyCode.RightArrow)){
            movement += new Vector3(1, 0, 0);
        }
        
        gardener.Move(movement);
        //Debug.Log("Gardener's Position: " + gardener.transform.position);
    }
}
