using UnityEngine;

public class LevelAssetsPlaced : MonoBehaviour
{
    [SerializeField] GameObject BaseHall;
    [SerializeField] GameObject BaseRoom;
    [SerializeField] GameObject StartLocation;
    [SerializeField] GameObject BlankSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void InstLevel(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == 1)
                {
                    Instantiate(BaseRoom, new Vector3(i * 15, j * 15, 0), Quaternion.identity);
                }
                else if (array[i, j] == 2)
                {
                    GameObject temp = Instantiate(BaseHall, new Vector3(i * 15, j * 15, 0), Quaternion.identity);
                    HallWayHandler tempHandler = temp.GetComponent<HallWayHandler>();
                    if (i - 1 >= 0)
                    {
                        if (array[i - 1, j] != 0)
                        {
                            tempHandler.hasLeftConnection = true;
                            if (array[i - 1, j] == 2)
                            {
                                tempHandler.leftIsHall = true;
                            }
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (array[i, j-1] != 0)
                        {
                            tempHandler.hasDownConnection = true;
                            if (array[i, j-1] == 2)
                            {
                                tempHandler.downIsHall = true;
                            }
                        }
                    }
                    if (i + 1 < array.GetLength(0))
                    {
                        if (array[i + 1, j] != 0)
                        {
                            tempHandler.hasRightConnection = true;
                            if (array[i+1, j] == 2)
                            {
                                tempHandler.rightIsHall = true;
                            }
                        }
                    }
                    if (j + 1 < array.GetLength(1))
                    {
                        if (array[i, j + 1] != 0)
                        {
                            tempHandler.hasUpConnection = true;
                            if (array[i, j + 1] == 2)
                            {
                                tempHandler.upIsHall = true;
                            }
                        }
                    }
                    tempHandler.EnablePieces();
                }
                else if (array[i, j] == 3)
                {
                    Instantiate(StartLocation, new Vector3(i * 15, j * 15, 0), Quaternion.identity);
                }
                else if (array[i, j] == 0)
                {
                    Instantiate(BlankSpace, new Vector3(i * 15, j * 15, 0), Quaternion.identity);
                }

            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
