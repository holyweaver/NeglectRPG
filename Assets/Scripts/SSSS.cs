using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class SSSS : MonoBehaviour {

	public enum SSTate
	{
		Idle,
		Attack,
	}

	public SSTate State;

	// Use this for initialization
	void Start () {
		StartCoroutine (IdleState());
	}
	
	IEnumerator IdleState()
	{

        yield return new WaitForSeconds(3);


		while(true)
		{
			Debug.Log ("IdleState");
			if(Input.GetKey(KeyCode.A))
			{
				Debug.Log ("NextState : Attack");
				State = SSTate.Attack;
				break;
			}
			yield return null;
		}

		NextState ();

	}

	IEnumerator AttackState()
	{
		while(true)
		{
			Debug.Log ("AttackState");

			if(Input.GetKey(KeyCode.A))
			{
				Debug.Log ("NextState : Idle");
				State = SSTate.Idle;
				break;
			}
			yield return null;
		}

		NextState ();
	}

	void NextState()
	{
		string MethodName = State.ToString () + "State";
		MethodInfo info = GetType ().GetMethod (MethodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.CreateInstance);
		StartCoroutine ((IEnumerator)info.Invoke(this, null));
	}

}
