using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RESPAWNGAMEOVER : MonoBehaviour
{
    // this is and indication where scene you want to spawn 
    [SerializeField] private int Respawn;
    // Start is called before the first frame update
    
    // need to put the collider to isTrigger
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
        }
	}
}
