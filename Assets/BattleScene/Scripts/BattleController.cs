using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public GameObject Player;
    public GameObject Enemy;
    CharacterScript playerScript;
    CharacterScript enemyScript;

    public Text playerHealth;
    public Text playerAP;

    public Text playerHealthGUI;

    public Text enemyHealth;
    public Text enemyAP;

    public GameObject SwordMenu;
    public GameObject CrossbowMenu;
    public GameObject FlintlockMenu;
    public GameObject MagicMenu;
    public GameObject UnarmedMenu;
    public GameObject UIMenu;
    public GameObject ItemsMenu;

    // Use this for initialization
    void Start () {
        playerScript = Player.GetComponent<CharacterScript>();
        enemyScript = Enemy.GetComponent<CharacterScript>();
    }
	
	// Update is called once per frame
	void Update () {
        playerHealth.text = "Health: " + playerScript.Health;
        playerAP.text = "AP: " + playerScript.ActionPoints;

        playerHealthGUI.text = "Health: " + playerScript.Health;

        enemyHealth.text = "Health: " + enemyScript.Health;
        enemyAP.text = "AP: " + enemyScript.ActionPoints;

        PlayerPrefs.SetFloat("PlayerHP", playerScript.Health);
    }

    public void AddCharactersToBattle(GameObject player, GameObject enemy)
    {
        player.AddComponent(typeof(CharacterScript));
        enemy.AddComponent(typeof(CharacterScript));

        playerScript = player.GetComponent<CharacterScript>();
        playerScript.isCharactersTurn = true;

        enemyScript = enemy.GetComponent<CharacterScript>();
        enemyScript.isAI = true;

        playerScript.opponent = enemyScript;
        enemyScript.opponent = playerScript;
    }

    public void MainMenu()
    {
        SwordMenu.SetActive(false);
        CrossbowMenu.SetActive(false);
        FlintlockMenu.SetActive(false);
        MagicMenu.SetActive(false);
        UnarmedMenu.SetActive(false);
        UIMenu.SetActive(false);
        ItemsMenu.SetActive(false);

        UIMenu.SetActive(true);
    }
}
