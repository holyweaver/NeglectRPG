using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {

    public CharState _Charstate;

	public Vector2 maxpos;
	public Vector2 minpos;

	public Vector3 charpos;

	public float AutoMoveSpeed;
    public float ClickMoveSpeed;

	public Transform chartrans;

	public int randirnumx;
	public int randirnumy;

	public int movecount = 0;

    int floorMask;
    float camRayLengh = 100f;
    public Vector3 playerToMouse;
    
    void randomdir()
    {
        randirnumx = Random.Range(-1, 2);
        randirnumy = Random.Range(-1, 2);
    }

    void AutoMovex()
	{
		charpos.x += AutoMoveSpeed * randirnumx; //dir값 -1 0 1 / movespeed값 0.01 ~ 0.02

		chartrans.position = charpos;
	}
		
	void AutoMovey()
	{
		charpos.y += AutoMoveSpeed * randirnumy;

		chartrans.position = charpos;
	}

	void ClickMove()
	{
        if(Input.GetMouseButtonDown(0))
        {

            _Charstate.stateC = CharState.Cstate.Click;

            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, camRayLengh, floorMask))
            {
                playerToMouse = floorHit.point;
                Debug.Log(playerToMouse);
            }
        }

        if (_Charstate.stateC == CharState.Cstate.Click)
        {
            chartrans.position = Vector3.MoveTowards(chartrans.position, playerToMouse, ClickMoveSpeed * Time.fixedDeltaTime);

            if (chartrans.position == playerToMouse)
            {
                _Charstate.stateC = CharState.Cstate.Idle;

                charpos = chartrans.position;

                _Charstate.NextState_();
            }
        }
       
    }

    void MoveLimit()
    {
        if (charpos.x > maxpos.x)
        {
            charpos.x = maxpos.x;
            randomdir();
        }

        if (charpos.x < minpos.x)
        {
            charpos.x = minpos.x;
            randomdir();
        }

        if (charpos.y > maxpos.y)
        {
            charpos.y = maxpos.y;
            randomdir();
        }

        if (charpos.y < minpos.y)
        {
            charpos.y = minpos.y;
            randomdir();
        }
    }

	void Awake()
	{

	}

	// Use this for initialization
	void Start () {

		chartrans = transform;
		charpos = chartrans.position;
        floorMask = LayerMask.GetMask("Floor");
    }

	// Update is called once per frame
	void FixedUpdate () {

        if(_Charstate.stateC == CharState.Cstate.Idle)
        {
            randomdir();
        }

        if(_Charstate.stateC == CharState.Cstate.Auto)
        {
            AutoMovex();
            AutoMovey();
        }

        MoveLimit();

        ClickMove();

    }

}
