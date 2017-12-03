using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Fixed a = new Fixed(569m);
        Fixed b = new Fixed(158m);
        a = a / b;
        Debug.Log(a);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
