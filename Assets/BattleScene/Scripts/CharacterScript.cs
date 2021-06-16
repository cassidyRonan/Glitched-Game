using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

[Serializable]
public enum BattleMove
{
    Heal,
    Punch,
    Uppercut,
    FlurryOfBlows,
    StunningStrike,
    Slash,
    FeintingAttack,
    DivineSmite,
    StarlightStrike,
    FireBolt,
    RayOfFrost,
    CloudOfDaggers,
    MagicMissile,
    Shoot,
    BarbedArrow,
    SniperShot,
    ExplosiveArrow,
    QuickDraw,
    TrickShot,
    ViolentShot,
    Deadshot,
    NoMove
}

public class CharacterScript : MonoBehaviour
{
    public float timeVar = 0;
    public bool isCharactersTurn = false;
    public bool isAI = false;
    public bool isStunned = false;

    public float Health = 100;
    public float MaxHealth = 100;

    public int ActionPoints = 10;
    public int maxActionPoints = 10;

    public int stunAmount = 2;
    private int currentStunCounter = 0;

    public float healAmount = 25;
    public int maxHealsAllowed = 2;
    public int healsPerformed = 0;

    public static string monsterName = "none";
    public GameObject BattleScene;

    public bool InBattle = false;
    public bool IsDefending = false;
    public bool IsTurn = true;


    static public int EnemyPerception = 100;

    

    //Enemy Sprites
    public GameObject Beholder;
    public GameObject Statue;

    //Turn Sequence
    public float elapsedTime = 0;
    public float breakTime = 2;
    static public bool isTurn = true;

    //UnnarmedDamage
    public float PunchAmount = 10;
    public float UppercutAmount = 16;
    public float FlurryOfBlowsAmount = 24;
    public float StunningStrikeAmount = 40;

    //SwordDamage
    public float SlashAmount = 12;
    public float FeintingAttackAmount = 16;
    public float DivineSmiteAmount = 25;
    public float StarlightStrikeAmount = 50;

    //MagicDamage
    public float FireBoltAmount = 14;
    public float RayOfFrostAmount = 12;
    public float CloudOfDaggersAmount = 24;
    public float MagicMissileAmount = 39;

    //CrossbowDamage
    public float ShootAmount = 11;
    public float BarbedArrowAmount = 15;
    public float SniperShotAmount = 28;
    public float ExplosiveArrowAmount = 60;

    //FlintlockDamage
    public float QuickDrawAmount = 12;
    public float TrickShotAmount = 16;
    public float ViolentShotAmount = 22;
    public float DeadshotAmount = 36;

    Dictionary<BattleMove, int> possibleMoves;
    public CharacterScript opponent;

