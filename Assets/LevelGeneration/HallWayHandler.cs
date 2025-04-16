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

    [SerializeField] GameObject upCol;
    [SerializeField] GameObject downCol;
    [SerializeField] GameObject leftCol;
    [SerializeField] GameObject rightCol;
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
            upCol.SetActive(false);
        }
        if (hasDownConnection)
        {
            downPiece.SetActive(true);
            downCol.SetActive(false);
        }
        if (hasLeftConnection)
        {
            leftPiece.SetActive(true);
            leftCol.SetActive(false);
        }
        if (hasRightConnection)
        {
            rightPiece.SetActive(true);
            rightCol.SetActive(false);
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
