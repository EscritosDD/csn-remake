// Decompiled with JetBrains decompiler
// Type: 딶.땪
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땪 : 땁, 땉
  {
    private int 딟;
    private RiotShieldGameObjectComponent 딟;

    public 땪([In] 땖 obj0, [In] int obj1, [In] int obj2)
      : base(obj1)
    {
      this.딟 = obj2;
      this.딟(obj0);
    }

    public override bool 땄([In] 딢.딴 obj0)
    {
      switch (obj0)
      {
        case 딢.딴.땔:
          return true;
        case 딢.딴.땛:
          return true;
        default:
          return false;
      }
    }

    public override 땓.땑 떁() => 땓.땑.딧;

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override bool 떂() => true;

    public override bool 딦() => true;

    public override bool 땄([In] 땓.땊 obj0) => obj0.땓() && !obj0.땺();

    public override int 땓() => 5;

    public override AudioShader2 딟([In] 땓.딘 obj0)
    {
      switch (obj0)
      {
        case 땓.딘.딧:
          return this.딟.SelectedShader;
        case 땓.딘.딢:
          return this.딟.MoveConfirmShader;
        case 땓.딘.땃:
          return this.딟.EnemySpottedShader;
        case 땓.딘.땋:
          return this.딟.MoveLoopShader;
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

    public override bool 딧([In] 땓.땊 obj0) => !obj0.땺();

    public override bool 땃() => true;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4) => !obj0.땺()[base.딟()].땺() ? -1 : 0;

    public override int 딟([In] 땓.땊 obj0) => obj0 != null && obj0.딢(딢.떍.딧) > 0 ? 0 : base.땄().땞().땋().ActionPoints;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => true;

    public 딢.딴 딟() => 딢.딴.땛;

    public int 땄() => this.딟;

    public override int 딱() => base.땄().땞().땋().MaxHealth;

    public override Transform 땩() => this.딟.SkeletonPrefab;

    public override Transform 때() => this.딟.ModelPrefab;

    public override string 딟([In] 땓.땊 obj0, [In] 땓.딺 obj1)
    {
      switch (obj1)
      {
        case 땓.딺.딧:
          return "Turn_R";
        case 땓.딺.딢:
          return "Turn_L";
        case 땓.딺.땃:
          return "Turn_180";
        case 땓.딺.딶:
          return "Walk";
        case 땓.딺.땓:
          return "Hit";
        case 땓.딺.땺:
          return "Death";
        case 땓.딺.떎:
          return "Deploy";
        default:
          return "Idle_01";
      }
    }

    public override Transform 딟([In] 땓.딺 obj0) => (Transform) null;

    public int 땺() => base.땄().땞().땋().RequiredAP;

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1) => obj0.Add((딟.땩) GlobalAppData.땼().땁(GlobalAppData.딟.RiotShieldPrefabId));

    public override void 땠()
    {
      GameObject gameObject = GlobalAppData.땼().땋(GlobalAppData.딟.RiotShieldPrefabId);
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<RiotShieldGameObjectComponent>();
    }

    public override void 땴() => this.딟 = (RiotShieldGameObjectComponent) null;

    public override void 딟([In] int obj0, [In] 땺.땃 obj1) => obj1.딟(obj0, this.딟);

    public new int 땥() => 1;

    public int 딝() => 1;

    public new bool 떎() => false;

    public new bool 땭() => false;
  }
}
