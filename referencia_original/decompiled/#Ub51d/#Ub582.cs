// Decompiled with JetBrains decompiler
// Type: 딝.떂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using 땥;

namespace 딝
{
  public static class 떂
  {
    public static 떒 딟([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2)
    {
      떁 떁 = obj0.땺(obj1.딶(obj2));
      return new 떒(obj0, obj1, 떁, obj2);
    }

    public static 떒 딟([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3)
    {
      떒 떒 = 떂.딟(obj1, obj2, obj3);
      obj0.딟((땺) 떒);
      return 떒;
    }

    public static 딝.땄 땄([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2) => new 딝.땄(obj0, obj1, obj0.땺(obj2), obj1.땺(obj2));

    public static 딝.땄 땄([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3)
    {
      딝.땄 땄 = 떂.땄(obj1, obj2, obj3);
      obj0.딟((땺) 땄);
      return 땄;
    }

    public static 딝.땄 딟([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4)
    {
      딝.땄 땄 = new 딝.땄(obj1, obj2, obj3, obj4);
      obj0.딟((땺) 땄);
      return 땄;
    }

    public static 땬 딟([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3)
    {
      떁 떁 = obj0.땺(obj1.딶(obj2));
      return new 땬(obj0, obj1, 떁, obj2, obj3);
    }

    public static 땬 땄([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4)
    {
      땬 땬 = 떂.딟(obj1, obj2, obj3, obj4);
      obj0.딟((땺) 땬);
      return 땬;
    }

    public static 딝.딧 땄([In] 딺 obj0, [In] 딺 obj1, [In] 떁 obj2, [In] 떁 obj3) => new 딝.딧(obj0, obj1, obj2, obj3);

    public static 딝.딧 딧([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4)
    {
      딝.딧 딧 = 떂.땄(obj1, obj2, obj3, obj4);
      obj0.딟((땺) 딧);
      return 딧;
    }

    public static 딼 딟([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2)
    {
      딼 딼 = new 딼(obj1, obj2);
      obj0.딟((땺) 딼);
      return 딼;
    }

    public static 땊 딟([In] 땱 obj0, [In] 딺 obj1)
    {
      땊 땊 = new 땊(obj1);
      obj0.딟((땺) 땊);
      return 땊;
    }

    public static 땧 딢([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4)
    {
      땧 땧 = new 땧(obj1, obj2, obj3, obj4);
      obj0.딟((땺) 땧);
      return 땧;
    }

    public static 딬 땃([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4)
    {
      딬 딬 = new 딬(obj1, obj2, obj3, obj4);
      obj0.딟((땺) 딬);
      return 딬;
    }

    public static 땸 딟([In] 땱 obj0, [In] 땺 obj1, [In] 땺 obj2, [In] float obj3)
    {
      땸 땸 = new 땸(obj1, obj2, obj3);
      obj0.딟((땺) 땸);
      return 땸;
    }

    public static 떊 딟([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4, [In] 떁 obj5, [In] 떁 obj6, [In] float obj7)
    {
      떊 떊 = new 떊(obj1, obj2, obj3, obj4, obj5, obj6, obj7);
      obj0.딟((땺) 떊);
      return 떊;
    }

    public static 딝.딟 딟([In] 땱 obj0, [In] 딺 obj1, [In] 딺 obj2, [In] 떁 obj3, [In] 떁 obj4, [In] float obj5, [In] float obj6)
    {
      딝.딟 딟 = new 딝.딟(obj1, obj2, obj3, obj4, obj5, obj6);
      obj0.딟((땺) 딟);
      return 딟;
    }

    public static 땍 딟([In] 땱 obj0, [In] 딺 obj1, [In] 떁 obj2)
    {
      땍 땍 = new 땍(obj1, obj2);
      obj0.딟((땺) 땍);
      return 땍;
    }
  }
}
