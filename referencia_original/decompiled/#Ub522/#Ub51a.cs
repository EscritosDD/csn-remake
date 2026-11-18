// Decompiled with JetBrains decompiler
// Type: 딢.딚
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 딚 : 땓.떒
  {
    private int[] 딟;
    private int[] 땄;

    private 딚([In] 딶.땖 obj0)
    {
      this.딟 = new int[obj0.땻().Count];
      this.땄 = new int[obj0.땻().Count];
      땓.땮.딟((땓.떒) this, obj0, new 땓.땮.딟(this.딟));
    }

    private void 딟([In] 딶.땙 obj0)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] 땓.떊 obj2)
    {
    }

    public void 딟(
      [In] 딶.땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] WeaponGameplayData obj4,
      [In] int obj5,
      [In] 땃.딤 obj6,
      [In] 딴 obj7)
    {
      if (obj0.땺()[obj1].땄 == obj0.땺()[obj2].땄)
        return;
      this.땄[obj2] += obj5;
    }

    public void 딟(
      [In] 딶.땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] WeaponGameplayData obj4,
      [In] 땃.딤 obj5,
      [In] 딴 obj6)
    {
      ++this.딟[obj2];
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] WeaponGameplayData obj2, [In] int obj3)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] 딴 obj2)
    {
    }

    public void 땄([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
    }

    public void 딧([In] 딶.땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
    }

    public void 딟([In] 딶.땙 obj0, [In] int obj1, [In] int obj2)
    {
    }

    public static 땕 딟([In] 딶.땖 obj0, [In] int obj1)
    {
      땕 땕 = 딚.땄(obj0, obj1);
      if (땕 == null)
      {
        GlobalAppData.땽().딟<땪>(땹.딱, 땪.딟);
        return (땕) null;
      }
      GlobalAppData.땽().딟<땪>(땹.딱, 땕.딢());
      return 땕;
    }

    public static 땕 땄([In] 딶.땖 obj0, [In] int obj1)
    {
      딚 딚 = new 딚(obj0);
      bool flag1 = obj0.떓() == 딶.딹.딧;
      bool flag2 = false;
      SinglePlayerMissionAsset playerMissionAsset = obj0.땠();
      if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
        flag2 = playerMissionAsset.AllowPlayerUnitChoice;
      bool flag3 = flag1 || flag2;
      bool flag4 = GlobalAppData.떏().땥();
      땪 땪 = GlobalAppData.땽().땄<땪>(땹.딱);
      딶.떉 떉 = obj0.떔().땄(obj0);
      List<땕> 땕List = new List<땕>();
      땕 땕1 = 딚.딟();
      if (땕1 != null)
        return 땕1;
      if (flag4)
      {
        if (flag1)
        {
          땕 땕2 = 딚.딟(obj0);
          if (땕2 != null)
            return 땕2;
        }
        else if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
        {
          땕 땕3 = 딚.딟(playerMissionAsset);
          if (땕3 != null)
            return 땕3;
        }
      }
      if (flag4)
      {
        bool flag5 = false;
        if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
          flag5 = playerMissionAsset.DisableMatchWonEvent || obj0.딱() == 3;
        if (!flag5 && 떉.딟 == obj1 && flag3 && 땪 != 땪.땓 && Random.Range(0, 2) == 0)
          return new 땕(땪.땓, new Dictionary<string, object>());
      }
      if (떉.딟 == obj1 && flag3 && flag4)
      {
        땕 땕4 = 딚.땄(obj0, obj1, 딚);
        if (땕4 != null)
          땕List.Add(땕4);
      }
      if (떉.딟 != obj1 && flag3 && flag4)
      {
        땕 땕5 = 딚.딟(obj0, 떉.딟, 딚);
        if (땕5 != null)
          땕List.Add(땕5);
        땕 땕6 = 딚.딧(obj0, obj1, 딚);
        if (땕6 != null)
          땕List.Add(땕6);
      }
      if (땕List.Count <= 0)
        return (땕) null;
      int index = Random.Range(0, 땕List.Count);
      return 땕List[index];
    }

    private static 땕 딟() => (땕) null;

    private static 땕 딟([In] SinglePlayerMissionAsset obj0)
    {
      List<땕> 땕List = new List<땕>();
      foreach (string advertId in obj0.AdvertIds)
      {
        딢.땃 땃 = GlobalAppData.땼().땝(advertId);
        if (땃 != null)
        {
          if (!땃.떎())
            땕List.Add(new 땕(땪.땺, new Dictionary<string, object>()
            {
              {
                "id",
                (object) advertId
              }
            }));
        }
        else
        {
          땥 땥 = GlobalAppData.땼().딸(advertId);
          if (땥 != null)
          {
            if (GlobalAppData.땽().땃(땥.땄()) == 0)
              땕List.Add(new 땕(땪.땥, new Dictionary<string, object>()
              {
                {
                  "id",
                  (object) advertId
                }
              }));
          }
          else
          {
            땻 땻 = GlobalAppData.땼().땔(advertId);
            if (땻 != null && GlobalAppData.땽().땃(땻.땄()) == 0)
              땕List.Add(new 땕(땪.딝, new Dictionary<string, object>()
              {
                {
                  "id",
                  (object) advertId
                }
              }));
          }
        }
      }
      if (땕List.Count <= 0)
        return (땕) null;
      int index = Random.Range(0, 땕List.Count);
      return 땕List[index];
    }

    private static bool 딟([In] string obj0)
    {
      땢 땢 = GlobalAppData.땼().땻(obj0);
      return string.IsNullOrEmpty(땢.땄()) || GlobalAppData.땽().딶(땢.땄());
    }

    public static 땕 딟([In] 딶.땖 obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딚.따 따 = new 딚.따();
      // ISSUE: reference to a compiler-generated field
      따.딟 = obj0.딟.땄;
      // ISSUE: reference to a compiler-generated field
      if (딚.딟(따.딟))
        return (땕) null;
      // ISSUE: reference to a compiler-generated method
      땟 땟 = GlobalAppData.땼().땼().FirstOrDefault<땟>(new Func<땟, bool>(따.딟));
      if (땟 == null)
        return (땕) null;
      return new 땕(땪.딶, new Dictionary<string, object>()
      {
        {
          "id",
          (object) 땟.딧()
        }
      });
    }

    private static 땕 딟([In] 딶.땖 obj0, [In] int obj1, [In] 딚 obj2)
    {
      int num1 = 0;
      땓.떀 떀 = (땓.떀) null;
      foreach (int index in obj0.딧(obj1))
      {
        int num2 = obj2.땄[index];
        if (num2 > num1)
        {
          떀 = obj0.땻()[index] as 땓.떀;
          num1 = num2;
        }
      }
      if (떀 != null)
      {
        땥 땥 = GlobalAppData.땼().딸(떀.떔());
        if (땥 != null && !string.IsNullOrEmpty(땥.땭()) && !GlobalAppData.땽().딶(땥.땄()))
          return new 땕(땪.딧, new Dictionary<string, object>()
          {
            {
              "id",
              (object) 땥.땭()
            },
            {
              "name",
              (object) 떀.땹()
            }
          });
      }
      return (땕) null;
    }

    private static 땕 땄([In] 딶.땖 obj0, [In] int obj1, [In] 딚 obj2)
    {
      int num1 = 0;
      땓.떀 떀1 = (땓.떀) null;
      foreach (int index in obj0.딧(obj1))
      {
        int num2 = obj2.딟[index];
        if (num2 > num1)
        {
          땓.떀 떀2 = obj0.땻()[index] as 땓.떀;
          if (!(떀2.땘() != GlobalAppData.땼().땳(떀2.떔())) && GlobalAppData.땼().땤(떀2.떔()).Count != 1)
          {
            떀1 = 떀2;
            num1 = num2;
          }
        }
      }
      if (num1 < 2)
        return (땕) null;
      return new 땕(땪.땄, new Dictionary<string, object>()
      {
        {
          "id",
          (object) 떀1.딳()
        },
        {
          "kills",
          (object) num1
        },
        {
          "name",
          (object) 떀1.땹()
        }
      });
    }

    private static 땕 딧([In] 딶.땖 obj0, [In] int obj1, [In] 딚 obj2)
    {
      int num1 = int.MaxValue;
      땓.떀 떀 = (땓.떀) null;
      foreach (int index in obj0.딧(obj1))
      {
        int num2 = obj2.땄[index];
        if (num2 < num1)
        {
          떀 = obj0.땻()[index] as 땓.떀;
          num1 = num2;
        }
      }
      if (떀 == null)
        return (땕) null;
      int num3 = GlobalAppData.땽().때();
      if (obj0.땞().딟(떀.딸()).SquadPoints > 4)
        return (땕) null;
      foreach (WeaponGameplayDataPair gameplayDataPair in obj0.땞().WeaponData)
      {
        if (gameplayDataPair.WeaponData.SquadPoints > 4 && gameplayDataPair.WeaponData.딟(떀))
        {
          땻 땻 = GlobalAppData.땼().땔(gameplayDataPair.WeaponId);
          if (땻 != null && 땻.땓() < num3 && !string.IsNullOrEmpty(땻.땄()) && !GlobalAppData.땽().딶(땻.땄()))
            return new 땕(땪.땃, new Dictionary<string, object>()
            {
              {
                "name",
                (object) 떀.땹()
              },
              {
                "id",
                (object) 떀.딳()
              }
            });
        }
      }
      return (땕) null;
    }
  }
}
