// Decompiled with JetBrains decompiler
// Type: 딶.딚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딚 : 땕
  {
    private SentryGunGameObjectComponent 딟;

    public 딚([In] 땖 obj0, [In] int obj1, [In] int obj2)
      : base(obj0, obj1, obj2)
    {
    }

    public override UnitWeapon 딢() => base.딟;

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override 딢.딴 딟() => 딢.딴.때;

    public override int 딱() => ((땁) this).땄().땞().땭().MaxHealth;

    public override Transform 땩() => this.딟.SkeletonPrefab;

    public override Transform 때() => this.딟.ModelPrefab;

    public override AudioShader2 딟([In] 땓.딘 obj0)
    {
      switch (obj0)
      {
        case 땓.딘.딟:
          return this.딟.FootstepShader;
        case 땓.딘.딧:
          return this.딟.SelectedShader;
        case 땓.딘.떏:
          return this.딟.Deploy1Shader;
        case 땓.딘.땼:
          return this.딟.Deploy2Shader;
        case 땓.딘.땢:
          return this.딟.Deploy3Shader;
        case 땓.딘.딷:
          return this.딟.Recover1Shader;
        case 땓.딘.떁:
          return this.딟.Recover2Shader;
        case 땓.딘.땟:
          return this.딟.Recover3Shader;
        case 땓.딘.땂:
          return this.딟.DisableShader;
        case 땓.딘.딱:
          return this.딟.TurnShader;
        case 땓.딘.때:
          return this.딟.Hit2Shader;
        case 땓.딘.땩:
          return this.딟.Death2Shader;
        case 땓.딘.땠:
          return this.딟.Death3Shader;
        default:
          return (AudioShader2) null;
      }
    }

    public override int 땺() => ((땁) this).땄().땞().땭().RequiredAP;

    public override int 딟([In] 땓.땊 obj0) => obj0 != null && obj0.딢(딢.떍.딧) > 0 ? 0 : ((땁) this).땄().땞().딟(딢.딴.때).ActionPoints;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1)
    {
      obj0.Add((딟.땩) GlobalAppData.땼().땔(this.딧()));
      obj0.Add((딟.땩) GlobalAppData.땼().땁(GlobalAppData.딟.SentryGunPrefabId));
    }

    public override void 땠()
    {
      base.딟 = GlobalAppData.땼().땽(this.딧());
      GameObject gameObject = GlobalAppData.땼().땋(GlobalAppData.딟.SentryGunPrefabId);
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<SentryGunGameObjectComponent>();
    }

    public override void 땴()
    {
      base.딟 = (UnitWeapon) null;
      this.딟 = (SentryGunGameObjectComponent) null;
    }

    public override string 딧() => ((땁) this).땄().땞().땭().WeaponId;

    public override bool 딟([In] 땓.땊 obj0, [In] bool obj1) => !obj0.땺() && obj0.땓() && !obj1 && obj0.딢(딢.떍.땺) < ((땁) this).땄().땞().땭().MaxOpFirePerTurn;

    public override 딢.딴 딟([In] 땙 obj0, [In] int obj1)
    {
      땓.땊 땊1 = obj0.땺()[((땁) this).딟()];
      땓.땊 땊2 = obj0.땺()[obj1];
      if (((땁) this).땄().딟(obj0, ((땁) this).딟(), 땊1.땃, 땊1.딶, obj1, 땊2.땃, 땊2.딶, true, false))
      {
        List<int> intList = new List<int>();
        if (땃.땫.딟(((땁) this).땄(), obj0, ((땁) this).딟(), 딢.딴.땄, 땊2.땃, 땊2.딶, true, intList))
          return 딢.딴.땄;
      }
      return 딢.딴.딟;
    }
  }
}
