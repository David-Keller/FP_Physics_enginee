using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: create a vector math class for fixed

public class BoundingSphere : collider {

	// Use this for initialization
	void Start () {
        radius = radiusEdit;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public float radiusEdit;
    public Fixed radius;

    public IntersectData IntersectBoundingSphere(BoundingSphere other)
    {

        Fixed RadiusDistance = radius + other.radius;
        RadiusDistance = RadiusDistance * RadiusDistance;
        vector direction = other.center - center;
        Fixed centerDistance = direction.magnitudeSquared;
        Fixed distance = centerDistance - RadiusDistance;
        direction = direction / centerDistance;

        if(centerDistance < RadiusDistance)
        {
            return new IntersectData(true, direction * distance);
        }
        else
        {
            return new IntersectData(false, direction * distance);
        }

    }

}
