using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    private AudioSource audioSource;
    [SerializeField] private GameObject explosionEffect; 
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (explosionEffect == null)
        {
            //Debug.LogError("Explosion Effect is NOT assigned!");
        }
        else
        {
            //Debug.Log("Explosion Effect is assigned: " + explosionEffect.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Enemy")) {

            if (explosionSound != null) {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }
            if (explosionEffect != null)
            {
                //Debug.Log("Spawning explosion effect!");
                Quaternion effectRotation = Quaternion.Euler(-120,0,0);

                GameObject explosion = Instantiate(explosionEffect, collision.transform.position, effectRotation);

                // Optional: Destroy the effect after a certain time to prevent clutter
                Destroy(explosion, 1f);
            }

            // update the GameManager
            GameManager.Instance.AddToScore(1);
            Destroy(collision.gameObject);  // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet

        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
       

    }
}
