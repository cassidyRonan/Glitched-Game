using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public Text HPGUI;
    float PlayerHealth;

    // Use this for initialization
    void Start () {
        PlayerHealth = PlayerPrefs.GetFloat("PlayerHP");
    }
	
	// Update is called once per frame
	void Update () {
        HPGUI.text = "HP: " + PlayerHealth;
        PlayerHealth = PlayerPrefs.GetFloat("PlayerHP");
    }
}
