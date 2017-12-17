using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FixedUpdate()
    {
        PhysicsObject[] AllObjects = FindObjectsOfType<PhysicsObject>();

        foreach (PhysicsObject o in AllObjects)
        {
            o.integrate();
        }
        handleColisions();
    }

    public void handleColisions()
    {
        PhysicsObject[] AllObjects = FindObjectsOfType<PhysicsObject>();
        for (int i = 0; i < AllObjects.Length; i++)
        {
            for(int j = i+1; j < AllObjects.Length; j++)
            {
                Debug.Log("testing");
                IntersectData intersectdata = AllObjects[i].col.intersect(AllObjects[j].col);

                if (intersectdata.DoesIntersect)
                {
                    Debug.Log("intersection");
                    vector direction = intersectdata.distance.normalized;
                    vector otherdirection = vector.reflect(direction, AllObjects[i].vel).normalized;
                    
                    AllObjects[i].vel = vector.reflect(AllObjects[i].vel, otherdirection);
                    AllObjects[j].vel = vector.reflect(AllObjects[j].vel, direction);

                    Debug.Log("intersection done");
                }
            }
        }
    }
}
