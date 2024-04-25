using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public PlayerAnimation playerAnimation;
    public Transform cameraTransform;
    public Dialog firstDialog;
    public Dialog lastDialog;
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;

    private void Start()
    {
        if (firstDialog == null)
            throw new NullReferenceException(nameof(firstDialog));
        DialogController.Instance.PlayDialog(firstDialog);
        GameClock.onTimeOver.AddListener(OnTimeOver);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Global.contact.Value != null)
            {
                Global.contact.Value.Interact();
            }
        }

        if (characterController.enabled)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDirection = Vector3.zero;

            if (vertical > 0)
            {
                moveDirection = transform.forward * vertical;
            }
            else if (vertical < 0)
            {
                moveDirection = -transform.forward * Mathf.Abs(vertical);
            }

            transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
            if (characterController.gameObject.activeSelf) 
            {
                characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
            }            

            if (moveDirection.magnitude > 0.01f)
            {
                playerAnimation.Walk();
            }
            else
            {
                playerAnimation.Idle();
            }
        }
    }

    public void OnTimeOver()
    {
        Debug.Log("TIME OVER");
        DialogController.Instance.PlayDialog(lastDialog);
    }
}