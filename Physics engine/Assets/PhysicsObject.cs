using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;

public class PhysicsObject : MonoBehaviour {
    PhysicsObject(vector pos_e, float mass_e)
    {
        //linear components
        pos = pos_e;
        mass = mass_e;

        vel = new vector();

        //rotational components
        //spin = Vector<float>.Build.Dense(4);
        //angularVelocity = new vector(0,0,0);
        
    }

    //collider

    public collider col
    {
        get { _col.center = pos; return _col;}
        set { _col = value; }
    }
    collider _col;
    //primary
    public vector pos {
        get { return _pos; }
        set { _pos = value; recalc(); } //keep the secondary values up to date
    }
    public vector momentum
    {
        get { return _momentum; }
        set { _momentum = value; recalc(); }//keep the secondary values up to date
    }
    public Quaternion orientation // actually a Quaternion
    {
        get { return orientation; }
        set { orientation = value; recalc(); }
    }
    public vector angularMomentum
    {
        get { return angularMomentum; }
        set { angularMomentum = value;  recalc(); }
    }
    [SerializeField]
    vector _pos;
    vector _momentum;


    //secondary
    public Vector3 vel_start;
    public vector vel;
    public Quaternion spin;
    public vector angularVelocity;

    //constant
    public float mass;
    public float inversMass;
    public float inertia;
    float inversInertia;
    float dt = 1000; // for now this is in milli seconds

    public void integrate()
    {
        pos = pos + (vel * new Fixed((decimal)Time.deltaTime));
    }

    void recalc()
    {
    }
    //    vel = momentum * inversMass;

        //    angularVelocity = angularMomentum * inversInertia;
        //    float norm = orientation.x * orientation.x + orientation.y * orientation.y + orientation.z * orientation.z + orientation.w * orientation.w;
        //    norm = Mathf.Sqrt(norm);


        //    //    Quaternion q;

        //    //spin = 0.5f * 

        //    //spin = spin.cross orientation;

        //}


    public void Update()
    {
        transform.position = pos;
    }

    //temporaty
    public void Start()
    {
        pos = new vector(new Fixed((decimal)transform.position.x),
                        new Fixed((decimal)transform.position.y),
                        new Fixed((decimal)transform.position.z));
        vel = new vector(new Fixed((decimal)vel_start.x),
                        new Fixed((decimal)vel_start.y),
                        new Fixed((decimal)vel_start.z));
        col = GetComponent<collider>();
    }

}
