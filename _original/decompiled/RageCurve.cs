// Decompiled with JetBrains decompiler
// Type: RageCurve
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class RageCurve
{
  public Vector3[] precalcNormals;
  public Vector3[] precalcPositions;
  public RageSplinePoint[] points;
  public float PercentPrecalcNormals = 1f;
  public bool Triangulate = true;
  private Vector3[] 딟;

  public RageCurve([In] Vector3[] obj0, [In] Vector3[] obj1, [In] bool[] obj2, [In] float[] obj3)
  {
    this.points = new RageSplinePoint[obj0.Length];
    for (int index = 0; index < obj0.Length; ++index)
      this.points[index] = new RageSplinePoint(obj0[index], obj1[index * 2], obj1[index * 2 + 1], obj3[index], obj2[index]);
  }

  public RageCurve 딟()
  {
    Vector3[] vector3Array1 = new Vector3[this.points.Length];
    Vector3[] vector3Array2 = new Vector3[this.points.Length * 2];
    float[] numArray = new float[this.points.Length];
    bool[] flagArray = new bool[this.points.Length];
    for (int index = 0; index < vector3Array1.Length; ++index)
    {
      vector3Array1[index] = this.points[index].point;
      numArray[index] = this.points[index].widthMultiplier;
      vector3Array2[index] = this.points[index].inCtrl;
      vector3Array2[index + 1] = this.points[index].outCtrl;
      flagArray[index] = this.points[index].natural;
    }
    return new RageCurve(vector3Array1, vector3Array2, flagArray, numArray);
  }

  [SpecialName]
  public Vector3[] 땄()
  {
    if (this.딟 == null || this.딟.Length != this.points.Length)
    {
      this.딟 = new Vector3[this.points.Length];
      for (int index = 0; index < this.points.Length; ++index)
        this.딟[index] = this.points[index].point;
    }
    return this.딟;
  }

  public float 딟([In] float obj0)
  {
    if (this.points.Length <= 0)
      return 0.0f;
    if ((double) obj0 > 0.999000012874603 || (double) obj0 < 0.0)
      obj0 = this.딟(obj0, 0.999f);
    int index = this.딢(obj0);
    float num1 = obj0 * (float) this.points.Length - (float) index;
    float num2 = (double) num1 >= 0.5 ? (float) ((1.0 - (1.0 - ((double) num1 - 0.5) * 2.0) * (1.0 - ((double) num1 - 0.5) * 2.0)) / 2.0 + 0.5) : (float) ((double) num1 * 2.0 * ((double) num1 * 2.0) / 2.0);
    return index < this.points.Length - 1 ? (float) ((double) this.points[index].widthMultiplier * (1.0 - (double) num2) + (double) this.points[index + 1].widthMultiplier * (double) num2) : (float) ((double) this.points[index].widthMultiplier * (1.0 - (double) num2) + (double) this.points[0].widthMultiplier * (double) num2);
  }

  public Vector3 땄([In] float obj0)
  {
    if ((double) obj0 > 0.999000012874603 || (double) obj0 < 0.0)
      obj0 = this.딟(obj0, 0.999f);
    return this.precalcNormals[Mathf.Clamp(Mathf.FloorToInt(obj0 * (float) this.precalcNormals.Length), 0, this.precalcNormals.Length - 1)];
  }

  public Vector3 딧([In] float obj0)
  {
    if ((double) obj0 > 0.999000012874603 || (double) obj0 < 0.0)
      obj0 = this.딟(obj0, 0.999f);
    Vector3 precalcNormal1 = this.precalcNormals[Mathf.Clamp(Mathf.FloorToInt(obj0 * (float) this.precalcNormals.Length), 0, this.precalcNormals.Length - 1)];
    Vector3 precalcNormal2 = this.precalcNormals[Mathf.Clamp(Mathf.FloorToInt(obj0 * (float) this.precalcNormals.Length) + 1, 0, this.precalcNormals.Length - 1)];
    float num = obj0 * (float) this.precalcNormals.Length - (float) Mathf.FloorToInt(obj0 * (float) this.precalcNormals.Length);
    Vector3 vector3 = Vector3.op_Addition(Vector3.op_Multiply(precalcNormal1, 1f - num), Vector3.op_Multiply(precalcNormal2, num));
    ((Vector3) ref vector3).Normalize();
    return vector3;
  }

  public Vector3 딟([In] int obj0)
  {
    if (obj0 >= this.points.Length || obj0 < 0)
      obj0 = this.딟(obj0, this.points.Length);
    return this.precalcNormals[Mathf.Clamp(Mathf.FloorToInt((float) obj0 / (float) this.points.Length * (float) this.precalcNormals.Length), 0, this.precalcNormals.Length - 1)];
  }

  public Vector3 딟([In] float obj0, [In] Vector3 obj1)
  {
    if (this.points.Length <= 0)
      return new Vector3(1f, 0.0f, 0.0f);
    obj0 = Mathf.Clamp01(obj0);
    float num1 = this.딟(obj0 - 1f / 1000f, 1f);
    int index1 = this.딢(num1);
    int index2 = this.땃(num1);
    float num2 = this.땥(num1);
    RageSplinePoint point1 = this.points[index1];
    RageSplinePoint point2 = this.points[index2];
    float num3 = this.딟(obj0 + 1f / 1000f, 1f);
    int index3 = this.딢(num3);
    int index4 = this.땃(num3);
    float num4 = this.땥(num3);
    RageSplinePoint point3 = this.points[index3];
    RageSplinePoint point4 = this.points[index4];
    Vector3 vector3_1 = Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(-3f, point1.point), Vector3.op_Multiply(9f, Vector3.op_Addition(point1.point, point1.outCtrl))), Vector3.op_Multiply(9f, Vector3.op_Addition(point2.point, point2.inCtrl))), Vector3.op_Multiply(3f, point2.point)), num2), num2), Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Multiply(6f, point1.point), Vector3.op_Multiply(12f, Vector3.op_Addition(point1.point, point1.outCtrl))), Vector3.op_Multiply(6f, Vector3.op_Addition(point2.point, point2.inCtrl))), num2)), Vector3.op_Multiply(3f, point1.point)), Vector3.op_Multiply(3f, Vector3.op_Addition(point1.point, point1.outCtrl)));
    Vector3 vector3_2 = Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(-3f, point3.point), Vector3.op_Multiply(9f, Vector3.op_Addition(point3.point, point3.outCtrl))), Vector3.op_Multiply(9f, Vector3.op_Addition(point4.point, point4.inCtrl))), Vector3.op_Multiply(3f, point4.point)), num4), num4), Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Multiply(6f, point3.point), Vector3.op_Multiply(12f, Vector3.op_Addition(point3.point, point3.outCtrl))), Vector3.op_Multiply(6f, Vector3.op_Addition(point4.point, point4.inCtrl))), num4)), Vector3.op_Multiply(3f, point3.point)), Vector3.op_Multiply(3f, Vector3.op_Addition(point3.point, point3.outCtrl)));
    Vector3 vector3_3 = Vector3.Cross(Vector3.op_Multiply(Vector3.op_Addition(((Vector3) ref vector3_1).normalized, ((Vector3) ref vector3_2).normalized), 0.5f), obj1);
    return ((Vector3) ref vector3_3).normalized;
  }

  public Vector3 딟([In] float obj0, [In] float obj1, [In] int obj2)
  {
    Vector3 vector3 = new Vector3();
    float num1 = 999999f;
    float num2 = -999999f;
    int index1 = this.땃(obj0);
    int index2 = this.딢(obj0);
    if (!this.points[index1].natural)
      num1 = index1 <= 0 ? (float) this.points.Length - 0.01f : (float) ((double) index1 / (double) this.points.Length - 0.00999999977648258);
    if (!this.points[index2].natural)
      num2 = index2 >= this.points.Length - 1 ? 0.01f : (float) ((double) index2 / (double) this.points.Length + 0.00999999977648258);
    for (float num3 = obj0 - obj1 / 2f; (double) num3 < (double) obj0 + (double) obj1 / 2.0 + (double) obj1 * 0.5 / (double) obj2; num3 += obj1 / (float) obj2)
    {
      if ((double) num3 > (double) num2 && (double) num3 < (double) num1)
        vector3 = Vector3.op_Addition(vector3, this.땄(num3));
    }
    return ((Vector3) ref vector3).normalized;
  }

  public void 딟([In] int obj0, [In] int obj1, [In] Vector3 obj2)
  {
    if (this.points[obj0].natural)
    {
      if (obj1 == 0)
      {
        this.points[obj0].inCtrl = obj2;
        this.points[obj0].outCtrl = Vector3.op_Multiply(obj2, -1f);
      }
      else
      {
        this.points[obj0].inCtrl = Vector3.op_Multiply(obj2, -1f);
        this.points[obj0].outCtrl = obj2;
      }
    }
    else if (obj1 == 0)
      this.points[obj0].inCtrl = obj2;
    else
      this.points[obj0].outCtrl = obj2;
  }

  public int 딢([In] float obj0)
  {
    int num = Mathf.FloorToInt(obj0 * (float) this.points.Length);
    if (num >= this.points.Length || num < 0)
      num = this.딟(num, this.points.Length);
    return num;
  }

  public int 땃([In] float obj0)
  {
    int num = Mathf.FloorToInt(obj0 * (float) this.points.Length) + 1;
    if (num >= this.points.Length || num < 0)
      num = this.딟(num, this.points.Length);
    return num;
  }

  public RageSplinePoint 땄([In] int obj0)
  {
    if (obj0 >= this.points.Length || obj0 < 0)
      obj0 = this.딟(obj0, this.points.Length);
    return this.points[obj0];
  }

  public Vector3 딶([In] float obj0)
  {
    if ((double) obj0 > 0.999000012874603 || (double) obj0 < 0.0)
      obj0 = this.딟(obj0, 0.999f);
    return this.precalcPositions[Mathf.Clamp(Mathf.FloorToInt(obj0 * (float) this.precalcPositions.Length), 0, this.precalcPositions.Length - 1)];
  }

  public Vector3 땓([In] float obj0)
  {
    if ((double) obj0 > 0.999000012874603 || (double) obj0 < 0.0)
      obj0 = this.딟(obj0, 0.999f);
    Vector3 precalcPosition1 = this.precalcPositions[Mathf.Clamp(Mathf.FloorToInt(obj0 * (float) this.precalcPositions.Length), 0, this.precalcPositions.Length - 1)];
    Vector3 precalcPosition2 = this.precalcPositions[Mathf.Clamp(Mathf.FloorToInt(obj0 * (float) this.precalcPositions.Length) + 1, 0, this.precalcPositions.Length - 1)];
    float num = obj0 * (float) this.precalcPositions.Length - (float) Mathf.FloorToInt(obj0 * (float) this.precalcPositions.Length);
    return Vector3.op_Addition(Vector3.op_Multiply(precalcPosition1, 1f - num), Vector3.op_Multiply(precalcPosition2, num));
  }

  public Vector3 땺([In] float obj0)
  {
    if ((double) obj0 < 9.99999974737875E-06 || (double) obj0 > 0.999989986419678)
      obj0 = this.딟(obj0, 1f);
    int index1 = this.딢(obj0);
    int index2 = this.땃(obj0);
    float num1 = this.땥(obj0);
    RageSplinePoint point1 = this.points[index1];
    RageSplinePoint point2 = this.points[index2];
    float num2 = 1f - num1;
    return Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Addition(Vector3.op_Multiply(num2 * num2 * num2, point1.point), Vector3.op_Multiply(3f * num2 * num2 * num1, Vector3.op_Addition(point1.point, point1.outCtrl))), Vector3.op_Multiply(3f * num2 * num1 * num1, Vector3.op_Addition(point2.point, point2.inCtrl))), Vector3.op_Multiply(num1 * num1 * num1, point2.point));
  }

  public float 땥([In] float obj0)
  {
    if ((double) obj0 < 0.0 || (double) obj0 > 1.0)
      obj0 = this.딟(obj0, 1f);
    int num = this.딢(obj0);
    return Mathf.Clamp01(obj0 * (float) this.points.Length - (float) num);
  }

  public Vector3 딧([In] int obj0)
  {
    Vector3 vector3 = Vector2.op_Implicit(new Vector2());
    for (int index = 0; index < obj0; ++index)
      vector3 = Vector3.op_Addition(vector3, this.땺((float) index / (float) obj0));
    return Vector3.op_Multiply(vector3, 1f / (float) obj0);
  }

  public float 딢([In] int obj0)
  {
    float num1 = 0.0f;
    float num2 = 1f / (float) obj0;
    Vector3 vector3_1 = this.땺(0.0f);
    for (int index = 1; index < obj0; ++index)
    {
      Vector3 vector3_2 = this.땺((float) index * num2);
      double num3 = (double) num1;
      Vector3 vector3_3 = Vector3.op_Subtraction(vector3_2, vector3_1);
      double magnitude = (double) ((Vector3) ref vector3_3).magnitude;
      num1 = (float) (num3 + magnitude);
      vector3_1 = vector3_2;
    }
    return num1;
  }

  public Vector3 딟([In] int obj0, [In] float obj1, [In] float obj2)
  {
    obj1 = Mathf.Clamp01(obj1);
    obj2 = Mathf.Clamp01(obj2);
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(1E+08f, 1E+08f, 1E+08f);
    for (int index = 0; index < obj0; ++index)
    {
      Vector3 vector3_2 = this.땺((float) ((double) index / (double) obj0 * ((double) obj2 - (double) obj1)) + obj1);
      if (vector3_2.x < vector3_1.x)
        vector3_1.x = vector3_2.x;
      if (vector3_2.y < vector3_1.y)
        vector3_1.y = vector3_2.y;
      if (vector3_2.z < vector3_1.z)
        vector3_1.z = vector3_2.z;
    }
    return vector3_1;
  }

  public Vector3 땄([In] int obj0, [In] float obj1, [In] float obj2)
  {
    obj1 = Mathf.Clamp01(obj1);
    obj2 = Mathf.Clamp01(obj2);
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(-1E+08f, -1E+08f, -1E+08f);
    for (int index = 0; index < obj0; ++index)
    {
      Vector3 vector3_2 = this.땺((float) ((double) index / (double) obj0 * ((double) obj2 - (double) obj1)) + obj1);
      if (vector3_2.x > vector3_1.x)
        vector3_1.x = vector3_2.x;
      if (vector3_2.y > vector3_1.y)
        vector3_1.y = vector3_2.y;
      if (vector3_2.z > vector3_1.z)
        vector3_1.z = vector3_2.z;
    }
    return vector3_1;
  }

  public Vector3[] 딝([In] float obj0)
  {
    int num1 = this.땃(obj0);
    float num2 = this.땥(obj0);
    Vector3 vector3_1 = this.땺(obj0);
    Vector3 point1 = this.points[this.딟(num1 - 1, this.points.Length)].point;
    Vector3 point2 = this.points[this.딟(num1, this.points.Length)].point;
    Vector3 vector3_2 = Vector3.op_Addition(point1, this.points[this.딟(num1 - 1, this.points.Length)].outCtrl);
    Vector3 vector3_3 = Vector3.op_Addition(point2, this.points[this.딟(num1, this.points.Length)].inCtrl);
    Vector3 vector3_4 = Vector3.Lerp(point1, vector3_2, num2);
    Vector3 vector3_5 = Vector3.Lerp(vector3_2, vector3_3, num2);
    Vector3 vector3_6 = Vector3.Lerp(vector3_3, point2, num2);
    Vector3 vector3_7 = Vector3.Lerp(vector3_4, vector3_5, num2);
    Vector3 vector3_8 = Vector3.Lerp(vector3_5, vector3_6, num2);
    return new Vector3[2]
    {
      Vector3.op_Subtraction(vector3_7, vector3_1),
      Vector3.op_Subtraction(vector3_8, vector3_1)
    };
  }

  private int 딟([In] int obj0, [In] RageSplinePoint[] obj1) => this.딟(obj0, obj1.Length);

  public int 떎([In] float obj0)
  {
    RageSplinePoint[] rageSplinePointArray = new RageSplinePoint[this.points.Length + 1];
    int index1 = this.땃(obj0);
    Vector3 vector3_1 = Vector3.op_Subtraction(this.땺(obj0 + 1f / 1000f), this.땺(obj0 - 1f / 1000f));
    Vector3 normalized1 = ((Vector3) ref vector3_1).normalized;
    float num1 = (float) ((double) ((Vector3) ref this.points[this.딟(index1 - 1, this.points.Length)].outCtrl).magnitude * 0.25 + (double) ((Vector3) ref this.points[this.딟(index1, this.points.Length)].inCtrl).magnitude * 0.25);
    int index2 = this.딟(index1 - 1, this.points);
    int index3 = this.딟(index1, this.points);
    RageSplinePoint point1 = this.points[index2];
    RageSplinePoint point2 = this.points[index3];
    RageSplinePoint rageSplinePoint1 = new RageSplinePoint(this.땺(obj0), Vector3.op_Multiply(Vector3.op_Multiply(num1, normalized1), -1f), Vector3.op_Multiply(num1, normalized1), this.딟(obj0), false);
    rageSplinePointArray[index1] = rageSplinePoint1;
    float num2 = this.딟(point1.point, 1000);
    float num3 = this.딟(point2.point, 1000);
    float num4 = this.딟(rageSplinePoint1.point, 1000);
    if ((double) num2 > (double) num4)
      --num2;
    if ((double) num3 < (double) num4)
      ++num3;
    float num5 = Mathf.Abs(num3 - num2);
    float num6 = 0.5f;
    if (!Mathf.Approximately(num5, 0.0f))
      num6 = Mathf.Abs(num4 - num2) / num5;
    Vector3 vector3_2 = Vector3.op_Multiply(num6, point1.outCtrl);
    Vector3 vector3_3 = Vector3.op_Multiply(1f - num6, point2.inCtrl);
    Vector3 vector3_4 = Vector3.op_Addition(Vector3.op_Multiply(1f - num6, Vector3.op_Addition(point1.point, point1.outCtrl)), Vector3.op_Multiply(num6, Vector3.op_Addition(point2.point, point2.inCtrl)));
    Vector3 vector3_5 = Vector3.op_Addition(Vector3.op_Multiply(1f - num6, Vector3.op_Addition(point1.point, vector3_2)), Vector3.op_Multiply(num6, vector3_4));
    Vector3 vector3_6 = Vector3.op_Addition(Vector3.op_Multiply(1f - num6, vector3_4), Vector3.op_Multiply(num6, Vector3.op_Addition(point2.point, vector3_3)));
    RageSplinePoint rageSplinePoint2 = rageSplinePoint1;
    Vector3 normalized2 = ((Vector3) ref rageSplinePoint1.inCtrl).normalized;
    Vector3 vector3_7 = Vector3.op_Subtraction(vector3_5, rageSplinePoint1.point);
    double magnitude1 = (double) ((Vector3) ref vector3_7).magnitude;
    Vector3 vector3_8 = Vector3.op_Multiply(normalized2, (float) magnitude1);
    rageSplinePoint2.inCtrl = vector3_8;
    RageSplinePoint rageSplinePoint3 = rageSplinePoint1;
    Vector3 normalized3 = ((Vector3) ref rageSplinePoint1.outCtrl).normalized;
    Vector3 vector3_9 = Vector3.op_Subtraction(vector3_6, rageSplinePoint1.point);
    double magnitude2 = (double) ((Vector3) ref vector3_9).magnitude;
    Vector3 vector3_10 = Vector3.op_Multiply(normalized3, (float) magnitude2);
    rageSplinePoint3.outCtrl = vector3_10;
    point1.outCtrl = vector3_2;
    point2.inCtrl = vector3_3;
    for (int index4 = 0; index4 < rageSplinePointArray.Length; ++index4)
    {
      if (index4 < index1)
        rageSplinePointArray[index4] = this.points[index4];
      if (index4 > index1)
        rageSplinePointArray[index4] = this.points[index4 - 1];
    }
    this.points = rageSplinePointArray;
    return index1;
  }

  private float 딟([In] Vector3 obj0, [In] float obj1) => Vector3.SqrMagnitude(Vector3.op_Subtraction(obj0, this.땺(obj1)));

  private float 땃([In] int obj0) => this.딟(this.points[obj0].point, 1000);

  public void 딟([In] int obj0, [In] Vector3 obj1)
  {
    RageSplinePoint[] rageSplinePointArray = new RageSplinePoint[this.points.Length + 1];
    float num1 = (float) ((double) obj0 / (double) this.points.Length + 1.0 / (double) this.points.Length);
    Vector3 vector3_1 = obj1;
    Vector3 vector3_2 = this.땺(num1 - 1f / 1000f);
    Vector3 normalized = ((Vector3) ref vector3_2).normalized;
    Vector3 vector3_3 = Vector3.op_Subtraction(vector3_1, normalized);
    Vector3 vector3_4 = Vector3.op_Subtraction(this.points[this.딟(obj0, this.points.Length)].point, this.points[this.딟(obj0 + 1, this.points.Length)].point);
    float num2 = ((Vector3) ref vector3_4).magnitude * 0.25f;
    rageSplinePointArray[obj0] = new RageSplinePoint(obj1, Vector3.op_Multiply(Vector3.op_Multiply(num2, vector3_3), -1f), Vector3.op_Multiply(num2, vector3_3), this.딟(num1), true);
    for (int index = 0; index < rageSplinePointArray.Length; ++index)
    {
      if (index < obj0)
        rageSplinePointArray[index] = this.points[index];
      if (index > obj0)
        rageSplinePointArray[index] = this.points[index - 1];
    }
    this.points = rageSplinePointArray;
  }

  public void 딧() => this.points = new RageSplinePoint[0];

  public void 딟([In] int obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3, [In] float obj4, [In] bool obj5)
  {
    RageSplinePoint[] rageSplinePointArray = new RageSplinePoint[this.points.Length + 1];
    rageSplinePointArray[obj0] = new RageSplinePoint(obj1, obj2, obj3, obj4, obj5);
    for (int index = 0; index < rageSplinePointArray.Length; ++index)
    {
      if (index < obj0)
        rageSplinePointArray[index] = this.points[index];
      if (index > obj0)
        rageSplinePointArray[index] = this.points[index - 1];
    }
    this.points = rageSplinePointArray;
  }

  public void 딶([In] int obj0)
  {
    if (this.points.Length <= 2)
      return;
    int index1 = obj0 <= 0 ? this.points.Length - 1 : obj0 - 1;
    int index2 = obj0 >= this.points.Length - 1 ? 0 : obj0 + 1;
    RageSplinePoint point1 = this.points[index1];
    RageSplinePoint point2 = this.points[obj0];
    RageSplinePoint point3 = this.points[index2];
    float num1 = this.딟(point1.point, 1000);
    float num2 = this.딟(point3.point, 1000);
    float num3 = this.딟(point2.point, 1000);
    if ((double) num1 > (double) num3)
      --num1;
    if ((double) num2 < (double) num3)
      ++num2;
    float num4 = Mathf.Abs(num2 - num1);
    if (Mathf.Approximately(num4, 0.0f))
    {
      this.땓(obj0);
    }
    else
    {
      float num5 = Mathf.Abs(num3 - num1) / num4;
      if ((double) num5 > 0.0)
        point1.outCtrl = Vector3.op_Division(point1.outCtrl, num5);
      if ((double) num5 < 1.0)
        point3.inCtrl = Vector3.op_Division(point3.inCtrl, 1f - num5);
      this.땓(obj0);
    }
  }

  public void 땓([In] int obj0)
  {
    if (this.points.Length <= 2)
      return;
    RageSplinePoint[] rageSplinePointArray = new RageSplinePoint[this.points.Length - 1];
    for (int index = 0; index < rageSplinePointArray.Length; ++index)
      rageSplinePointArray[index] = index >= obj0 ? this.points[index + 1] : this.points[index];
    this.points = rageSplinePointArray;
  }

  public float 딟([In] Vector3 obj0, [In] int obj1)
  {
    float num1 = 1E+11f;
    float num2 = 0.0f;
    for (int index = 0; index < obj1; ++index)
    {
      Vector3 vector3_1 = this.땺((float) index / (float) obj1);
      Vector3 vector3_2 = Vector3.op_Subtraction(obj0, vector3_1);
      if ((double) ((Vector3) ref vector3_2).sqrMagnitude < (double) num1)
      {
        num2 = (float) index / (float) obj1;
        Vector3 vector3_3 = Vector3.op_Subtraction(obj0, vector3_1);
        num1 = ((Vector3) ref vector3_3).sqrMagnitude;
      }
    }
    return num2;
  }

  public int 떂([In] float obj0) => (double) this.땥(obj0) > 0.5 ? this.땃(obj0) : this.딢(obj0);

  public void 땺([In] int obj0)
  {
    this.precalcNormals = new Vector3[obj0];
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(0.0f, 0.0f, -1f);
    for (int index = 0; index < obj0; ++index)
      this.precalcNormals[index] = this.딟((float) index / (float) (obj0 - 1), vector3);
  }

  public void 땥([In] int obj0)
  {
    this.precalcPositions = new Vector3[obj0];
    for (int index = 0; index < obj0; ++index)
    {
      this.precalcPositions[index] = this.땺((float) index / (float) (obj0 - 1));
      Debug.Log((object) ("precalcPositions[" + (object) index + "]=" + (object) this.precalcPositions[index]));
    }
  }

  public void 딢()
  {
    foreach (RageSplinePoint point in this.points)
    {
      if (!Mathf.Approximately((float) point.point.z, 0.0f))
        point.point = new Vector3((float) point.point.x, (float) point.point.y, 0.0f);
      if (!Mathf.Approximately((float) point.inCtrl.z, 0.0f))
        point.inCtrl = new Vector3((float) point.inCtrl.x, (float) point.inCtrl.y, 0.0f);
      if (!Mathf.Approximately((float) point.outCtrl.z, 0.0f))
        point.outCtrl = new Vector3((float) point.outCtrl.x, (float) point.outCtrl.y, 0.0f);
    }
  }

  private int 딟([In] int obj0, [In] int obj1) => (obj0 % obj1 + obj1) % obj1;

  private float 딟([In] float obj0, [In] float obj1) => (obj0 % obj1 + obj1) % obj1;

  public bool 딟([In] Vector3 obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3)
  {
    float num1 = this.딟(obj0, obj1, obj2);
    float num2 = this.딟(obj0, obj1, Vector3.op_Addition(obj2, obj3));
    if ((double) num1 > 0.0 && (double) num2 < 0.0)
      return true;
    return (double) num1 < 0.0 && (double) num2 > 0.0;
  }

  public Vector3 땄([In] Vector3 obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3)
  {
    float num1 = this.딟(obj0, obj1, obj2);
    float num2 = this.딟(obj0, obj1, Vector3.op_Addition(obj2, obj3));
    return (double) num1 > 0.0 && (double) num2 < 0.0 || (double) num1 < 0.0 && (double) num2 > 0.0 ? this.딧(obj0, Vector3.op_Addition(obj0, obj1), obj2, Vector3.op_Addition(obj2, obj3)) : Vector3.op_Addition(obj2, obj3);
  }

  public float 딟([In] Vector3 obj0, [In] Vector3 obj1, [In] Vector3 obj2)
  {
    Vector3 vector3_1 = obj0;
    Vector3 vector3_2 = Vector3.op_Addition(obj0, obj1);
    Vector3 vector3_3 = obj2;
    return (float) ((vector3_2.x - vector3_1.x) * (vector3_3.y - vector3_1.y) - (vector3_2.y - vector3_1.y) * (vector3_3.x - vector3_1.x));
  }

  public Vector3 딧([In] Vector3 obj0, [In] Vector3 obj1, [In] Vector3 obj2, [In] Vector3 obj3)
  {
    float num1 = (float) (obj1.y - obj0.y);
    float num2 = (float) (obj0.x - obj1.x);
    float num3 = (float) ((double) num1 * obj0.x + (double) num2 * obj0.y);
    float num4 = (float) (obj3.y - obj2.y);
    float num5 = (float) (obj2.x - obj3.x);
    float num6 = (float) ((double) num4 * obj2.x + (double) num5 * obj2.y);
    float num7 = (float) ((double) num1 * (double) num5 - (double) num4 * (double) num2);
    return (double) num7 == 0.0 ? obj3 : new Vector3((float) ((double) num5 * (double) num3 - (double) num2 * (double) num6) / num7, (float) ((double) num1 * (double) num6 - (double) num4 * (double) num3) / num7, 0.0f);
  }
}
