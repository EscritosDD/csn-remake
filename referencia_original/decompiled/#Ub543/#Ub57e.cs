// Decompiled with JetBrains decompiler
// Type: 땃.땾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땾 : 떑
  {
    protected 딢.딴 딟;
    protected WeaponGameplayData 딟;
    protected AbilityGameplayData 딟;

    public 땾([In] 딶.땖 obj0, [In] int obj1, [In] 딢.딴 obj2)
    {
      this.딟 = obj2;
      UnitWeapon unitWeapon = 땓.땎.딢(obj2, obj0.땻()[obj1]);
      if (Object.op_Inequality((Object) unitWeapon, (Object) null))
        this.딟 = unitWeapon.딟(obj0);
      this.딟 = GlobalAppData.딢().딟(obj2);
    }

    public override bool 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딡 obj2) => !Object.op_Equality((Object) this.딟, (Object) null) && this.딟.딟(obj0, obj2.딟.땴(), false);

    public override void 딟([In] 딡 obj0, [In] 딵 obj1)
    {
      if (obj0.딟 == null)
        obj0.딟 = new 떋[딮.딟];
      땓.땊 땊1 = obj1.딣().땼().떎()[obj0.딟.땔()];
      for (int index = 0; index < obj0.딟.Length; ++index)
      {
        if (obj0.딟[index] == null)
          obj0.딟[index] = this.딟.LineRange != 0 ? new 떋(Mathf.Max(1, (this.딟.LineRange + 2) * 4), false) : new 떋(Mathf.Max(1, this.딟.SplashRange / 2), true);
        if (index < obj1.땻() && obj1.땁()[index].딟)
        {
          땓.땊 땊2 = obj1.땁()[index].딟.땴();
          obj0.딟[index].딟 = this.딟(obj1, obj0, 땊1, 땊2);
          Array.Clear((Array) obj0.딟[index].딟, 0, obj0.딟[index].딟.Length);
        }
      }
      for (int index1 = 0; index1 < obj1.땻(); ++index1)
      {
        if (obj1.땁()[index1].딟)
        {
          for (int index2 = 0; index2 < obj0.딟[index1].딟.Length; ++index2)
          {
            GameTileComponent gameTileComponent1 = obj0.딟[index1].딟[index2];
            if (Object.op_Inequality((Object) gameTileComponent1, (Object) null))
            {
              GameTileComponent gameTileComponent2 = (GameTileComponent) null;
              if (index2 < obj0.딟[index1].딟.Length - 1)
                gameTileComponent2 = obj0.딟[index1].딟[index2 + 1];
              int num1 = 0;
              int num2 = this.딟(obj1, obj0.딟.땴(), gameTileComponent1, gameTileComponent2, ref num1);
              obj0.딟[index1].딟[index2] = this.딟 != 딢.딴.딗 ? num2 : num1;
            }
          }
        }
      }
    }

    private GameTileComponent[] 딟([In] 딵 obj0, [In] 딡 obj1, [In] 땓.땊 obj2, [In] 땓.땊 obj3)
    {
      if (this.딟.LineRange > 0)
      {
        List<GameTileComponent> gameTileComponentList = new List<GameTileComponent>();
        딶.땩 땩 = new 딶.땩(obj3.땃 + 1, obj3.딶);
        gameTileComponentList.Add(obj0.딣().땼().땹().get_Tiles()[obj3.땃, obj3.딶]);
        gameTileComponentList.AddRange((IEnumerable<GameTileComponent>) 땫.딟(obj0.딣().땼(), 땩.딟, 땩.땄, obj3.땃, obj3.딶, this.딟));
        gameTileComponentList.Add((GameTileComponent) null);
        땩 = new 딶.땩(obj3.땃 - 1, obj3.딶);
        gameTileComponentList.Add(obj0.딣().땼().땹().get_Tiles()[obj3.땃, obj3.딶]);
        gameTileComponentList.AddRange((IEnumerable<GameTileComponent>) 땫.딟(obj0.딣().땼(), 땩.딟, 땩.땄, obj3.땃, obj3.딶, this.딟));
        gameTileComponentList.Add((GameTileComponent) null);
        땩 = new 딶.땩(obj3.땃, obj3.딶 + 1);
        gameTileComponentList.Add(obj0.딣().땼().땹().get_Tiles()[obj3.땃, obj3.딶]);
        gameTileComponentList.AddRange((IEnumerable<GameTileComponent>) 땫.딟(obj0.딣().땼(), 땩.딟, 땩.땄, obj3.땃, obj3.딶, this.딟));
        gameTileComponentList.Add((GameTileComponent) null);
        땩 = new 딶.땩(obj3.땃, obj3.딶 - 1);
        gameTileComponentList.Add(obj0.딣().땼().땹().get_Tiles()[obj3.땃, obj3.딶]);
        gameTileComponentList.AddRange((IEnumerable<GameTileComponent>) 땫.딟(obj0.딣().땼(), 땩.딟, 땩.땄, obj3.땃, obj3.딶, this.딟));
        gameTileComponentList.Add((GameTileComponent) null);
        return gameTileComponentList.ToArray();
      }
      땓.딲 딲 = obj0.딣().땼().땻()[obj1.딟.땔()];
      return obj0.딣().땓().get_TileNetwork().딟(obj0.딣().땼(), obj0.딣().땼().떂(), obj3.땃, obj3.딶, Mathf.Max(1, this.딟.SplashRange / 2), 딲, obj1.딟.땴().땄, -1);
    }

    private int 딟([In] 딵 obj0, [In] 땓.땊 obj1, [In] GameTileComponent obj2, [In] GameTileComponent obj3, [In] ref int obj4)
    {
      float num = (this.딟.딟(obj0.딣().땼().땞(), obj1) + this.딟.DamageSpread) * this.딟.Accuracy * (float) this.딟.ShotsPerAttack;
      return this.딟.SplashRange <= 0 ? (this.딟.LineRange <= 0 ? (int) (num * 땫.딟(obj0.딣().땼(), this.딟, obj2.TileIndexX, obj2.TileIndexY, obj1.땃, obj1.딶) * this.딟.딟(obj0.딣().땼(), obj1.땃, obj1.딶, obj2.TileIndexX, obj2.TileIndexY)) : (int) 땾.딟(obj0, this.딟, this.딟, obj2, obj3)) : (int) 땾.딟(obj0, this.딟, this.딟, obj2, num, this.딟, ref obj4);
    }

    private static float 딟([In] float obj0, [In] WeaponGameplayData obj1, [In] 땓.땊 obj2, [In] int obj3)
    {
      float num = obj1.딟((float) obj3 / (float) obj1.SplashRange);
      return Mathf.Min(obj0 * num, (float) obj2.딧);
    }

    public static float 딟(
      [In] 딵 obj0,
      [In] WeaponGameplayData obj1,
      [In] AbilityGameplayData obj2,
      [In] GameTileComponent obj3,
      [In] GameTileComponent obj4)
    {
      float num1 = 0.0f;
      float num2 = !Object.op_Inequality((Object) obj2, (Object) null) ? 0.0f : (float) (obj2.TickDamage * obj2.Duration);
      float num3 = obj1.땄() + obj1.DamageSpread;
      if (Object.op_Equality((Object) obj4, (Object) null))
        return num1;
      List<GameTileComponent> gameTileComponentList = 땫.딟(obj0.딣().땼(), obj3.TileIndexX, obj3.TileIndexY, obj4.TileIndexX, obj4.TileIndexY, obj1);
      for (int index1 = 0; index1 < gameTileComponentList.Count; ++index1)
      {
        GameTileComponent gameTileComponent = gameTileComponentList[index1];
        for (int index2 = 0; index2 < obj0.땻(); ++index2)
        {
          땓.땊 땊 = obj0.땁()[index2].딟.땴();
          if (땊.땃 == gameTileComponent.TileIndexX && 땊.딶 == gameTileComponent.TileIndexY)
            num1 += num3;
        }
        if ((double) num1 > 0.0)
          num1 += num2;
        bool flag = false;
        for (int index3 = 0; index3 < obj0.땔().Count; ++index3)
        {
          땓.땊 땊 = obj0.땔()[index3].딟.땴();
          if (땊.땃 == gameTileComponent.TileIndexX && 땊.딶 == gameTileComponent.TileIndexY)
          {
            num1 = 0.0f;
            flag = true;
            break;
          }
        }
        if (flag)
          break;
      }
      return num1;
    }

    public static float 딟(
      [In] 딵 obj0,
      [In] WeaponGameplayData obj1,
      [In] AbilityGameplayData obj2,
      [In] GameTileComponent obj3,
      [In] float obj4,
      [In] 딢.딴 obj5,
      [In] ref int obj6)
    {
      float num1 = 0.0f;
      float num2 = !Object.op_Inequality((Object) obj2, (Object) null) ? 0.0f : (float) (obj2.TickDamage * obj2.Duration);
      obj6 = 0;
      for (int index = 0; index < obj0.땻(); ++index)
      {
        땓.땊 땊 = obj0.땁()[index].딟.땴();
        if ((double) num2 <= 0.0 || !obj0.땁()[index].땄() && obj0.땁()[index].딟(obj0.딣().땼(), obj5))
        {
          int num3 = obj0.땁()[index].딟(obj3, obj0.딣().땼());
          if (num3 <= obj1.SplashRange)
          {
            float num4 = 땾.딟(obj4, obj1, 땊, num3);
            num1 += num4;
            ++obj6;
          }
        }
      }
      if ((double) num1 > 0.0)
        num1 += num2;
      for (int index = 0; index < obj0.땔().Count; ++index)
      {
        땓.땊 땊 = obj0.땔()[index].딟.땴();
        int num5 = 땊.딟(obj3.TileIndexX, obj3.TileIndexY);
        if (num5 <= obj1.SplashRange)
        {
          obj6 = 0;
          if ((double) 땾.딟(obj4, obj1, 땊, num5) > 0.0)
          {
            num1 = 0.0f;
            break;
          }
        }
      }
      return num1;
    }

    public override void 딟([In] 딠 obj0, [In] 딩 obj1, [In] GameTileComponent obj2, [In] int obj3, [In] int obj4)
    {
      if (obj3 > obj0.딟.딢 - this.딟.RequiredActionPoints)
        return;
      for (int index1 = 0; index1 < obj0.딟.땻(); ++index1)
      {
        GameTileComponent[] 딟 = obj0.딟.딟[index1].딟;
        for (int index2 = 0; index2 < 딟.Length; ++index2)
        {
          GameTileComponent gameTileComponent1 = 딟[index2];
          if (!Object.op_Equality((Object) gameTileComponent1, (Object) null))
          {
            if (this.딟.LineRange > 0)
            {
              GameTileComponent gameTileComponent2 = 딟[index2 + 1];
              if (Object.op_Equality((Object) gameTileComponent2, (Object) null) || Object.op_Inequality((Object) obj2, (Object) gameTileComponent2))
                continue;
            }
            int num = 땓.땊.딟(obj2.TileIndexX, obj2.TileIndexY, gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY);
            if (num <= this.딟.MaxRange && num >= this.딟.MinRange && this.딟(obj0.딟.땼(), obj0.딟.땼().떂(), obj0.딟, obj2, gameTileComponent1, obj0.딟))
              this.딟(obj0.딟, obj0.딟, obj1, obj2, gameTileComponent1, obj0.딟.딟[index1].딟[index2], obj4, index1);
          }
        }
      }
    }

    private bool 딟(
      [In] 딶.땖 obj0,
      [In] 딶.땙 obj1,
      [In] 땓.땊 obj2,
      [In] GameTileComponent obj3,
      [In] GameTileComponent obj4,
      [In] List<int> obj5)
    {
      return (this.딟.IgnoreVisCheck || obj0.땹().get_VisMap().TileIsVisible(obj0, obj1, obj2.땄, obj3.TileIndexX, obj3.TileIndexY, obj4.TileIndexX, obj4.TileIndexY, this.딟.MaxRange, obj5)) && obj0.땹().TileCanBeAttacked(obj4) && obj4.GetCoverType(obj3) == 딶.딥.딟;
    }

    private void 딟(
      [In] 딵 obj0,
      [In] 딡 obj1,
      [In] 딩 obj2,
      [In] GameTileComponent obj3,
      [In] GameTileComponent obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7)
    {
      int index = obj2.딟(this.딟, obj5, obj4, obj3, this.딟, obj6);
      if (index == -1)
        return;
      float num = (float) obj2.딟[index].딟 / (float) obj0.땘()[obj3.TileIndexX, obj3.TileIndexY, 딮.딟];
      if ((double) num <= (double) obj1.딟)
        return;
      obj1.딟 = num;
      obj1.딟 = obj2.딟[index];
      obj1.딟.딧 = obj7;
    }
  }
}
