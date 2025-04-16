using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesInScene : MonoBehaviour
{
    int enemiesInScene;
    int kills;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementEnemies()
    {
        enemiesInScene++;
        Debug.Log(enemiesInScene);
    }
    public void IncrementKills()
    {
        kills++;
        Debug.Log(kills);
        if(kills >= enemiesInScene)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
