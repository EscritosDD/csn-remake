// Decompiled with JetBrains decompiler
// Type: 땃.딲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딲 : 떑
  {
    public override void 딟([In] 딠 obj0, [In] 딩 obj1, [In] GameTileComponent obj2, [In] int obj3, [In] int obj4)
    {
      if (obj3 > obj0.딟.딢)
        return;
      int num1 = (obj0.딟.딢 - obj3) / Mathf.Max(1, obj0.딟.RequiredActionPoints);
      if (num1 == 0)
        return;
      for (int index = 0; index < obj0.딟.땻(); ++index)
      {
        땓.땊 땊 = obj0.딟[index].딟.땴();
        float num2 = 딲.딟(obj0.딟, obj0.딟, obj0.딟, obj0.딟[index], obj0.딟, obj0.딟, obj0.딟, obj1, obj2, num1, 땊, obj0.딟);
        if (obj0.딟.딟.땄((int) num2, index, num1))
          obj0.딟.딟.딢(obj4, index, num1);
      }
    }

    public static float 딟(
      [In] 딶.딡 obj0,
      [In] 딵 obj1,
      [In] 딡 obj2,
      [In] 딡 obj3,
      [In] WeaponGameplayData obj4,
      [In] List<딡> obj5,
      [In] 땓.땊 obj6,
      [In] 딩 obj7,
      [In] GameTileComponent obj8,
      [In] int obj9,
      [In] 땓.땊 obj10,
      [In] List<int> obj11)
    {
      int num1 = 땓.땊.딟(obj8.TileIndexX, obj8.TileIndexY, obj10.땃, obj10.딶);
      if (num1 > obj4.MaxRange || num1 < obj4.MinRange || !obj4.IgnoreVisCheck && !obj0.땓().get_VisMap().TileIsVisible(obj0.땼(), obj0.땼().떂(), obj6.땄, obj8.TileIndexX, obj8.TileIndexY, obj10.땃, obj10.딶, obj4.MaxRange, obj11))
        return 0.0f;
      float num2 = obj4.딟(obj0.땼().땞(), obj6) * obj4.Accuracy * (float) obj4.ShotsPerAttack;
      float num3 = 0.0f;
      if (obj4.SplashRange > 0)
      {
        for (int index = 0; index < obj1.땻(); ++index)
        {
          int num4 = obj5[index].딟.땴().딟(obj10.땃, obj10.딶);
          float num5 = obj4.딟((float) num4 / (float) obj4.SplashRange);
          num3 += num2 * num5;
        }
      }
      else
      {
        float num6 = 땫.딟(obj0.땼(), obj0.땼().떂(), obj2.딟.땔(), 딢.딴.땄, obj3.딟.땔(), 1f, obj8);
        num3 = num2 * (float) obj9 * num6;
      }
      return Mathf.Min(num3, (float) obj10.딧);
    }

    public static float 딟(
      [In] 딶.딡 obj0,
      [In] WeaponGameplayData obj1,
      [In] 땓.땊 obj2,
      [In] GameTileComponent obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6)
    {
      float num = (obj1.딟(obj0.땼().땞(), obj2) + obj1.DamageSpread) * obj1.Accuracy * (float) obj1.ShotsPerAttack * (float) obj4;
      딶.딥 coverType = obj0.땓().GetCoverType(obj5, obj6, obj3.TileIndexX, obj3.TileIndexY);
      return num * 땫.딟(obj1, coverType) * obj1.딟(obj0.땼(), obj5, obj6, obj3.TileIndexX, obj3.TileIndexY);
    }

    public static float 딟([In] 딠 obj0, [In] GameTileComponent obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
      딡 딡 = obj0.딟[obj3];
      땓.땊 땊1 = obj0.딟.땺()[딡.딟.땔()];
      float num1 = 0.0f;
      for (int index1 = 0; index1 < obj0.딟.땻(); ++index1)
      {
        int index2 = obj0.딟[index1].딟.땔();
        WeaponGameplayData 딟 = obj0.딟[index1].딟;
        if (!Object.op_Equality((Object) 딟, (Object) null))
        {
          땓.땊 땊2 = obj0.딟.땺()[index2];
          bool flag = obj0.딟.땼().땻()[index2].땄(딢.딴.땤);
          if (딲.딟(obj1.TileIndexX, obj1.TileIndexY, obj0.딟, obj0.딟, index2, 딟, 땊2))
          {
            float num2 = 0.0f;
            int num3 = 땓.땊.딟(땊1.땃, 땊1.딶, 땊2.땃, 땊2.딶);
            if (땊2 == 땊1 && num3 <= obj2.SplashRange)
            {
              num2 = obj0.딟.땼().땞().GenericData.ReturnFireDamageScale;
              if (땊2.딢(딢.떍.땢) > 0)
                num2 += obj0.딟.땼().땞().땄().DamageModifier;
            }
            else if (flag)
              num2 = obj0.딟.땼().땞().딟(딢.딴.땤).DamageModifier;
            float num4 = 딟.딟(obj0.딟.땼().땞(), 땊2);
            float num5 = num1 + (num4 + 0.5f * 딟.DamageSpread) * 딟.Accuracy * num2 * (float) 딟.ShotsPerAttack;
            딶.딥 coverType = obj0.딟.땓().GetCoverType(땊2.땃, 땊2.딶, obj1.TileIndexX, obj1.TileIndexY);
            num1 = num5 * 땫.딟(딟, coverType) * 딟.딟(obj0.딟.땼(), 땊2.땃, 땊2.딶, obj1.TileIndexX, obj1.TileIndexY);
          }
        }
      }
      return num1;
    }

    public static bool 딟(
      [In] int obj0,
      [In] int obj1,
      [In] 딶.딡 obj2,
      [In] 딶.땙 obj3,
      [In] int obj4,
      [In] WeaponGameplayData obj5,
      [In] 땓.땊 obj6)
    {
      if (!obj5.AllowsReturnFire || !땓.땊.딟(obj6, obj0, obj1))
        return false;
      bool flag = false;
      int num = 땓.땊.딟(obj0, obj1, obj6.땃, obj6.딶);
      if (num >= obj5.MinRange && num <= obj5.MaxRange)
        flag = true;
      return flag;
    }
  }
}
