using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSettings audioSettings;

    public AudioMixer audioMixer;

    public string volumeName;

    private Slider Slider => GetComponent<Slider>();

    public void UpdateValueOnChange(float value) => audioMixer.SetFloat(volumeName, value);
}
