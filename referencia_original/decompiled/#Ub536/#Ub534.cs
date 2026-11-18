// Decompiled with JetBrains decompiler
// Type: 딶.딴
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 딴 : 땛
  {
    private new bool 딟;

    public override void 딟([In] 땖 obj0)
    {
      base.딟(obj0);
      this.딟 = false;
      base.딟 = false;
    }

    public override void 딟([In] 땖 obj0, [In] GameplayHUDHandler obj1) => obj1.SetCallbacks(new GameplayHUDHandler.땉(this.딟), new GameplayHUDHandler.땉(this.땄));

    public override void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2)
    {
    }

    public override void 딟()
    {
    }

    public override void 딟([In] 땯 obj0, [In] 딨 obj1)
    {
      base.딟.땉().땢().StartReset(true);
      base.딟.땉().땢().ActivateGameplayHUD();
      obj0.땹();
      base.딟 = true;
    }

    public override 떉 땄([In] 땖 obj0)
    {
      if (obj0.딥().Count > 2)
      {
        int num = 떍.딢(obj0);
        if (num != -1)
          return new 떉(num, 떌.땄);
      }
      return 떉.딟();
    }

    public override bool 딧([In] 땖 obj0)
    {
      if (base.딧(obj0))
      {
        땯 땯 = obj0.땉().딷();
        if (땯.떇() != 딨.땃 && 땯.떇() != 딨.딶 && 땯.떇() != 딨.땓)
        {
          this.딟(땯, 딨.딟);
          base.딟 = true;
          return true;
        }
      }
      return false;
    }

    public override void 딟([In] 땖 obj0, [In] 땙 obj1)
    {
    }

    private bool 땄([In] 땖 obj0, [In] 땙 obj1)
    {
      if (!obj0.땼() && !obj0.땉().딷().딸())
      {
        switch (obj0.땉().딷().떇())
        {
          case 딨.땃:
          case 딨.딶:
          case 딨.땓:
            break;
          default:
            return true;
        }
      }
      return false;
    }

    public override void 딟([In] 땖 obj0, [In] 땓.떒 obj1)
    {
    }

    public override void 딟([In] int obj0, [In] 땓.땊 obj1)
    {
    }

    public override bool 땃() => false;

    public override bool 딶() => false;

    public override bool 떂() => !this.딟;

    public override bool 땭() => !this.딟;

    public override void 딦()
    {
      base.딦();
      this.딟 = true;
      base.딟.땉().땢().ActivateGameplayHUD();
    }

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

    public override bool 땤() => false;

    public void 딟([In] GameplayHUDHandler obj0) => obj0.ShowTryoutHud();

    public void 땄([In] GameplayHUDHandler obj0) => obj0.HideTryoutHud();
  }
}
