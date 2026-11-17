// Decompiled with JetBrains decompiler
// Type: RageTriangulator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RageTriangulator : ScriptableObject, 땺.땺
{
  public int[] 딟([In] Vector2[] obj0)
  {
    List<int> intList = new List<int>();
    List<Vector2> vector2List = new List<Vector2>((IEnumerable<Vector2>) obj0);
    int count = vector2List.Count;
    if (count < 3)
      return intList.ToArray();
    int[] numArray = new int[count];
    if ((double) this.딟(vector2List) > 0.0)
    {
      for (int index = 0; index < count; ++index)
        numArray[index] = index;
    }
    else
    {
      for (int index = 0; index < count; ++index)
        numArray[index] = count - 1 - index;
    }
    int num1 = count;
    int num2 = 2 * num1;
    int num3 = 0;
    int index1 = num1 - 1;
    while (num1 > 2)
    {
      if (num2-- <= 0)
        return intList.ToArray();
      int index2 = index1;
      if (num1 <= index2)
        index2 = 0;
      index1 = index2 + 1;
      if (num1 <= index1)
        index1 = 0;
      int index3 = index1 + 1;
      if (num1 <= index3)
        index3 = 0;
      if (this.딟(index2, index1, index3, num1, numArray, vector2List))
      {
        int num4 = numArray[index2];
        int num5 = numArray[index1];
        int num6 = numArray[index3];
        intList.Add(num4);
        intList.Add(num5);
        intList.Add(num6);
        ++num3;
        int index4 = index1;
        for (int index5 = index1 + 1; index5 < num1; ++index5)
        {
          numArray[index4] = numArray[index5];
          ++index4;
        }
        --num1;
        num2 = 2 * num1;
      }
    }
    intList.Reverse();
    return intList.ToArray();
  }

  public float 딟([In] List<Vector2> obj0)
  {
    int count = obj0.Count;
    float num = 0.0f;
    int index1 = count - 1;
    for (int index2 = 0; index2 < count; index1 = index2++)
    {
      Vector2 vector2_1 = obj0[index1];
      Vector2 vector2_2 = obj0[index2];
      num += (float) (vector2_1.x * vector2_2.y - vector2_2.x * vector2_1.y);
    }
    return num * 0.5f;
  }

  public bool 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int[] obj4, [In] List<Vector2> obj5)
  {
    Vector2 vector2_1 = obj5[obj4[obj0]];
    Vector2 vector2_2 = obj5[obj4[obj1]];
    Vector2 vector2_3 = obj5[obj4[obj2]];
    if (1.40129846432482E-45 > (vector2_2.x - vector2_1.x) * (vector2_3.y - vector2_1.y) - (vector2_2.y - vector2_1.y) * (vector2_3.x - vector2_1.x))
      return false;
    for (int index = 0; index < obj3; ++index)
    {
      if (index != obj0 && index != obj1 && index != obj2)
      {
        Vector2 vector2_4 = obj5[obj4[index]];
        if (this.딟(vector2_1, vector2_2, vector2_3, vector2_4))
          return false;
      }
    }
    return true;
  }

  public bool 딟([In] Vector2 obj0, [In] Vector2 obj1, [In] Vector2 obj2, [In] Vector2 obj3)
  {
    float num1 = (float) (obj2.x - obj1.x);
    float num2 = (float) (obj2.y - obj1.y);
    float num3 = (float) (obj0.x - obj2.x);
    float num4 = (float) (obj0.y - obj2.y);
    float num5 = (float) (obj1.x - obj0.x);
    float num6 = (float) (obj1.y - obj0.y);
    float num7 = (float) (obj3.x - obj0.x);
    float num8 = (float) (obj3.y - obj0.y);
    float num9 = (float) (obj3.x - obj1.x);
    float num10 = (float) (obj3.y - obj1.y);
    float num11 = (float) (obj3.x - obj2.x);
    float num12 = (float) (obj3.y - obj2.y);
    float num13 = (float) ((double) num1 * (double) num10 - (double) num2 * (double) num9);
    float num14 = (float) ((double) num5 * (double) num8 - (double) num6 * (double) num7);
    float num15 = (float) ((double) num3 * (double) num12 - (double) num4 * (double) num11);
    return (double) num13 >= 0.0 && (double) num15 >= 0.0 && (double) num14 >= 0.0;
  }
}
