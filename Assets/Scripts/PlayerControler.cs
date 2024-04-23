using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = Vector3.zero;

        if (vertical > 0)
        {
            moveDirection = cameraTransform.forward * vertical;
        }
        else if (vertical < 0)
        {
            moveDirection = -cameraTransform.forward * Mathf.Abs(vertical);
        }
        
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}