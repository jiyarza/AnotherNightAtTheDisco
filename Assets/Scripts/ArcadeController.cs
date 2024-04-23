using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArcadeController : MonoBehaviour, Interactable
{
    public Entity Entity;
    public Camera arcadeCamera;
    private Camera[] allCameras;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        allCameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
    }

    public void Interact()
    {
        EnterArcadeMachine();
    }

    private void EnterArcadeMachine()
    {
        playerController.enabled = false;
        SwitchCamera(arcadeCamera);
    }

    public void ExitArcadeMachine()
    {
        SwitchCamera(Camera.main);
        playerController.enabled = true;
    }

    void SwitchCamera(Camera newCamera)
    {
        // Desactivar todas las cámaras
        //Camera.main.gameObject.SetActive(false);
        foreach (Camera cam in allCameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Activar la cámara seleccionada
        newCamera.gameObject.SetActive(true);
    }

}
