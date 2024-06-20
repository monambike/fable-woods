using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera ThisCamera;

    public float scrollSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    private void Update()
    {
        HandleCameraZoom();
    }

    private void HandleCameraZoom()
    {
        // Captura o input do scroll do mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Calcula o novo tamanho da c�mera baseado no scroll
        float newSize = Camera.main.orthographicSize - scroll * scrollSpeed;

        // Limita o tamanho da c�mera entre minZoom e maxZoom
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

        // Aplica o novo tamanho � c�mera
        ThisCamera.orthographicSize = newSize;
    }
}