using UnityEngine;
using Cinemachine;

public class RotateCameraAroundPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform playerTransform;
    public float rotationSpeed = 5f;

    private Transform followTarget;
    private Transform lookAtTarget;
    private bool isRotating = false;

    void Start()
    {
        followTarget = virtualCamera.Follow;
        lookAtTarget = virtualCamera.LookAt;
    }

    void Update()
    {
        isRotating = Input.GetMouseButton(2);

        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X");

            // Rotar la cámara horizontalmente alrededor del player
            transform.RotateAround(playerTransform.position, Vector3.up, mouseX * rotationSpeed * Time.deltaTime);

            // Mantener el LookAt sobre el player
            lookAtTarget.position = playerTransform.position;
        }
    }
}