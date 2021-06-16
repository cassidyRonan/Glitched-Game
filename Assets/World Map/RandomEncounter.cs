using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour {

    public float currenttime;
    public float trigTime;
	// Use this for initialization
	void Start () {

        currenttime = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {

        trigTime = Random.Range(20, 40);

        if(currenttime >= trigTime)
        {
            SceneManager.LoadScene(0); // Enter fight scene build number here.
        }
		
	}
}
