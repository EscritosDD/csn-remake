// Decompiled with JetBrains decompiler
// Type: 땃.딗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딗
  {
    protected 딶.딡 딟;
    protected 딶.딡 땄;
    public 딗.땳 딟;
    protected 딵 딟;
    public static bool 딟;
    private List<땠> 딟;
    private List<int> 딟;
    private List<int> 땄;
    public GUIStyle 딟 = new GUIStyle();
    public GUIStyle 땄 = new GUIStyle();

    public 딗([In] 딶.딡 obj0)
    {
      this.딟 = obj0;
      this.딟 = new 딵(obj0);
      this.딟 = 딗.땳.딟;
      this.딟 = new List<땠>();
      // ISSUE: reference to a compiler-generated method
      딗.딟(false);
      // ISSUE: reference to a compiler-generated method
      딗.땄(false);
      // ISSUE: reference to a compiler-generated method
      딗.딧(false);
      // ISSUE: reference to a compiler-generated method
      딗.딢(false);
      // ISSUE: reference to a compiler-generated method
      딗.땃(false);
      // ISSUE: reference to a compiler-generated method
      딗.딶(false);
      // ISSUE: reference to a compiler-generated method
      딗.땃(-1);
      this.땄.alignment = (TextAnchor) 4;
      this.땄.normal.textColor = Color.yellow;
      this.딟.alignment = (TextAnchor) 1;
      this.딟.normal.textColor = Color.green;
    }

    public void 딟()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      ScenarioComponent scenarioComponent = this.딟.땼().땃();
      if (Object.op_Equality((Object) scenarioComponent, (Object) null))
        return;
      foreach (GameRulesComponent gameComponent in scenarioComponent.GameComponents)
      {
        if (!Object.op_Equality((Object) gameComponent, (Object) null))
        {
          AIDeployComponent component1 = ((Component) gameComponent).GetComponent<AIDeployComponent>();
          if (!Object.op_Equality((Object) component1, (Object) null))
          {
            GameTileComponent component2 = ((Component) component1).GetComponent<GameTileComponent>();
            this.땼().Add(component2);
          }
        }
      }
    }

    public void 딟([In] int obj0, [In] int obj1, [In] int obj2)
    {
      for (int index = 0; index < this.땼().Count; ++index)
      {
        GameTileComponent gameTileComponent = this.땼()[index];
        if (gameTileComponent.TileIndexX == obj0 && gameTileComponent.TileIndexY == obj1)
        {
          AIDeployComponent component = ((Component) gameTileComponent).GetComponent<AIDeployComponent>();
          if (Object.op_Inequality((Object) component, (Object) null))
            component.Call(obj2);
        }
      }
    }

    public void 딟([In] int obj0, [In] int obj1)
    {
      for (int index = 0; index < this.땼().Count; ++index)
      {
        GameTileComponent gameTileComponent = this.땼()[index];
        if (gameTileComponent.TileIndexX == obj0 && gameTileComponent.TileIndexY == obj1)
        {
          AIDeployComponent component = ((Component) gameTileComponent).GetComponent<AIDeployComponent>();
          if (Object.op_Inequality((Object) component, (Object) null))
            component.Uncall();
        }
      }
    }

    public void 땄()
    {
      if (this.딟.땼().떔() is 딶.딮 딮)
      {
        this.딟 = new List<int>();
        this.땄 = new List<int>();
        for (int index = 0; index < 2; ++index)
          this.땄.Add(int.MaxValue);
        List<int> visBlockingTiles = this.딟.땼().땹().GatherBlockingTiles(this.딟.땼(), this.딟.땼().떂());
        int num1 = 0;
        for (int index1 = 0; index1 < 딮.딦().Count; ++index1)
        {
          int num2 = 0;
          GameTileComponent gameTileComponent1 = 딮.딦()[index1];
          for (int index2 = 0; index2 < 딮.딦().Count; ++index2)
          {
            GameTileComponent gameTileComponent2 = 딮.딦()[index2];
            if (this.딟.땓().get_VisMap().TileIsVisible(this.딟.땼(), this.딟.땼().떂(), 1, gameTileComponent1.TileIndexX, gameTileComponent1.TileIndexY, gameTileComponent2.TileIndexX, gameTileComponent2.TileIndexY, -1, visBlockingTiles))
              ++num2;
          }
          if (num2 > num1)
            num1 = num2;
        }
        this.딟.딟 = (float) num1 / (float) 딮.딦().Count;
        this.딟.딟(딮);
      }
      if (this.딟.땼() == null)
        return;
      SinglePlayerMissionAsset playerMissionAsset = this.딟.땼().땠();
      if (!Object.op_Inequality((Object) playerMissionAsset, (Object) null))
        return;
      this.딟.딶 = playerMissionAsset.AllowAIRecklessAdvance;
      this.딟.딟 = playerMissionAsset.AIDeployVisibilityFractionLimit;
      this.딟.땄 = playerMissionAsset.AIHandicap;
      this.딟.딟 = playerMissionAsset.AllowAIDeployables;
    }

    public void 딟([In] int obj0) => this.딟.Add(obj0);

    public void 땄([In] int obj0) => this.딟.Remove(obj0);

    public int 딧() => this.딟.Count;

    public int 딧([In] int obj0) => this.땄 != null ? this.땄[obj0] : -1;

    public int 딢() => this.딟.땼().떔() is 딶.딮 딮 ? 딮.땭().TurnsToCaptureZone : -1;

    public int 땃() => this.딟.딶();

    public int 딶() => this.딟.땓();

    public void 땓()
    {
      bool flag1 = true;
      while (flag1)
      {
        switch (this.딟)
        {
          case 딗.땳.딟:
            this.딟.딟();
            this.딟 = 딗.땳.땄;
            continue;
          case 딗.땳.땄:
            this.딟 = 딗.땳.딧;
            this.딟.딟 = this.딟.땼().딝();
            this.딟.딧();
            this.딝();
            continue;
          case 딗.땳.딧:
            float realtimeSinceStartup1 = Time.realtimeSinceStartup;
            flag1 = false;
            if (this.딟.땃())
            {
              this.딟 = 딗.땳.딢;
              if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup1 < (double) this.딟.땄 * 0.25)
              {
                flag1 = true;
                continue;
              }
              continue;
            }
            continue;
          case 딗.땳.딢:
            float realtimeSinceStartup2 = Time.realtimeSinceStartup;
            bool flag2 = true;
            flag1 = false;
            while (!this.딟.땥())
            {
              if (!this.딟.땺())
              {
                this.딟.땄();
                this.딟 = 딗.땳.땄;
                flag2 = false;
              }
              if (!flag2)
                break;
            }
            bool flag3 = this.딟.땼().떔().딢(this.딟.땼());
            if (!flag2)
              flag2 = flag3;
            if (flag2)
            {
              if (!flag3 && this.딟.떓())
              {
                this.딟.딥();
                this.딟 = 딗.땳.땄;
              }
              else
                this.딟 = 딗.땳.땃;
            }
            if ((double) Time.realtimeSinceStartup - (double) realtimeSinceStartup2 < (double) this.딟.땄 * 0.25)
            {
              flag1 = true;
              continue;
            }
            continue;
          case 딗.땳.땃:
            this.딟.딷().딟(딶.딨.땥);
            this.딟 = 딗.땳.딶;
            continue;
          case 딗.땳.딶:
            flag1 = false;
            딶.땯 땯 = this.딟.딷();
            if (땯 != null && !땯.딸())
            {
              땯.딟(true, false, false);
              EventTimelineManager.딟().RunToEnd(true);
              continue;
            }
            continue;
          default:
            continue;
        }
      }
    }

    public void 땺()
    {
    }

    [Conditional("DEBUG_AI")]
    public static void 딟([In] string obj0, [In] 땴 obj1)
    {
      switch (obj1)
      {
        case 땴.딟:
          if (!딗.땭() && !딗.땋())
            break;
          Debug.Log((object) obj0);
          break;
        case 땴.땄:
          if (!딗.딦() && !딗.땋())
            break;
          Debug.Log((object) obj0);
          break;
        case 땴.딧:
          if (!딗.땤() && !딗.땋())
            break;
          Debug.Log((object) obj0);
          break;
        case 땴.딢:
          if (!딗.땽() && !딗.땋())
            break;
          Debug.Log((object) obj0);
          break;
      }
    }

    public void 땥()
    {
      if (!딗.땲() || this.딟 == null)
        return;
      this.딟.딟(this.딟);
    }

    private 땠 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (new 땠(obj0, obj1, obj2, obj3, (GameTileComponent[]) null).Equals((object) this.딟[index]))
          return this.딟[index];
      }
      return (땠) null;
    }

    public GameTileComponent[] 딟(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] 딶.땙 obj4,
      [In] 땓.딲 obj5,
      [In] int obj6)
    {
      땠 땠 = this.딟(obj0, obj1, obj2, obj3);
      if (땠 != null)
        return 땠.딟;
      GameTileComponent[] gameTileComponentArray = this.딟.땓().get_TileNetwork().딟(this.딟.땼(), obj4, obj0, obj1, obj2, obj5, obj6, obj3);
      if (gameTileComponentArray.Length > 0)
        this.딟.Add(new 땠(obj0, obj1, obj2, obj3, gameTileComponentArray));
      return gameTileComponentArray;
    }

    private void 딝()
    {
      if (!(this.딟.땼().떔() is 딶.딮 딮))
        return;
      for (int index = 0; index < this.땄.Count; ++index)
        this.땄[index] = 딮.딟(this.딟.땼(), index);
    }

    public bool 딟([In] int obj0, [In] 딶.딹 obj1)
    {
      if (딗.딟)
        return true;
      return obj1 == 딶.딹.땄 && this.딟.딟 == obj0;
    }

    public bool 딟([In] 땓.땊 obj0)
    {
      if (this.딟 == null || this.딟.땼() == null || this.딟.땼().떓() != 딶.딹.땄)
        return false;
      return 딗.딟 || obj0.땄 == this.딟.딟;
    }

    public 땕 딟([In] int obj0, [In] int obj1, [In] int obj2, [In] 땝 obj3) => this.딟.딟(obj0, obj1, obj2, obj3);

    public bool 떎() => this.딟.딛();

    public void 떂()
    {
      this.딟.땼().딥().RemoveAt(this.딟.땼().딥().Count - 1);
      this.딟.딷()?.땄(true);
    }

    public string 딢([In] int obj0) => this.딟.딟(obj0, this.딟.땁());

    [CompilerGenerated]
    [SpecialName]
    public static bool 땭() => 딗.땄;

    [CompilerGenerated]
    [SpecialName]
    public static bool 딦() => 딗.딧;

    [CompilerGenerated]
    [SpecialName]
    public static bool 땤() => 딗.딢;

    [CompilerGenerated]
    [SpecialName]
    public static bool 땽() => 딗.땃;

    [CompilerGenerated]
    [SpecialName]
    public static bool 땋() => 딗.딶;

    [CompilerGenerated]
    [SpecialName]
    public static bool 땲() => 딗.땓;

    [CompilerGenerated]
    [SpecialName]
    public static int 떏() => 딗.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 땼() => this.딟;

    public enum 땳
    {
      딟,
      땄,
      딧,
      딢,
      땃,
      딶,
    }
  }
}
