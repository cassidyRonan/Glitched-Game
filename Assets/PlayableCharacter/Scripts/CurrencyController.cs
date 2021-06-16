using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour {

    static public int playerMoney;

	// Use this for initialization
	void Start () {
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
	}

    // Update is called once per frame
    void Update()
    {
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
    }
}
