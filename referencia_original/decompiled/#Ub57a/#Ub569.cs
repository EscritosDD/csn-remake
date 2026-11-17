// Decompiled with JetBrains decompiler
// Type: 땺.땩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public class 땩
  {
    public static void 딟([In] RageSvgObject obj0)
    {
      if (obj0.Paths.Count < 2)
        return;
      for (int index1 = 0; index1 < obj0.Paths.Count - 1; ++index1)
      {
        딥 spline1 = obj0.Paths[index1].Spline;
        Dictionary<int, 딥> dictionary = new Dictionary<int, 딥>();
        for (int index2 = index1 + 1; index2 < obj0.Paths.Count; ++index2)
        {
          딥 spline2 = obj0.Paths[index2].Spline;
          if (spline1 != spline2)
            dictionary.Add(index2, spline2);
        }
        List<int> intList = 땩.딟(spline1, dictionary);
        for (int index3 = intList.Count - 1; index3 >= 0; --index3)
        {
          ((Object) obj0.Paths[intList[index3]].Spline.딦()).딟();
          obj0.Paths.RemoveAt(intList[index3]);
        }
      }
    }

    private static List<int> 딟([In] 딥 obj0, [In] Dictionary<int, 딥> obj1)
    {
      List<딥> 딥List = new List<딥>();
      List<int> intList = new List<int>();
      foreach (KeyValuePair<int, 딥> keyValuePair in obj1)
      {
        if (땩.딟(obj0, keyValuePair.Value) && !땩.딟(obj1, keyValuePair.Value))
        {
          딥List.Add(keyValuePair.Value);
          intList.Add(keyValuePair.Key);
        }
      }
      while (딥List.Count > 0)
      {
        int index = 땩.딟(obj0, 딥List);
        땩.땄(obj0, 딥List[index]);
        딥List.RemoveAt(index);
      }
      return intList;
    }

    private static bool 딟([In] Dictionary<int, 딥> obj0, [In] 딥 obj1)
    {
      foreach (KeyValuePair<int, 딥> keyValuePair in obj0)
      {
        if (keyValuePair.Value != obj1 && 땩.딟(keyValuePair.Value, obj1))
          return true;
      }
      return false;
    }

    private static int 딟([In] 딥 obj0, [In] List<딥> obj1)
    {
      int num1 = 0;
      float num2 = 0.0f;
      for (int index = 0; index < obj1.Count; ++index)
      {
        float num3 = 0.0f;
        float num4 = 0.0f;
        Vector3 vector3_1 = obj0.딧(0).땄();
        Vector3 vector3_2 = obj1[index].딧(0).땄();
        float num5 = 0.0f;
        땩.딟(obj0, obj1[index], ref num3, ref num4, ref vector3_1, ref vector3_2, ref num5);
        if (index == 0)
          num2 = num5;
        else if ((double) num5 < (double) num2)
        {
          num1 = index;
          num2 = num5;
        }
      }
      return num1;
    }

    private static bool 딟([In] 딥 obj0, [In] 딥 obj1)
    {
      if (obj0.딷() < 3 || obj1.딷() < 3)
        return false;
      bool flag = true;
      for (int index = 0; index < obj1.딷(); ++index)
      {
        Vector3 vector3 = obj1.딧(index).땄();
        flag = 땩.딟(obj0, Vector2.op_Implicit(vector3));
        if (!flag)
          break;
      }
      return flag;
    }

    private static void 땄([In] 딥 obj0, [In] 딥 obj1)
    {
      float splinePosition1 = 0.0f;
      float splinePosition2 = 0.0f;
      Vector3 vector3_1 = obj0.딧(0).땄();
      Vector3 vector3_2 = obj1.딧(0).땄();
      float num1 = 0.0f;
      땩.딟(obj0, obj1, ref splinePosition1, ref splinePosition2, ref vector3_1, ref vector3_2, ref num1);
      int num2 = obj0.땟().spline.떂(splinePosition1);
      if ((double) Vector2.Distance(Vector2.op_Implicit(obj0.딧(num2).땄()), Vector2.op_Implicit(vector3_1)) > 0.100000001490116)
        num2 = obj0.땟().AddPoint(splinePosition1);
      딛 딛1 = obj0.딧(num2);
      int num3 = obj0.딟(num2 + 1, 딛1.땃(), Vector3.zero, 딛1.땓(), 1f, false).딟();
      딛1.딶(Vector3.zero);
      int num4 = obj1.땟().spline.떂(splinePosition2);
      if ((double) Vector2.Distance(Vector2.op_Implicit(obj1.딧(num4).땄()), Vector2.op_Implicit(vector3_2)) > 0.1)
        num4 = obj1.땟().AddPoint(splinePosition2);
      if (num4 != 0 && num4 != obj1.딷() - 1)
      {
        for (; num4 != 0; --num4)
        {
          obj1.딧(obj1.딷() - 1).딶(obj1.딧(0).땓());
          obj1.땄(0);
          딛 딛2 = obj1.딧(0);
          obj1.딟(obj1.딷(), 딛2.땃(), 딛2.딶(), 딛2.땓(), 1f, false);
        }
      }
      float num5 = 0.01f;
      Vector3 vector3_3 = Vector3.Cross(!obj1.떏() ? Vector3.back : Vector3.forward, Vector3.op_Subtraction(obj1.딧(0).땄(), 딛1.땄()));
      Vector3 vector3_4 = Vector3.op_Multiply(num5, ((Vector3) ref vector3_3).normalized);
      딛 딛3 = obj1.딧(0);
      딛3.딟(Vector3.op_Addition(딛3.땄(), vector3_4));
      딛 딛4 = 딛1;
      딛4.딟(Vector3.op_Addition(딛4.땄(), vector3_4));
      for (int index = 0; index < obj1.딷(); ++index)
      {
        딛 딛5 = obj1.딧(index);
        if (index == obj1.딷() - 1)
          obj0.딟(num3, 딛5.땃(), 딛5.딶(), Vector3.zero, 1f, false);
        else if (index == 0)
          obj0.딟(num3, 딛5.땃(), Vector3.zero, 딛5.땓(), 1f, false);
        else
          obj0.딟(num3, 딛5.땃(), 딛5.딶(), 딛5.땓(), 1f, false);
        ++num3;
      }
    }

    private static void 딟(
      [In] 딥 obj0,
      [In] 딥 obj1,
      [In] ref float obj2,
      [In] ref float obj3,
      [In] ref Vector3 obj4,
      [In] ref Vector3 obj5,
      [In] ref float obj6)
    {
      int num1 = obj0.딷() <= 10 ? 10 : obj0.딷();
      int num2 = obj1.딷() <= 10 ? 10 : obj1.딷();
      float num3 = 1f / (float) num1;
      float num4 = 1f / (float) num2;
      for (float num5 = 0.0f; (double) num5 < 1.0; num5 += num3)
      {
        Vector3 vector3_1 = obj0.땟().spline.땺(num5);
        for (float num6 = 0.0f; (double) num6 < 1.0; num6 += num4)
        {
          Vector3 vector3_2 = obj1.땟().spline.땺(num6);
          float num7 = Vector2.Distance(Vector2.op_Implicit(vector3_1), Vector2.op_Implicit(vector3_2));
          if (Mathf.Approximately(num5, 0.0f) && Mathf.Approximately(num6, 0.0f))
            obj6 = num7;
          if ((double) obj6 > (double) num7)
          {
            obj6 = num7;
            obj2 = num5;
            obj3 = num6;
            obj4 = vector3_1;
            obj5 = vector3_2;
          }
        }
      }
    }

    private static bool 딟([In] 딥 obj0, [In] Vector2 obj1)
    {
      int num = obj0.딷() - 1;
      bool flag = false;
      for (int index = 0; index < obj0.딷(); ++index)
      {
        Vector3 vector3_1 = obj0.딧(index).땄();
        Vector3 vector3_2 = obj0.딧(num).땄();
        if ((vector3_1.y < obj1.y && vector3_2.y >= obj1.y || vector3_2.y < obj1.y && vector3_1.y >= obj1.y) && vector3_1.x + (obj1.y - vector3_1.y) / (vector3_2.y - vector3_1.y) * (vector3_2.x - vector3_1.x) < obj1.x)
          flag = !flag;
        num = index;
      }
      return flag;
    }
  }
}
