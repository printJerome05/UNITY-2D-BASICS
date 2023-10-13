using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RESPAWNGAMEOVER : MonoBehaviour
{
    // this is and indication where scene you want to spawn 
    [SerializeField] private int Respawn;

	public GameObject gameobject;


	// Start is called before the first frame update
	private void Start()
	{
		gameobject.SetActive(false);
		Debug.Log("Start Game");
		Time.timeScale = 1f;
	}

	// need to put the collider to isTrigger
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
			gameobject.SetActive(true);
		
			Time.timeScale = 0f;
			Debug.Log("Dead");
		}
	}

	public void Gameover()
	{
		SceneManager.LoadScene(Respawn);
	}


}
