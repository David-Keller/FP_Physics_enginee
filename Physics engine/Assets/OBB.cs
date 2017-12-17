using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;


// I worked on modigying this class to get it to work with my own custome math libraries
// but I ran out of time to finish it.  The quaternion (quat) class does work as does the
// additions to the Fixed class (sinCos).


public class OBB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    vector pos;
    vector extents;
    vector[] axis = new vector[3];
    //Matrix<float> inversRotation;
	
	// Update is called once per frame
	void Update () {

	}

    OBB()
    {
        
    }
    bool intersectTest(OBB b)
    {
        //this is a trial at rewriting this class to use my own math libraies
        Fixed3x3 R  = new Fixed3x3();
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                R.v[i, j] = vector.dot(axis[i], b.axis[j]);
            }
        }



        IntersectData data = new IntersectData();
        return true;






    //    Matrix<float> C =  axis.Transpose() * b.axis;
    //    Vector<float> D = pos - b.pos;//Difference of centers



    //    //Check all 15 possible collision vectors
    //    // All checks are derived from the table on pg 7 of https://www.geometrictools.com/Documentation/DynamicCollisionDetection.pdf

    //    // For Vector A0
    //    if (
    //        extents[0] +                                //R0
    //        ((b.extents[0] * System.Math.Abs(C[0, 0]))  //R1
    //        + (b.extents[1] * System.Math.Abs(C[0,1]))
    //        + (b.extents[2] * System.Math.Abs(C[0,2]))) 
    //        >
    //        System.Math.Abs( axis.Row(0).DotProduct(D))) //R                                      //R
    //    {
    //        return true;
    //    }
    //    // For vector A1
    //    if (
    //        extents[1] +                                //R0
    //        ((b.extents[0] * System.Math.Abs(C[1, 0]))  //R1
    //        + (b.extents[1] * System.Math.Abs(C[1, 1]))
    //        + (b.extents[2] * System.Math.Abs(C[1, 2])))
    //        >
    //        System.Math.Abs(axis.Row(1).DotProduct(D))) //R                                 //R
    //    {
    //        return true;
    //    }

    //    // For vector A2
    //    if (
    //        extents[2] +                                //R0
    //        ((b.extents[0] * System.Math.Abs(C[2, 0]))  //R1
    //        + (b.extents[1] * System.Math.Abs(C[2, 1]))
    //        + (b.extents[2] * System.Math.Abs(C[2, 2])))
    //        >
    //System.Math.Abs(axis.Row(2).DotProduct(D)))           //R                            //R
    //    {
    //        return true;
    //    }
    //    // For vector B0
    //    if (
    //        b.extents[0] +                            //R0
    //        ((extents[0] * System.Math.Abs(C[0, 0]))  //R1
    //        + (extents[1] * System.Math.Abs(C[1, 0]))
    //        + (extents[2] * System.Math.Abs(C[2, 0])))
    //        >
    //        System.Math.Abs(b.axis.Row(0).DotProduct(D)))                                       //R
    //    {
    //        return true;
    //    }

    //    // For vector B1
    //    if (
    //        b.extents[1] +                            //R0
    //        ((extents[0] * System.Math.Abs(C[0, 1]))  //R1
    //        + (extents[1] * System.Math.Abs(C[1, 1]))
    //        + (extents[2] * System.Math.Abs(C[2, 1])))
    //        >
    //        System.Math.Abs(b.axis.Row(1).DotProduct(D)))  //R                                     //R
    //    {
    //        return true;
    //    }

    //    // For vector B2
    //    if (b.extents[2] +                            //R0
    //        ((extents[0] * System.Math.Abs(C[0, 2]))  //R1
    //        + (extents[1] * System.Math.Abs(C[1, 2]))
    //        + (extents[2] * System.Math.Abs(C[2, 2])))
    //        >
    //        System.Math.Abs(b.axis.Row(0).DotProduct(D)))  //R                                 //R
    //    {
    //        return true;
    //    }

    //    // For vector A0 X B0
    //    if(
    //        (extents[1]* System.Math.Abs(C[2,0]))
    //        + (extents[2] * System.Math.Abs(C[1, 0]))
    //        + (b.extents[1] * System.Math.Abs(C[0, 2]))
    //        + (b.extents[2] * System.Math.Abs(C[0, 1]))
    //        >
    //        System.Math.Abs(
    //            C[1,0] * axis.Row(2).DotProduct(D)
    //            - C[2, 0] * axis.Row(1).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }
    //    // For vector A0 X B1
    //    if (
    //        (extents[1] * System.Math.Abs(C[2, 1]))
    //        + (extents[2] * System.Math.Abs(C[1, 1]))
    //        + (b.extents[0] * System.Math.Abs(C[0, 2]))
    //        + (b.extents[2] * System.Math.Abs(C[0, 0]))
    //        >
    //        System.Math.Abs(
    //            C[1, 1] * axis.Row(2).DotProduct(D)
    //            - C[2, 1] * axis.Row(1).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A0 X B2
    //    if (
    //        (extents[1] * System.Math.Abs(C[2, 2]))
    //        + (extents[2] * System.Math.Abs(C[1, 2]))
    //        + (b.extents[0] * System.Math.Abs(C[0, 1]))
    //        + (b.extents[1] * System.Math.Abs(C[0, 0]))
    //        >
    //        System.Math.Abs(
    //            C[1, 2] * axis.Row(2).DotProduct(D)
    //            - C[2, 2] * axis.Row(1).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A1 X B0
    //    if (
    //        (extents[0] * System.Math.Abs(C[2, 0]))
    //        + (extents[2] * System.Math.Abs(C[0, 0]))
    //        + (b.extents[1] * System.Math.Abs(C[1, 2]))
    //        + (b.extents[2] * System.Math.Abs(C[1, 0]))
    //        >
    //        System.Math.Abs(
    //            C[2, 0] * axis.Row(0).DotProduct(D)
    //            - C[0, 0] * axis.Row(2).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A1 X B1
    //    if (
    //        (extents[0] * System.Math.Abs(C[2, 1]))
    //        + (extents[2] * System.Math.Abs(C[0, 1]))
    //        + (b.extents[0] * System.Math.Abs(C[1, 2]))
    //        + (b.extents[2] * System.Math.Abs(C[1, 0]))
    //        >
    //        System.Math.Abs(
    //            C[2, 1] * axis.Row(0).DotProduct(D)
    //            - C[0, 1] * axis.Row(2).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A1 X B2
    //    if (
    //        (extents[0] * System.Math.Abs(C[2, 2]))
    //        + (extents[2] * System.Math.Abs(C[0, 2]))
    //        + (b.extents[0] * System.Math.Abs(C[0, 2]))
    //        + (b.extents[1] * System.Math.Abs(C[1, 0]))
    //        >
    //        System.Math.Abs(
    //            C[2, 2] * axis.Row(0).DotProduct(D)
    //            - C[0, 2] * axis.Row(2).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A2 X B0
    //    if (
    //        (extents[0] * System.Math.Abs(C[1, 1]))
    //        + (extents[1] * System.Math.Abs(C[0, 1]))
    //        + (b.extents[1] * System.Math.Abs(C[2, 2]))
    //        + (b.extents[2] * System.Math.Abs(C[2, 1]))
    //        >
    //        System.Math.Abs(
    //            C[0, 0] * axis.Row(1).DotProduct(D)
    //            - C[1, 0] * axis.Row(0).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A2 X B1
    //    if (
    //        (extents[0] * System.Math.Abs(C[1, 1]))
    //        + (extents[1] * System.Math.Abs(C[0, 1]))
    //        + (b.extents[0] * System.Math.Abs(C[2, 2]))
    //        + (b.extents[2] * System.Math.Abs(C[2, 0]))
    //        >
    //        System.Math.Abs(
    //            C[0, 1] * axis.Row(1).DotProduct(D)
    //            - C[1, 1] * axis.Row(0).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    // For vector A2 X B2
    //    if (
    //        (extents[0] * System.Math.Abs(C[1, 2]))
    //        + (extents[1] * System.Math.Abs(C[0, 2]))
    //        + (b.extents[0] * System.Math.Abs(C[2, 1]))
    //        + (b.extents[1] * System.Math.Abs(C[2, 0]))
    //        >
    //        System.Math.Abs(
    //            C[0, 2] * axis.Row(1).DotProduct(D)
    //            - C[1, 2] * axis.Row(0).DotProduct(D)
    //            )
    //        )
    //    {
    //        return true;
    //    }

    //    return false;
    }

    IntersectData doesIntersect(OBB other)
    {
        //Calculate all needed info
        //Vector<float> D = pos - other.pos;//Difference of centers
        //Vector<float>[] L = new Vector<float>[15]; // potential axis of seperation



        //L[0] = axis.Row(0);
        //L[1] = axis.Row(1);
        //L[2] = axis.Row(2);
        //L[3] = other.axis.Row(0);
        //L[4] = other.axis.Row(1);
        //L[5] = other.axis.Row(2);
        //L[6] = CrossProduct( axis.Row(0), other.axis.Row(0));
        //L[7] = 








        IntersectData data = new IntersectData();
        return data;
    }

    private Vector<float> CrossProduct(Vector<float> A, Vector<float> B)
    {
        Vector<float> C = Vector<float>.Build.Dense(4);
        C[0] = ((A[1] * B[2]) - (A[2] * B[1]));
        C[1] = ((A[2] * B[0]) - (A[0] * B[2]));
        C[2] = ((A[0] * B[1]) - (A[1] * B[0]));

        return C;
    }
}
