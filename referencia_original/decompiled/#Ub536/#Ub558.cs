// Decompiled with JetBrains decompiler
// Type: 딶.땘
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땘 : 딶.땁
  {
    protected int 딟;
    protected CrateGameObjectComponent 딟;
    protected 딢.딴 딟;
    protected int 땄;

    public 땘([In] 땖 obj0, [In] int obj1, [In] int obj2, [In] 딢.딴 obj3)
      : base(obj1)
    {
      this.딟 = obj2;
      this.딟 = obj3;
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
          return "Idle_01";
        default:
          if (딺 != 땓.딺.딟)
            return (string) null;
          goto case 땓.딺.땭;
      }
    }

    public override Transform 딟([In] 땓.딺 obj0) => obj0 == 땓.딺.땺 ? this.딟.DeathEffectPrefab : (Transform) null;

    public override int 딟([In] 땙 obj0, [In] 땓.딲 obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      땓.땊 땊 = obj0.땺()[this.딟()];
      return 땊.땺() || !땊.땓() || obj2 == -1 || 땊.땄 == obj2 ? 0 : -1;
    }

    public override UnitWeapon 딢() => GlobalAppData.딟.땤();

    public override string 딧() => GlobalAppData.딟.GrenadeMarkerWeaponId;

    public override int 딱()
    {
      switch (this.딟)
      {
        case 딢.딴.땈:
          return this.땄().땞().떏().MaxHealth;
        case 딢.딴.땞:
          return this.땄().땞().땼().MaxHealth;
        case 딢.딴.땜:
          return this.땄().땞().땢().MaxHealth;
        case 딢.딴.땪:
          return this.땄().땞().딷().MaxHealth;
        default:
          return 0;
      }
    }

    public override Material 땟() => this.딟.UnitIcon;

    public override string 땂() => 딧.딪.딟(this.딟.UnitName);

    public override bool 땄([In] 딢.딴 obj0) => false;

    public override bool 딧([In] 땓.땊 obj0) => false;

    public override bool 땃() => true;

    public override bool 땄([In] 땓.땊 obj0) => false;

    public override bool 딶()
    {
      if (this.땄().딝() != this.땄().떂().땺()[this.딟].땄)
        return true;
      if (this.땄().땉().딷().땈() == null)
        return false;
      땓.땽 땽 = this.땄().땉().딷().땕();
      땓.땊 땊 = this.땄().떂().땺()[this.딟];
      return 땽 == null || !땽.딟().Contains(this.땄().땹().GetTile(땊.땃, 땊.딶));
    }

    public override bool 딟([In] 땓.딲 obj0, [In] 땓.땊 obj1, [In] 땓.땊 obj2) => true;

    public override bool 딟([In] 땓.땊 obj0, [In] int obj1) => true;

    public override bool 땽() => true;

    public override int 땓() => 2;

    public override 땓.딵 땼() => 땓.딵.딧;

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

    public override void 딟([In] List<딟.땩> obj0, [In] 땓.땾 obj1) => obj0.Add((딟.땩) GlobalAppData.땼().땁(this.땷()));

    public override void 땠()
    {
      GameObject gameObject = GlobalAppData.땼().땋(this.땷());
      if (!Object.op_Inequality((Object) gameObject, (Object) null))
        return;
      this.딟 = gameObject.GetComponent<CrateGameObjectComponent>();
    }

    public override void 땴() => this.딟 = (CrateGameObjectComponent) null;

    public 딢.딴 딗() => this.딟;

    public int 땳() => this.딟;

    public Transform 땻() => this.딟.ModelPrefab;

    public Transform 딥() => this.딟.SkeletonPrefab;

    public int 떓() => 0;

    public int 딛() => 0;

    public int 딣() => 0;

    public bool 땔() => true;

    public bool 땁() => true;

    public void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.땊 obj2)
    {
      땓.땊 땊 = obj1.땺()[this.딟];
      딢.떍 떍 = 땓.땎.땭(this.딟);
      if (떍 == 딢.떍.딹)
        return;
      땊.땄(떍);
    }

    public void 딟([In] 땓.딟 obj0, [In] 땖 obj1, [In] 땙 obj2, [In] 땓.떒 obj3, [In] int obj4)
    {
      땓.딲 딲 = obj1.땻()[obj4];
      땓.땊 땊 = obj2.땺()[obj4];
      딢.떍 떍 = 땓.땎.떎(this.딟);
      switch (this.딟)
      {
        case 딢.딴.땈:
          this.땄 = Mathf.Min(obj1.땞().딟(딢.딴.땈).HealAmount, 딲.딱() - 땊.딧);
          obj0.딟((땏) new 땓.땄(obj1, obj2, obj3, obj4, this.땄));
          break;
        case 딢.딴.땞:
          if (떍 == 딢.떍.딹)
            break;
          obj0.딟((땏) new 땓.땃(obj1, obj2, obj3, obj4, 땓.땎.떎(this.딟), 땓.딢.딟, obj1.땞().땼().Duration));
          break;
        case 딢.딴.땜:
          if (떍 == 딢.떍.딹)
            break;
          obj0.딟((땏) new 땓.땃(obj1, obj2, obj3, obj4, 땓.땎.떎(this.딟), 땓.딢.딟, obj1.땞().땢().Duration));
          break;
        case 딢.딴.땪:
          int num = (int) ((double) obj1.땞().딷().APFraction * (double) 딲.딟(땊));
          obj0.딟((땏) new 땓.딧(obj1, obj2, obj3, obj4, num));
          break;
      }
    }

    public int 딟([In] 땖 obj0, [In] 땙 obj1)
    {
      int num = -1;
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (obj0.땻()[index] is 딶.땷 땷1 && obj1.땺()[index].땓() && 땷1.땄() == this.딟 && 땷1.딟() == this.딟)
        {
          num = index;
          break;
        }
      }
      return num;
    }

    public void 딟([In] 땓.딟 obj0, [In] 땖 obj1, [In] 땙 obj2)
    {
      int index = this.딟(obj1, obj2);
      if (index == -1)
        return;
      땓.땊 땊 = obj2.땺()[index];
      obj0.딟((땏) new 땓.땄(obj1, obj2, (땓.떒) 딶.딣.딟, index, -땊.딧));
      obj0.딟((땏) new 땓.딝(obj1, obj2, (땓.떒) 딶.딣.딟, index, 딶.땩.딟, 딢.딯.딟));
    }

    private void 딟(
      [In] 땓.딟 obj0,
      [In] int obj1,
      [In] Transform obj2,
      [In] float obj3,
      [In] AudioShader2 obj4,
      [In] AutoPositionText obj5)
    {
      if (this.땄().땉() == null || this.땄().땉().딷() == null)
        return;
      땯 땯 = this.땄().땉().딷();
      땓.땦 땦 = 땯.딟(obj1);
      if (Object.op_Inequality((Object) obj2, (Object) null))
      {
        땊 땊;
        if (Object.op_Inequality((Object) 땦.딣(), (Object) null))
        {
          땊 = new 땊(땦.딣().transform, ((Component) obj2).gameObject, 0.0f, obj3);
          ((땏) 땊).딟 = true;
        }
        else
        {
          땊 = new 땊(new 딶.땩(땯.딟(this.딟).땴().땃, 땯.딟(this.딟).땴().딶), ((Component) obj2).gameObject, 0.0f, obj3);
          ((땏) 땊).딟 = true;
        }
        obj0.딟((땏) 땊);
      }
      땫 땫 = new 땫(obj1, obj4);
      ((땏) 땫).딟 = true;
      obj0.딟((땏) 땫);
      if (!Object.op_Inequality((Object) obj5, (Object) null))
        return;
      string str = "+" + this.땄.ToString();
      Transform transform;
      if (Object.op_Inequality((Object) 땦.딣(), (Object) null))
      {
        transform = 땦.딣().transform;
      }
      else
      {
        땓.땊 땊 = 땯.딟(this.딟).땴();
        transform = ((Component) this.땄().땹().GetTile(땊.땃, 땊.딶)).transform;
      }
      땑 땑 = new 땑(obj5, transform, str, 0.0f, 0.0f);
      ((땏) 땑).딟 = true;
      obj0.딟((땏) 땑);
    }

    public void 딟([In] 땓.딟 obj0, [In] 땖 obj1, [In] int obj2, [In] bool obj3)
    {
      Transform transform = (Transform) null;
      float num = 0.0f;
      AudioShader2 audioShader2 = (AudioShader2) null;
      AutoPositionText autoPositionText = (AutoPositionText) null;
      switch (this.딟)
      {
        case 딢.딴.땈:
          transform = GlobalAppData.딟.HealthCrateEffectPrefab;
          num = GlobalAppData.딟.HealthCrateDuration;
          audioShader2 = GlobalAppData.딟.HealthCrateShader;
          autoPositionText = GlobalAppData.딟.GameAssets.HealingText;
          break;
        case 딢.딴.땞:
          transform = GlobalAppData.딟.ImprovedAmmoCrateEffectPrefab;
          num = GlobalAppData.딟.ImprovedAmmoCrateDuration;
          audioShader2 = GlobalAppData.딟.ImprovedAmmoCrateShader;
          autoPositionText = (AutoPositionText) null;
          break;
        case 딢.딴.땜:
          transform = GlobalAppData.딟.PainKillerCrateEffectPrefab;
          num = GlobalAppData.딟.PainKillerCrateDuration;
          audioShader2 = GlobalAppData.딟.PainKillerCrateShader;
          autoPositionText = (AutoPositionText) null;
          break;
        case 딢.딴.땪:
          transform = GlobalAppData.딟.TeamSpiritCrateEffectPrefab;
          num = GlobalAppData.딟.TeamSpiritCrateDuration;
          audioShader2 = GlobalAppData.딟.TeamSpiritCrateShader;
          break;
      }
      this.딟(obj0, obj2, transform, num, audioShader2, autoPositionText);
    }

    [SpecialName]
    private string 땷()
    {
      switch (this.딟)
      {
        case 딢.딴.땞:
          return GlobalAppData.딟.HighVelocityAmmoCratePrefabId;
        case 딢.딴.땜:
          return GlobalAppData.딟.PainKillersCratePrefabId;
        case 딢.딴.땪:
          return GlobalAppData.딟.TeamSpiritCratePrefabId;
        default:
          return GlobalAppData.딟.HealthCratePrefabId;
      }
    }
  }
}
