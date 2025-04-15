using UnityEngine;

public class HallWayHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool hasUpConnection;
    public bool hasDownConnection;
    public bool hasLeftConnection;
    public bool hasRightConnection;
    [SerializeField] GameObject upPiece;
    [SerializeField] GameObject downPiece;
    [SerializeField] GameObject leftPiece;
    [SerializeField] GameObject rightPiece;


    public bool upIsHall;
    public bool downIsHall;
    public bool leftIsHall;
    public bool rightIsHall;
    [SerializeField] GameObject upDoor;
    [SerializeField] GameObject downDoor;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    void Start()
    {
        
    }
    public void EnablePieces()
    {
        if (hasUpConnection)
        {
            upPiece.SetActive(true);
        }
        if (hasDownConnection)
        {
            downPiece.SetActive(true);
        }
        if (hasLeftConnection)
        {
            leftPiece.SetActive(true);
        }
        if (hasRightConnection)
        {
            rightPiece.SetActive(true);
        }

        if(!upIsHall)
        {
            upDoor.SetActive(true);
        }
        if(!downIsHall)
        {
            downDoor.SetActive(true);
        }
        if (!leftIsHall)
        {
            leftDoor.SetActive(true);
        }
        if(!rightIsHall) { rightDoor.SetActive(true); }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
