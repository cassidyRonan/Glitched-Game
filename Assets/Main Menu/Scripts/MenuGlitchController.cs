using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGlitchController : MonoBehaviour {

    public GameObject Play;
    public GameObject Exit;

    void Start () {
       
       
        
      

    }
	
	void Update () {
        


        }
    private void OnMouseDown()
    {
        if(gameObject.tag == "Play")
        {
            SceneManager.LoadScene(0); //Enter the build number of the level you wish to go to.
        }
        else if(gameObject.tag == "Exit")
        {
            Application.Quit();
        }
    }
    private void OnMouseOver()
    {
        if(Play)
        {
            Play.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}

