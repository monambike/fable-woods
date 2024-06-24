using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera FarCamera;

    //kldkjfcdksldkslk

    public CinemachineVirtualCamera CloseCamera;

    private CameraTypee currentCamera;

    private Dictionary<CameraTypee, CinemachineVirtualCamera> cameras;

    public enum CameraTypee
    {
        FarCamera,
        CloseCamera
    }

    private void Start()
    {
        // Configuring all the cameras.
        cameras = new()
        {
            { CameraTypee.FarCamera, FarCamera },
            { CameraTypee.CloseCamera, CloseCamera }
        };

        // Disabling all cameras initially.
        foreach (var cameraPair in cameras)
            cameraPair.Value.gameObject.SetActive(false);

        // Setting and enabling the initial active camera.
        currentCamera = CameraTypee.FarCamera;
        cameras[currentCamera].gameObject.SetActive(true);
    }

    public void SwitchCamera(CameraTypee newCamera)
    {
        // Disabling the current active camera.
        cameras[currentCamera].gameObject.SetActive(false);

        // Enabling the new camera.
        cameras[newCamera].gameObject.SetActive(true);

        // Updating current camera to the new camera.
        currentCamera = newCamera;
    }

    public CameraTypee GetSwitchNextCamera()
    {
        return (currentCamera) switch
        {
            CameraTypee.CloseCamera => CameraTypee.FarCamera,
            CameraTypee.FarCamera => CameraTypee.CloseCamera,
            _ => CameraTypee.FarCamera
        };
    }
}