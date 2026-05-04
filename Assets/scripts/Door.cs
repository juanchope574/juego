using UnityEngine;

public class Door : MonoBehaviour
{
    public void OpenDoor()
    {
        Debug.Log("Door Opened");
        gameObject.SetActive(false);
    }
}