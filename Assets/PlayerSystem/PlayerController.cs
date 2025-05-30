using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] LineOfSight losScript;
    float xVel;
    float yVel;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField]
    LayerMask lmAvoidPlayer;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(xVel * moveSpeed,yVel*moveSpeed,0);
    }
    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            yVel = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yVel = -1;
        }
        else
        {
            yVel = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xVel = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xVel = 1;
        }
        else
        {
            xVel = 0;
        }





        if(Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, Color.red, .5f);
            RaycastHit2D ray = Physics2D.Raycast(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, 40,lmAvoidPlayer);
            if(ray.collider != null)
            {
                if(ray.transform.gameObject.tag == "Enemy")
                {
                    if(ray.transform.gameObject.GetComponent<EnemyManager>() != null)
                    {
                        ray.transform.gameObject.GetComponent<EnemyManager>().Kill();
                    }
                   
                }
                else
                {
                    
                }
            }
        }


        this.transform.GetChild(3).rotation = Quaternion.Euler(0, 0, VectorToAngle((Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)).normalized));

        losScript.SetAimDir((Input.mousePosition - new Vector3(Screen.width/2,Screen.height/2,0)).normalized);
        losScript.SetStartPos(transform.position);
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
