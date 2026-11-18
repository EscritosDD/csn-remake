// Decompiled with JetBrains decompiler
// Type: 딢.딲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 딲
  {
    private float 딟;
    private 딳.땝 딟;
    private 딲.떀 딟;

    public void 딟([In] float obj0)
    {
      this.딟 = obj0;
      this.딟 = 딲.떀.딟;
      this.딟();
    }

    private void 딟()
    {
      if (땚.딢())
      {
        if (GlobalAppData.떏().땥())
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(떑.땄);
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(떑.땓);
        }
        this.딟 = 딲.떀.딧;
      }
      else
      {
        SinglePlayerMissionAsset playerMissionAsset = GlobalAppData.땼().땢().Select<딢.땓, SinglePlayerMissionAsset>((Func<딢.땓, SinglePlayerMissionAsset>) (obj0 => obj0.땓())).FirstOrDefault<SinglePlayerMissionAsset>((Func<SinglePlayerMissionAsset, bool>) (obj0 => 땚.딟(obj0)));
        if (Object.op_Inequality((Object) playerMissionAsset, (Object) null))
        {
          if (!playerMissionAsset.딧())
            this.딧();
          else if (this.딟(playerMissionAsset))
          {
            this.딟 = 딲.떀.땄;
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            this.딟(떑.땃);
            this.딟 = 딲.떀.딧;
            // ISSUE: reference to a compiler-generated method
            this.딟(playerMissionAsset.Id);
          }
        }
        else
          this.땄();
      }
    }

    public void 땄([In] float obj0)
    {
      switch (this.딟)
      {
        case 딲.떀.땄:
          if (!this.딟.땄())
            break;
          this.딟 = 딲.떀.딧;
          // ISSUE: reference to a compiler-generated method
          this.딟(this.딟.딟());
          if (this.딶() == null)
          {
            this.딢();
            break;
          }
          // ISSUE: reference to a compiler-generated method
          this.딟(떑.딶);
          break;
      }
    }

    private void 땄()
    {
      int num1 = 3;
      SinglePlayerMissionAsset playerMissionAsset1 = (SinglePlayerMissionAsset) null;
      bool flag1 = false;
      foreach (딢.땃 땃 in GlobalAppData.땼().딷())
      {
        if (땃.떎())
        {
          foreach (SinglePlayerMissionAsset playerMissionAsset2 in ChallengePackAsset.딢(땃.딝()))
          {
            bool flag2 = playerMissionAsset2.딧();
            if (flag2 && this.딟(playerMissionAsset2))
            {
              this.딟 = 딲.떀.땄;
              return;
            }
            int num2 = GlobalAppData.땽().떎(playerMissionAsset2.Id);
            if (num2 < num1)
            {
              num1 = num2;
              playerMissionAsset1 = playerMissionAsset2;
              flag1 = flag2;
            }
          }
        }
      }
      if (Object.op_Inequality((Object) playerMissionAsset1, (Object) null))
      {
        if (!flag1)
        {
          this.딧();
        }
        else
        {
          this.딟 = 딲.떀.딧;
          // ISSUE: reference to a compiler-generated method
          this.딟(떑.땃);
          // ISSUE: reference to a compiler-generated method
          this.딟(playerMissionAsset1.Id);
        }
      }
      else
        this.딢();
    }

    private void 딧()
    {
      this.딟 = 딲.떀.딧;
      if (((딟.딗) GlobalAppData.땼()).땋())
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(떑.땺);
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(떑.땥);
      }
    }

    private bool 딟([In] SinglePlayerMissionAsset obj0)
    {
      if (딳.땝.딧(obj0))
      {
        this.딟 = 딳.딟(obj0);
        if (this.딟 != null)
          return true;
      }
      return false;
    }

    private void 딢()
    {
      this.딟 = 딲.떀.딧;
      List<SinglePlayerMissionAsset> playerMissionAssetList = new List<SinglePlayerMissionAsset>();
      foreach (딢.땃 땃 in GlobalAppData.땼().딷())
      {
        if (땃.떎())
        {
          foreach (SinglePlayerMissionAsset playerMissionAsset in ChallengePackAsset.딢(땃.딝()))
          {
            if (playerMissionAsset.딧())
              playerMissionAssetList.Add(playerMissionAsset);
          }
        }
      }
      if (playerMissionAssetList.Count == 0)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(떑.딟);
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(playerMissionAssetList[Random.Range(0, playerMissionAssetList.Count)].Id);
        // ISSUE: reference to a compiler-generated method
        this.딟(떑.땃);
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딶.땖 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 떑 땓() => this.딟;

    [SpecialName]
    public bool 땺() => this.딟 == 딲.떀.딧;

    private enum 떀
    {
      딟,
      땄,
      딧,
    }
  }
}
