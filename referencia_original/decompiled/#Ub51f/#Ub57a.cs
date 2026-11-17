// Decompiled with JetBrains decompiler
// Type: 딟.땺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using System;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 땺 : 딝
  {
    public 땺([In] string obj0)
      : base(obj0)
    {
      딧.땓.딟("unity_ga_init", obj0, (Action<object>) null);
    }

    public override void 딟([In] string obj0) => 딧.땓.딟("track_ga_screen", 딧.땾.땄((object) new GAEvent()
    {
      Category = obj0
    }), (Action<object>) null);

    public override void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3) => 딧.땓.딟("track_ga_ecommerce", 딧.땾.땄((object) new GAPurchase()
    {
      딟 = obj0,
      땄 = obj1,
      딧 = obj2,
      딢 = obj3
    }), (Action<object>) null);

    protected override void 딟([In] GAEvent obj0) => 딧.땓.딟("track_ga_event", 딧.땾.땄((object) obj0), (Action<object>) null);

    public override void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 딧.땓.딟("track_ga_timing", 딧.땾.땄((object) new GATiming()
    {
      딟 = obj0,
      땄 = obj1,
      딧 = obj2,
      딢 = obj3
    }), (Action<object>) null);
  }
}
