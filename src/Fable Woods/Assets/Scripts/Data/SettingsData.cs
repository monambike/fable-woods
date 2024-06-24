using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "ScriptableObjects/Settings", order = 0)]
public class SettingsData : ScriptableObject
{
    [Header("Audio Settings")]
    [Tooltip("The master volume of the game.")]
    [Range(0f, 1f)]
    public float masterVolume;

    [Tooltip("The music volume of the game.")]
    [Range(0f, 1f)]
    public float musicVolume;

    [Tooltip("The sound effects volume of the game.")]
    [Range(0f, 1f)]
    public float sfxVolume;

    [Header("Graphics Settings")]
    [Tooltip("The resolution width of the game.")]
    public int resolutionWidth;

    [Tooltip("The resolution height of the game.")]
    public int resolutionHeight;

    [Tooltip("The quality level of the game graphics.")]
    public int qualityLevel;

    [Header("Gameplay Settings")]
    [Tooltip("The sensitivity of the mouse.")]
    public float mouseSensitivity;

    [Tooltip("Whether to invert the Y axis.")]
    public bool invertYAxis;
}
