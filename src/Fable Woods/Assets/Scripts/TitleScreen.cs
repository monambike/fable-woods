using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public Camera CameraTitle;

    private void Update()
    {
        CameraTitle.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
    }
}