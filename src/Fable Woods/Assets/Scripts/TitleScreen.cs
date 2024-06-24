using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public float afterFadeWait = 1;

    [Header("Audio")]

    public AudioSource startMenuSound;

    [Header("Camera")]

    [SerializeField]
    private CinemachineVirtualCamera CameraTitle;

    [SerializeField]
    private bool _starting = false;

    private void Start()
    {
        CameraTitle = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        CameraTitle.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;


        if (Input.anyKey)
        {
            if (!_starting)
            {
                // Flagging that we are starting the game.
                _starting = true;

                // Starting the routine to start the game.
                StartCoroutine(StartTheGame());
            }
        }
    }

    private IEnumerator StartTheGame()
    {
        // Playing button sound effect.
        startMenuSound.Play();

        // Waiting time.
        yield return new WaitForSeconds(afterFadeWait);

        // Loading the scene.
        SceneManager.LoadScene($"{Scenes.Game}");

        // Resetting the starting flag.
        _starting = false;
    }
}