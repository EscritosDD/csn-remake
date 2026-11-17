// Decompiled with JetBrains decompiler
// Type: 딶.땐
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땐 : 떒
  {
    private new 땩 딟;
    private new float 딟;
    private Quaternion 딟;

    public 땐([In] int obj0, [In] 땩 obj1)
      : base(2f)
    {
      ((땏) this).딟 = obj0;
      this.딟 = obj1;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      Vector3 tileCentre = 땇.딟().땓().GetTileCentre(땇.딟(((땏) this).딟).땴().땃, 땇.딟(((땏) this).딟).땴().딶);
      Vector3 vector3 = Vector3.op_Subtraction(땇.딟().땓().GetTileCentre(this.딟.딟, this.딟.땄), tileCentre);
      vector3.y = (__Null) 0.0;
      ((Vector3) ref vector3).Normalize();
      this.딟 = Quaternion.LookRotation(vector3);
      this.딟 = 0.0f;
    }

    protected override void 땄()
    {
      this.딟 += Time.deltaTime;
      float num = Mathf.Clamp01(this.딟 / 0.1f);
      땇 땇 = (땇) 딡.땴().딷();
      땇.딟(((땏) this).딟).딟(Quaternion.Slerp(땇.딟(((땏) this).딟).땳(), this.딟, num));
      if ((double) num < 1.0)
        return;
      this.딧(true);
    }

    public override string ToString() => string.Format("[AimCinematicEvent] Unit:{0} Aim At:{1}", (object) ((땏) this).딟, (object) this.딟);
  }
}
