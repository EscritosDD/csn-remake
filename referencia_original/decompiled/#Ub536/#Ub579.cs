// Decompiled with JetBrains decompiler
// Type: 딶.땹
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땹 : 땁
  {
    protected CrateGameObjectComponent 딟;

    public 땹([In] 땖 obj0, [In] int obj1)
      : base(obj1)
    {
      this.딟(obj0);
    }

    public override 땓.땑 떁() => 땓.땑.딢;

    public override Transform 때() => this.딟.SecondarySkeletonPrefab;

    public override Transform 땩() => this.딟.SecondaryModelPrefab;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1)
    {
      땓.딺 딺 = obj1;
      switch (딺)
      {
        case 땓.딺.땺:
          return "Death";
        case 땓.딺.떎:
          return "Deploy";
        case 땓.딺.땭:
          return "Idle_01_Loot";
        default:
          if (딺 != 땓.딺.딟)
            return (string) null;
          goto case 땓.딺.땭;
      }
    }

    public override Transform 딟([In] 땓.딺 obj0) => obj0 == 땓.딺.땺 ? this.딟.DeathEffectPrefab : (Transform) null;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4) => 0;

    public override UnitWeapon 딢() => (UnitWeapon) null;

    public override string 딧() => (string) null;

    public override int 딱() => 1;

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override bool 땄([In] 딢.딴 obj0) => false;

    public override bool 딧([In] 땓.땊 obj0) => false;

    public override bool 땃() => true;

    public override bool 땄([In] 땓.땊 obj0) => false;

    public override bool 딶() => false;

    public override bool 딟([In] 땓.딲 obj0, [In] 땓.땊 obj1, [In] 땓.땊 obj2) => true;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => true;

    public override bool 땽() => false;

    public override 땓.딵 땼() => 땓.딵.딧 | 땓.딵.딢 | 땓.딵.땺;

    public override AudioShader2 딟([In] 땓.딘 obj0)
    {
      switch (obj0)
      {
        case 땓.딘.딶:
          return this.딟.DeathShader;
        case 땓.딘.떏:
          return this.딟.DeployShader;
        default:
          return (AudioShader2) null;
      }
    }

    public override bool 땢() => false;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1) => obj0.Add((딟.땩) GlobalAppData.땼().땁(this.땔()));

    public override void 땠()
    {
      GameObject gameObject = GlobalAppData.땼().땋(this.땔());
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<CrateGameObjectComponent>();
    }

    public override void 땴() => this.딟 = (CrateGameObjectComponent) null;

    public Transform 딗() => this.딟.ModelPrefab;

    public Transform 땳() => this.딟.SkeletonPrefab;

    public int 땻() => 1;

    public int 딥() => 0;

    public int 떓() => 0;

    public bool 딛() => false;

    public bool 딣() => false;

    public void 딟([In] 땓.딟 obj0, [In] int obj1)
    {
      if (this.땄().땉() == null || this.땄().땉().딷() == null)
        return;
      땓.땦 땦 = this.땄().땉().딷().딟(obj1);
      if (Object.op_Inequality((Object) GlobalAppData.딟.LootCrateEffectPrefab, (Object) null))
      {
        Transform crateEffectPrefab = GlobalAppData.딟.LootCrateEffectPrefab;
        if (Object.op_Inequality((Object) 땦.딣(), (Object) null))
        {
          땊 땊 = new 땊(땦.딣().transform, ((Component) crateEffectPrefab).gameObject, 0.0f, GlobalAppData.딟.LootCrateDuration);
          ((땏) 땊).딟 = true;
          obj0.딟((땏) 땊);
        }
      }
      땫 땫 = new 땫(obj1, GlobalAppData.딟.LootCrateShader);
      ((땏) 땫).딟 = true;
      obj0.딟((땏) 땫);
    }

    [SpecialName]
    private string 땔() => GlobalAppData.딟.LootDropPrefabId;
  }
}
