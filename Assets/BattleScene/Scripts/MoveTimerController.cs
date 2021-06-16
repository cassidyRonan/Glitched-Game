using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTimerController : MonoBehaviour {

    public float elapsedTime = 0;
    public float breakTime = 2;
    static public bool isTurn = true;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isTurn == false)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > breakTime)
            {
                elapsedTime = 0;
                isTurn = true;
            }
        }
    }
}
