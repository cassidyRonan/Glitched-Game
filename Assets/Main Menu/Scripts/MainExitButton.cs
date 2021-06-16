using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainExitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        Application.Quit(); 
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
