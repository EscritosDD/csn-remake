// Decompiled with JetBrains decompiler
// Type: 땥.딝
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 딝
  {
    public static List<땨> 딟([In] 땨 obj0, [In] float obj1)
    {
      List<땽> 땽List1 = new List<땽>(obj0.Count);
      foreach (떁 떁 in (List<떁>) obj0)
        땽List1.Add(new 땽(떁.딟, 떁.땄));
      땢 땢 = new 땢(땽List1, obj1);
      List<땨> 땨List = new List<땨>();
      foreach (List<땽> 땽List2 in 땢.딟)
      {
        땨 땨 = new 땨(땽List2.Count);
        foreach (땽 땽 in 땽List2)
          땨.Add(new 떁(땽.딟, 땽.땄));
        땨List.Add(땨);
      }
      return 땨List;
    }

    public static List<땨> 땄([In] 땨 obj0, [In] float obj1)
    {
      List<땽> 땽List = new List<땽>(obj0.Count);
      foreach (떁 떁 in (List<떁>) obj0)
        땽List.Add(new 땽(떁.딟, 떁.땄));
      땢 땢 = new 땢(땽List, obj1);
      List<땨> 땨List = new List<땨>();
      foreach (땲 땲 in 땢.딟)
      {
        땨 땨 = new 땨();
        foreach (땽 땽 in 땲.땄())
          땨.Add(new 떁(땽.딟, 땽.땄));
        땨List.Add(땨);
      }
      return 땨List;
    }
  }
}
