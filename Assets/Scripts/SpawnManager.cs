using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wall_pf;
    public GameObject enemyPrefab;
    public List<GameObject> obstacleList;
    private GameManager gameManager;

    private float spawnZ = 25;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {
        InvokeRepeating("GenerateWall", 1.0f, 4.0f);
        InvokeRepeating("GenerateEnemy", 2.0f, 2.0f);
    }

    public void GenerateWall()
    {
        if (gameManager.gameOver)
            return;
        GameObject rgo = obstacleList[Random.Range(0, obstacleList.Count)];
        Instantiate(rgo, new Vector3( rgo.transform.position.x, rgo.transform.position.y, spawnZ), rgo.transform.rotation);
    }

    public void GenerateEnemy()
    {
        if (gameManager.gameOver)
            return;
        Instantiate(enemyPrefab, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(0.5f, 4.5f), spawnZ), 
            wall_pf.transform.rotation * Quaternion.Euler(0,180,0));
    }

        public Vector3 makeVectorAtZ(float xRan, float yRan, float z)
    {
        return new Vector3(Random.Range(-xRan,xRan), Random.Range(-yRan, yRan),z);
    }
}
