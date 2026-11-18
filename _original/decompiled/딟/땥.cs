// Decompiled with JetBrains decompiler
// Type: 딟.땥
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using System;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 땥 : 딝
  {
    private string 딟;

    public 땥([In] string obj0)
      : base(obj0)
    {
      this.딟 = obj0;
      딧.떂.땄(딧.떎.땭, "init", string.Format("({0}){1}", (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0);
    }

    public override void 딟([In] string obj0) => 딧.떂.땄(딧.떎.땭, "sendScreen", string.Format("({0}){1}", (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0);

    public override void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3)
    {
      double result;
      if (!double.TryParse(obj2, out result))
      {
        result = 0.0;
        딧.떀.딟("Invalid price '{0}'", (object) obj2);
      }
      딧.떂.땄(딧.떎.땭, "sendECommerce", string.Format("({0}{1}{2}{3}){4}", (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.땥, (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0, (object) obj1, (object) result, (object) obj3);
    }

    protected override void 딟([In] GAEvent obj0) => 딧.떂.땄(딧.떎.땭, "sendEvent", string.Format("({0}{1}{2}{3}){4}", (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.딝, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0.Category, (object) obj0.Action, (object) obj0.Label, (object) (long) obj0.Value);

    public override void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 딧.떂.땄(딧.떎.땭, "sendTiming", string.Format("({0}{1}{2}{3}){4}", (object) 딧.떎.딟, (object) 딧.떎.딝, (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0, (object) (long) obj1, (object) obj2, (object) obj3);
  }
}
