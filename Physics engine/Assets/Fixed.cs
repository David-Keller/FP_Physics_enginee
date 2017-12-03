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
    static int scale = 32;

    //------------------ constructors ----------------//

    public Fixed(int num)
    {
        fix = num;
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
    //TODO implement the / (division) operator
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
        return sqrt_callback(1);
    }

    Fixed sqrt_callback( Fixed guess)
    {
        Fixed improvedValue = guess + ((fix / guess) / 2);


        Fixed error = fix - (improvedValue * improvedValue);
        if(error < new Fixed(0m))
        {
            error = error * new Fixed(-1m);
        }

        if (error < new Fixed(0.0001m))
        {
            return improvedValue;
        }

        return sqrt_callback(improvedValue);
    }

    public Fixed sqrt2()
    {
        return new Fixed();
    }
}
