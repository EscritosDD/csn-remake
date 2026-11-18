// Decompiled with JetBrains decompiler
// Type: 딶.딽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딽
  {
    public bool 딟;
    public Vector3 딟;
    public Vector3 땄;
    public Vector3 딧;
    public 딢.딯 딟;
    private AnimationCurve 딟;
    private AnimationCurve 땄;

    public Vector3 딟([In] float obj0) => new Vector3(this.딟.Evaluate(obj0), Mathf.Lerp((float) this.딟.y, (float) this.딧.y, obj0), this.땄.Evaluate(obj0));

    public Quaternion 땄([In] float obj0)
    {
      float num = 0.05f;
      return (double) obj0 > 1.0 - (double) num ? 땓.땊.딟(this.딟) : Quaternion.LookRotation(Vector3.op_Subtraction(this.딟(obj0 + num), this.딟(obj0)));
    }

    public void 딟()
    {
      if (this.땄.x == (double) Mathf.Lerp((float) this.딟.x, (float) this.딧.x, 0.5f) && this.땄.z == (double) Mathf.Lerp((float) this.딟.z, (float) this.딧.z, 0.5f))
      {
        this.딟 = AnimationCurve.Linear(0.0f, (float) this.딟.x, 1f, (float) this.딧.x);
        this.땄 = AnimationCurve.Linear(0.0f, (float) this.딟.z, 1f, (float) this.딧.z);
      }
      else
      {
        this.딟 = new AnimationCurve(new Keyframe[3]
        {
          new Keyframe(0.0f, (float) this.딟.x),
          new Keyframe(0.5f, (float) this.땄.x),
          new Keyframe(1f, (float) this.딧.x)
        });
        this.땄 = new AnimationCurve(new Keyframe[3]
        {
          new Keyframe(0.0f, (float) this.딟.z),
          new Keyframe(0.5f, (float) this.땄.z),
          new Keyframe(1f, (float) this.딧.z)
        });
        this.딟.SmoothTangents(1, 0.0f);
        this.땄.SmoothTangents(1, 0.0f);
      }
    }
  }
}
