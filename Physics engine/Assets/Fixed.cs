using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//this class is a new base data type called fixed
//it represents fractional numbers with a unmoving decimal point (aka fixed decimal point)

public struct Fixed : IEquatable<Fixed> , IFormattable
{

    //--------------- member variables----------------//
    public long fix;
    //static int scale = 32;

    //------------------ constructors ----------------//

    public Fixed(int num)
    {
        fix = num* 4294967296;
    }

    public Fixed(long num)
    {
        fix = num;
    }
    public Fixed(decimal num)
    {
        fix = Decimal.ToInt64(num * 4294967296m);
    }
    //------------------operators -------------------//
    public static Fixed operator +(Fixed a, Fixed b)
    {
        Fixed c = new Fixed();
        c.fix = a.fix + b.fix;
        return c;
    }
    public static Fixed operator -(Fixed a, Fixed b)
    {
        Fixed c = new Fixed();
        c.fix = a.fix - b.fix;
        return c;
    }
    public static Fixed operator *(Fixed a, Fixed b)
    {
        Fixed c = new Fixed();
        c.fix = ((a.fix >>12) * (b.fix >> 12))>>8;
        //c.fix = c.fix >> scale;
        return c;
    }
    public static Fixed operator /(Fixed a, Fixed b)
    {
        Fixed c = new Fixed();
        c.fix = ((a.fix << 12) / (b.fix >> 12)) << 8;
        return c;
    }
    public static Fixed operator >>(Fixed a, int b)
    {
        Fixed c = new Fixed();
        c.fix = a.fix >> b;
        return c;
    }

    public static Fixed operator <<(Fixed a, int b)
    {
        Fixed c = new Fixed();
        c.fix = a.fix << b;
        return c;
    }
    public override bool Equals(object obj)
    {
        if(obj is Fixed)
        {
            return this.Equals((Fixed)obj);
        }
        return false;
    }

    public static bool operator >(Fixed a, Fixed b)
    {
        if (a.fix > b.fix)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal float ToFloat()
    {

        return (float)((decimal)fix / 4294967296m);
    }

    public static bool operator <(Fixed a, Fixed b)
    {
        if (a.fix < b.fix)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static implicit operator Fixed(float v)
    {
        return new Fixed((decimal)v);
    }

    public static implicit operator Fixed(int v)
    {
        return new Fixed(v);
    }

    public bool Equals(Fixed f)
    {
        return f.fix == fix;
    }



    public override string ToString()
    {
        return (((decimal)fix) / 4294967296m).ToString();
    }

    public string ToString(string format, IFormatProvider provider)
    {
        return (((decimal)fix) / 4294967296m).ToString();
    }

    public Fixed sqrt1()
    {
        return sqrt_callback(1, 0);
    }

    Fixed sqrt_callback( Fixed guess, int tryNum)
    {
        //Debug.Log(guess);
        //Debug.Log(this / guess);
        Fixed improvedValue = (guess + (this / guess)) / new Fixed(2m);
       

        Fixed error = this - (improvedValue * improvedValue);
        //if(error < new Fixed(0m))
        //{
        //    error = error * new Fixed(-1m);
        //}

        if (error < new Fixed(0.0001m) && error > new Fixed(-0.0001m) || tryNum > 200)
        {
            //Debug.Log(tryNum);
            return improvedValue;
        }

        return sqrt_callback(improvedValue, tryNum + 1);
    }

    public Fixed sqrt2()
    {
        return new Fixed();
    }


    public void sincos(out Fixed sin, out Fixed cos)
    {
        Fixed angle = this;
        Fixed inverter = new Fixed(1m); // used to invert if needed
        //get the angle between 0 and 360
        while(angle > new Fixed(360m))
        {
            angle = angle - new Fixed(360m);
        }
        while(angle < new Fixed(0m))
        {
            angle = angle + new Fixed(360m);
        }

        //=========== for sine ===============//
        //get the angle between 0 and 90
        if(angle > new Fixed(180m))
        {
            angle = angle - new Fixed(180m);
            inverter = new Fixed(-1m);
        }
        if(angle > 90)
        {
            angle = new Fixed(180m) - angle;
        }

        //get the angle between 0 and 45
        if(angle > new Fixed(45m))
        {
            Debug.Log(angle);
            //calculate the cofuntions of the angle
            angle = new Fixed(90m) - angle;
            Debug.Log(angle);
            sin = new Fixed(1m) - (angle * angle / new Fixed(2m)) + (angle * angle * angle * angle / new Fixed(24m)) - (angle * angle * angle * angle * angle * angle / new Fixed(720m));
            sin = sin * inverter;
        }
        else
        {
            Debug.Log(angle);
            // calculate the angles
            angle = angle * new Fixed(3.14159265359m / 180m);
            Debug.Log(angle);
            sin = angle - (angle * angle * angle / new Fixed(6m)) + (angle * angle * angle * angle * angle / new Fixed(120m));
            sin = sin * inverter;
        }

        //============ for cosine ==============//
        angle = this;
        inverter = new Fixed(1m); //reset inverter
        //get the angel between 0 and 90
        if (angle > new Fixed(270m))
        {
            angle = angle - new Fixed(270m);
            angle = new Fixed(90m) - angle;
        }
        if (angle > new Fixed(180m))
        {
            angle =  angle - new Fixed(180m);
            //angle = new Fixed(90m) - angle;
            inverter = new Fixed(-1m);
        }
        if (angle > new Fixed(90m))
        {
            angle = angle - new Fixed(90m);
            angle = new Fixed(90m) - angle;
            inverter = new Fixed(-1m);
        }

        //get the angle between 0 and 45
        if (angle < new Fixed(45m))
        {
            //calculate the cofuntions of the angle
            
            angle = angle * new Fixed(3.14159265359m / 180m);
            cos = new Fixed(1m) - (angle * angle / new Fixed(2m)) + (angle * angle * angle * angle / new Fixed(24m)) - (angle * angle * angle * angle * angle * angle / new Fixed(720m));
            cos = cos * inverter;
        }
        else
        {

            // calculate the angles
            angle = new Fixed(90m) - angle;
            angle = angle * new Fixed(3.14159265359m / 180m);

            cos = angle - (angle * angle * angle / new Fixed(6m)) + (angle * angle * angle * angle * angle / new Fixed(120m));
            cos = cos * inverter;
        }

    }
}
