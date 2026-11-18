// Decompiled with JetBrains decompiler
// Type: 딝.떎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public static class 떎
  {
    public static 땥.떀 딟([In] 떁 obj0, [In] 떁 obj1, [In] 땥.딺 obj2) => 떎.딟(obj0, obj1, obj2, (object) null);

    public static 땥.떀 딟([In] 떁 obj0, [In] 떁 obj1, [In] 땥.딺 obj2, [In] object obj3)
    {
      땺.땖 땖 = new 땺.땖(obj0, obj1);
      return obj2.딟((땺.땏) 땖, obj3);
    }

    public static 땥.떀 딟([In] 땨 obj0, [In] 땥.딺 obj1) => 떎.딟(obj0, obj1, (object) null);

    public static 땥.떀 딟([In] 땨 obj0, [In] 땥.딺 obj1, [In] object obj2)
    {
      땺.땿 땿 = new 땺.땿(obj0);
      return obj1.딟((땺.땏) 땿, obj2);
    }

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] 떁 obj3, [In] 땥.딺 obj4, [In] object obj5)
    {
      땨 땨 = 땥.딾.딟(obj0 / 2f, obj1 / 2f);
      땨.딟(ref obj3);
      땺.떅 떅 = new 땺.떅(땨, obj2);
      return obj4.딟((땺.땏) 떅, obj5);
    }

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] float obj2, [In] 떁 obj3, [In] 땥.딺 obj4) => 떎.딟(obj0, obj1, obj2, obj3, obj4, (object) null);

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] 땥.딺 obj2) => 떎.딟(obj0, obj1, obj2, (object) null);

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] 땥.딺 obj2, [In] object obj3)
    {
      땺.땶 땶 = (double) obj0 > 0.0 ? new 땺.땶(obj0, obj1) : throw new ArgumentOutOfRangeException("radius", "Radius must be more than 0 meters");
      return obj2.딟((땺.땏) 땶, obj3);
    }

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] 땥.딺 obj2, [In] 떁 obj3) => 떎.딟(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] 땥.딺 obj2, [In] 떁 obj3, [In] object obj4)
    {
      땺.땶 땶 = (double) obj0 > 0.0 ? new 땺.땶(obj0, obj1) : throw new ArgumentOutOfRangeException("radius", "Radius must be more than 0 meters");
      땶.딟(obj3);
      return obj2.딟((땺.땏) 땶, obj4);
    }

    public static 땥.떀 딟([In] 땨 obj0, [In] float obj1, [In] 땥.딺 obj2) => 떎.딟(obj0, obj1, obj2, (object) null);

    public static 땥.떀 딟([In] 땨 obj0, [In] float obj1, [In] 땥.딺 obj2, [In] object obj3)
    {
      땺.떅 떅 = obj0.Count > 1 ? new 땺.떅(obj0, obj1) : throw new ArgumentOutOfRangeException("vertices", "Too few points to be a polygon");
      return obj2.딟((땺.땏) 떅, obj3);
    }

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] int obj2, [In] float obj3, [In] 땥.딺 obj4) => 떎.딟(obj0, obj1, obj2, obj3, obj4, (object) null);

    public static 땥.떀 딟([In] float obj0, [In] float obj1, [In] int obj2, [In] float obj3, [In] 땥.딺 obj4, [In] object obj5)
    {
      if ((double) obj0 <= 0.0)
        throw new ArgumentOutOfRangeException("xRadius", "X-radius must be more than 0");
      if ((double) obj1 <= 0.0)
        throw new ArgumentOutOfRangeException("yRadius", "Y-radius must be more than 0");
      땺.떅 떅 = new 땺.떅(땥.딾.딟(obj0, obj1, obj2), obj3);
      return obj4.딟((땺.땏) 떅, obj5);
    }

    public static List<땥.떀> 딟([In] List<땨> obj0, [In] float obj1, [In] 땥.딺 obj2) => 떎.딟(obj0, obj1, obj2, (object) null);

    public static List<땥.떀> 딟([In] List<땨> obj0, [In] float obj1, [In] 땥.딺 obj2, [In] object obj3)
    {
      List<땥.떀> 떀List = new List<땥.떀>(obj0.Count);
      foreach (땨 땨 in obj0)
      {
        if (땨.Count == 2)
        {
          땺.땖 땖 = new 땺.땖(땨[0], 땨[1]);
          떀List.Add(obj2.딟((땺.땏) 땖, obj3));
        }
        else
        {
          땺.떅 떅 = new 땺.떅(땨, obj1);
          떀List.Add(obj2.딟((땺.땏) 떅, obj3));
        }
      }
      return 떀List;
    }

    public static List<땥.떀> 딟(
      [In] float obj0,
      [In] int obj1,
      [In] float obj2,
      [In] 떁 obj3,
      [In] float obj4,
      [In] bool obj5,
      [In] 땥.딺 obj6)
    {
      땨 땨 = 땥.딾.딟(obj0, obj1, obj2);
      땨.딟((float) ((3.14159274101257 - (double) obj0) / 2.0) + obj4);
      땨.딟(ref obj3);
      List<땥.떀> 떀List = new List<땥.떀>(땨.Count);
      if (obj5)
        떀List.Add(떎.딟(땨, obj6));
      for (int index = 1; index < 땨.Count; ++index)
        떀List.Add(떎.딟(땨[index], 땨[index - 1], obj6));
      return 떀List;
    }

    public static List<땥.떀> 딟(
      [In] float obj0,
      [In] float obj1,
      [In] int obj2,
      [In] float obj3,
      [In] 떁 obj4,
      [In] float obj5,
      [In] 땥.딺 obj6)
    {
      땨 땨 = 땥.딾.딟(obj1, obj2, obj3);
      땨.딟((float) ((3.14159274101257 - (double) obj1) / 2.0) + obj5);
      땨.딟(ref obj4);
      땨.Add(땨[0]);
      return 떎.딟(땥.땓.딟(땨), obj0, obj6);
    }
  }
}
