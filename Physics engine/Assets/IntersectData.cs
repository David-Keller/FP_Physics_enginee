using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectData {

    public IntersectData(bool intersect, vector distance)
    {
        DoesIntersect = intersect;
        this.distance = distance;
    }
    public IntersectData() { } // null case

    public bool DoesIntersect { get; set; }
    public vector distance { get; set; }

}
