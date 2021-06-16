using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour {

    private Animator player;
    bool test;
	// Use this for initialization

    public enum Direction
    {
        Dead,
        Up,
        Down,
        Left,
        Right,
        IdleUp,
        IdleDown,
        IdleLeft,
        IdleRight
    }

	void Start () {
	}

    private void Awake()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        Direction State = Direction.IdleDown;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            State = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            State = Direction.Right;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            State = Direction.Up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            State = Direction.Down;
        }

        if ((Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.UpArrow)))
        {
            State = Direction.IdleUp;
        }
        else if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            State = Direction.IdleDown;
        }

        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            State = Direction.IdleLeft;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            State = Direction.IdleRight;
        }

        player.SetInteger("direction", (int)State);
    }

}
