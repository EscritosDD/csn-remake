// Decompiled with JetBrains decompiler
// Type: FarseerTriangulator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 땺;

public class FarseerTriangulator : ScriptableObject, 땺.땺
{
  public int[] 딟([In] Vector2[] obj0)
  {
    땺.땊[] 땊Array = new 땺.땊[obj0.Length];
    for (int index = 0; index < obj0.Length; ++index)
      땊Array[index] = new 땺.땊((double) obj0[index].x, (double) obj0[index].y);
    땧 땧 = new 땧((IList<땺.땊>) 땊Array);
    땺.땣 땣 = new 땺.땣();
    땣.딟((땫) 땧);
    땺.딤.딟(땣);
    int[] numArray1 = new int[땧.땄().Count * 3];
    int num1 = 0;
    foreach (땺.딽 딽 in (IEnumerable<땺.딽>) 땧.땄())
    {
      int[] numArray2 = numArray1;
      int index1 = num1;
      int num2 = index1 + 1;
      int num3 = this.딟(땊Array, 딽.딟.딟);
      numArray2[index1] = num3;
      int[] numArray3 = numArray1;
      int index2 = num2;
      int num4 = index2 + 1;
      int num5 = this.딟(땊Array, 딽.딟.땄);
      numArray3[index2] = num5;
      int[] numArray4 = numArray1;
      int index3 = num4;
      num1 = index3 + 1;
      int num6 = this.딟(땊Array, 딽.딟.딧);
      numArray4[index3] = num6;
    }
    return numArray1;
  }

  private int 딟([In] 땺.땊[] obj0, [In] 땮 obj1)
  {
    for (int index = 0; index < obj0.Length; ++index)
    {
      땺.땊 땊 = obj0[index];
      if (땊 == obj1 || ((땮) 땊).딟 == obj1.딟 && ((땮) 땊).땄 == obj1.땄)
        return index;
    }
    return -1;
  }
}
