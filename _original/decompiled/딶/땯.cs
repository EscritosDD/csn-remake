// Decompiled with JetBrains decompiler
// Type: 딶.땯
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땯 : 땇
  {
    private BitArray 딟;
    private 땙 딟;
    private 땙 땄;
    private 딶.땼 딟 = new 딶.땼();
    private 딶.땺 딟 = new 딶.땺();
    private GameTileComponent 딟;
    private List<땓.땦> 딟;
    private 땓.땊[] 딟;
    private 땓.땽 딟;
    private 땓.딴 딟;
    private 땓.딴 땄;
    private 땓.딴 딧;
    private 땓.딴 딢;
    private 땓.딴 땃;
    private 땓.딴 딶;
    private 땓.딴 땓;
    private 땓.딴 땺;
    private 땓.딴 땥;
    private 땓.딴 딝;
    private 땓.딴 떎;
    private 땓.땢 딟;
    private 땓.땲 딟;
    private 땓.땤 딟;
    private 땓.떏 딟;
    private 땓.땼 딟;
    private 땓.딷 딟;
    private 땓.떁 딟;
    private 땓.땟 딟;
    private 딡 딟;
    private bool 딟;
    private bool 땄;
    private bool 딧;
    private bool 딢 = true;
    private 땓.땦 딟;

    public 땯([In] 딡 obj0)
    {
      this.딟 = obj0;
      this.딟 = new 땓.딴(GlobalAppData.딟.GameAssets.MovementHighlightModel, 32);
      this.땄 = new 땓.딴(GlobalAppData.딟.GameAssets.FirePossibleHighlightModelHigh, 32);
      this.딧 = new 땓.딴(GlobalAppData.딟.GameAssets.FirePossibleHighlightModelMedium, 32);
      this.딢 = new 땓.딴(GlobalAppData.딟.GameAssets.FirePossibleHighlightModelLow, 32);
      this.땃 = new 땓.딴(GlobalAppData.딟.GameAssets.ReturnFireHighlightModel, 32);
      this.딶 = new 땓.딴(GlobalAppData.딟.GameAssets.EnemyHighlightModel, 32);
      this.땓 = new 땓.딴(((Component) GlobalAppData.딟.GameAssets.TargetDisplayInfo.ModelPrefab).gameObject, 8);
      this.땺 = new 땓.딴(((Component) GlobalAppData.딟.GameAssets.TwoStageTargetDisplayInfo.ModelPrefab).gameObject, 8);
      this.땥 = new 땓.딴(GlobalAppData.딟.GameAssets.CanAttackAfterMoveModel, 8);
      this.딝 = new 땓.딴(GlobalAppData.딟.GameAssets.UnitEmoteBubbleUI, 32);
      this.떎 = new 땓.딴(GlobalAppData.딟.GameAssets.SpawnHighlightModel, 32);
    }

    public void 딟([In] bool obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딠(this.딟));
      this.딟 = new List<땓.땦>();
      List<땓.땊> 땊List = this.딟.땼().떎();
      for (int index = 0; index < 땊List.Count; ++index)
      {
        Vector3 vector3;
        Quaternion quaternion;
        if (땊List[index].땓())
        {
          vector3 = this.딟.땓().GetTileCentre(땊List[index].땃, 땊List[index].딶);
          quaternion = 땊List[index].땃();
        }
        else
        {
          vector3 = Vector3.zero;
          quaternion = Quaternion.identity;
        }
        this.딟.Add(new 땓.땦(this.딟, 땊List[index], index, vector3, quaternion));
      }
      if (obj0)
        this.딧();
      this.딷();
      this.떏();
    }

    public void 딧()
    {
      if (this.딟.땼().떓() == 딹.딟)
      {
        if (this.딟.땼().떔() is 딖)
          this.땄(딨.딧);
        else
          this.땄(딨.땄);
      }
      else
      {
        if (this.딟.땼().떁() && !this.딟.땼().딷())
          return;
        this.땄(딨.땃);
      }
    }

    public bool 딟([In] int obj0, [In] int obj1)
    {
      if (this.땢() == obj1)
        return this.딟[obj0];
      땙 땙 = this.땃();
      return this.딟.땼().딟(땙, obj0, 땙.땺()[obj0].땃, 땙.땺()[obj0].딶, obj1, false);
    }

    public void 딢()
    {
      this.땄(딨.딧);
      this.딟(this.딟.땼().떂());
      this.딟(true, false);
    }

    private 땙 땃() => this.떇() == 딨.땃 || this.떇() == 딨.딶 ? this.땄 : this.딟.땼().떂();

    public bool 딟([In] int obj0, [In] int obj1, [In] int obj2)
    {
      땙 땙 = this.땃();
      this.딟[obj0] = this.딟.땼().딟(땙, obj0, obj1, obj2, this.딟.땼().딝(), false);
      if (땃.딗.땲() && this.딟(this.딟[obj0].땴()))
        this.딟[obj0] = true;
      this.딧(obj0);
      return this.딟[obj0];
    }

    public void 딟([In] int obj0, [In] Vector3 obj1) => this.딟[obj0].딟(obj1);

    public void 땄([In] int obj0) => this.딟(this.딟[obj0]);

    public void 딟([In] 땓.땦 obj0)
    {
      if (!obj0.땴().땓())
        return;
      obj0.땄(this.딟.땓().GetTileCentre(obj0.땴().땃, obj0.땴().딶));
      obj0.딟(obj0.땴().땃());
    }

    public void 딟([In] int obj0, [In] bool obj1) => this.딟[obj0].딢(obj1);

    public void 땄([In] int obj0, [In] bool obj1) => this.딟[obj0].땃(obj1);

    private void 딧([In] int obj0) => this.딧(obj0, true);

    private void 딧([In] int obj0, [In] bool obj1)
    {
      땓.땦 땦 = this.딟[obj0];
      if (this.딟 != null && !this.딟[obj0])
        땦.딟(땓.딵.땥);
      else
        땦.딟(땓.딵.딟);
      if (!obj1)
        return;
      땦.땄(false);
    }

    public void 딟([In] 딨 obj0) => this.땄(obj0);

    private void 땄([In] 딨 obj0) => this.딟(obj0, false);

    private void 딟([In] 딨 obj0, [In] bool obj1)
    {
      if (this.떇() == obj0)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딢(this.떇());
      // ISSUE: reference to a compiler-generated method
      this.딧(obj0);
      Vector3 cameraTargetPos;
      if (this.땉() == 딨.땃 && obj0 == 딨.딶 && this.딟.딟.OnTurnStart(this.딟.땼().딝(), out cameraTargetPos))
        EventTimelineManager.딟().AddEvent((땏) new 딜(cameraTargetPos, 0.5f));
      if (this.땉() == 딨.땥 && (obj0 == 딨.땄 || obj0 == 딨.땺))
        this.딟.딟.OnTurnEnd((this.딟.땼().딝() + 1) % 2);
      if (this.땉() == 딨.딧)
      {
        if (!this.딟.땼().땼())
          this.딟.땢().OpenMapNameScreen();
        this.땪().Dispose();
        // ISSUE: reference to a compiler-generated method
        this.딟(new 딠(this.딟));
      }
      if (this.떇() == 딨.딧)
      {
        this.딶();
        this.땪().딟();
        this.딟.땼().떔().딟();
      }
      if (this.떇() == 딨.땄)
      {
        this.때();
        if (this.땉() != 딨.딟)
          this.딟.땢().OpenTurnTitleScreenWhileInGame();
      }
      if (this.떇() == 딨.떂 || this.떇() == 딨.떎)
      {
        this.때();
        if (!this.딧)
        {
          this.딧 = true;
          EventTimelineManager.딟().AddEvent((땏) new 딲());
        }
      }
      if (this.떇() == 딨.땺)
      {
        if (!obj1)
        {
          if ((this.딟 || this.딟.땼().딟.땄()) && !this.딟.떁().딟(this.딟.땼().딝(), this.딟.땼().떓()))
          {
            this.딟.땼().떔().딟(this, 딨.떂);
            return;
          }
          if (this.땄 && !this.딟.떁().딟(this.딟.땼().딝(), this.딟.땼().떓()))
          {
            this.딟.땼().떔().딟(this, 딨.떎);
            return;
          }
        }
        if ((this.땉() == 딨.딶 || this.땉() == 딨.땓) && !(this.딟.땼().떔() is 딖) && this.딟.땼().떓() != 딹.딟)
        {
          this.딟.땼().떔().딧();
          if (!this.딟 && !this.땄)
            this.딟.땢().OpenTurnTitleScreenWhileInGame();
        }
        else if (this.땓())
        {
          this.딟.땼().떔().딧();
          this.딟.땢().ActivateGameplayHUD();
        }
        else if (this.땉() == 딨.딧)
          this.딟.땼().떔().딧();
        else if (this.땉() == 딨.딢 && !this.딟.땼().땼())
          this.딟.땢().OpenTurnTitleScreenWhileInGame();
        this.딟(this.딟.땼().떂());
        this.딟 = false;
        this.땄 = false;
      }
      if (this.떇() == 딨.땃)
      {
        if (this.딟.땼().딥().Count < 2)
        {
          this.땄(딨.딶);
          return;
        }
        this.땥();
        this.딟(false, false);
        this.딷();
        if (this.딟.땥().Count > 0)
        {
          if (!(this.딟.땼().떔() is 딖))
          {
            this.딟.땼().떔().딧();
            this.딟.땢().OpenReplayScreen();
          }
          else
            this.딟.땢().DeactivateGameplayHUD();
        }
        else
          this.딥();
      }
      if (this.떇() == 딨.딶)
      {
        if (!(this.딟.땼().떔() is 딖))
          this.딟.땢().OpenReplayScreen();
        this.딟 = this.딟.땼().떂();
        this.땄 = this.딟.땼().땤();
        this.딟(this.땄);
        this.때();
        this.딟(false, false);
        this.딷();
        this.딟 = this.딟.땼().떔().딢(this.딟.땼());
        this.딶();
      }
      if (this.떇() == 딨.땓)
        this.땄 = this.딟.땼().떔().딢(this.딟.땼());
      if (this.떇() == 딨.땥)
      {
        if (this.딟.땼().떔() is 딖 && this.딟.땼().떔().딢(this.딟.땼()))
        {
          this.딟.땭();
          return;
        }
        List<땓.땊> 땊List = this.딟.땼().떎();
        int num = this.딟.땼().딝();
        bool APRemaining = false;
        for (int index = 0; index < 땊List.Count; ++index)
        {
          if (땊List[index].땄 == num && 땊List[index].딧 > 0 && 땊List[index].땓() && 땊List[index].딢 > 0)
          {
            APRemaining = true;
            break;
          }
        }
        if (!this.딟.땼().땼())
          this.딟.땢().OpenEndTurnVerification(APRemaining);
      }
      if (this.떇() == 딨.딝)
      {
        this.딱();
        this.땟();
      }
      this.딷();
    }

    private void 딶()
    {
      if (this.딟.땼().떂().땥().Count != 0)
        return;
      this.딟.땼().딟((땃.땧) new 땃.땮())?.땄(true);
    }

    public bool 땓()
    {
      int num = this.딟.땼().떓() != 딹.딟 ? 1 : 2;
      return this.땉() != 딨.딧 && this.땉() != 딨.딢 && this.딟.땼().딥().Count > num;
    }

    private void 땺()
    {
      if (this.딟.땼().떔() is 딖 || this.땈() != null || this.딟.떁().딟(this.딟.땼().딝(), this.딟.땼().떓()))
        return;
      foreach (int index in this.딟.땼().딧(this.딟.땼().딝()))
      {
        if (!this.딟.땼().떂().땺()[index].땺())
        {
          this.딟(this.딟[index], false, true);
          break;
        }
      }
    }

    public void 땥()
    {
      this.딟 = this.딟.땼().땭();
      this.땄 = this.딟.땼().땽();
      this.딟(this.땄);
    }

    private void 딟([In] 땙 obj0)
    {
      List<땓.땊> 땊List = obj0.땺();
      for (int index = 0; index < 땊List.Count; ++index)
        this.딟[index].딟(땊List[index]);
    }

    public void 딝()
    {
    }

    public void 딟([In] int obj0, [In] 땮 obj1)
    {
      땓.딲 딲 = this.딟.땼().땻()[obj0];
      땓.딘 딘 = this.딟(obj1);
      switch (딘)
      {
        case 땓.딘.딶:
        case 땓.딘.땓:
        case 땓.딘.땩:
        case 땓.딘.땠:
          AudioShader2.딟(this.딟[obj0].딣(), 딧.땸.땄);
          break;
      }
      AudioShader2 audioShader2 = 딲.딟(딘);
      if (Object.op_Inequality((Object) audioShader2, (Object) null))
        this.딟[obj0].딟(audioShader2);
      EventTimelineManager.딟().OnCinematicEvent(obj0, obj1);
    }

    private 땓.딘 딟([In] 땮 obj0)
    {
      switch (obj0)
      {
        case 땮.딧:
          return 땓.딘.딟;
        case 땮.딢:
          return 땓.딘.땄;
        case 땮.땃:
          return 땓.딘.딦;
        case 땮.딶:
          return 땓.딘.땤;
        case 땮.땓:
          return 땓.딘.땽;
        case 땮.딦:
          return 땓.딘.딶;
        case 땮.땤:
          return 땓.딘.땓;
        case 땮.땽:
          return 땓.딘.땺;
        case 땮.땋:
          return 땓.딘.땥;
        case 땮.땲:
          return 땓.딘.딝;
        case 땮.떏:
          return 땓.딘.떎;
        case 땮.땼:
          return 땓.딘.떂;
        case 땮.땢:
          return 땓.딘.땭;
        case 땮.떁:
          return 땓.딘.떏;
        case 땮.땟:
          return 땓.딘.땼;
        case 땮.땂:
          return 땓.딘.땢;
        case 땮.딱:
          return 땓.딘.딷;
        case 땮.때:
          return 땓.딘.떁;
        case 땮.땩:
          return 땓.딘.땟;
        case 땮.땠:
          return 땓.딘.땂;
        case 땮.땴:
          return 땓.딘.딱;
        case 땮.딗:
          return 땓.딘.때;
        case 땮.땳:
          return 땓.딘.땩;
        case 땮.땻:
          return 땓.딘.땠;
        case 땮.딥:
          return 땓.딘.딗;
        case 땮.떓:
          return 땓.딘.땳;
        default:
          return 땓.딘.땲;
      }
    }

    public 땓.땦 딟([In] int obj0) => this.딟[obj0];

    public int 떎() => this.딟.Count;

    [Conditional("NEVER_COMPILE")]
    public void 딢([In] int obj0) => Debug.Log((object) "THIS SHOULD NEVER BE VISIBLE");

    public int 땃([In] int obj0)
    {
      int num1 = 0;
      foreach (int num2 in this.딟.땼().딧(obj0))
        ++num1;
      return num1;
    }

    public 딡 딟() => this.딟;

    private void 떂()
    {
      switch (this.떇())
      {
        case 딨.딢:
          if (this.딸() || this.딟.땢().CloudsAreOpen())
            break;
          this.땄(딨.땺);
          break;
        case 딨.땃:
        case 딨.딶:
          if (this.딸())
            break;
          if (this.땄.땥().Count < this.딟.땥().Count)
          {
            do
            {
              땃.땧 땧 = this.딟.땥()[this.땄.땥().Count];
              EventTimelineManager.딟().AddEventTimeline(this.딟.땼().딟(땧, this.땄, (땓.떒) 딶.딣.딟));
              this.땄.땥().Add(땧);
            }
            while (this.땄.땥().Count < this.딟.땥().Count && EventTimelineManager.딟().IsEmpty());
            if (this.딟.땼().떔().딢())
              this.딟.땢().ReplayScreen.GameStatus.InitailiseGameStatusBox(this.딟.땼(), 0, 1, this.땄);
            if (EventTimelineManager.딟().IsEmpty() && this.땄.땄().딧())
              this.딥();
            if (this.땄.땥().Count != this.딟.땥().Count || this.떇() != 딨.땃)
              break;
            EventTimelineManager.딟().AddEventTimeline(this.땄.땄());
            break;
          }
          if (EventTimelineManager.딟().IsRunning() && !EventTimelineManager.딟().IsEmpty())
            break;
          if (this.떇() == 딨.딶)
          {
            this.땄(딨.땓);
            break;
          }
          if (this.떇() != 딨.땃)
            break;
          this.땄(딨.딶);
          break;
        case 딨.땓:
          if (this.딸())
            break;
          if (this.딟.딟() && !this.딟.땼().딷())
          {
            this.땄(딨.딧);
            break;
          }
          this.땄(딨.땺);
          break;
        case 딨.딝:
          if (this.딸())
            break;
          this.땼();
          break;
        case 딨.떎:
          if (this.딸())
            break;
          this.딟(true, true, false);
          break;
        case 딨.떂:
          if (this.딸())
            break;
          this.딟.딦();
          break;
      }
    }

    private void 땭()
    {
    }

    private void 딦()
    {
    }

    public void 땤()
    {
      // ISSUE: reference to a compiler-generated method
      this.땃(this.딸());
      // ISSUE: reference to a compiler-generated method
      this.딢(EventTimelineManager.딟().IsRunning());
      this.떂();
      if (this.딟.떏())
        return;
      if (this.땘() && !this.딸())
        this.떏();
      this.딟(false, this.딸());
      땙 땙 = this.땃();
      this.딟.땼().떔().딟(this.딟.땼(), 땙);
      this.땋();
      this.땴();
      this.땽();
    }

    private void 땽()
    {
      if (this.딟.땼().떂().딧() == 0)
      {
        if (this.딟 != null)
          return;
        this.딟 = new 땓.땼(this.딟, this.떎);
      }
      else
      {
        if (this.딟 == null)
          return;
        this.딟.Dispose();
        this.딟 = (땓.땼) null;
      }
    }

    public void 땋()
    {
      if (this.떇() != 딨.땺 && this.떇() != 딨.땥)
        return;
      if (this.딟.땼().땼())
      {
        this.딟.떁().땓();
      }
      else
      {
        if (this.딟.땼().떓() != 딹.땄)
          return;
        this.딟.떁().땺();
      }
    }

    public void 딟([In] GameTileComponent obj0)
    {
      if (this.떇() == 딨.딧)
      {
        this.땪().딧(obj0);
      }
      else
      {
        if (this.떇() != 딨.땺 || this.딟.땼().땼())
          return;
        if (this.딸() && this.딟.땼().땩())
        {
          this.딥();
        }
        else
        {
          땓.땦 unitOnTile = obj0.GetUnitOnTile(this.땞());
          if (this.땈() != null)
          {
            GameTileComponent gameTileComponent = (GameTileComponent) null;
            if (this.딟(obj0, out gameTileComponent))
            {
              if (this.땲().TwoStageAttack)
              {
                if (this.딟 == null)
                {
                  this.딟 = unitOnTile;
                  this.떏();
                }
                else
                  this.땃(gameTileComponent);
              }
              else
                this.땃(gameTileComponent);
            }
            else if (this.딟 != null && this.딟.딟().Contains(obj0))
            {
              if (!this.딢 || Object.op_Equality((Object) this.딟, (Object) obj0))
              {
                this.딢(obj0);
              }
              else
              {
                if (!this.딢)
                  return;
                this.땄(obj0);
              }
            }
            else if (this.딟 != null && this.딟.딟().Contains(obj0))
              this.딧(obj0);
            else if (this.딟 != null && this.딟.딟().Contains(obj0))
              this.땄(unitOnTile);
            else
              this.딟(unitOnTile, obj0);
          }
          else if (unitOnTile != null)
          {
            this.딟(unitOnTile, false, false);
          }
          else
          {
            this.땩();
            this.딟(obj0, false, true);
          }
        }
      }
    }

    private void 딟([In] 땓.땦 obj0, [In] GameTileComponent obj1)
    {
      if (obj0 == this.땈())
      {
        딶.땢 땢 = new 딶.땢(obj0.땔());
        if (this.딟.땼().떔().딟((딶.땃) 땢, true))
        {
          this.딟 = (땓.땦) null;
          this.떏();
        }
        if (this.딟 == null)
          this.딟(obj0, false, false);
        else
          this.땷();
      }
      else
      {
        딶.땭 땭 = new 딶.땭();
        if (!this.딟.땼().떔().딟((딶.땃) 땭, true))
          return;
        if (this.딟 == null)
        {
          if (obj0 != null)
          {
            this.딟(obj0, false, false);
          }
          else
          {
            this.때();
            this.딟(obj1, false, true);
          }
        }
        this.땠();
      }
    }

    private void 땄([In] GameTileComponent obj0)
    {
      this.땠();
      this.딟 = obj0;
      bool flag = false;
      딶.땤 땤 = new 딶.땤(this.땈().땔(), obj0.TileIndexX, obj0.TileIndexY);
      if (this.딟.땼().떔().딟((딶.땃) 땤, false))
        flag = true;
      if (flag && this.딟.딟(obj0))
      {
        if (this.딟 != null)
        {
          this.딟.Dispose();
          this.딟 = (땓.땢) null;
        }
        this.딟 = new 땓.땢(this.딟, this.땥, this.딝, this.땈(), obj0, this.땞(), this.딟);
      }
      else
      {
        if (this.딟 != null)
        {
          this.딟.Dispose();
          this.딟 = (땓.땢) null;
        }
        WeaponGameplayData weaponGameplayData = this.땲();
        if (Object.op_Inequality((Object) weaponGameplayData, (Object) null) && weaponGameplayData.TwoStageAttack)
          this.딟(obj0, weaponGameplayData);
        else
          this.딟 = new 땓.땢(this.딟, this.땓, this.딝, this.땈(), (GameTileComponent) null, this.땞(), this.딟);
      }
      if (!flag)
        return;
      this.딟 = new 땓.땤(this.딟, this.땈(), this.땈().땴().땃, this.땈().땴().딶, obj0.TileIndexX, obj0.TileIndexY, this.땈().땴().딟, this.땈().땴().땄);
    }

    private void 딟([In] GameTileComponent obj0, [In] WeaponGameplayData obj1)
    {
      땓.딲 딲 = this.딟.땼().땻()[this.땈().땔()];
      List<GameTileComponent> gameTileComponentList = this.딟.땓().get_TileNetwork().딟(this.딟.땼(), this.딟.땼().떂(), this.땈().땴().땃, this.땈().땴().딶, obj0.TileIndexX, obj0.TileIndexY, 딲);
      if (gameTileComponentList == null || gameTileComponentList.Count <= 0)
        return;
      int num = (gameTileComponentList.Count - 1) * 딲.땥();
      if (this.땈().땴().딢 - num < obj1.RequiredActionPoints)
        return;
      this.딟 = new 땓.땢(this.딟, this.땺, this.딝, this.땈(), obj0, this.땞(), this.딟);
    }

    private bool 딟([In] GameTileComponent obj0, out GameTileComponent _param2)
    {
      _param2 = (GameTileComponent) null;
      if (this.딟 == null)
        return false;
      if (this.딟.딟().Contains(obj0))
      {
        _param2 = obj0;
        return true;
      }
      if (obj0.GetUnitOnTile(딢.딴.딟) != null)
        return false;
      땓.땦 땦 = this.딟(obj0, true, false, false);
      if (땦 != null)
      {
        GameTileComponent gameTileComponent = this.딟.땓().get_Tiles()[땦.땴().땃, 땦.땴().딶];
        if (this.딟.딟().Contains(gameTileComponent))
        {
          _param2 = gameTileComponent;
          return true;
        }
      }
      return false;
    }

    private void 땄([In] 땓.땦 obj0)
    {
      if (딶.딢.딟(this.딟.땼(), this.딟.땼().떂(), this.땈().땔(), this.땞(), true) == -1)
        return;
      딶.떏 떏 = new 딶.떏(this.땈().땔(), this.땞(), obj0.땔());
      if (!this.딟.땼().떔().딟((딶.땃) 떏, true))
        return;
      this.딟(떏.딟());
      if (this.땈() != null)
        this.딟(딢.딴.땄, true);
      this.딱();
    }

    private void 딧([In] GameTileComponent obj0)
    {
      딶.땋 땋 = new 딶.땋(this.땈().땔(), this.땞(), obj0.TileIndexX, obj0.TileIndexY);
      if (!this.딟.땼().떔().딟((딶.땃) 땋, true))
        return;
      this.딟(땋.딟());
      if (this.땈() != null)
        this.딟(딢.딴.땄, true);
      this.딱();
    }

    private void 딢([In] GameTileComponent obj0)
    {
      딶.땤 땤 = new 딶.땤(this.땈().땔(), obj0.TileIndexX, obj0.TileIndexY);
      if (!this.딟.땼().떔().딟((딶.땃) 땤, true))
        return;
      AudioShader2 audioShader2 = this.딟.땼().땻()[this.땈().땔()].딟(땓.딘.딢);
      AudioShader2.딟(this.땈().딣(), 딧.땸.땄);
      this.땈().딟(audioShader2);
      this.딟(땤.딟());
      this.딱();
      this.땠();
    }

    private void 땃([In] GameTileComponent obj0)
    {
      List<int> intList = new List<int>();
      if (!땃.땫.딟(this.딟.땼(), this.딟.땼().떂(), this.땈().땔(), this.땞(), obj0.TileIndexX, obj0.TileIndexY, false, intList))
        return;
      딶.땽 땽 = new 딶.땽(this.땈().땔(), this.땞(), obj0.TileIndexX, obj0.TileIndexY);
      if (!this.딟.땼().떔().딟((딶.땃) 땽, true))
        return;
      this.딟(땽.딟());
      if (this.땈() != null)
      {
        if (this.땈().땴().땺())
          this.때();
        else
          this.딟(딢.딴.땄, true);
      }
      this.딱();
      this.딟 = (땓.땦) null;
    }

    private 땓.땦 딟([In] GameTileComponent obj0, [In] bool obj1, [In] bool obj2, [In] bool obj3)
    {
      땓.땦 땦1 = (땓.땦) null;
      for (int index = 0; index < this.딟.땼().떎().Count; ++index)
      {
        땓.땦 땦2 = this.딟(index);
        if (땦2.딱())
        {
          땓.땊 땊 = 땦2.땴();
          if (땊.땓() && !땊.땺() && (!obj3 || this.딟.땼().땻()[땦2.땔()].딶()) && (obj1 || 땊.땄 == this.딟.땼().딝()) && (obj2 || 땊.땄 != this.딟.땼().딝()))
          {
            int num1 = Mathf.Abs(obj0.TileIndexX - 땊.땃);
            int num2 = Mathf.Abs(obj0.TileIndexY - 땊.딶);
            if (num1 <= 1 && num2 <= 1)
            {
              Ray ray = ((Component) 딡.땴().딟).camera.ScreenPointToRay(Input.mousePosition);
              Vector3 tileCentre = this.딟.땓().GetTileCentre(땊.땃, 땊.딶);
              ref Vector3 local = ref tileCentre;
              local.y = (__Null) (local.y + 0.5);
              Bounds bounds;
              // ISSUE: explicit constructor call
              ((Bounds) ref bounds).\u002Ector(tileCentre, Vector3.one);
              if (((Bounds) ref bounds).IntersectRay(ray))
              {
                땦1 = 땦2;
                break;
              }
            }
          }
        }
      }
      return 땦1;
    }

    private void 딟([In] GameTileComponent obj0, [In] bool obj1, [In] bool obj2) => this.딟(obj0, obj1, obj2, true)?.땼();

    public void 딶([In] GameTileComponent obj0)
    {
      if (Object.op_Inequality((Object) this.딟.딟, (Object) null) && this.딟 != null && !this.딟.딟().Contains(obj0) && !(this.딟.땼().떔() is 딖))
        this.딟.딟.MoveToPos(((Component) obj0).transform.position, -1f);
      this.딟(obj0);
    }

    public void 딧([In] 땓.땦 obj0)
    {
    }

    public void 딢([In] 땓.땦 obj0)
    {
    }

    public void 딟([In] 땓.땦 obj0, [In] bool obj1, [In] bool obj2)
    {
      if (this.딸() && !obj2 || this.떇() != 딨.땺 || this.딟.땼().땼())
        return;
      if (this.딟.땼().딝() != obj0.땴().땄)
      {
        this.딟(obj0, obj1);
      }
      else
      {
        bool flag1 = this.딟.땼().떔() is 딖;
        bool flag2 = this.딟.땼().떔() is 딴;
        if (!flag1 && !flag2)
          this.딟.땢().DisplayTooltip(딢.딮.땷);
        this.땠();
        if (this.땈() == obj0 || obj1)
        {
          if (!flag1)
            this.딟.딟.MoveToPos(new 딶.땩(obj0.땴().땃, obj0.땴().딶), 0.5f, true);
          if (this.땈() == obj0)
            return;
        }
        딶.땢 땢 = new 딶.땢(obj0.땔());
        if (!this.딟.땼().떔().딟((딶.땃) 땢, true))
          return;
        this.때();
        AudioShader2 audioShader2 = this.딟.땼().땻()[obj0.땔()].딟(땓.딘.딧);
        AudioShader2.딟(obj0.딣(), 딧.땸.땄);
        obj0.딟(audioShader2);
        // ISSUE: reference to a compiler-generated method
        this.땃(obj0);
        this.땄(딢.딴.땄);
        this.떏();
      }
    }

    public void 딟([In] 땓.땦 obj0, [In] bool obj1)
    {
      if (this.딸() || this.떇() != 딨.땺 || !this.딟(obj0.땔(), this.딟.땼().딝()))
        return;
      this.땟();
      if (this.땈() != null)
      {
        딶.땭 땭 = new 딶.땭();
        if (!this.딟.땼().떔().딟((딶.땃) 땭, true))
          return;
        this.때();
      }
      딶.딷 딷 = new 딶.딷(obj0.땔());
      if (!this.딟.땼().떔().딟((딶.땃) 딷, true))
        return;
      this.땩();
      // ISSUE: reference to a compiler-generated method
      this.딶(obj0);
      this.딟 = new 땓.딷(this.딟, this.땃, obj0, obj0.땴().딟);
      if (!obj1)
        return;
      this.딟.딟.MoveToPos(new 딶.땩(obj0.땴().땃, obj0.땴().딶), -1f);
    }

    public void 딟(out int _param1, out int _param2, [In] int obj2)
    {
      _param1 = 0;
      _param2 = 0;
      if (this.땞() == 딢.딴.딟 || this.땈() == null)
        return;
      WeaponGameplayData weaponGameplayData = this.땲();
      if (Object.op_Equality((Object) weaponGameplayData, (Object) null))
        return;
      float num1 = 땃.땫.딟(this.딟.땼(), this.딟.땼().떂(), this.땈().땔(), this.땞(), obj2, 1f);
      float num2 = weaponGameplayData.딟(this.딟.땼().땞(), this.땈().땴());
      _param1 = Mathf.RoundToInt(num2 * num1) * weaponGameplayData.ShotsPerAttack;
      _param2 = Mathf.RoundToInt((num2 + weaponGameplayData.DamageSpread) * num1) * weaponGameplayData.ShotsPerAttack;
    }

    private WeaponGameplayData 땲()
    {
      UnitWeapon unitWeapon = 땓.땎.딢(this.땞(), this.딟.땼().땻()[this.땈().땔()]);
      return Object.op_Inequality((Object) unitWeapon, (Object) null) ? unitWeapon.딟(this.딟.땼()) : (WeaponGameplayData) null;
    }

    public float 딟([In] int obj0, [In] GameTileComponent obj1) => this.땞() != 딢.딴.딟 && this.땈() != null ? 땃.땫.딟(this.딟.땼(), this.딟.땼().떂(), this.땈().땔(), this.땞(), obj0, 1f, obj1) : 0.0f;

    private void 떏()
    {
      this.딱();
      if (this.땈() == null)
        return;
      if (!this.땈().땴().땓())
      {
        this.때();
      }
      else
      {
        if (this.땈().땴().땄 != this.딟.땼().딝() || EventTimelineManager.딟().IsRunning())
          return;
        if (땓.땎.땺(this.땞()))
        {
          if (this.딟 == null && 땓.땎.땓(this.땞()) && this.딟.땼().땻()[this.땈().땔()].땄(딢.딴.땔))
            this.딟 = new 땓.땽(this.딟, this.땄, this.딧, this.딢, this.딟, this.땈());
          WeaponGameplayData weaponGameplayData = 땓.땎.딧(this.땞(), this.딟.땼().땻()[this.땈().땔()]);
          if (Object.op_Inequality((Object) weaponGameplayData, (Object) null))
            this.딟 = !weaponGameplayData.TwoStageAttack ? new 땓.땢(this.딟, !weaponGameplayData.딟() ? this.땓 : this.딶, this.딝, this.땈(), (GameTileComponent) null, this.땞(), this.딟) : (this.딟 == null ? new 땓.땢(this.딟, this.땺, this.딝, this.땈(), (GameTileComponent) null, this.땞(), this.딟) : new 땓.땢(this.딟, this.딶, this.딝, this.땈(), (GameTileComponent) null, this.땞(), this.딟));
        }
        else if (땓.땎.딢(this.땞()))
          this.딟 = new 땓.땲(this.딟, this.땈(), this.땞());
        else if (땓.땎.딶(this.땞()))
          this.딟 = new 땓.떏(this.딟, this.땈(), this.땞());
        this.땈().땓(true);
      }
    }

    public void 딟([In] bool obj0, [In] bool obj1, [In] bool obj2)
    {
      int num = this.딟.땼().떔().땃(this.딟.땼());
      if (obj2 && num != -1 && num != this.딟.땼().딝())
      {
        this.땄(딨.떎);
      }
      else
      {
        this.땄(딨.딝);
        if (obj0)
          this.딟.땼().떂().딟(this.딟.땼().딟((땃.땧) new 땃.떒()));
        땓.딟 timeline = this.딟.땼().떂().땄();
        if (obj1)
          timeline.땄(true);
        else
          EventTimelineManager.딟().AddEventTimeline(timeline);
      }
    }

    public void 땼()
    {
      bool flag = this.딟.땼().떔() is 딖;
      this.땷();
      RandomAudioComponent.딟();
      딟.딦.땄();
      this.딟.땼().딟(true, false)?.땄(true);
      this.딷();
      if (this.딟.땼().떓() == 딹.딟)
      {
        if (!(this.딟.땼().떔() is 딖))
          this.땄(딨.땄);
        if (flag)
        {
          this.땄(딨.땃);
          this.땄(딨.딶);
          this.땄(딨.땓);
          this.땄(딨.땺);
        }
      }
      else if (this.딟.땼().떓() != 딹.딧)
      {
        if (!this.딟.땼().땼() && !flag)
          this.땄(딨.땃);
        else if (this.딟.딟() && !this.딟.땼().딷())
          this.땄(딨.딧);
        else
          this.땄(딨.땺);
      }
      if (this.딟.땼().땼() && !this.딟.땼().떔().딢(this.딟.땼()))
      {
        this.딟.떁().딟 = 땃.딗.땳.딟;
        this.딟.땽();
      }
      else
      {
        if (this.딟.땼().땼() || !this.딟.땤())
          return;
        this.딟.땋();
      }
    }

    private bool 딟([In] 땓.땊 obj0) => this.딟.떁().딟(obj0);

    private int 땢() => this.딟.땼().딝();

    private void 딷()
    {
      this.딟 = new BitArray(this.딟.Count);
      switch (this.떇())
      {
        case 딨.땄:
          this.딟.SetAll(false);
          break;
        case 딨.땃:
        case 딨.딶:
          for (int index = 0; index < this.딟.Count; ++index)
            this.딟[index] = this.딟.땼().딟(this.땄, index, this.딟[index].땴().땃, this.딟[index].땴().딶, this.땢(), false);
          break;
        case 딨.땓:
        case 딨.땺:
        case 딨.땥:
        case 딨.딝:
        case 딨.떎:
        case 딨.떂:
          for (int index = 0; index < this.딟.Count; ++index)
            this.딟[index] = this.딟.땼().딟(this.딟.땼().떂(), index, this.딟[index].땴().땃, this.딟[index].땴().딶, this.땢(), false);
          break;
      }
      if (!땃.딗.땲())
        return;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟(this.딟[index].땴()))
          this.딟[index] = true;
      }
    }

    private void 떁()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (땓.딷) null;
    }

    private void 땟()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (땓.떁) null;
    }

    private void 땂()
    {
      if (this.딟 == null)
        return;
      this.딟.Dispose();
      this.딟 = (땓.땟) null;
    }

    private void 딱()
    {
      if (this.딟 != null)
      {
        this.딟.Dispose();
        this.딟 = (땓.땽) null;
      }
      if (this.딟 != null)
      {
        this.딟.Dispose();
        this.딟 = (땓.땢) null;
      }
      if (this.딟 != null)
      {
        this.딟.Dispose();
        this.딟 = (땓.땲) null;
      }
      if (this.딟 != null)
      {
        this.딟.Dispose();
        this.딟 = (땓.떏) null;
      }
      this.땠();
    }

    public void 때()
    {
      // ISSUE: reference to a compiler-generated method
      this.땃((땓.땦) null);
      this.딟 = (땓.땦) null;
      this.땩();
      this.땄(딢.딴.딟);
      this.떏();
    }

    private void 땩()
    {
      if (this.땜() != null)
      {
        this.땜().딟(0);
        this.땜().땄(0);
        // ISSUE: reference to a compiler-generated method
        this.딶((땓.땦) null);
      }
      this.떁();
      this.땟();
      this.떏();
    }

    private void 땠()
    {
      this.딟 = (GameTileComponent) null;
      if (this.딟 != null)
      {
        this.딟.Dispose();
        this.딟 = (땓.땤) null;
      }
      this.땂();
    }

    private void 딟([In] bool obj0, [In] bool obj1)
    {
      if (this.땈() != null && this.땈().땴().땺())
        this.때();
      if (this.땜() != null && this.땜().땴().땺())
        this.땩();
      for (int index = 0; index < this.딟.Count; ++index)
      {
        땓.땦 땦 = this.딟[index];
        if (!this.딸() || obj0)
          this.딟(땦);
        this.딧(index, false);
        if (!this.딟.땼().땼())
        {
          땦.땄(false);
          땦.땟();
        }
      }
    }

    private void 땴() => this.딟.땼().떔().딧(this.딟.땼());

    public void 딗()
    {
      this.딱();
      this.떁();
      this.땟();
      this.땠();
      foreach (땓.땦 땦 in this.딟)
        땦.Dispose();
      this.딟.Clear();
      this.딟.Dispose();
      this.땄.Dispose();
      this.딧.Dispose();
      this.딢.Dispose();
      this.땃.Dispose();
      this.딶.Dispose();
      this.땓.Dispose();
      this.땺.Dispose();
      this.땥.Dispose();
      this.딝.Dispose();
    }

    public void 딟([In] 땃.땧 obj0) => this.딟(obj0, false);

    public void 딟([In] 땃.땧 obj0, [In] bool obj1)
    {
      if (obj0 == null)
        return;
      EventTimelineManager.딟().AddEventTimeline(this.딟.땼().딟(obj0));
      if (!EventTimelineManager.딟().IsRunning())
        return;
      RandomAudioComponent.딟();
      this.딷();
    }

    public void 땳()
    {
      this.땷();
      this.땄(딨.땃);
      this.땻();
    }

    public void 땄([In] bool obj0)
    {
      if (this.떇() != 딨.땺)
        return;
      딶.땃 땃 = !obj0 ? (딶.땃) new 딶.땺() : (딶.땃) new 딶.땥();
      if (!this.딟.땼().떔().딟(땃, true))
        return;
      EventTimelineManager.딟().DestroyTempVisualEffects();
      if (this.딸())
      {
        EventTimelineManager.딟().RunToEnd(true);
        this.딥();
      }
      땓.땊 땊 = this.딟.땼().딟(obj0);
      this.딟(this.딟.땼().떂());
      if (this.땈() != null)
        this.딟(딢.딴.땄, true);
      if (땊 != null && 땊.땓())
        this.딟.딟.MoveToPos(((Component) this.딟.땓().get_Tiles()[땊.땃, 땊.딶]).transform.position, -1f, true);
      this.딷();
      this.떏();
    }

    public void 땻()
    {
      if (this.떇() != 딨.땃 && this.떇() != 딨.딶)
        return;
      EventTimelineManager.딟().RunToEnd(true);
      EventTimelineManager.딟().DestroyTempVisualEffects();
      this.땥();
      this.딟(true, false);
      this.딷();
      this.땄(딨.땃);
    }

    public void 딥()
    {
      if (this.떇() == 딨.땺 && !this.딸())
      {
        int num1 = this.딟.땼().땂();
        for (int index = 0; index != this.딟.Count; ++index)
        {
          땓.땦 땦 = this.딟[index];
          int num2 = this.딟.땼().땻()[땦.땔()].딟(땦.땴());
          if (땦.땴().땄 == num1 && 땦.땴().땓() && !땦.땴().땺() && num2 != 0 && this.딟.딷().땈() != 땦 && 땦.땴().딢 == num2 && !땦.땷())
          {
            this.딟.땢().CurrentPlayerUnitInfo.ShouldAnimatePointsIcon = true;
            this.딟.딷().딟(this.딟[index], true, false);
            땦.땥(true);
            return;
          }
        }
        딶.땼 땼 = new 딶.땼();
        if (!this.딟.땼().떔().딟((딶.땃) 땼, false))
          return;
        this.땄(딨.땥);
      }
      else
      {
        if (this.떇() == 딨.딝)
        {
          this.떓();
          this.딟(true, false);
          this.땼();
        }
        if (this.떇() == 딨.땺 && this.딸() && this.딟.땼().땩())
        {
          this.딛();
          this.딟(true, false);
          this.떏();
          if (this.땈() != null && (object) this.딟.땼().딟 == (object) typeof (땃.땸) && !(this.딟.땼().떔() is 딖))
          {
            땓.땊 땊 = this.땈().땴();
            this.딟.딟.MoveToPos(new 딶.땩(땊.땃, 땊.딶), -1f);
          }
        }
        if (this.떇() == 딨.딶)
        {
          this.떓();
          this.땄.땄().땄(true);
          if (this.딟.딟() && !this.딟.땼().딷())
          {
            this.땄(딨.딧);
          }
          else
          {
            this.땄(딨.땓);
            this.땄(딨.땺);
          }
        }
        if (this.떇() != 딨.땃)
          return;
        this.떓();
        this.땄.땄().땄(true);
        this.땄(딨.딶);
        this.딟(true, true);
      }
    }

    private void 떓()
    {
      this.딛();
      EventTimelineManager.딟().RunToEnd(true);
    }

    private void 딛()
    {
      EventTimelineManager.딟().RunToEnd(true);
      for (int index = 0; index != this.딟.딷().딟.Count; ++index)
        this.딟.딷().딟[index].떏();
      this.딟.딟.ClearCinematics();
    }

    public void 딣()
    {
      if (this.떇() != 딨.땄)
        return;
      this.땄(딨.땃);
    }

    public void 딟([In] 딢.딴 obj0) => this.딟(obj0, false);

    public void 딟([In] 딢.딴 obj0, [In] bool obj1)
    {
      if (땓.땎.딦(obj0))
      {
        if (딶.딢.딟(this.딟.땼(), this.딟.땼().떂(), this.땈().땔(), obj0) != -1)
        {
          딶.떏 떏 = new 딶.떏(this.땈().땔(), obj0, this.땈().땔());
          if (!this.딟.땼().떔().딟((딶.땃) 떏, true))
            return;
          this.딟.땢().SetSelectedAbility(obj0);
          this.딧(obj0);
          this.딟(떏.딟());
        }
      }
      else
      {
        딶.땲 땲 = new 딶.땲(obj0);
        if (!obj1 && !this.딟.땼().떔().딟((딶.땃) 땲, true))
          return;
        this.땄(obj0);
        this.딧(obj0);
      }
      this.딧(false);
    }

    private void 땄([In] 딢.딴 obj0)
    {
      this.딟.땢().HideAbilityInfoButton();
      this.딟.땢().SetSelectedAbility(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딢(obj0);
    }

    private void 딧([In] 딢.딴 obj0)
    {
      if (!this.딟.땢().DisplayAbilityTooltip(obj0, false))
        return;
      this.딟.땢().ShowAbilityInfoButton();
    }

    public void 딧([In] bool obj0)
    {
      if (this.땞() == 딢.딴.딟)
        return;
      if (obj0)
        this.땄(땓.땎.딟(this.땞(), this.딟.땼().땻()[this.땈().땔()]));
      this.땩();
      this.땠();
    }

    public void 딟([In] string obj0)
    {
      if (obj0 == "Continue")
        this.딣();
      else if (obj0 == "Replay")
        this.땻();
      else if (obj0 == "Next")
        this.딥();
      else if (obj0 == "Pause")
        this.땄(false);
      else if (obj0 == "Undo")
      {
        this.땄(false);
      }
      else
      {
        if (obj0 == "Resume")
          return;
        if (obj0 == "Ability")
          this.딧(true);
        else if (obj0 == "EndTurnCancel")
        {
          this.땔();
        }
        else
        {
          if (!(obj0 == "EndTurnAccept"))
            return;
          this.땁();
        }
      }
    }

    public void 땔()
    {
      if (this.떇() != 딨.땥)
        return;
      this.딟(딨.땺, true);
    }

    public void 땁()
    {
      if (this.떇() != 딨.땥)
        return;
      딶.땼 땼 = new 딶.땼();
      if (!this.딟.땼().떔().딟((딶.땃) 땼, true))
        return;
      this.딟(true, false, true);
    }

    private void 땷()
    {
      this.딱();
      this.떁();
      this.땟();
      this.땠();
      this.때();
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딸() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public bool 땘() => this.딶;

    [SpecialName]
    public int 땄() => this.딟.Count;

    public bool 떔() => this.딟.땼().떔().딟((딶.땃) this.딟, false);

    public bool 딳() => this.딟.땼().떔().딟((딶.땃) this.딟, false);

    public void 땝()
    {
      int num = -1;
      if (this.땈() != null)
        num = this.땈().땔();
      this.딶(num);
    }

    private void 딶([In] int obj0)
    {
      int count = this.딟.Count;
      int num1 = 1;
      int num2 = this.딟.땼().땂();
      for (; num1 < count; ++num1)
      {
        int index = obj0 + num1;
        if (index >= this.딟.Count)
          index -= this.딟.Count;
        땓.땦 땦 = this.딟[index];
        땓.딲 딲 = this.딟.땼().땻()[index];
        if (땦.땴().땄 == num2 && 땦.땴().땓() && !땦.땴().땺() && 딲.딟(땦.땴()) > 0)
        {
          this.딟(땦, true, false);
          break;
        }
      }
    }

    public void 땹()
    {
      this.딟 = false;
      this.땄 = false;
    }

    [CompilerGenerated]
    [SpecialName]
    public 딨 떇() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딨 땉() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 땓.땦 땈() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 딢.딴 땞() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땓.땦 땜() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public 딠 땪() => this.딟;

    public 땓.땽 땕() => this.딟;
  }
}
