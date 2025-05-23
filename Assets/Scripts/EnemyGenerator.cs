using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class EnemyControler : MonoBehaviour{

    [SerializeField] private GameObject EnemyPrefab;
    private readonly float enemySpawnIntervallTime = 3f;
    private float nextEnemyGenerationTime;
    private float enemyLifeTime;
    private float screenHeight;
    private float screenWidth;
    float leftBoundary;
    float rightBoundary;
    float topBoundary;
    float bottomBoundary;
    private readonly float speed = 1f ; 

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = Camera.main.aspect * screenHeight;

        leftBoundary = -screenWidth + 1f;
        rightBoundary = screenWidth - 1f;

        enemyLifeTime = (2 * screenHeight / speed) + 1;
        


    }





// Update is called once per frame
void Update()

    {

        if (!EnemyPrefab)
        {
            Debug.Log("No enemy prefab attached!");
            return;
        }

        if(Time.time > nextEnemyGenerationTime)
        {
            GameObject enemy = spawnEnemy();
            // add to GameManger
            GameManager.Instance.AddToSpawnedEnemies();
            Destroy(enemy, enemyLifeTime);
            nextEnemyGenerationTime = Time.time + enemySpawnIntervallTime;
        }

        
    }

    private GameObject spawnEnemy()
    {
        float xEnemyPosition = Random.Range(leftBoundary, rightBoundary);
        float yEnemyPosition = screenHeight + 1; // spaw from top of the screen

        Vector3 enemySpawnPosition = new Vector3(xEnemyPosition, yEnemyPosition, 0);
        GameObject enemy = Instantiate(EnemyPrefab, enemySpawnPosition, Quaternion.identity);

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector3.down * speed;

        return enemy;
    }
}
