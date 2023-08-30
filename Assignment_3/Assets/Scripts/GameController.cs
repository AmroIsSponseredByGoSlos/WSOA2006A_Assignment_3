using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float Timer = 30f;
    public float Interval = 0f;
    //public TextMeshProUGUI TimeText;
    public bool TimerActive = true;
    public bool Started = false;
    public bool StudySessionFinished = false;
    public AudioSource src;
    public AudioClip GameAudio;
    // Start is called before the first frame update
    void Start()
    {
        src.clip = GameAudio;
        src.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        Scene ActiveScene = SceneManager.GetActiveScene();
        if (ActiveScene.name == "GameScene")
        {
            Started = true;
        }
        if (Timer != 0)
        {
            if (Started)
            {
                if (Interval < 1f)
                {
                    Interval += Time.deltaTime;
                }
                else
                {
                    Timer--;
                    Interval = 0f;
                }
            }
        }
        else
        {
            StudySessionFinished = true;
            TimerActive = false;
        }
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
