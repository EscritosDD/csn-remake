// Decompiled with JetBrains decompiler
// Type: 딶.땍
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땍 : 떒
  {
    protected new int 딟 = -1;
    protected int 땄 = -1;
    protected new bool 딟;

    public 땍([In] int obj0)
      : base(obj0)
    {
    }

    protected override void 딟()
    {
      ((땏) this).딟 = true;
      base.딟();
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      땓.땦 땦 = 딡.땴().딷().딟(((땏) this).딟);
      string str = 딡.땴().땼().땻()[((땏) this).딟].딟(땦.땴(), 땓.딺.딟);
      if (str == null || 땦.땴().땺())
        return;
      double num = (double) 땦.땄(str, (WrapMode) 1);
    }

    public override string ToString() => string.Format("[StopAnimationsCinematicEvent]: unit {0}", (object) ((땏) this).딟);
  }
}