    // Use this for initialization
    void Start ()
    {
        possibleMoves = new Dictionary<BattleMove, int>();
        possibleMoves.Add(BattleMove.Heal, 2); //Heal
        possibleMoves.Add(BattleMove.Punch, 0); //Unarmed
        possibleMoves.Add(BattleMove.Uppercut, 0);
        possibleMoves.Add(BattleMove.FlurryOfBlows, 5);
        possibleMoves.Add(BattleMove.StunningStrike, 10);
        possibleMoves.Add(BattleMove.Slash, 0); //Sword
        possibleMoves.Add(BattleMove.FeintingAttack, 0);
        possibleMoves.Add(BattleMove.DivineSmite, 5);
        possibleMoves.Add(BattleMove.StarlightStrike, 10);
        possibleMoves.Add(BattleMove.FireBolt, 0); //Magic
        possibleMoves.Add(BattleMove.RayOfFrost, 0);
        possibleMoves.Add(BattleMove.CloudOfDaggers, 5);
        possibleMoves.Add(BattleMove.MagicMissile, 10);
        possibleMoves.Add(BattleMove.Shoot, 0); //Crossbow
        possibleMoves.Add(BattleMove.BarbedArrow, 0);
        possibleMoves.Add(BattleMove.SniperShot, 5);
        possibleMoves.Add(BattleMove.ExplosiveArrow, 10);
        possibleMoves.Add(BattleMove.QuickDraw, 0); //FlintLock
        possibleMoves.Add(BattleMove.TrickShot, 0);
        possibleMoves.Add(BattleMove.ViolentShot, 5);
        possibleMoves.Add(BattleMove.Deadshot, 10);
        possibleMoves.Add(BattleMove.NoMove, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;

        //Health Limator
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        //In Battle
        if(BattleScene == true)
        {
            InBattle = true;
        }
        else
        {
            InBattle = false;
        }



        //if this is the AI and it's the AI turn and the turn break has elapsed
        if (isAI && isCharactersTurn && InBattle)
        {
            //if the AI is not stunned
            if (!isStunned)
            {
                //update the AI
                UpdateAI();
            }
            else
            {
                currentStunCounter--;

                if (currentStunCounter <= 0)
                    isStunned = false;
            }
        }

        //Enemy Stat Assignment
        if (isAI)
        {
            if(monsterName == "BeholderInit")
            {
                EnemySpriteOff();
                Health = 70;
                MaxHealth = 70;
                Beholder.SetActive(true);
                EnemyPerception = 85;
                monsterName = "Beholder";
            }
            else if(monsterName == "StatueInit")
            {
                EnemySpriteOff();
                Health = 40;
                MaxHealth = 40;
                Statue.SetActive(true);
                EnemyPerception = 45;
                monsterName = "Animated Statue";
            }
        }
        else
        {
            if (monsterName == "BeholderInit")
            {
                EnemyPerception = 85;
                monsterName = "Beholder";
            }
            else if (monsterName == "StatueInit")
            {
                EnemyPerception = 45;
                monsterName = "Animated Statue";
            }
        }

        //Check if enemy or Player is Dead
        if (isAI && Health <= 0) //Enemy
        {
            BattleScene.SetActive(false);
           
        }
        else if (!isAI && Health <= 0) //Player
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(6);
            
        }
    }


    void UpdateAI()
    {
        
        //priorites healing
        if (Health <= 50 && CanAffordMove(BattleMove.Heal) && healsPerformed < maxHealsAllowed)
        {
            MakeMove(BattleMove.Heal);
            healsPerformed++;
        }
        else
        {
            BattleMove selectedMove = PickRandomMove();

            if (selectedMove != BattleMove.NoMove )
            {
                if(Health > 0)
                {
                    MakeMove(selectedMove);
                }
                
            }
            else
            {
                EndTurn();
            }
        }
    }


    public void HandleMove(BattleMove move)
    {
        switch (move)
        {
            //Unarmed
            case BattleMove.Punch:
                Health -= PunchAmount;
                break;

            case BattleMove.Uppercut:
                Health -= UppercutAmount;
                break;

            case BattleMove.FlurryOfBlows:
                Health -= FlurryOfBlowsAmount;
                break;

            case BattleMove.StunningStrike:
                Health -= StunningStrikeAmount;
                break;

            //Sword
            case BattleMove.Slash:
                Health -= SlashAmount;
                break;

            case BattleMove.FeintingAttack:
                Health -= FeintingAttackAmount;
                break;

            case BattleMove.DivineSmite:
                Health -= DivineSmiteAmount;
                break;

            case BattleMove.StarlightStrike:
                Health -= StarlightStrikeAmount;
                break;

            //Magic
            case BattleMove.FireBolt:
                Health -= FireBoltAmount;
                break;

            case BattleMove.RayOfFrost:
                Health -= RayOfFrostAmount;
                break;

            case BattleMove.CloudOfDaggers:
                Health -= CloudOfDaggersAmount;
                break;

            case BattleMove.MagicMissile:
                Health -= MagicMissileAmount;
                break;

            //Crossbow
            case BattleMove.Shoot:
                Health -= ShootAmount;
                break;

            case BattleMove.BarbedArrow:
                Health -= BarbedArrowAmount;
                break;

            case BattleMove.SniperShot:
                Health -= SniperShotAmount;
                break;

            case BattleMove.ExplosiveArrow:
                Health -= ExplosiveArrowAmount;
                break;

            //Flintlock
            case BattleMove.QuickDraw:
                Health -= ExplosiveArrowAmount;
                break;

            case BattleMove.TrickShot:
                Health -= TrickShotAmount;
                break;

            case BattleMove.ViolentShot:
                Health -= ViolentShotAmount;
                break;

            case BattleMove.Deadshot:
                Health -= DeadshotAmount;
                break;
        }
    }

