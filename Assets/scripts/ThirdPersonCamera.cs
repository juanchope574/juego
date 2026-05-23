using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;

    public float mouseSensitivity = 100f;

    public Vector3 offset = new Vector3(0f, 3f, -6f);

    private float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0f, rotationY, 0f);

        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = desiredPosition;

        transform.LookAt(player.position + Vector3.up * 2f);
    }
}