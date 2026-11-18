// Decompiled with JetBrains decompiler
// Type: 딶.딛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 딛 : 땓.떒
  {
    private int 딟;
    private 땖 딟;
    private bool 딟;

    public 딛([In] 땖 obj0)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(new 땔(obj0));
      this.딟 = obj0.땂();
      if (obj0.떔() is 딖)
        this.딟 = false;
      else
        this.딟 = true;
    }

    private void 딟([In] PlayerAchievement obj0)
    {
      if (!this.딟)
        return;
      GlobalAppData.땽().땄(obj0);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 땓.떊 obj2) => this.딟().딟(obj0, obj1, obj2);

    public void 딟(
      [In] 땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] WeaponGameplayData obj4,
      [In] int obj5,
      [In] 땃.딤 obj6,
      [In] 딢.딴 obj7)
    {
      this.딟().딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6, obj7);
    }

    public void 딟(
      [In] 땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] WeaponGameplayData obj4,
      [In] 땃.딤 obj5,
      [In] 딢.딴 obj6)
    {
      땓.땊 땊1 = obj0.땺()[obj1];
      땓.땊 땊2 = obj0.땺()[obj2];
      if (this.딟 == 땊2.땄 && 땊1.땄 != 땊2.땄)
      {
        bool flag1 = false;
        bool flag2 = false;
        foreach (int index in this.딟.딧(땊1.땄))
        {
          땓.떀 떀 = this.딟.땻()[index] as 땓.떀;
          if (obj0.땺()[index].땺())
          {
            if (떀.땁().ClassType == 땓.땅.땃)
              flag1 = true;
            else
              flag2 = true;
          }
        }
        if (flag1 && !flag2)
          this.딟(GlobalAppData.딟.Achievements.LeadByExample);
        if (this.딟.땻()[obj2] is 딾)
          this.딟(GlobalAppData.딟.Achievements.KillerRobots);
        if (obj4.DamageType == 딱.땃)
        {
          if (this.딟.땹().GetTile(땊1.땃, 땊1.딶).GetCoverType(this.딟.땹().GetTile(땊2.땃, 땊2.딶)) != 딥.딟)
            this.딟(GlobalAppData.딟.Achievements.WhatCover);
          if (this.딟.땻()[obj1] is 땕)
            this.딟(GlobalAppData.딟.Achievements.BadKitty);
        }
        if (obj4.Category == 땓.땍.땃 && 땊1.땄(땊2) == 1)
          this.딟(GlobalAppData.딟.Achievements.DodgeThis);
        if ((obj5 & 땃.딤.땄) != 땃.딤.딟)
          this.딟(GlobalAppData.딟.Achievements.OhHi);
      }
      if (this.딟 == 땊1.땄 && 땊1.땄 != 땊2.땄 && (obj5 & 땃.딤.딢) != 땃.딤.딟)
        this.딟(GlobalAppData.딟.Achievements.IMeantToDoThat);
      this.딟().딟(obj0, obj1, obj2, obj3, obj4, obj5, obj6);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3) => this.딟().딟(obj0, obj1, obj2, obj3);

    public void 땄([In] 땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
      if (obj2.DamageType == 딱.땄)
      {
        if (obj3 >= 2)
          this.딟(GlobalAppData.딟.Achievements.RookieExploder);
        if (obj3 >= 3)
          this.딟(GlobalAppData.딟.Achievements.CompetentExploder);
        if (obj3 >= 4)
          this.딟(GlobalAppData.딟.Achievements.MasterExploder);
      }
      this.딟().땄(obj0, obj1, obj2, obj3);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4) => this.딟().딟(obj0, obj1, obj2, obj3, obj4);

    public void 땄([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4) => this.딟().땄(obj0, obj1, obj2, obj3, obj4);

    public void 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3) => this.딟().딟(obj0, obj1, obj2, obj3);

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 딢.딴 obj2) => this.딟().딟(obj0, obj1, obj2);

    public void 땄([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3) => this.딟().땄(obj0, obj1, obj2, obj3);

    public void 딧([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3) => this.딟().딧(obj0, obj1, obj2, obj3);

    public void 딟([In] 땙 obj0, [In] int obj1, [In] int obj2)
    {
      if (obj0.땺()[obj1].땄 == this.딟)
        this.딟(GlobalAppData.딟.Achievements.ISpy);
      this.딟().딟(obj0, obj1, obj2);
    }

    [CompilerGenerated]
    [SpecialName]
    public 땔 딟() => this.딟;
  }
}
