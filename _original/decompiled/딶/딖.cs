// Decompiled with JetBrains decompiler
// Type: 딶.딖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딖 : 땛
  {
    private int 딟;
    private int 땄;
    private int 딧 = -1;
    private int 딢 = -1;
    private List<GameObject> 딟 = new List<GameObject>();
    private GameObject 딟;
    private GameObject 땄;
    private 떋[] 딟;
    private 땀[] 딟;
    private Transform 딟;
    private int 땃;
    private GameObject 딧;
    private new bool 딟;

    public override void 딟([In] 땖 obj0)
    {
      base.딟(obj0);
      this.땃 = -1;
      TutorialRulesComponent tutorialRulesComponent = (TutorialRulesComponent) null;
      foreach (GameRulesComponent gameComponent in obj0.땃().GameComponents)
      {
        tutorialRulesComponent = gameComponent as TutorialRulesComponent;
        if (Object.op_Inequality((Object) tutorialRulesComponent, (Object) null))
          break;
      }
      if (Object.op_Equality((Object) tutorialRulesComponent, (Object) null))
      {
        Debug.LogError((object) "No Tutorial Component Found");
      }
      else
      {
        this.땃 = tutorialRulesComponent.FixedSeed;
        this.딟 = new 땀[tutorialRulesComponent.Characters.Length];
        int count = obj0.땻().Count;
        int index1 = 0;
        while (index1 < this.딟.Length)
        {
          TutorialEditorCharacterData character = tutorialRulesComponent.Characters[index1];
          this.딟[index1] = new 땀();
          땓.떀 떀 = new 땓.떀(-1, character.CharacterId);
          떀.딟(character.WeaponId);
          떀.땄(character.OutfitId);
          떀.땃(character.Name);
          떀.땠();
          this.딟[index1].딟 = 떀;
          this.딟[index1].딟 = character.SpawnDirection;
          this.딟[index1].딧 = character.SpawnLocationX;
          this.딟[index1].딢 = character.SpawnLocationY;
          this.딟[index1].땄 = character.Team != 땂.딟 ? 1 : 0;
          this.딟[index1].딟 = obj0.땻().Count;
          obj0.딟(떀, character.UseAbilities);
          ++index1;
          ++count;
        }
        this.딟 = new 떋[tutorialRulesComponent.Turns.Length];
        for (int index2 = 0; index2 < this.딟.Length; ++index2)
        {
          TutorialEditorTurn turn = tutorialRulesComponent.Turns[index2];
          떋 떋 = new 떋();
          this.딟[index2] = 떋;
          떋.딟 = new 딩[turn.Stages.Length];
          for (int index3 = 0; index3 < 떋.딟.Length; ++index3)
          {
            TutorialEditorStage stage = turn.Stages[index3];
            딩 딩 = new 딩();
            떋.딟[index3] = 딩;
            딩.딟 = new 딶.땃[stage.Actions.Length];
            딩.딟 = stage.AllowUserControl;
            딩.딟 = stage.PreActionPauseTime;
            딩.땄 = stage.PostActionPauseTime;
            딩.딟 = stage.TutorialPopUp;
            for (int index4 = 0; index4 < 딩.딟.Length; ++index4)
            {
              TacticsUserActionEditorBase actionEditorBase = stage.Actions[index4].딟();
              actionEditorBase.GameObjectIndex = actionEditorBase.GameObjectIndex < 0 || actionEditorBase.GameObjectIndex >= this.딟.Length ? -1 : this.딟[actionEditorBase.GameObjectIndex].딟;
              actionEditorBase.OtherGameObjectIndex = actionEditorBase.OtherGameObjectIndex < 0 || actionEditorBase.OtherGameObjectIndex >= this.딟.Length ? -1 : this.딟[actionEditorBase.OtherGameObjectIndex].딟;
              딩.딟[index4] = 딶.땓.딟(actionEditorBase);
            }
          }
        }
      }
    }

    public override void 딟([In] 땯 obj0, [In] 딨 obj1) => obj0.딟(obj1);

    public override void 딟([In] 땖 obj0, [In] GameplayHUDHandler obj1)
    {
    }

    public override void 딟()
    {
    }

    public override void 딟([In] 땖 obj0, [In] 땙 obj1, [In] 땓.떒 obj2)
    {
    }

    public override bool 땭() => false;

    public override 떉 땄([In] 땖 obj0) => this.딟 >= this.딟.Length || this.딟 == this.딟.Length - 1 && this.땄 >= this.딟[this.딟].딟.Length ? new 떉(0, 떌.땄) : 떉.딟();

    public override void 딟([In] 땖 obj0, [In] 땙 obj1)
    {
      땯 땯 = 딡.땴().딷();
      do
      {
        딩 딩 = this.땲();
        if (딩 != null && !딩.딟)
        {
          this.땋();
          EventTimelineManager.딟().AddEvent((땏) new 땬(딩.딟));
          EventTimelineManager.딟().AddEvent((땏) new 떒(딩.딟));
          foreach (딶.땃 땃 in 딩.딟)
          {
            땃.땧 땧 = 땃.딟();
            if (땧 != null)
              땯.딟(땧);
          }
          EventTimelineManager.딟().AddEvent((땏) new 떒(딩.땄));
          ++this.땄;
        }
        else
          break;
      }
      while (this.땲() != null);
      if (!EventTimelineManager.딟().IsRunning())
      {
        if (this.딟)
        {
          ++this.딟;
          this.땄 = 0;
          this.딟 = false;
        }
        if (this.땲() == null)
        {
          ++this.딟;
          this.땄 = 0;
          땯?.땼();
        }
      }
      if (EventTimelineManager.딟().IsRunning() || this.딧 == this.딟 && this.딢 == this.땄)
        return;
      this.땋();
      this.땄(obj0, obj1);
      this.딧 = this.딟;
      this.딢 = this.땄;
    }

    public override void 땄() => this.땽();

    public override void 딧()
    {
    }

    public override bool 딢() => false;

    private void 땄([In] 땖 obj0, [In] 땙 obj1)
    {
      딩 딩 = this.땲();
      if (딩 == null || !딩.딟)
        return;
      if (Object.op_Equality((Object) this.딟, (Object) null))
      {
        for (int index = 0; index != obj1.땺().Count; ++index)
        {
          if (obj1.땺()[index].땄 == 0)
            this.딟 = 딡.땴().딷().딟(index).딣().transform;
        }
      }
      List<Transform> targets = new List<Transform>();
      int numTargetsInView = 0;
      foreach (딶.땃 땃 in 딩.딟)
      {
        떒 떒 = (떒) null;
        targets.Clear();
        targets.Add(this.딟);
        딢.땘 cameraZoom;
        bool canFitWithoutMoving;
        if (땃 is 땢 땢2)
        {
          this.딟(obj1, 땢2.딟, "Green");
          떒 = (떒) new 딜(obj0.땉().딟.CalculateFocusOnTargets(targets, true, out numTargetsInView, out cameraZoom, out canFitWithoutMoving), 0.5f);
        }
        if (땃 is 딷 딷2)
          this.딟(obj1, 딷2.딟, "Orange");
        if (땃 is 딦 딦2)
        {
          this.딟(딦2.땄, 딦2.딧, "Green");
          targets.Add(((Component) obj0.땉().땓().GetTile(딦2.땄, 딦2.딧)).transform);
          떒 = (떒) new 딜(obj0.땉().딟.CalculateFocusOnTargets(targets, true, out numTargetsInView, out cameraZoom, out canFitWithoutMoving), 0.5f);
        }
        if (땃 is 땤 땤2)
        {
          this.딟(땤2.땄, 땤2.딧, "Orange");
          targets.Insert(0, ((Component) obj0.땉().땓().GetTile(땤2.땄, 땤2.딧)).transform);
          떒 = (떒) new 딜(obj0.땉().딟.CalculateFocusOnTargets(targets, true, out numTargetsInView, out cameraZoom, out canFitWithoutMoving), 0.5f);
        }
        if (땃 is 딶.땽 땽2)
        {
          this.딟(땽2.땄, 땽2.딧, "Red");
          targets.Add(((Component) obj0.땉().땓().GetTile(땽2.땄, 땽2.딧)).transform);
          Vector3 vector3 = obj0.땉().딟.CalculateFocusOnTargets(targets, true, out numTargetsInView, out cameraZoom, out canFitWithoutMoving);
          if (numTargetsInView == 1)
            vector3 = ((Component) obj0.땉().땓().GetTile(땽2.땄, 땽2.딧)).transform.position;
          떒 = (떒) new 딜(vector3, 0.5f);
        }
        if (땃 is 떏 떏2)
          this.딟(obj1, 떏2.땄, "Green");
        if (떒 != null)
          EventTimelineManager.딟().AddEvent((땏) 떒);
      }
      this.딟(딩.딟);
    }

    public void 딟([In] GameObject obj0)
    {
      if (Object.op_Equality((Object) obj0, (Object) this.땄))
        return;
      this.땄 = obj0;
      this.땽();
      if (!Object.op_Inequality((Object) obj0, (Object) null))
        return;
      GameObject gameObject = GameObject.Find("UICamera");
      this.딟 = Object.Instantiate((Object) obj0) as GameObject;
      this.딟.transform.parent = gameObject.transform;
      this.딟.transform.localPosition = new Vector3(0.0f, 0.0f, 1f);
      this.딟.transform.position = new Vector3((float) this.딟.transform.position.x, (float) (this.딟.transform.position.y - 0.5), (float) this.딟.transform.position.z);
    }

    private void 땽()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      Object.Destroy((Object) this.딟.gameObject);
    }

    private void 딟([In] 땙 obj0, [In] int obj1, [In] string obj2)
    {
      땓.땊 땊 = obj0.땺()[obj1];
      if (!땊.땓())
        return;
      this.딟(땊.땃, 땊.딶, obj2);
    }

    private void 딟([In] int obj0, [In] int obj1, [In] string obj2) => this.딟(base.딟.땹().GetTileCentre(obj0, obj1), obj2);

    private void 딟([In] Vector3 obj0, [In] string obj1)
    {
      string key = obj1;
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (딖.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          딖.딟 = new Dictionary<string, int>(3)
          {
            {
              "Green",
              0
            },
            {
              "Orange",
              1
            },
            {
              "Red",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (딖.딟.TryGetValue(key, out num))
        {
          switch (num)
          {
            case 0:
              this.딧 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.TutorialArrowGreen) as GameObject;
              break;
            case 1:
              this.딧 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.TutorialArrowOrange) as GameObject;
              break;
            case 2:
              this.딧 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.TutorialArrowRed) as GameObject;
              break;
          }
        }
      }
      this.딧.transform.position = obj0;
      this.딧.transform.rotation = Quaternion.identity;
      this.딟.Add(this.딧);
    }

    private void 땋()
    {
      for (int index = 0; index < this.딟.Count; ++index)
        Object.Destroy((Object) this.딟[index]);
      this.딟.Clear();
    }

    public override void 딟([In] 땖 obj0, [In] 땓.떒 obj1)
    {
    }

    public override void 딟([In] int obj0, [In] 땓.땊 obj1)
    {
      for (int index = 0; index < this.딟.Length; ++index)
      {
        if (this.딟[index].딟 == obj0)
        {
          obj1.땄 = this.딟[index].땄;
          obj1.딧 = 200;
          obj1.딢 = 8;
        }
      }
    }

    public override bool 땃() => false;

    public override bool 딶() => true;

    public override void 딟([In] List<딠.딿> obj0)
    {
      foreach (딠.딿 딿 in obj0)
      {
        for (int index = 0; index < this.딟.Length; ++index)
        {
          if (this.딟[index].딟 == 딿.딟)
          {
            딿.딟 = base.딟.땹().GetTile(this.딟[index].딧, this.딟[index].딢);
            딿.딟 = this.딟[index].딟;
            break;
          }
        }
      }
    }

    private 딩 땲()
    {
      if (this.딟 >= this.딟.Length)
        return (딩) null;
      return this.땄 >= this.딟[this.딟].딟.Length ? (딩) null : this.딟[this.딟].딟[this.땄];
    }

    public override bool 딟([In] 딶.땃 obj0, [In] bool obj1)
    {
      bool flag = false;
      딩 딩 = this.땲();
      if (딩 == null || !딩.딟)
        return false;
      딶.땃 땃1 = (딶.땃) null;
      foreach (딶.땃 땃2 in 딩.딟)
      {
        if (땃2.딟(obj0))
        {
          땃1 = 땃2;
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        if (obj1)
        {
          Debug.Log((object) ("Active Team = " + (object) base.딟.딝()));
          Debug.Log((object) ("Tried Action " + obj0.ToString()));
          foreach (object obj in 딩.딟)
            Debug.Log((object) ("Current allowed actions " + obj.ToString()));
        }
        return false;
      }
      if (obj1)
      {
        ++this.땄;
        if (obj0 is 땼)
          this.딟 = true;
      }
      if (obj1 && 땃1 != null)
        땃1.딟((땛) this);
      return true;
    }

    public override void 딟([In] List<딟.땩> obj0)
    {
    }

    public override void 땓()
    {
    }

    public override LocalisationEntry 땺() => (LocalisationEntry) null;

    public override LocalisationEntry 땥() => (LocalisationEntry) null;

    public override void 딟([In] 땖 obj0, out float _param2, out float _param3)
    {
      _param3 = 0.0f;
      _param2 = 0.0f;
    }

    public override void 딝() => this.땽();

    public override void 딟([In] string obj0)
    {
      if (!GlobalAppData.땟() || string.IsNullOrEmpty(obj0))
        return;
      딟.딦.딟(obj0);
    }

    [SpecialName]
    public override int 떎() => this.땃;
  }
}
