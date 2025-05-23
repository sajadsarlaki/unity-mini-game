using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip hitBulletSound;

    [SerializeField] private GameObject BulletPrefab;
    float bullet_thrust = 10f;
    float bullet_life_time = 1f;
    float fire_rate = 0.25f;
    float next_fire_time;
    // Start is called before the first frame update
    void Start()
    {
        if (BulletPrefab == null)
        {
            Debug.LogError("PlayerShooting prefab is not assigned in the Inspector!");
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per 
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > next_fire_time)
        {
       

                shoot();
                next_fire_time = Time.time + fire_rate;
            
        }
        
    }

    void shoot()
    {
        if (!BulletPrefab)
        {
            Debug.Log("no shooting!");
            return;
        }
        Vector3 spawningPosition = transform.position;
        spawningPosition.y = spawningPosition.y + 1;


        if (hitBulletSound != null)
        {
            AudioSource.PlayClipAtPoint(hitBulletSound, spawningPosition);
        }
        GameObject bullet =  Instantiate(BulletPrefab, spawningPosition, Quaternion.identity);
        Rigidbody2D bulletRigid = bullet.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.up * bullet_thrust, ForceMode2D.Impulse);
        // add to GameManager
        GameManager.Instance.AddToshootedBullets();

        Destroy(bullet, bullet_life_time);

    }

   
}
