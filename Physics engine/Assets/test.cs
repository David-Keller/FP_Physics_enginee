using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fixed a = new Fixed(45m);
        Fixed sin = new Fixed(1m);
        Fixed cos = new Fixed();
        a.sincos(out sin,out cos);
        //a = a / b;
        Debug.Log(sin);
        Debug.Log(cos);

        Debug.Log("test 2");
        Fixed test;// = new Fixed();
        test = 234;
        Debug.Log(test);

        //Debug.Log(a.sqrt1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
