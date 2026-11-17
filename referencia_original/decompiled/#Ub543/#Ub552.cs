// Decompiled with JetBrains decompiler
// Type: 땃.땒
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땒
  {
    public static 떈 딟([In] 떈 obj0)
    {
      List<떌> 떌List = obj0.땓();
      return 떌List.Count == 0 ? (떈) null : 떌List[Random.Range(0, 떌List.Count - 1)].딟;
    }
  }
}
