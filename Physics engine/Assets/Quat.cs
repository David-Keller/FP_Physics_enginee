using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat : MonoBehaviour {

    //---------member vars----------//
    Fixed x;
    Fixed y;
    Fixed z;
    Fixed w;
    //------------construtor----------//
    Quat(Fixed _X, Fixed _y, Fixed _z, Fixed _w)
    {
        x = _X;
        y = _y;
        z = _z;
        w = _w;
    }
    Quat(vector axis, Fixed angle)
    {
        SetFromAxisAngle(axis, angle);
    }


    //-----------functions-----------//

    void SetFromAxisAngle(vector axis, Fixed angle)
    {
        Fixed sinZ, cosZ;
        (angle * new Fixed(0.5m)).sincos(out sinZ, out cosZ);
        x = axis.x * sinZ;
        y = axis.y * sinZ;
        z = axis.z * sinZ;
        w = cosZ;
    }

    public static Quat operator *(Quat a, Quat r)
    {
        return new Quat(a.x*r.w - a.y*r.z + a.z*r.y - a.w*r.x,
                        a.x * r.z + a.y * r.w - a.z * r.x - a.w * r.y,
                        a.y * r.x + a.z * r.w - a.w * r.z - a.x * r.y,
                        a.x * r.x + a.y * r.y + a.z * r.z + a.w * r.w);
    }

    public Quat rotateX(Fixed angle)
    {
        return new Quat(new vector(1, 0, 0), angle);
    }
    public Quat rotateY(Fixed angle)
    {
        return new Quat(new vector(0, 1, 0), angle);
    }
    public Quat rotateZ(Fixed angle)
    {
        return new Quat(new vector(0, 0, 1), angle);
    }
    public void SetFromXYZ(vector XYZ)
    {
        Quat temp = rotateX(XYZ.x) * rotateY(XYZ.y) * rotateZ(XYZ.z);
        x = temp.x;
        y = temp.y;
        z = temp.z;
        w = temp.w;
    }
}
