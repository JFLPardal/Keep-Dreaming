using UnityEngine;

public class EnemyLoader : MonoBehaviour
{
    [SerializeField] GameObject[] roomObjects;
    [SerializeField] int[] numberOfEnemiesPerRoom;
    [SerializeField] int numberOfRooms = 3;

    public static int numberOfEnemiesAlive;
    public static int currentRoomNumber = 0;
    public static bool isRoomClear = false;
    private static bool isLastRoom = false;

    public void EnemyDied()
    {
        if(--numberOfEnemiesAlive <= 0)
        {
            isRoomClear = true;
        }
    }
    
    public bool IsLastRoom()
    {
        return isLastRoom;
    }

    public void PlayerEnteredNewRoom()
    {
        roomObjects[currentRoomNumber].SetActive(false);
        currentRoomNumber++;
        isRoomClear = false;
        roomObjects[currentRoomNumber].SetActive(true);
        numberOfEnemiesAlive = numberOfEnemiesPerRoom[currentRoomNumber];
    }
}
