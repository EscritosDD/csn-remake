// Decompiled with JetBrains decompiler
// Type: 땃.딙
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딙
  {
    private static float 딟 = 1f / Mathf.Sqrt(2f);

    public static 떈 딟([In] 떈 obj0)
    {
      if (obj0.딟().Count == 0)
        return (떈) null;
      float num1 = 0.0f;
      List<떈> 떈List = new List<떈>();
      for (int index = 0; index < obj0.딟().Count; ++index)
      {
        떈 딟 = obj0.딟()[index].딟;
        float num2 = 딟.딧() != 0 ? 딟.딶() + 2f * 딙.딟 * Mathf.Sqrt(2f * Mathf.Log((float) obj0.딧()) / (float) 딟.딧()) : float.MaxValue;
        if ((double) num2 > (double) num1)
        {
          num1 = num2;
          떈List.Clear();
          떈List.Add(딟);
        }
        else if ((double) num2 == (double) num1)
          떈List.Add(딟);
      }
      return 떈List.Count > 0 ? 떈List[Random.Range(0, 떈List.Count - 1)] : (떈) null;
    }
  }
}
