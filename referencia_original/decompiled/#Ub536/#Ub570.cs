// Decompiled with JetBrains decompiler
// Type: 딶.땰
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땰 : 떒
  {
    private Transform 딟;
    private Transform 땄;
    private AnimationCurve 딟;
    private Vector3 딟;
    private Vector3 땄;
    private new float 딟;
    private new float 땄;
    private float 딧 = 1f;
    private string 딟;
    private string 땄;
    private new 땩 딟 = 땩.딟;
    private 땩 땄 = 땩.딟;

    public 땰([In] 땩 obj0, [In] 땩 obj1, [In] string obj2)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.땄 = obj2;
    }

    public 땰([In] int obj0, [In] string obj1, [In] 땩 obj2, [In] string obj3)
      : base(obj0)
    {
      this.딟 = obj1;
      this.땄 = obj2;
      this.땄 = obj3;
    }

    private void 딟([In] string obj0)
    {
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(obj0);
      if (!Object.op_Inequality((Object) unitWeapon, (Object) null))
        return;
      this.딟 = unitWeapon.ProjectileMeshPrefab;
      this.딟 = unitWeapon.ProjectileCurve;
      this.딧 = unitWeapon.ProjectileSpeed;
    }

    public override string ToString() => string.Format("[MoveProjectileCinematicEvent]");

    protected override void 딟()
    {
      base.딟();
      this.딟(this.땄);
      if (!string.IsNullOrEmpty(this.딟))
      {
        Transform transform = 딡.땴().딷().딟(((땏) this).딟).땄(this.딟);
        if (Object.op_Inequality((Object) transform, (Object) null))
        {
          this.딟 = transform.position;
          this.땄 = 딡.땴().땓().GetTileCentre(this.땄.딟, this.땄.땄);
        }
      }
      else
      {
        this.딟 = 딡.땴().땓().GetTileCentre(this.딟.딟, this.딟.땄);
        this.땄 = 딡.땴().땓().GetTileCentre(this.땄.딟, this.땄.땄);
      }
      this.땄 = Object.Instantiate((Object) this.딟, this.딟, Quaternion.LookRotation(Vector3.op_Subtraction(this.땄, this.딟))) as Transform;
      this.딟 = 0.0f;
      Vector3 vector3 = Vector3.op_Subtraction(this.땄, this.딟);
      this.땄 = ((Vector3) ref vector3).magnitude / this.딧;
      Object.Destroy((Object) ((Component) this.땄).gameObject, this.땄);
    }

    protected override void 땄()
    {
      this.딟 += Time.deltaTime;
      float num = Mathf.Min(this.딟 / this.땄, 1f);
      Vector3 vector3 = Vector3.Lerp(this.딟, this.땄, num);
      vector3.y = this.딟.y;
      ref Vector3 local = ref vector3;
      local.y = (__Null) (local.y + (double) this.딟.Evaluate(num));
      if (Object.op_Inequality((Object) this.땄, (Object) null))
        this.땄.position = vector3;
      if ((double) this.딟 < (double) this.땄)
        return;
      this.딧(true);
    }
  }
}
