﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vector {
    public Fixed x;
    public Fixed y;
    public Fixed z;

    public Fixed magnitudeSquared
    {
        get { return (x * x) + (y * y) + (z * z); }
    }

    public Fixed magnitude
    {
        get { return magnitudeSquared.sqrt1(); }
    }
    public vector normalized
    {
        get { return this/magnitude; }
    }

    public vector()
    {
        x.fix = 0;
        y.fix = 0;
        z.fix = 0;
    }
    public vector(Fixed ax, Fixed ay, Fixed az)
    {
        x = ax;
        y = ay;
        z = az;
    }
    void set(Fixed ax, Fixed ay, Fixed az)
    {
        x = ax;
        y = ay;
        z = az;
    }
    //------------------operators -------------------------//

    public static vector operator +( vector a, vector b)
    {
        vector c = new vector();
        c.x = a.x + b.x;
        c.y = a.y + b.y;
        c.z = a.z + b.z;
        return c;
    }
    public static vector operator -(vector a, vector b)
    {
        vector c = new vector();
        c.x = a.x - b.x;
        c.y = a.y - b.y;
        c.z = a.z - b.z;
        return c;
    }
    public static vector operator *(vector a, Fixed b)
    {
        vector c = new vector();
        c.x = a.x * b;
        c.y = a.y * b;
        c.z = a.z * b;
        return c;
    }
    public static vector operator *(Fixed b, vector a)
    {
        vector c = new vector();
        c.x = a.x * b;
        c.y = a.y * b;
        c.z = a.z * b;
        return c;
    }
    public static vector operator /(vector a, Fixed b)
    {
        vector c = new vector();
        c.x = a.x / b;
        c.y = a.y / b;
        c.z = a.z / b;
        return c;
    }
    public static vector operator /(Fixed b, vector a)
    {
        vector c = new vector();
        c.x = a.x / b;
        c.y = a.y / b;
        c.z = a.z / b;
        return c;
    }

    public static implicit operator Vector3(vector v)
    {
        Vector3 n = new Vector3();
        n.x = v.x.ToFloat();
        n.y = v.y.ToFloat();
        n.z = v.z.ToFloat();
        return n;
    }


    //---------------------functions -----------------------//
    public static vector reflect(vector R, vector normal)
    {

        //R = R * new Fixed(-1m);
        Debug.Log("a = " + R.ToString());
        Debug.Log("b = " + normal.ToString());

        vector c = R - (dot(R, normal)* new Fixed(2m)*normal);
        Debug.Log("c = " + c.ToString());
        return c;
    }
    public static Fixed dot(vector a, vector b)
    {
        //dot product was implimented wrong took time to solve
        Fixed c = new Fixed(); 
        c = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        return c;
    }

    public override String ToString()
    {
        return x.ToString() + "\n" + y.ToString() + "\n" + z.ToString();
    }


}
