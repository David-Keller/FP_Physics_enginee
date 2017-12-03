

//#define FPMUL(x,y)	((((x)>>6)*((y)>>6))>>4)
//#define FPDIV(x,y)	((((x)<<6)/((y)>>6))>>4)
//#define FPONE		65536
//#define FPP			16
//#define FPI(x)		((x)<<FPP)
//#define FPABS(n)	(((n)&(1<<31))?(-(n)):(n)) 
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// ===================================================
//// MATH.H           -=- Focus3 -=-     By Jacco Bikker
//// Integer math 3D engine for mobile devices  ><> 2003 
//// ===================================================




//namespace Overloaded
//{

//    class Plane;
//    class Matrix;
//    class Vector
//    {
//        public:
//	Vector(void ) { x = y = z = 0; }
//        Vector(int a_X, int a_Y, int a_Z) { x = a_X; y = a_Y; z = a_Z; }
//        void Set(int a_X, int a_Y, int a_Z) { x = a_X; y = a_Y; z = a_Z; }
//        void Between(Vector& a_V1, Vector& a_V2, int a_Pos);
//        int Distance(Plane& a_Plane, bool oldmethod = false);
//        int Distance(Vector& a_C1, Vector& a_C2 );
//        int Distance(Vector& a_Pos );
//        Vector ClosestPoint(Vector& a_C1, Vector& a_C2 );
//        void Normalize(void );
//        int Length(void );
//        void Transform(Matrix& a_Matrix );
//        void InvTransform(Matrix& m );
//        int Dot(Vector a_V) { return FPMUL(a_V.x, x) + FPMUL(a_V.y, y) + FPMUL(a_V.z, z); }
//        Vector Cross(Vector b) { return Vector(FPMUL(y, b.z) - FPMUL(z, b.y), FPMUL(z, b.x) - FPMUL(x, b.z), FPMUL(x, b.y) - FPMUL(y, b.x)); }
//	operator += ( Vector& a_V ) { x += a_V.x; y += a_V.y; z += a_V.z; }

//    operator += ( Vector* a_V)
//    { x += a_V->x; y += a_V->y; z += a_V->z; }

//    operator -= ( Vector& a_V )
//    { x -= a_V.x; y -= a_V.y; z -= a_V.z; }

//    operator -= ( Vector* a_V)
//    { x -= a_V->x; y -= a_V->y; z -= a_V->z; }

//    operator *= ( int f)
//    { x = FPMUL(x, f); y = FPMUL(y, f); z = FPMUL(z, f); }
//    Vector operator -() const { return Vector( -x, -y, -z );
//}
//friend Vector operator +(const Vector& v1, const Vector& v2) { return Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z); }
//friend Vector operator -(const Vector& v1, const Vector& v2) { return Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z); }
//friend Vector operator +(const Vector& v1, Vector* v2) { return Vector(v1.x + v2->x, v1.y + v2->y, v1.z + v2->z); }
//friend Vector operator -(const Vector& v1, Vector* v2) { return Vector(v1.x - v2->x, v1.y - v2->y, v1.z - v2->z); }
//friend Vector operator *(const Vector& v, int f) { return Vector(FPMUL(v.x, f), FPMUL(v.y, f), FPMUL(v.z, f)); }
//friend Vector operator *(int f, const Vector& v) { return Vector(FPMUL(v.x, f), FPMUL(v.y, f), FPMUL(v.z, f)); }
//int x, y, z;
//};

//class Matrix
//{
//    public:
//	Matrix() { Identity(); }
//    void Identity(void );
//    void Invert(void );
//    void LookAt(Vector& a_Eye, Vector& a_At, Vector& a_Up );
//    void Rotate(Vector a_Trans, int a_RX, int a_RY, int a_RZ, int* a_Sin, int* a_Cos);
//    void RotateX(int a_RX, int* a_Sin, int* a_Cos);
//    void RotateY(int a_RY, int* a_Sin, int* a_Cos);
//    void RotateZ(int a_RZ, int* a_Sin, int* a_Cos);
//    void Translate(Vector a_Trans) { m_Cell[TX] += a_Trans.x; m_Cell[TY] += a_Trans.y; m_Cell[TZ] += a_Trans.z; }
//    void Concatenate(Matrix& a_M2 );
//    int Get(int a_Idx) { return m_Cell[a_Idx]; }
//    void Set(int a_Idx, int a_Value) { m_Cell[a_Idx] = a_Value; m_Virgin = false; }
//    enum { TX = 3, TY = 7, TZ = 11, W = 15 };
//    Matrix GetTransformMatrix(void );
//    Matrix GetTranslationMatrix(void );
//    Vector GetTranslation(void );
//    void SetTranslation(Vector a_Trans) { m_Cell[TX] = a_Trans.x; m_Cell[TY] = a_Trans.y; m_Cell[TZ] = a_Trans.z; }
//    void CheckIdentity(void );
//    private:
//	int m_Cell[16];
//    bool m_Virgin;
//};

//class Polygon;
//class Plane
//{
//    public:
//	Plane(Vector a_Normal, int a_D) { m_Normal = a_Normal; m_D = a_D; }
//    Plane(void ) { m_Normal = Vector(0, 0, 0); m_D = 0; }
//    void Face(Vector a_Pos) { if (a_Pos.Distance(m_Normal) > 0) Swap(); }
//    void DontFace(Vector a_Pos) { if (a_Pos.Distance(m_Normal) < 0) Swap(); }
//    bool Facing(Vector a_Pos) { return ((m_Normal.Dot(a_Pos) - m_D) > -EPSILON); }
//    void ABCD(Vector& a_V1, Vector& a_V2, Vector& a_V3 );
//    void Reset(void ) { m_Normal = Vector(0, 0, 0); m_D = 0; }
//    void Swap(void ) { m_Normal = -m_Normal; m_D = -m_D; }
//    int GetD() { return m_D; }
//    void SetD(int a_D) { m_D = a_D; }
//    Vector& GetNormal(void ) { return m_Normal; }
//    void SetNormal(Vector a_N) { m_Normal = a_N; }
//    private:
//	Vector m_Normal;
//    int m_D;
//};

//class BSphere
//{
//    public:
//	BSphere() { }
//    BSphere(Vector& a_Centre, int a_Radius) { m_Centre = a_Centre; m_Radius = a_Radius; }
//    ~BSphere() { }
//    void SetCentre(Vector& a_Centre ) { m_Centre = a_Centre; }
//    Vector& GetCentre(void ) { return m_Centre; }
//    void SetRadius(int a_Radius) { m_Radius = a_Radius; }
//    int GetRadius(void ) { return m_Radius; }
//    private:
//	Vector m_Centre;
//    int m_Radius;
//};

//class Frustum
//{
//    public:
//	Frustum();
//    ~Frustum();
//    void AddPlane(Plane* a_Plane) { m_Plane[m_Planes++] = a_Plane; }
//    Plane* GetPlane(int a_Idx) { return m_Plane[a_Idx]; }
//    Plane* GetRotPlane(int a_Idx) { return m_RotPlane[a_Idx]; }
//    void SetNrPlanes(int a_Count) { m_Planes = a_Count; }
//    int NrPlanes() { return m_Planes; }
//    void Transform(Matrix& a_Matrix );
//    void Reset();
//    private:
//	int m_Planes;
//    Plane* m_Plane[10];
//    Plane* m_RotPlane[10];
//};

//}; // namespace Overloaded

//#endif

//// ===================================================
//// EOF
