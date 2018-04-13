using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public Transform Enemytrans;

    public int randomdirx;
    public int randomdiry;

    public float Speed;


    void randomdir()
    {
        randomdirx = Random.Range(-1, 2);
        randomdiry = Random.Range(-1, 2);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

	}
}
