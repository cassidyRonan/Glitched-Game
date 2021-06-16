using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.OnGrass = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController.OnGrass = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
            PlayerController.OnGrass = false;
        
    }
}
