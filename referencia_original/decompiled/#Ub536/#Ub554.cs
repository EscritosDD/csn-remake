// Decompiled with JetBrains decompiler
// Type: 딶.땔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 땔 : 땓.떒
  {
    private 땖 딟;
    private int 딟;
    private int 땄;
    private int 딧;
    private int 딢;
    private int 땃;
    private int[] 딟;
    private bool 딟;

    public 땔([In] 땖 obj0)
    {
      this.딟 = obj0;
      this.딟 = obj0.땂();
      if (obj0.떔() is 딖)
        this.딟 = false;
      else
        this.딟 = true;
    }

    public void 딟()
    {
      this.땄 = 0;
      this.딧 = 0;
      this.딢 = 0;
      this.땃 = 0;
      this.딟 = new int[this.딟.땻().Count];
      땓.땮.딟((땓.떒) this, this.딟, new 땓.땮.딟(this.딟));
    }

    private void 딟([In] PlayerAchievement obj0)
    {
      if (!this.딟)
        return;
      GlobalAppData.땽().땄(obj0);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 땓.떊 obj2)
    {
    }

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
      this.딟[obj1] += obj5;
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
      if (this.딟 != 땊2.땄 || 땊1.땄 == 땊2.땄)
        return;
      ++this.땃;
      if (this.땃 >= 2)
        this.딟(GlobalAppData.딟.Achievements.DoubleKill);
      if (this.땃 >= 3)
        this.딟(GlobalAppData.딟.Achievements.TriKillStreak);
      if (this.땃 >= 4)
        this.딟(GlobalAppData.딟.Achievements.QuadKiller);
      int num = this.딟.땻()[obj1].딱();
      if (this.딟[obj1] < num)
        return;
      this.딟(GlobalAppData.딟.Achievements.DogPile);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
    }

    public void 땄([In] 땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
    }

    public void 땄([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj0.땺()[obj1].땄 != this.딟)
        return;
      ++this.딢;
      if (this.딢 < 100)
        return;
      this.딟(GlobalAppData.딟.Achievements.OutOfBreath);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
    }

    public void 땄([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj0.땺()[obj1].땄 != this.딟)
        return;
      this.땄 += obj3;
      if (this.땄 >= 200)
        this.딟(GlobalAppData.딟.Achievements.LightHealing);
      if (this.땄 >= 300)
        this.딟(GlobalAppData.딟.Achievements.MediumHealing);
      if (this.땄 < 400)
        return;
      this.딟(GlobalAppData.딟.Achievements.HeavyHealing);
    }

    public void 딟([In] 땙 obj0)
    {
      this.땃 = 0;
      Array.Clear((Array) this.딟, 0, this.딟.Length);
    }

    public void 딧([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj0.땺()[obj1].땄 != this.딟 || obj0.땺()[obj2].땄 == this.딟)
        return;
      this.딧 += obj3;
      if (this.딧 < 8)
        return;
      this.딟(GlobalAppData.딟.Achievements.GetOffMyLawn);
    }

    public void 딟([In] 땙 obj0, [In] int obj1, [In] int obj2)
    {
    }
  }
}
