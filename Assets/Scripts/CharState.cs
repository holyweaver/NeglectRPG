using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CharState : MonoBehaviour {

    public enum Cstate
    {
        Idle = 1,
        Auto,
        Click
    }

    public Cstate stateC;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(IdleC());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator IdleC()
    {
        yield return new WaitForSeconds(3);

        stateC = Cstate.Auto;

        NextState_();
    }

    IEnumerator AutoC()
    {
        yield return new WaitForSeconds(3);

        stateC = Cstate.Idle;

        NextState_();
    }

    void NextState_()
    {
        string MethodName = stateC + "C";
        Debug.Log(MethodName);
        MethodInfo info = GetType().GetMethod(MethodName, BindingFlags.Instance | BindingFlags.NonPublic);
        StartCoroutine((IEnumerator)info.Invoke(this, null));

    }
}
