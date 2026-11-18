// Decompiled with JetBrains decompiler
// Type: 땥.땁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  public static class 땁
  {
    public static void 딟([In] 땔 obj0, [In] 딺 obj1, [In] int obj2)
    {
      땨 땨 = obj0.딧(obj2);
      if (obj0.딟)
      {
        땺.땿 땿 = new 땺.땿(땨);
        obj1.딟((땺.땏) 땿);
      }
      else
      {
        for (int index = 1; index < 땨.Count; ++index)
          obj1.딟((땺.땏) new 땺.땖(땨[index], 땨[index - 1]));
      }
    }

    public static void 딟([In] 땔 obj0, [In] 딺 obj1, [In] float obj2, [In] int obj3)
    {
      if (!obj0.딟)
        throw new Exception("The path must be closed to convert to a polygon.");
      foreach (땨 땨 in 땓.딟(new 땨((IList<떁>) obj0.딧(obj3))))
        obj1.딟((땺.땏) new 땺.떅(땨, obj2));
    }

    public static List<딺> 딟(
      [In] 땱 obj0,
      [In] 땔 obj1,
      [In] IEnumerable<땺.땏> obj2,
      [In] 땎 obj3,
      [In] int obj4,
      [In] object obj5)
    {
      List<땟> 땟List = obj1.땃(obj4);
      List<딺> 딺List = new List<딺>();
      for (int index = 0; index < 땟List.Count; ++index)
      {
        딺 딺 = new 딺(obj0);
        딺.딟(obj3);
        딺.땄(new 떁(땟List[index].딟, 땟List[index].땄));
        딺.땃(땟List[index].딧);
        foreach (땺.땏 땏 in obj2)
          딺.딟(땏, obj5);
        딺List.Add(딺);
      }
      return 딺List;
    }

    public static List<딺> 딟([In] 땱 obj0, [In] 땔 obj1, [In] IEnumerable<땺.땏> obj2, [In] 땎 obj3, [In] int obj4) => 땁.딟(obj0, obj1, obj2, obj3, obj4, (object) null);

    public static List<딺> 딟([In] 땱 obj0, [In] 땔 obj1, [In] 땺.땏 obj2, [In] 땎 obj3, [In] int obj4, [In] object obj5) => 땁.딟(obj0, obj1, (IEnumerable<땺.땏>) new List<땺.땏>(1)
    {
      obj2
    }, obj3, obj4, obj5);

    public static List<딺> 딟([In] 땱 obj0, [In] 땔 obj1, [In] 땺.땏 obj2, [In] 땎 obj3, [In] int obj4) => 땁.딟(obj0, obj1, obj2, obj3, obj4, (object) null);

    public static void 딟([In] 땔 obj0, [In] 딺 obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      떁 떁1 = obj0.땄(obj2);
      떁 떁2 = (obj1.땼() - 떁1) / obj4 * obj3;
      obj1.딟(-떁2);
    }

    public static List<떒> 딟([In] 땱 obj0, [In] List<딺> obj1, [In] 떁 obj2, [In] 떁 obj3, [In] bool obj4, [In] bool obj5)
    {
      List<떒> 떒List = new List<떒>(obj1.Count + 1);
      for (int index = 1; index < obj1.Count; ++index)
      {
        떒 떒 = new 떒(obj1[index], obj1[index - 1], obj2, obj3);
        ((딝.땺) 떒).딟(obj5);
        obj0.딟((딝.땺) 떒);
        떒List.Add(떒);
      }
      if (obj4)
      {
        떒 떒 = new 떒(obj1[0], obj1[obj1.Count - 1], obj2, obj3);
        ((딝.땺) 떒).딟(obj5);
        obj0.딟((딝.땺) 떒);
        떒List.Add(떒);
      }
      return 떒List;
    }

    public static List<딝.딟> 딟(
      [In] 땱 obj0,
      [In] List<딺> obj1,
      [In] 떁 obj2,
      [In] 떁 obj3,
      [In] bool obj4,
      [In] bool obj5,
      [In] float obj6,
      [In] float obj7)
    {
      List<딝.딟> 딟List = new List<딝.딟>(obj1.Count + 1);
      for (int index = 1; index < obj1.Count; ++index)
      {
        딝.딟 딟 = new 딝.딟(obj1[index], obj1[index - 1], obj2, obj3, obj6, obj7);
        딟.딟(obj5);
        obj0.딟((딝.땺) 딟);
        딟List.Add(딟);
      }
      if (obj4)
      {
        딝.딟 딟 = new 딝.딟(obj1[0], obj1[obj1.Count - 1], obj2, obj3, obj6, obj7);
        딟.딟(obj5);
        obj0.딟((딝.땺) 딟);
        딟List.Add(딟);
      }
      return 딟List;
    }

    public enum 땷
    {
      딟,
      땄,
    }
  }
}
