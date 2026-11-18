// Decompiled with JetBrains decompiler
// Type: 딶.딪
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딪 : 떒
  {
    public new const float 딟 = 0.5f;
    private new float 땄;
    private float 딧;
    private float 딢;

    public 딪([In] float obj0) => this.딧 = obj0;

    protected override void 딟()
    {
      base.딟 = 0.5f;
      ((땏) this).딟 = true;
      base.딟();
      this.딢 = Time.time;
      this.땄 = Time.timeScale;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if (!obj0)
        return;
      Time.timeScale = this.딧;
    }

    protected override void 딧()
    {
      base.딧();
      Time.timeScale = Mathf.Lerp(this.땄, this.딧, Mathf.Clamp01((float) (((double) Time.time - (double) this.딢) / 0.5)));
    }

    public override string ToString() => "[ChangeTimeScaleCinematicEvent]";
  }
}
