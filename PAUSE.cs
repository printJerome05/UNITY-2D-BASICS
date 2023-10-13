using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAUSE : MonoBehaviour
{
	[SerializeField] private int Respawn;
	[SerializeField] private int MainMenu;

	// audio
	[SerializeField] public AudioSource audio;

	public GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();    
        gameobject.SetActive(false);
        Time.timeScale = 1f;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Mainmenu();
            audio.Pause();
        }
    }

    private void Mainmenu()
    {
        gameobject.SetActive(true);
        Time.timeScale = 0f;
	}

    public void Resume()
    {
		gameobject.SetActive(false);
        Time.timeScale = 1f;
		audio.Play();
	}

    public void Mainemnu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Restart()
    {
		SceneManager.LoadScene(Respawn);
	}
}
