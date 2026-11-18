// Decompiled with JetBrains decompiler
// Type: 딝.딝
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public static class 딝
  {
    public static 땥.딺 딟([In] 땥.땱 obj0) => 딝.딝.딟(obj0, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] object obj1) => new 땥.딺(obj0, obj1);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 떁 obj1) => 딝.딝.딟(obj0, obj1, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 떁 obj1, [In] object obj2)
    {
      땥.딺 딺 = 딝.딝.딟(obj0, obj2);
      딺.땄(obj1);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 떁 obj1, [In] 떁 obj2) => 딝.딝.딟(obj0, obj1, obj2, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 떁 obj1, [In] 떁 obj2, [In] object obj3)
    {
      땥.딺 딺 = 딝.딝.딟(obj0);
      떎.딟(obj1, obj2, 딺, obj3);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1) => 딝.딝.딟(obj0, obj1, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] object obj2) => 딝.딝.딟(obj0, obj1, 떁.딟(), obj2);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] 떁 obj2) => 딝.딝.딟(obj0, obj1, obj2, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] 떁 obj2, [In] object obj3)
    {
      땥.딺 딺 = 딝.딝.딟(obj0, obj2);
      떎.딟(obj1, 딺, obj3);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] float obj3) => 딝.딝.딟(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] object obj4) => 딝.딝.딟(obj0, obj1, obj2, obj3, 떁.딟(), obj4);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] 떁 obj4) => 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] 떁 obj4, [In] object obj5)
    {
      if ((double) obj1 <= 0.0)
        throw new ArgumentOutOfRangeException("width", "Width must be more than 0 meters");
      if ((double) obj2 <= 0.0)
        throw new ArgumentOutOfRangeException("height", "Height must be more than 0 meters");
      땥.딺 딺 = 딝.딝.딟(obj0, obj4);
      땺.떅 떅 = new 땺.떅(땥.딾.딟(obj1 / 2f, obj2 / 2f), obj3);
      딺.딟((땺.땏) 떅, obj5);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2) => 딝.딝.딟(obj0, obj1, obj2, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] object obj3) => 딝.딝.딟(obj0, obj1, obj2, 떁.딟(), obj3);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] 떁 obj3) => 딝.딝.딟(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] 떁 obj3, [In] object obj4)
    {
      땥.딺 딺 = 딝.딝.딟(obj0, obj3);
      떎.딟(obj1, obj2, 딺, obj4);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] float obj4) => 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] float obj4, [In] object obj5) => 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, 떁.딟(), obj5);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] float obj4, [In] 떁 obj5) => 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, obj5, (object) null);

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] int obj3,
      [In] float obj4,
      [In] 떁 obj5,
      [In] object obj6)
    {
      땥.딺 딺 = 딝.딝.딟(obj0, obj5);
      떎.딟(obj1, obj2, obj3, obj4, 딺, obj6);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2) => 딝.딝.딟(obj0, obj1, obj2, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2, [In] object obj3) => 딝.딝.딟(obj0, obj1, obj2, 떁.딟(), obj3);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2, [In] 떁 obj3) => 딝.딝.딟(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2, [In] 떁 obj3, [In] object obj4)
    {
      땥.딺 딺 = 딝.딝.딟(obj0, obj3);
      떎.딟(obj1, obj2, 딺, obj4);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] List<땨> obj1, [In] float obj2) => 딝.딝.딟(obj0, obj1, obj2, (object) 땥.땎.딟);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] List<땨> obj1, [In] float obj2, [In] object obj3) => 딝.딝.딟(obj0, obj1, obj2, 떁.딟(), obj3);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] List<땨> obj1, [In] float obj2, [In] 떁 obj3) => 딝.딝.딟(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] List<땨> obj1, [In] float obj2, [In] 떁 obj3, [In] object obj4)
    {
      땥.딺 딺 = 딝.딝.딟(obj0, obj3);
      떎.딟(obj1, obj2, 딺, obj4);
      return 딺;
    }

    public static 땥.딺 딟([In] 땥.땱 obj0, [In] float obj1, [In] int obj2, [In] float obj3, [In] float obj4, [In] float obj5) => 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, obj5, (object) null);

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] int obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] object obj6)
    {
      땨 땨 = 땥.딾.딟(obj1, obj2, obj3, obj4);
      if (땨.딶())
        return 딝.딝.딟(obj0, 땨, obj5, obj6);
      List<땨> 땨List = 땥.땓.딟(땨);
      return 딝.딝.딟(obj0, 땨List, obj5, obj6);
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] int obj3,
      [In] float obj4,
      [In] int obj5,
      [In] float obj6,
      [In] 떁 obj7,
      [In] object obj8)
    {
      땨 땨 = 땥.딾.딟(obj1, obj2, obj3, obj4, obj5);
      if (땨.Count >= 딝.땥.땺)
      {
        List<땨> 땨List = 땥.땓.딟(땨);
        땥.딺 딺 = 딝.딝.딟(obj0, 땨List, obj6, obj8);
        딺.땄(obj7);
        return 딺;
      }
      땥.딺 딺1 = 딝.딝.딟(obj0, 땨, obj6, obj8);
      딺1.땄(obj7);
      return 딺1;
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] int obj3,
      [In] float obj4,
      [In] int obj5,
      [In] float obj6,
      [In] 떁 obj7)
    {
      return 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7, (object) null);
    }

    public static 땥.딺 땄([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] float obj3) => 딝.딝.땄(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.딺 땄([In] 땥.땱 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] object obj4)
    {
      땨 땨 = 땥.딾.딟(obj2, obj1 / 2f);
      땥.딺 딺 = 딝.딝.딟(obj0, new List<땨>() { 땨 }, obj3, obj4);
      땺.땶 땶1 = new 땺.땶(obj2, obj3);
      땶1.딟(new 떁(0.0f, obj1 / 2f));
      딺.딟((땺.땏) 땶1, obj4);
      땺.땶 땶2 = new 땺.땶(obj2, obj3);
      땶2.딟(new 떁(0.0f, (float) -((double) obj1 / 2.0)));
      딺.딟((땺.땏) 땶2, obj4);
      return 딺;
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] int obj5,
      [In] float obj6,
      [In] 떁 obj7,
      [In] object obj8)
    {
      땨 땨 = 땥.딾.딟(obj1, obj2, obj3, obj4, obj5);
      if (땨.Count < 딝.땥.땺)
        return 딝.딝.딟(obj0, 땨, obj6);
      List<땨> 땨List = 땥.땓.딟(땨);
      땥.딺 딺 = 딝.딝.딟(obj0, 땨List, obj6, obj8);
      딺.땄(obj7);
      return 딺;
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] int obj5,
      [In] float obj6,
      [In] 떁 obj7)
    {
      return 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7, (object) null);
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] int obj5,
      [In] float obj6)
    {
      return 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, (object) null);
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] int obj5,
      [In] float obj6,
      [In] object obj7)
    {
      return 딝.딝.딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, 떁.딟(), obj7);
    }

    public static 땥.땾 땄([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2) => 딝.딝.땄(obj0, obj1, obj2, (object) null);

    public static 땥.땾 땄([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2, [In] object obj3) => 딝.딝.땄(obj0, obj1, obj2, 떁.딟(), obj3);

    public static 땥.땾 땄([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2, [In] 떁 obj3, [In] object obj4)
    {
      땥.땾 땾 = new 땥.땾((IEnumerable<땨>) 땥.땓.딟(obj1), obj0, obj2, obj4);
      땾.딟.땄(obj3);
      obj0.딟(땾);
      return 땾;
    }

    public static 땥.땾 땄([In] 땥.땱 obj0, [In] 땨 obj1, [In] float obj2, [In] 떁 obj3) => 딝.딝.땄(obj0, obj1, obj2, obj3, (object) null);

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] int obj2,
      [In] float obj3,
      [In] 떁 obj4,
      [In] float obj5,
      [In] bool obj6)
    {
      땥.딺 딺 = 딝.딝.딟(obj0);
      떎.딟(obj1, obj2, obj3, obj4, obj5, obj6, 딺);
      return 딺;
    }

    public static 땥.딺 딟(
      [In] 땥.땱 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] int obj3,
      [In] float obj4,
      [In] 떁 obj5,
      [In] float obj6)
    {
      땥.딺 딺 = 딝.딝.딟(obj0);
      떎.딟(obj1, obj2, obj3, obj4, obj5, obj6, 딺);
      return 딺;
    }
  }
}
