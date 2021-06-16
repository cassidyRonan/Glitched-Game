using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolcanoDialougeController : MonoBehaviour {

    public GameObject DialougeBox;
    public Text DialougeText;
    public bool PreviouslyEnteredVolcano = false;
    public bool DialougeActive = false;
    public int DialougeNumber;

	// Use this for initialization
	void Start () {
		if(PreviouslyEnteredVolcano == false)
        {
            DialougeNumber = 0;
            DialougeBox.SetActive(true);
            DialougeActive = true;
            DialougeText.text = "Oh god, I feel like im going to turn into beef jerkey in this heat.";


        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown && DialougeActive == true)
        {
            switch (DialougeNumber)
            {
                case 0:
                    
                    DialougeNumber = 1;
                    break;

                case 1:
                    DialougeText.text = "Maybe I should look around for something to get me out of here...";
                    DialougeNumber = 2;

                    break;

                case 2:
                    DialougeText.text = "Games usually end when you beat the boss, so maybe thats what I need to do!";
                    DialougeNumber = 3;

                    break;

                case 3:
                    DialougeText.text = "But I could really do with a glass of water as well...";
                    DialougeNumber = 4;
                    DialougeBox.SetActive(false);
                    DialougeActive = false;
                    PreviouslyEnteredVolcano = true;
                    break;

                default:
                    break;
            }
        }
       
    }
}
