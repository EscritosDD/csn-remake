// Decompiled with JetBrains decompiler
// Type: 딶.떍
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 떍 : 땛
  {
    public override void 딟([In] 땖 obj0) => base.딟(obj0);

    public override void 딟([In] 땖 obj0, [In] GameplayHUDHandler obj1)
    {
    }

    public override void 딟()
    {
    }

    public override void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2)
    {
    }

    public static int 딢([In] 땖 obj0)
    {
      bool flag1 = false;
      bool flag2 = false;
      for (int index = 0; index < obj0.떎().Count; ++index)
      {
        if (obj0.땻()[index] is 땓.떀 && obj0.떎()[index].딧 > 0)
        {
          if (obj0.떎()[index].땄 == 0)
            flag1 = true;
          if (obj0.떎()[index].땄 == 1)
            flag2 = true;
        }
      }
      if (!flag1)
        return 1;
      return !flag2 ? 0 : -1;
    }

    public static bool 땃([In] 땖 obj0)
    {
      for (int index = 0; index < obj0.떎().Count; ++index)
      {
        if (obj0.땻()[index] is 땓.떀 && obj0.떎()[index].딧 > 0)
          return false;
      }
      return true;
    }

    public override 떉 땄([In] 땖 obj0)
    {
      int num = 떍.딢(obj0);
      return num != -1 ? new 떉(num, 떌.땄) : 떉.딟();
    }

    public override void 딟([In] 땖 obj0, [In] 땙 obj1)
    {
    }

    public override void 딟([In] 땖 obj0, [In] 땓.떒 obj1)
    {
    }

    public override void 딟([In] int obj0, [In] 땓.땊 obj1)
    {
    }

    public override bool 땃() => true;

    public override bool 딶() => false;

    public override void 딟([In] List<딠.딿> obj0)
    {
    }

    public override bool 딟([In] 딶.땃 obj0, [In] bool obj1) => true;

    public override void 딟([In] List<딟.땩> obj0)
    {
    }

    public override void 땓()
    {
    }

    public override LocalisationEntry 땺() => (LocalisationEntry) null;

    public override LocalisationEntry 땥() => (LocalisationEntry) null;

    public override void 딟([In] 땖 obj0, out float _param2, out float _param3)
    {
      _param3 = 0.0f;
      _param2 = 0.0f;
    }

    public override void 딝()
    {
    }

    public override void 딟([In] string obj0)
    {
    }

    public override void 땄()
    {
    }

    public override void 딧()
    {
    }

    public override bool 딢() => false;

    [SpecialName]
    public override int 떎() => -1;
  }
}
