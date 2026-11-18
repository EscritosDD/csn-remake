// Decompiled with JetBrains decompiler
// Type: 딟.딦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 딟
{
  public static class 딦
  {
    private static List<땋> 딟 = new List<땋>();

    public static void 딟([In] 땋 obj0) => 딦.딟.Add(obj0);

    public static void 딟()
    {
      foreach (땋 땋 in 딦.딟)
        땋.딟();
    }

    public static void 땄()
    {
      foreach (땋 땋 in 딦.딟)
        땋.땄();
    }

    public static void 딟([In] string obj0, [In] Dictionary<string, string> obj1)
    {
      foreach (땋 땋 in 딦.딟)
        땋.딟(obj0, obj1);
    }

    public static void 딟([In] string obj0)
    {
      foreach (땋 땋 in 딦.딟)
        땋.딟(obj0);
    }

    public static void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3) => 딦.딟.ForEach(new Action<땋>(new 딦.땤()
    {
      딟 = obj0,
      땄 = obj1,
      딧 = obj2,
      딢 = obj3
    }.딟));

    public static void 딟([In] string obj0, [In] double obj1, [In] Dictionary<string, string> obj2)
    {
      foreach (땋 땋 in 딦.딟)
        땋.딟(obj0, obj1, obj2);
    }

    public static void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 딦.딟.ForEach(new Action<땋>(new 딦.땽()
    {
      딟 = obj0,
      딟 = obj1,
      땄 = obj2,
      딧 = obj3
    }.딟));
  }
}
