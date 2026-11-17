// Decompiled with JetBrains decompiler
// Type: 땓.떀
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 떀 : 딶.땁
  {
    private string 딟;
    private WeakReference 딟;
    private WeakReference 땄;
    private WeakReference 딧;

    public 떀([In] int obj0, [In] string obj1)
      : base(obj0)
    {
      this.딧(obj1);
      this.딟(GlobalAppData.땼().딗(obj1));
      this.땄(GlobalAppData.땼().땳(obj1));
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딢.딴>());
      this.딥();
    }

    private 떀([In] 떀 obj0)
      : base(obj0.딟())
    {
      this.땄 = obj0.땄;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.땁());
      this.딟 = obj0.딟;
      this.딧 = obj0.딧;
      this.땄(obj0.땝());
      this.땃(obj0.땹());
      // ISSUE: reference to a compiler-generated method
      this.딢(obj0.딳());
      this.딧(obj0.떔());
      this.딟(obj0.딸());
      this.땄(obj0.땘());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<딢.딴>());
      foreach (딢.딴 딴 in obj0.떓())
        this.떓().Add(딴);
    }

    public 떀([In] int obj0, [In] UnitCharacterData obj1)
      : base(obj0)
    {
      this.딟(obj1.WeaponId);
      this.땄(obj1.OutfitId);
      this.딧(obj1.CharacterId);
      this.땄(obj1.XP);
      this.땃(obj1.Name);
      // ISSUE: reference to a compiler-generated method
      this.딢(obj1.UniqueId);
      if (string.IsNullOrEmpty(this.딸()))
        this.딟(GlobalAppData.땼().딗(this.떔()));
      if (string.IsNullOrEmpty(this.땘()))
        this.땄(GlobalAppData.땼().땳(this.떔()));
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<딢.딴>) 딧.땾.딟<딢.딴>(obj1.SelectedAbilities)).ToList<딢.딴>());
    }

    public new void 딟([In] int obj0) => base.딟(obj0);

    public 떀 딗() => new 떀(this);

    public 떀 땳() => new 떀(this);

    public UnitCharacterData 땻() => new UnitCharacterData()
    {
      WeaponId = this.딸(),
      OutfitId = this.땘(),
      CharacterId = this.떔(),
      XP = this.땝(),
      Name = this.땹(),
      UniqueId = this.딳(),
      SelectedAbilities = this.떓().ToArray()
    };

    public override bool 땄([In] 딢.딴 obj0)
    {
      if (obj0 == 딢.딴.딟 || obj0 == 딢.딴.땄 || obj0 == 딢.딴.땔)
        return true;
      if (Object.op_Inequality((Object) this.땁(), (Object) null))
      {
        for (int index = 0; index < this.땁().Abilities.Length; ++index)
        {
          if (this.땁().Abilities[index] == obj0)
            return true;
        }
      }
      return this.떓().Contains(obj0);
    }

    public void 딟([In] 딶.땖 obj0, [In] List<딲> obj1, [In] int obj2)
    {
      int num = obj2 + 1;
      for (int index1 = 0; index1 < this.땁().Abilities.Length; ++index1)
      {
        List<딲> 딲List = 땎.딟(obj0, this.땁().Abilities[index1], obj2, num);
        for (int index2 = 0; index2 < 딲List.Count; ++index2)
          obj1.Add(딲List[index2]);
        num += 딲List.Count;
      }
      for (int index3 = 0; index3 < this.떓().Count; ++index3)
      {
        List<딲> 딲List = 땎.딟(obj0, this.떓()[index3], obj2, num);
        for (int index4 = 0; index4 < 딲List.Count; ++index4)
          obj1.Add(딲List[index4]);
        num += 딲List.Count;
      }
    }

    public override Material 땟() => this.땁().CharacterIcon;

    public override string 땂() => this.땹();

    public override 땑 떁() => 땑.땄;

    public override bool 땃() => true;

    public override int 딟([In] 딢.딴 obj0) => 1;

    public override int 땓() => 10;

    public override int 땥() => this.땷().ActionPointsPerMove;

    public override int 딟([In] 땊 obj0)
    {
      int basicActionPoints = this.땷().BasicActionPoints;
      return obj0 != null && obj0.딢(딢.떍.땼) > 0 ? 떀.딟(this.땄(), basicActionPoints) : basicActionPoints;
    }

    public static int 딟([In] 딶.땖 obj0, [In] int obj1) => (int) ((double) obj1 * (double) obj0.땞().떂().APFraction);

    public static 딶.땩 땓([In] 땊 obj0)
    {
      딶.땩 땩 = 딶.땩.딟;
      땩.딟 = obj0.딢(딢.떍.땥);
      땩.땄 = obj0.딢(딢.떍.딝);
      if (땩.딟 == -1 || 땩.땄 == -1)
        땩 = new 딶.땩(obj0.땃, obj0.딶);
      return 땩;
    }

    public override UnitWeapon 딢() => this.딛();

    public override string 딧() => this.딸();

    public override int 딱() => this.땷().MaxHealth;

    public override Transform 때() => Object.op_Equality((Object) this.딣(), (Object) null) ? (Transform) null : this.딣().Mesh;

    public override Transform 땩() => Object.op_Equality((Object) this.딣(), (Object) null) ? (Transform) null : GlobalAppData.딢(this.딣().SkeletonId);

    public override bool 땺() => true;

    public override bool 딟([In] 땊 obj0, [In] int obj1) => obj0.딢(딢.떍.떏) > 0 || obj0.딢(딢.떍.딢) <= 0 || obj1 == obj0.땄;

    public int 딟([In] VersionedGameData obj0)
    {
      WeaponGameplayData weaponGameplayData = obj0.딟(this.딸());
      return Object.op_Equality((Object) weaponGameplayData, (Object) null) ? 0 : weaponGameplayData.SquadPoints;
    }

    public override bool 딝() => true;

    public override bool 떎() => true;

    public override bool 땭() => true;

    public override bool 땋() => true;

    public override bool 땲() => true;

    public override bool 딷() => false;

    public override AudioShader2 딟([In] 딘 obj0)
    {
      switch (obj0)
      {
        case 딘.딟:
          return this.땷().FootStepShader;
        case 딘.땄:
          return this.땷().FoleyShader;
        case 딘.딦:
          return this.땷().SwishShader;
        case 딘.땤:
          return this.땷().BodyFallShader;
        case 딘.땽:
          return this.땷().WeaponDropShader;
        default:
          if (Object.op_Inequality((Object) this.땔(), (Object) null))
          {
            switch (obj0)
            {
              case 딘.딧:
                return this.땔().SelectionShader;
              case 딘.딢:
                return this.땔().MoveConfirmShader;
              case 딘.땃:
                return this.땔().EnemySpottedShader;
              case 딘.딶:
                return this.땔().DeathShader;
              case 딘.땓:
                return this.땔().PainShader;
              case 딘.땺:
                return this.땔().AppreciationShader;
              case 딘.땥:
                return this.땔().ExertionShader;
              case 딘.딝:
                return this.땔().IdleShader;
              case 딘.떎:
                return this.땔().FiringShader;
              case 딘.떂:
                return this.땔().UpsetShader;
              case 딘.땴:
                return this.땔().ThankYouShader;
              case 딘.딗:
                return this.땔().CommandShader;
              case 딘.땳:
                return this.땔().CommandReplyShader;
            }
          }
          return (AudioShader2) null;
      }
    }

    public override void 딟([In] List<딟.땩> obj0, [In] 땾 obj1)
    {
      딢.딛 딛 = GlobalAppData.땼();
      obj0.Add((딟.땩) 딛.딸(this.떔()));
      if ((obj1 & 땾.딟) != (땾) 0)
      {
        obj0.Add((딟.땩) 딛.땔(this.딸()));
        obj0.Add((딟.땩) 딛.딣(this.땘()));
      }
      if ((obj1 & 땾.딧) != (땾) 0 && Object.op_Inequality((Object) this.땁(), (Object) null))
      {
        foreach (딢.딴 ability in this.땁().Abilities)
        {
          string str = 땎.땄(ability, (딲) this);
          if (!string.IsNullOrEmpty(str))
            obj0.Add((딟.땩) 딛.땔(str));
        }
        foreach (딢.딴 딴 in this.떓())
        {
          string str = 땎.땄(딴, (딲) this);
          if (!string.IsNullOrEmpty(str))
            obj0.Add((딟.땩) 딛.땔(str));
        }
      }
      bool flag = false;
      딢.딗 딗 = (딢.딗) null;
      if ((obj1 & 땾.땄) != (땾) 0)
      {
        if (!flag)
        {
          딗 = 딛.땷(딛.땠(this.떔()));
          flag = 딗 == null || !딛.딢((딟.땩) 딗);
        }
        if (flag)
          딗 = 딛.땷(딛.땴(this.떔()));
      }
      if (딗 == null)
        return;
      obj0.Add((딟.땩) 딗);
    }

    public override void 땠()
    {
      딢.딛 딛 = GlobalAppData.땼();
      this.땄 = new WeakReference((object) 딛.땽(this.딸()));
      this.딟 = new WeakReference((object) 딛.떏(this.땘()));
      // ISSUE: reference to a compiler-generated method
      this.딟(딛.땢(this.떔()));
      UnitVoicePack unitVoicePack = 딛.땼(딛.땠(this.떔()));
      if (Object.op_Equality((Object) unitVoicePack, (Object) null))
        unitVoicePack = 딛.땼(딛.땴(this.떔()));
      this.딧 = new WeakReference((object) unitVoicePack);
      if (!Object.op_Inequality((Object) this.땁(), (Object) null))
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(GlobalAppData.딧(this.땁().BodyTypeId));
    }

    public override void 땴()
    {
    }

    public void 딥() => this.딢(Guid.NewGuid().ToString());

    [CompilerGenerated]
    [SpecialName]
    public List<딢.딴> 떓() => this.딟;

    [SpecialName]
    public UnitWeapon 딛() => this.땄 == null ? (UnitWeapon) null : this.땄.Target as UnitWeapon;

    [SpecialName]
    public UnitOutfit 딣() => this.딟 == null ? (UnitOutfit) null : this.딟.Target as UnitOutfit;

    [SpecialName]
    public UnitVoicePack 땔() => this.딧 == null ? (UnitVoicePack) null : this.딧.Target as UnitVoicePack;

    [CompilerGenerated]
    [SpecialName]
    public UnitClass 땁() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public UnitBodyType 땷() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딸() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 땘() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] string obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 떔() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] string obj0) => this.딢 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 딳() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public int 땝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] int obj0) => this.딟 = obj0;

    [SpecialName]
    public string 땹()
    {
      if (!string.IsNullOrEmpty(this.딟))
        return this.딟;
      return Object.op_Equality((Object) this.땁(), (Object) null) ? string.Empty : 딧.딪.딟(this.땁().DefaultName);
    }

    [SpecialName]
    public void 땃([In] string obj0) => this.딟 = obj0;

    public override string 딟([In] 땊 obj0, [In] 딺 obj1)
    {
      if (this.떂() && obj0.딢(딢.떍.딧) > 0)
      {
        switch (obj1)
        {
          case 딺.땓:
            return "Disable";
          default:
            return "Disable_Idle";
        }
      }
      else
      {
        if (Object.op_Inequality((Object) this.딛(), (Object) null))
        {
          string str = this.딛().딟(this.땄(), obj1);
          if (str != null)
            return str;
        }
        return (string) null;
      }
    }

    public override Transform 딟([In] 딺 obj0) => (Transform) null;

    public static void 딟([In] 땓.딟 obj0, [In] 딶.땖 obj1, [In] 딶.땙 obj2, [In] 떒 obj3, [In] int obj4)
    {
      obj0.딟((딶.땏) new 땓.땃(obj1, obj2, obj3, obj4, 딢.떍.딢, 땓.딢.땄, -1));
      obj0.딟((딶.땏) new 딶.떊(obj4));
      obj0.딟((딶.땏) new 땓.떎(obj1, obj2, obj3, obj4));
    }
  }
}
