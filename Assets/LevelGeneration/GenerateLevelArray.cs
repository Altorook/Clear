
using System;
using UnityEngine;

public class GenerateLevelArray : MonoBehaviour
{
    private int[,] LevelArray = new int[25, 25];
    [SerializeField] int inputSeed;
    [SerializeField] bool useSeed;
    [SerializeField] public int thisSeed;
    [SerializeField] LevelAssetsPlaced placeAssets;
    int currentX = 12;
    int currentY = 12;
    int genAttempts = 0;
    int genMax = 500;
    int roomsMade = 0;
    int roomMax = 20;
    int failedAttempts = 0;
    int failedMax = 5;
    public enum RoomType
    {
        Blank = 0,
        Basic = 1,
        Hallway = 2,
        StartLocation = 3

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (useSeed)
        {
            UnityEngine.Random.InitState(inputSeed);
            thisSeed = inputSeed;
        }
        else
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
            int randSeed = UnityEngine.Random.Range(0, 100000);
            thisSeed = randSeed;
            UnityEngine.Random.InitState(randSeed);
        }
        CreateLevelArray();
    }
    public void CreateLevelArray()
    {
        LevelArray[LevelArray.GetLength(0) /2,LevelArray.GetLength(1)-1] = (int)RoomType.StartLocation;
        Debug.Log(LevelArray[LevelArray.GetLength(0) / 2, LevelArray.GetLength(1) - 1]);
        currentX = LevelArray.GetLength(0) / 2;
        currentY = LevelArray.GetLength(1) - 1;
        bool isFirstGen = true;
        do
        {
            if (isFirstGen)
            {
               // currentX--;
                AssignRoomType(false,false);
                isFirstGen = false;
            }
            else
            {
                int tempRand = UnityEngine.Random.Range(0, 4);
                if(tempRand == 0)
                {
                    if(currentX+1 < LevelArray.GetLength(0))
                    {
                        if (LevelArray[currentX+1,currentY] == 0)
                        {
                           // currentX++;
                            AssignRoomType(false,true);
                        }
                    }
                }
                else if(tempRand == 1)
                {
                    if (currentX - 1 >=0)
                    {
                        if (LevelArray[currentX - 1, currentY] == 0)
                        {
                           // currentX--;
                            AssignRoomType(false,false);
                        }
                    }
                }
                else if(tempRand == 2)
                {
                    if (currentY + 1 < LevelArray.GetLength(1))
                    {
                        if (LevelArray[currentX , currentY +1] == 0)
                        {
                           // currentY++;
                            AssignRoomType(true,true);
                        }
                    }
                }
                else if(tempRand == 3)
                {
                    if (currentY - 1 >=0)
                    {
                        if (LevelArray[currentX, currentY -1] == 0)
                        {
                            //currentY--;
                            AssignRoomType(true,false);
                        }
                    }
                }
            }
            genAttempts++;
        } while (roomsMade < roomMax/3 && genAttempts < genMax);

        currentX = LevelArray.GetLength(0) / 2;
        currentY = LevelArray.GetLength(1) - 1;
        do
        {
            if (isFirstGen)
            {
                // currentX--;
                AssignRoomType(false, true);
                isFirstGen = false;
            }
            else
            {
                int tempRand = UnityEngine.Random.Range(0, 4);
                if (tempRand == 0)
                {
                    if (currentX + 1 < LevelArray.GetLength(0))
                    {
                        if (LevelArray[currentX + 1, currentY] == 0)
                        {
                            // currentX++;
                            AssignRoomType(false, true);
                        }
                    }
                }
                else if (tempRand == 1)
                {
                    if (currentX - 1 >= 0)
                    {
                        if (LevelArray[currentX - 1, currentY] == 0)
                        {
                            // currentX--;
                            AssignRoomType(false, false);
                        }
                    }
                }
                else if (tempRand == 2)
                {
                    if (currentY + 1 < LevelArray.GetLength(1))
                    {
                        if (LevelArray[currentX, currentY + 1] == 0)
                        {
                            // currentY++;
                            AssignRoomType(true, true);
                        }
                    }
                }
                else if (tempRand == 3)
                {
                    if (currentY - 1 >= 0)
                    {
                        if (LevelArray[currentX, currentY - 1] == 0)
                        {
                            //currentY--;
                            AssignRoomType(true, false);
                        }
                    }
                }
            }
            genAttempts++;
        } while (roomsMade < (roomMax/3)*2 && genAttempts < genMax);
        currentX = LevelArray.GetLength(0) / 2;
        currentY = LevelArray.GetLength(1) - 1;
        do
        {
            if (isFirstGen)
            {
                // currentX--;
                AssignRoomType(true, false) ;
                isFirstGen = false;
            }
            else
            {
                int tempRand = UnityEngine.Random.Range(0, 4);
                if (tempRand == 0)
                {
                    if (currentX + 1 < LevelArray.GetLength(0))
                    {
                        if (LevelArray[currentX + 1, currentY] == 0)
                        {
                            // currentX++;
                            AssignRoomType(false, true);
                        }
                    }
                }
                else if (tempRand == 1)
                {
                    if (currentX - 1 >= 0)
                    {
                        if (LevelArray[currentX - 1, currentY] == 0)
                        {
                            // currentX--;
                            AssignRoomType(false, false);
                        }
                    }
                }
                else if (tempRand == 2)
                {
                    if (currentY + 1 < LevelArray.GetLength(1))
                    {
                        if (LevelArray[currentX, currentY + 1] == 0)
                        {
                            // currentY++;
                            AssignRoomType(true, true);
                        }
                    }
                }
                else if (tempRand == 3)
                {
                    if (currentY - 1 >= 0)
                    {
                        if (LevelArray[currentX, currentY - 1] == 0)
                        {
                            //currentY--;
                            AssignRoomType(true, false);
                        }
                    }
                }
            }
            genAttempts++;
        } while (roomsMade < roomMax && genAttempts < genMax);
        if(roomsMade < roomMax / 2 && failedAttempts < failedMax)
        {
            roomsMade = 0;
            genAttempts=0;
            for (int i = 0; i < LevelArray.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < LevelArray.GetLength(1) - 1; j++)
                {
                    LevelArray[i, j] = 0;  
                }
            }
            failedAttempts++;
            CreateLevelArray();
            }
        else
        {
            placeAssets.InstLevel(LevelArray);
        }
      
        /*for(int i=0; i< LevelArray.GetLength(0)-1;  i++)
        {
            string lineString = "";
            for(int j = 0; j< LevelArray.GetLength(1)-1; j++)
            {
                lineString += LevelArray[i, j].ToString();
            }
            Debug.Log(lineString);
        }*/
    }
    public void AssignRoomType(bool isYAxis, bool isAdd)
    {
        
        int tempRand = UnityEngine.Random.Range(0, 3);
        if (tempRand == 0)
        {

            return;
        }
        else if (tempRand == 1)
        {
            if (isYAxis)
            {
                if (isAdd)
                {
                    currentY++;
                }
                else
                {
                    currentY--;
                }
            }
            else
            {
                if (isAdd)
                {
                    currentX++;
                }
                else
                {
                    currentX--;
                }
            }
            LevelArray[currentX, currentY] = (int)RoomType.Basic;
            roomsMade++;
        }
        else if (tempRand == 2)
        {
            if (isYAxis)
            {
                if (isAdd)
                {
                    currentY++;
                }
                else
                {
                    currentY--;
                }
            }
            else
            {
                if (isAdd)
                {
                    currentX++;
                }
                else
                {
                    currentX--;
                }
            }
            LevelArray[currentX, currentY] = (int)RoomType.Hallway;
           // roomsMade++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
