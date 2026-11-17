// Decompiled with JetBrains decompiler
// Type: 딧.딵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public static class 딵
  {
    public static void 딟<딟>([In] 딟[] obj0)
    {
      for (int index1 = 0; index1 < obj0.Length; ++index1)
      {
        int index2 = Random.Range(index1, obj0.Length);
        딟 딟 = obj0[index1];
        obj0[index1] = obj0[index2];
        obj0[index2] = 딟;
      }
    }

    public static 딟[] 딟<딟>([In] 딟[] obj0, [In] int obj1)
    {
      딟[] 딟Array = new 딟[obj1];
      int[] numArray = new int[obj0.Length];
      for (int index = 0; index < obj1; ++index)
        numArray[index] = index;
      딵.딟<int>(numArray);
      for (int index = 0; index < obj1; ++index)
        딟Array[index] = obj0[numArray[index]];
      return 딟Array;
    }
  }
}
