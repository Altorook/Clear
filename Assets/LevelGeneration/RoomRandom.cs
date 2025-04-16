using UnityEngine;

public class RoomRandom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject enemyPrefab;
    void Start()
    {
        
    }
    public int RandomObstacle(int seed)
    {
        Random.InitState(seed);
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 4) != 1)
            {
                obstacles[i].SetActive(false);
            }
        }
        return Random.Range(0, 100000);
    }
    public int RandomEnemySpawn(int seed, EnemiesInScene script)
    {
        Random.InitState(seed);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 6) == 1)
            {
                GameObject tempEnemy = Instantiate(enemyPrefab, spawnPoints[i].transform.position, Quaternion.identity);
                if(tempEnemy.GetComponent<EnemyManager>() != null)
                {
                    tempEnemy.GetComponent<EnemyManager>().SetEISScript(script);
                }
                script.IncrementEnemies();
            }
        }
        return Random.Range(0, 100000);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
