using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour {

    public Text scoreDisplay;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "HPPotText")
        {
            scoreDisplay.text = "X" + ButtonController.HPPotAmount;
        }
        else if (gameObject.tag == "MPPotText")
        {
            scoreDisplay.text = "X" + ButtonController.MPPotAmount;
        }
        else if (gameObject.tag == "StrengthPotText")
        {
            scoreDisplay.text = "X" + ButtonController.StrengthPotAmount;
        }
        else if (gameObject.tag == "ShieldPotText")
        {
            scoreDisplay.text = "X" + ButtonController.ShieldPotAmount;
        }
        else if (gameObject.tag == "MoneyText")
        {
            scoreDisplay.text = "$" + CurrencyController.playerMoney;
        }
    }
}
