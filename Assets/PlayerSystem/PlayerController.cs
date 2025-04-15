using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] LineOfSight losScript;
    float xVel;
    float yVel;
    [SerializeField] float moveSpeed;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(this.transform.position.x + xVel * moveSpeed, this.transform.position.y + yVel*moveSpeed,0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            yVel = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            yVel = -1;
        }
      
        if (Input.GetKeyDown(KeyCode.A))
        {
            xVel = -1;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            xVel = 1;
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            yVel = 0;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            yVel = 0;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            xVel = 0;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            xVel = 0;
        }





        losScript.SetAimDir((Input.mousePosition - new Vector3(Screen.width/2,Screen.height/2,0)).normalized);
        losScript.SetStartPos(transform.position);
    }
}
