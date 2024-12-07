using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weeder : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public Transform hitPoint; // Point where the player "hits"
    public float hitRadius = 0.5f; // Radius of hit detection 
    public LayerMask weedLayer; // Layer assigned to weeds
    [SerializeField] GameManager gm;
    public GameObject whackAnim;
    public GameObject Gardener;
    public AudioSource[] sources;
    public AudioSource hit;

    void Update()
    {
        // Move player left and right
        sources = GetComponents<AudioSource>();
        hit = sources[1];
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Check for spacebar press to "whack"
        if (Input.GetKey(KeyCode.Space)){
            Whack();
            hit.Play();
        }
    }

    void Whack(){

        
        // check for weeds in front of player
        Collider2D hit = Physics2D.OverlapCircle(hitPoint.position, hitRadius, weedLayer);

        if (hit != null){
            
            StartCoroutine(ActivateDeactivate());
            // Destroy weed and notify the GameManager
            gm.WhackAWeed();
            Destroy(hit.gameObject);

        }
    }

    IEnumerator ActivateDeactivate(){

        whackAnim.SetActive(true);
        Gardener.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        whackAnim.SetActive(false);
        Gardener.SetActive(true);
        
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, hitRadius);
    }
}