    public void MakeMove(BattleMove move)
    {
        if (CanAffordMove(move))
        {
            Debug.Log("IsAI: " + isAI + " , Move: " + move);

            if (move == BattleMove.Heal)
            {
                Health += healAmount;
            }
            else
            {
                opponent.HandleMove(move);
            }

            ActionPoints -= possibleMoves[move];
            EndTurn();
        }

        if (IsOutOfMoves())
        {
            EndTurn();
        }
    }

    private void EndTurn()
    {
        isCharactersTurn = false;
        opponent.ActionPoints += 2;
        if(opponent.ActionPoints > 10)
        {
            opponent.ActionPoints = 10;
        }

        /*while(elapsedTime < breakTime)
        {
            elapsedTime = 0;
        }
        elapsedTime += Time.deltaTime;
        if (elapsedTime > breakTime)
        {
            elapsedTime = 0;
            opponent.isCharactersTurn = true;
        } */
        
        opponent.isCharactersTurn = true;
    }

    public BattleMove PickRandomMove()
    {
        Dictionary<BattleMove, int> moves = possibleMoves.Where(m => CanAffordMove(m.Key)).ToDictionary(m => m.Key, m => m.Value);

        if (moves.Count == 0)
            return BattleMove.NoMove;

        if (moves.ContainsKey(BattleMove.Heal))
            moves.Remove(BattleMove.Heal);

        if (moves.Count == 0)
            return BattleMove.NoMove;

        return moves.ElementAt(Random.Range(0, moves.Count - 1)).Key;
    }

    public void MakeMake(string move)
    {
        MakeMove((BattleMove)Enum.Parse(typeof(BattleMove), move));
    }

    public bool CanAffordMove(BattleMove desiredMove)
    {
        return possibleMoves[desiredMove] <= ActionPoints;
    }

    public bool IsOutOfMoves()
    {
        return ActionPoints < possibleMoves.Values.ToList().Min();
    }

    public void Timer()
    {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > breakTime)
            {
                elapsedTime = 0;
                opponent.isCharactersTurn = true;
            }
    }

    public void EnemySpriteOff()
    {
        Beholder.SetActive(false);
        Statue.SetActive(false);

        PlayerPrefs.SetInt("Test", 0);
        int test = PlayerPrefs.GetInt("Test");
        Debug.Log("Test" + test);

        PlayerPrefs.SetInt("Test", 1);
        test = PlayerPrefs.GetInt("Test");
        Debug.Log("Test" + test);
    }

    public void Defend()
    {
        isCharactersTurn = true;
        ActionPoints += 2;
        opponent.ActionPoints += 2;
        if (ActionPoints > 10)
        {
            ActionPoints = 10;
        }
        if(opponent.ActionPoints > 10)
        {
            opponent.ActionPoints = 10;
        }
        opponent.isCharactersTurn = false;
        Debug.Log("Defend");
    }

    public void Flee()
    {
        

        int fleeAttempt = Random.Range(1,100);
        int EnemyPerceptionLocal = EnemyPerception;

        Debug.Log("Flee Attempt: " + fleeAttempt);
        Debug.Log("Enemy Perception: " + EnemyPerceptionLocal);

        if (fleeAttempt >= EnemyPerceptionLocal)
        {
            Debug.Log("Flee");
            BattleScene.SetActive(false);
        }

        isCharactersTurn = false;
        opponent.isCharactersTurn = true;
    }

    public void PotionTurn()
    {
        isCharactersTurn = false;
        opponent.ActionPoints += 2;
        if (opponent.ActionPoints > 10)
        {
            opponent.ActionPoints = 10;
        }
        /*timeVar = 0;
        Debug.Log("Before Loop");
        while(timeVar < 15)
        {
            timeVar += Time.deltaTime;
            Debug.Log("In Loop");
        }
        Debug.Log("Past Loop");*/
        opponent.isCharactersTurn = true;
    }
}
