using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemiesInScene enemiesInScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetEISScript(EnemiesInScene eis)
    {
        enemiesInScene = eis;
    }
    public void Kill()
    {
        enemiesInScene.IncrementKills();
        Destroy(this.gameObject);
    }
    public void OnDestroy()
    {
        
    }
}
