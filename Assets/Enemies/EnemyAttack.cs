using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float timePlayerSeen = 0;
    [SerializeField] float timeTillKill;
    [SerializeField] KillPlayer soKill;
    Transform enemyTransform;
    void Start()
    {
        enemyTransform = this.transform.parent.GetComponent<Transform>();
    }
    [SerializeField] LayerMask lmEnemy;
    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            enemyTransform.rotation = Quaternion.Euler(0, 0, VectorToAngle((collision.transform.position - enemyTransform.position).normalized));
            RaycastHit2D ray = Physics2D.Raycast(this.transform.position, collision.transform.position - transform.position, 20,lmEnemy);
            if (ray.collider.gameObject.layer == 3)
            {
               
                timePlayerSeen += Time.deltaTime;
                if(timePlayerSeen > timeTillKill)
                {
                    soKill.isPlayerDead = true;
                }
            }
            else
            {
                timePlayerSeen = 0;
            }
        }
    }
    public void OnTriggerLeave(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            timePlayerSeen = 0;
        }
    }
    public float VectorToAngle(Vector3 vect)
    {
        vect = vect.normalized;
        float thisAng = Mathf.Atan2(vect.y, vect.x) * Mathf.Rad2Deg;
        if (thisAng < 0)
        {
            thisAng += 360;
        }
        return thisAng;
    }
}
