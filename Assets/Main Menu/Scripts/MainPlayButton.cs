using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

       
		
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1); // Build number of scene you want.
        PlayerPrefs.SetInt("PlayerMoney", 100);
        PlayerPrefs.SetFloat("PlayerHP", 100);
        PlayerPrefs.SetInt("Volume", 100);
    }
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().flipX = false;

        
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().flipX = true;
    }
}
