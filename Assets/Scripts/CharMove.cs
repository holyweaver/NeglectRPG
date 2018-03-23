using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {

	public enum charmotion
	{
		idle,
		automove,
		clickmove,

	}

	public Vector2 maxpos;
	public Vector2 minpos;

	public Vector3 charpos;

	public float movespeed;
	public Vector2 movedir;

	public Transform chartrans;

	public int randirnumx;
	public int randirnumy;

	public charmotion icharmotion;

	public int movecount = 0;



	void charidle()
	{

		icharmotion = charmotion.automove;
		
	}

	void charautomove()
	{
		AutoMovex ();
		AutoMovey ();
	}

	void AutoMovex()
	{
		charpos.x += movespeed * randirnumx * movedir.x; //dir값 -1 0 1 / movespeed값 0.01 ~ 0.02

		chartrans.position = charpos;
	}
		
	void AutoMovey()
	{
		charpos.y += movespeed * randirnumy * movedir.y;

		chartrans.position = charpos;
	}

	void ClickMove()
	{

	}

	void Awake()
	{
		//icharmotion = charmotion.idle;
	}

	// Use this for initialization
	void Start () {

		chartrans = transform;
		charpos = chartrans.position;
		movedir = Vector2.one;
		randirnumx = Random.Range (-1, 2);
		randirnumy = Random.Range (-1, 2);

	}

	// Update is called once per frame
	void Update () {

		if (icharmotion == charmotion.idle) 
		{
			
		}
		else if (icharmotion == charmotion.automove) 
		{
			charautomove ();
		}

		if (charpos.x > maxpos.x) 
		{
			charpos.x = maxpos.x;
		}

		if (charpos.x < minpos.x) 
		{
			charpos.x = minpos.x;
		}

		if (charpos.y > maxpos.y) 
		{
			charpos.y = maxpos.y;
		}

		if (charpos.y < minpos.y) 
		{
			charpos.y = minpos.y;
		}
		
		
	}
}
