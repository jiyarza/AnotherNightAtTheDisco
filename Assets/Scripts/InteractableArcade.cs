using UnityEngine;

public class InteractableArcade : MonoBehaviour
{
    public Entity Entity;
    public GameObject arcadeRoot;
    public Camera arcadeCamera;
    private Camera[] allCameras;
    private PlayerController playerController;

    private Color color;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        allCameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);

        color = GetComponent<Renderer>().material.color;
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

    public virtual void Contact()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public virtual void ContactLost()
    {
        GetComponent<Renderer>().material.color = color;
    }
}
