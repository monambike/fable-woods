using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    /// <summary>
    /// The camera used to take the screenshot.
    /// </summary>
    public Camera screenshotCamera;

    /// <summary>
    /// Screenshot width resolution.
    /// </summary>
    [SerializeField] private int widthResolution = 256;

    /// <summary>
    /// Screenshot height resolution.
    /// </summary>
    [SerializeField] private int heightResolution = 256;

    /// <summary>
    /// Path inside Assets folder where the icons will be saved.
    /// </summary>
    [SerializeField] private string relativePath = "Images/InventoryIcons";

    /// <summary>
    /// Takes a screenshot and saves it to the specified path.
    /// </summary>
    /// <param name="fullPath">The full path where the screenshot will be saved.</param>
    [ContextMenu("Take a Screenshot")]
    public void TakeScreenshot()
    {
        // Creating a new RenderTexture with specified resolution and 24-bit depth, and setting it as
        // the camera's target texture.
        var renderTexture = new RenderTexture(widthResolution, heightResolution, 24);
        screenshotCamera.targetTexture = renderTexture;

        // Creating a new Texture2D to store the screenshot.
        var screenshot = new Texture2D(widthResolution, heightResolution, TextureFormat.RGBA32, false);

        // Rendering the camera.
        screenshotCamera.Render();

        // Setting the active render texture to the render texture.
        RenderTexture.active = renderTexture;

        // Reading the pixels from the render texture and storing them in the Texture2D.
        var areaToRender = new Rect(0, 0, widthResolution, heightResolution);
        screenshot.ReadPixels(areaToRender, 0, 0);

        // Resetting camera's target texture and the active render texture.
        ResetCameraAndRenders(renderTexture);

        // Opening a dialog box so the user can choose an output folder.
        string folderPath = $"{Application.dataPath}/{relativePath}";

        var currentDate = DateTime.Now;
        var fileName = $"IMG-{currentDate:yyyyMMdd_HHmmss}.png";

        // Combining the folder path with the file name.
        string filePath = Path.Combine(folderPath, fileName);

        // Encoding the Texture2D to a PNG byte array and writing the byte array to a file at the specified path.
        File.WriteAllBytes(filePath, screenshot.EncodeToPNG());


#if UNITY_EDITOR
        // Refresh the Asset Database in the Unity editor to reflect the new image.
        AssetDatabase.Refresh();
#endif
    }

    /// <summary>
    /// Resets the camera's target texture and the active render texture, and destroys the render texture.
    /// </summary>
    /// <param name="renderTexture">The render texture to be reset and destroyed.</param>
    private void ResetCameraAndRenders(RenderTexture renderTexture)
    {
        // Resetting  the camera's target texture and active render texture.
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;

        // Checking if the application is running in the editor.
        if (Application.isEditor)
            // Immediately destroying the render texture if in the editor.
            DestroyImmediate(renderTexture);
        else
            // Destroying the render texture on the next frame if not in the editor.
            Destroy(renderTexture);
    }
}