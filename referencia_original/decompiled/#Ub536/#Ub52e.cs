// Decompiled with JetBrains decompiler
// Type: 딶.딮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딮 : 땛
  {
    private const string 딟 = "com.warchestgames.radtactics.objectives.rocket01.media";
    private const float 딟 = 2f;
    private Material[] 딟;
    private Color[] 딟;
    private Color[] 땄;
    private GameObject[] 딟;
    private GameObject 딟;
    private 딸 딟;
    private Vector4 딟;
    private List<Bounds> 딟;
    private Bounds 딟;
    private bool[] 딟 = new bool[2];
    private new bool 딟;
    private bool 땄;
    private AudioShader2 딟;
    private AudioShader2 땄;

    public override void 딟([In] 땖 obj0)
    {
      base.딟(obj0);
      this.땃(obj0);
      this.딟 = new 딸(obj0.땻().Count);
      obj0.땻().Add((땓.딲) this.딟);
      if (obj0.떓() == 딹.땄 && obj0.딟.땃 > 0)
        obj0.땻().Add((땓.딲) new 땹(obj0, obj0.땻().Count));
      this.딟 = true;
    }

    public override void 딟([In] 땖 obj0, [In] GameplayHUDHandler obj1)
    {
    }

    public override void 딟() => this.땄 = true;

    public bool 딟([In] 땖 obj0, [In] 땙 obj1, [In] int obj2)
    {
      if (obj2 < 0 || obj2 >= obj0.땻().Count || !(obj0.땻()[obj2] is 땓.떀))
        return false;
      땓.땊 땊 = obj1.땺()[obj2];
      if (땊.땺() || !땊.땓() || 땊.딢(딢.떍.딢) > 0)
        return false;
      GameTileComponent gameTileComponent = obj0.땹().get_Tiles()[땊.땃, 땊.딶];
      return this.딦().Contains(gameTileComponent);
    }

    public bool 땄([In] 땖 obj0, [In] 땙 obj1, [In] int obj2)
    {
      if (!(obj0.땻()[obj2] is 땓.떀))
        return false;
      땓.땊 땊 = obj1.땺()[obj2];
      if (땊.땺() || !땊.땓() || 땊.딢(딢.떍.딢) > 0 || 딡.땴().딷() == null)
        return false;
      땓.땦 땦 = 딡.땴().딷().딟(obj2);
      if (!((Bounds) ref this.딟).Contains(땦.딗()))
        return false;
      foreach (Bounds bounds in this.딟)
      {
        if (((Bounds) ref bounds).Contains(땦.딗()))
          return true;
      }
      return false;
    }

    public bool[] 땄([In] 땖 obj0, [In] 땙 obj1)
    {
      bool[] flagArray = new bool[2];
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        땓.땊 땊 = obj1.땺()[index];
        if (땊.땄 >= 0 && 땊.땄 <= 1 && !flagArray[땊.땄] && this.딟(obj0, obj1, index))
          flagArray[땊.땄] = true;
      }
      return flagArray;
    }

    public bool[] 딧([In] 땖 obj0, [In] 땙 obj1)
    {
      bool[] flagArray = new bool[2];
      for (int index = 0; index < obj1.땺().Count; ++index)
      {
        땓.땊 땊 = obj1.땺()[index];
        if (땊.땄 >= 0 && 땊.땄 <= 1 && !flagArray[땊.땄] && this.땄(obj0, obj1, index))
          flagArray[땊.땄] = true;
      }
      return flagArray;
    }

    public override void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2)
    {
      bool[] flagArray = this.땄(obj0, obj1);
      if (flagArray[0] == flagArray[1])
        return;
      if (flagArray[obj1.땃()])
      {
        딢.떍 떍 = !flagArray[0] ? 딢.떍.땽 : 딢.떍.땤;
        obj1.땺()[this.딟.딟()].땄(떍);
        this.딟(obj0, obj1, obj2, flagArray);
      }
      this.딟(obj0, obj1, flagArray);
    }

    private void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2, [In] bool[] obj3)
    {
      if (!obj3[obj1.땃()])
        return;
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (this.딟(obj0, obj1, index))
        {
          if (obj1.땺()[index].땄 == obj1.땃())
          {
            땙 땙 = obj1;
            땙.땄(땙.딢() + obj0.땞().RatingModifiersData.PerCapture);
            obj2.딟(obj1, index, 땓.떊.땺);
          }
          else
          {
            땙 땙 = obj1;
            땙.땄(땙.딢() + obj0.땞().RatingModifiersData.PerCaptureInterrupt);
            obj2.딟(obj1, index, 땓.떊.땺);
          }
        }
      }
    }

    public override 떉 땄([In] 땖 obj0)
    {
      if (obj0.딥().Count > 2)
      {
        int num = 떍.딢(obj0);
        if (num != -1)
          return new 떉(num, 떌.땄);
      }
      int num1 = this.딢(obj0);
      return num1 != -1 ? new 떉(num1, 떌.딧) : 떉.딟();
    }

    public override void 땄()
    {
    }

    public override void 딧() => this.딟 = true;

    public override bool 딢() => true;

    public static int 딟([In] 땖 obj0, [In] int obj1, [In] int obj2, [In] 땙 obj3) => obj3 == null || obj2 == -1 ? 0 : Mathf.Clamp(obj3.땺()[obj2].딢(obj1 != 0 ? 딢.떍.땽 : 딢.떍.땤), 0, int.MaxValue);

    public static int 딟([In] 땖 obj0, [In] int obj1, [In] int obj2) => 딮.딟(obj0, obj1, obj2, obj0.떂());

    public int 딟([In] 땖 obj0, [In] int obj1) => 딮.딟(obj0, obj1, this.딟.딟());

    public int 딢([In] 땖 obj0)
    {
      int num1 = this.딟(obj0, 0);
      int num2 = this.딟(obj0, 1);
      if (num1 >= 5)
        return 0;
      return num2 >= 5 ? 1 : -1;
    }

    private void 땃([In] 땖 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      this.딟 = new List<Bounds>();
      this.딟 = new Bounds();
      ScenarioComponent scenarioComponent = obj0.땃();
      if (Object.op_Equality((Object) scenarioComponent, (Object) null))
        return;
      ControlPointManagerComponent component1 = ((Component) scenarioComponent).GetComponent<ControlPointManagerComponent>();
      if (Object.op_Inequality((Object) component1, (Object) null) && Object.op_Equality((Object) this.땭(), (Object) null))
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(component1);
      }
      foreach (GameRulesComponent gameComponent in scenarioComponent.GameComponents)
      {
        ControlPointComponent controlPointComponent = gameComponent as ControlPointComponent;
        if (!Object.op_Equality((Object) controlPointComponent, (Object) null))
        {
          GameTileComponent component2 = ((Component) controlPointComponent).GetComponent<GameTileComponent>();
          this.딦().Add(component2);
          Bounds tileBounds = obj0.땹().GetTileBounds(component2.TileIndexX, component2.TileIndexY);
          this.딟.Add(tileBounds);
          ((Bounds) ref this.딟).Encapsulate(tileBounds);
        }
      }
      if (!Object.op_Equality((Object) this.땭(), (Object) null))
        return;
      Debug.LogError((object) "No ControlPointManagerComponent in the scenario!");
    }

    public override void 딟([In] 땯 obj0, [In] 딨 obj1) => obj0.딟(obj1);

    public override bool 딧([In] 땖 obj0)
    {
      if (base.딧(obj0) && base.땃(obj0) == obj0.딝())
      {
        땯 땯 = obj0.땉().딷();
        if (땯.떇() != 딨.땃 && 땯.떇() != 딨.딶 && 땯.떇() != 딨.땓)
        {
          this.딟(땯, 딨.떎);
          base.딟 = true;
          return true;
        }
      }
      return false;
    }

    public override void 딟([In] 땖 obj0, [In] 땙 obj1)
    {
      bool[] ActiveZones = this.딧(obj0, obj1);
      if (this.딟 == null && Object.op_Inequality((Object) this.땭().Team0OutlinePrefab, (Object) null) && Object.op_Inequality((Object) this.땭().Team1OutlinePrefab, (Object) null))
      {
        this.딟 = new GameObject[2];
        this.딟 = new Color[2];
        this.땄 = new Color[2];
        this.딟 = new Material[2];
        this.딟[0] = Object.Instantiate((Object) this.땭().Team0OutlinePrefab) as GameObject;
        this.딟[0] = GlobalAppData.딟.GameAssets.ControlPointDefault;
        this.땄[0] = GlobalAppData.딟.GameAssets.ControlPointDefaultAlt;
        this.딟[0] = new Material(GlobalAppData.딟.GameAssets.ControlPointBaseMaterial);
        foreach (Renderer componentsInChild in this.딟[0].GetComponentsInChildren<Renderer>())
          componentsInChild.sharedMaterial = this.딟[0];
        this.딟[1] = Object.Instantiate((Object) this.땭().Team1OutlinePrefab) as GameObject;
        this.딟[1] = GlobalAppData.딟.GameAssets.Grey;
        this.땄[1] = GlobalAppData.딟.GameAssets.ControlPointDefaultAlt;
        this.딟[1] = new Material(GlobalAppData.딟.GameAssets.ControlPointBaseMaterial);
        foreach (Renderer componentsInChild in this.딟[1].GetComponentsInChildren<Renderer>())
          componentsInChild.sharedMaterial = this.딟[1];
      }
      if (Object.op_Equality((Object) this.떂(), (Object) null))
      {
        if (Object.op_Inequality((Object) this.딟, (Object) null) && Object.op_Inequality((Object) this.땭().ObjectiveSpawnPoint, (Object) null))
        {
          GameObject gameObject = Object.Instantiate((Object) this.딟) as GameObject;
          gameObject.SetActive(true);
          // ISSUE: reference to a compiler-generated method
          this.딟(gameObject.GetComponent<ControlPointObjectiveComponent>());
          this.떂().UpdateActiveZones(ActiveZones, obj0.딝());
          this.떂().Init(this.땭().ObjectiveSpawnPoint);
          if (this.땄)
            this.떂().SetObjectiveModelVisible(false);
          this.딢(obj0, obj1);
          GlobalAppData.딟(gameObject);
        }
      }
      else
      {
        this.떂().UpdateActiveZones(ActiveZones, obj0.딝());
        this.딢(obj0, obj1);
      }
      if (this.딟 == null)
        return;
      if (ActiveZones[0] || ActiveZones[1])
      {
        ref Vector4 local1 = ref this.딟;
        local1.x = (__Null) (local1.x + 0.5 * (double) Time.deltaTime);
        ref Vector4 local2 = ref this.딟;
        local2.x = (__Null) (local2.x - (double) Mathf.Floor((float) this.딟.x));
      }
      for (int index = 0; index < this.딟.Length; ++index)
      {
        Color color1 = GlobalAppData.딟.GameAssets.ControlPointDefault;
        Color color2 = GlobalAppData.딟.GameAssets.ControlPointDefaultAlt;
        if ((index & 1) == 0)
        {
          if (ActiveZones[0])
          {
            color1 = GlobalAppData.딟.GameAssets.Blue;
            color2 = GlobalAppData.딟.GameAssets.DarkBlue;
          }
          else if (ActiveZones[1])
          {
            color1 = GlobalAppData.딟.GameAssets.Red;
            color2 = GlobalAppData.딟.GameAssets.DarkRed;
          }
        }
        else if (ActiveZones[1])
        {
          color1 = GlobalAppData.딟.GameAssets.Red;
          color2 = GlobalAppData.딟.GameAssets.DarkRed;
        }
        else if (ActiveZones[0])
        {
          color1 = GlobalAppData.딟.GameAssets.Blue;
          color2 = GlobalAppData.딟.GameAssets.DarkBlue;
        }
        this.딟[index] = Color.Lerp(this.딟[index], color1, 2f * Time.deltaTime);
        this.땄[index] = Color.Lerp(this.땄[index], color2, 2f * Time.deltaTime);
        this.딟[index].SetColor("_Color", this.딟[index]);
        this.딟[index].SetColor("_Color2", this.땄[index]);
        this.딟[index].SetVector("_UVOffset", this.딟);
      }
    }

    public override void 딟([In] 땖 obj0, [In] 땓.떒 obj1)
    {
      for (int index = 0; index < obj0.땻().Count; ++index)
      {
        if (this.딟(obj0, obj0.떂(), index))
          obj1.딟(obj0.떂(), index, 땓.떊.떎);
      }
    }

    public override void 딟([In] int obj0, [In] 땓.땊 obj1)
    {
    }

    public override bool 땃() => true;

    public override bool 딶() => false;

    public override void 딟([In] List<딠.딿> obj0)
    {
    }

    public override bool 딟([In] 딶.땃 obj0, [In] bool obj1) => true;

    public override void 딟([In] List<딟.땩> obj0) => obj0.Add((딟.땩) GlobalAppData.땼().땁("com.warchestgames.radtactics.objectives.rocket01.media"));

    public override void 땓() => this.딟 = GlobalAppData.땼().땋("com.warchestgames.radtactics.objectives.rocket01.media");

    private void 딟([In] 땖 obj0, [In] 땙 obj1, [In] bool[] obj2)
    {
      if (obj0.땉() == null)
        return;
      땯 땯 = obj0.땉().딷();
      if (땯 == null || this.딦().Count == 0 || Object.op_Equality((Object) GlobalAppData.딟.GameAssets.MusicShaders.MyTeamControlPointCapture, (Object) null) || Object.op_Equality((Object) GlobalAppData.딟.GameAssets.MusicShaders.OtherTeamControlPointCapture, (Object) null))
        return;
      if (obj2[obj0.딝()])
      {
        if (땯.떇() != 딨.딶 || AudioShader2.딟(this.딟))
          return;
        double num = (double) GlobalAppData.딟.GameAssets.MusicShaders.MyTeamControlPointCapture.PlayOneShot(((Component) this.딦()[0]).gameObject, 0.0f, out this.딟);
      }
      else
      {
        if (땯.떇() != 딨.땃 || AudioShader2.딟(this.땄))
          return;
        double num = (double) GlobalAppData.딟.GameAssets.MusicShaders.OtherTeamControlPointCapture.PlayOneShot(((Component) this.딦()[0]).gameObject, 0.0f, out this.땄);
      }
    }

    public override LocalisationEntry 땺() => GlobalAppData.딟.GameAssets.ControlPointGameModeText;

    public override LocalisationEntry 땥() => GlobalAppData.딟.GameAssets.ControlPointGameModeSubText;

    public override void 딟([In] 땖 obj0, out float _param2, out float _param3)
    {
      딮.딯 딯 = !obj0.땞().RatingModifiersData.CoinPotRoundingMethodCeil ? new 딮.딯(Mathf.Round) : new 딮.딯(Mathf.Ceil);
      int num1 = this.딢(obj0);
      if (num1 != -1)
      {
        int num2 = this.딟(obj0, num1);
        int num3 = this.딟(obj0, (num1 + 1) % 2);
        float num4 = 1f + 딯((float) num2 * 0.5f);
        float num5 = 1f + 딯((float) num3 * 0.5f);
        float num6 = num4 + num5;
        _param2 = num4 / num6;
        _param3 = num5 / num6;
      }
      else
      {
        if (obj0.딥().Count > 2)
        {
          int num7 = 떍.딢(obj0);
          if (num7 != -1)
          {
            int num8 = obj0.딝(num7);
            float num9 = 1f + 딯((float) num8 * 0.5f);
            float num10 = 1f;
            float num11 = num9 + num10;
            _param2 = num9 / num11;
            _param3 = num10 / num11;
            return;
          }
        }
        if (obj0.떓() == 딹.딧)
        {
          for (int index = 0; index < 2; ++index)
          {
            if (obj0.딟.딟[index] == 딟.땾.딧 && obj0.딟.딟[(index + 1) % 2] == 딟.땾.딶)
            {
              _param2 = 0.8f;
              _param3 = 0.0f;
              return;
            }
          }
        }
        _param2 = 0.0f;
        _param3 = 0.0f;
      }
    }

    public override void 딝()
    {
    }

    public override void 딟([In] string obj0)
    {
    }

    private void 딢([In] 땖 obj0, [In] 땙 obj1)
    {
      땯 땯 = obj0.땉().딷();
      if (땯 == null)
        return;
      GameplayHUDHandler gameplayHudHandler = obj0.땉().땢();
      bool[] ActiveZones = (bool[]) null;
      if (땯.떇() == 딨.땃 || 땯.떇() == 딨.딶)
      {
        ActiveZones = this.딧(obj0, obj1);
        if (this.딟 == null)
          this.딟 = ActiveZones;
        gameplayHudHandler.InitGameStatus(ActiveZones, this.딟, this.딟);
        gameplayHudHandler.UpdateGameStatus();
        this.딟 = false;
      }
      else if (Object.op_Inequality((Object) gameplayHudHandler.TurnsTitleScreen, (Object) null) && gameplayHudHandler.TurnsTitleScreen.get_Active())
      {
        ActiveZones = this.땄(obj0, obj1);
        if (this.딟 == null)
          this.딟 = ActiveZones;
        gameplayHudHandler.InitGameStatus(ActiveZones, this.딟, this.딟);
        gameplayHudHandler.UpdateGameStatus();
        this.딟 = false;
      }
      else if (땯.떇() == 딨.땺)
      {
        ActiveZones = this.딧(obj0, obj1);
        if (this.딟 == null)
          this.딟 = ActiveZones;
        gameplayHudHandler.UpdateCapturePointStatus(obj0, ActiveZones, this.딟, this.딟);
        this.딟 = false;
      }
      this.딟 = ActiveZones;
    }

    [SpecialName]
    public override int 떎() => -1;

    [CompilerGenerated]
    [SpecialName]
    public ControlPointObjectiveComponent 떂() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public ControlPointManagerComponent 땭() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딦() => this.딟;

    private delegate float 딯([In] float obj0);
  }
}
