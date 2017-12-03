using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;


public class collider : MonoBehaviour {
    public enum type
    {
        sphere,
        aabb,
        obb
    }

    public type t;
    public vector center;


    public IntersectData intersect(collider other)
    {
        // figure out what type of coliders the objects have and use the
        // appropriate function
        if(t == type.sphere && other.t == type.sphere)
        {
            return((BoundingSphere)this).IntersectBoundingSphere((BoundingSphere)other);
        }

        return new IntersectData(); //default null case
    }
}
