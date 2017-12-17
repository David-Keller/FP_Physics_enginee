using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed3x3 : MonoBehaviour {

    //-----------------member veriable -----------//
    public Fixed[,] v = new Fixed[3, 3];

    //---------------- Constructor ---------------//
    public Fixed3x3()
    {
        for(int i =0; i < 3; i++)
        {
            for( int j = 0; j < 3; j++)
            {
                v[i, j] = 0;
            }
        }
    }
    //-------------functions-------------------//



    public Fixed At(int row, int col)
    {
        return v[row, col];
    }
}
