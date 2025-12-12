using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Referências")]
    public Transform playerBody; // o corpo inteiro do player

    [Header("Configurações")]
    public float mouseSensitivity = 350f;
    public float verticalLimit = 85f; // trava o olhar para cima/baixo

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotação vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLimit, verticalLimit);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotação horizontal
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
