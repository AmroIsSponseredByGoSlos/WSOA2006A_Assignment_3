using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Target);
    }

    public void OnCloseClick()
    {
        Application.Quit();
    }

    public void PlayAgainClick()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
