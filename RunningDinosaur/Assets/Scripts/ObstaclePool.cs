using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public GameObject obstaclePrefab;

    [SerializeField]
    private int obstaclePoolSize = 5;
    [SerializeField]
    private float spawnRate;
    [SerializeField]

    private GameObject[] obstacles;
    private float lastSpawnedTimer = 0;
    private float spawnPosX = 11;
    private float spawnPosY = -2.1f;
    private int currentObstacleIndex = 0;
    

	// Use this for initialization
	void Start () {
        spawnRate = Random.Range(0.8f, 2.1f);
        obstacles = new GameObject[obstaclePoolSize];
        for (int i = 0; i < obstacles.Length; i++) {
            obstacles[i] = Instantiate(obstaclePrefab, new Vector2(20, 20), Quaternion.identity) as GameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        lastSpawnedTimer += Time.deltaTime;

        for (int i = 0; i < obstacles.Length; i++) {
            obstacles[i].transform.Translate(GameManager.instance.scrollSpeed * Vector3.left * Time.deltaTime);
        }

        if (lastSpawnedTimer > spawnRate) {
            lastSpawnedTimer = 0;
            obstacles[currentObstacleIndex].transform.position = new Vector2(spawnPosX, spawnPosY);
            currentObstacleIndex++;
            if(currentObstacleIndex >= obstaclePoolSize) {
                currentObstacleIndex = 0;
            }
            spawnRate = Random.Range(0.8f, 2.1f);
        }
	}
}
