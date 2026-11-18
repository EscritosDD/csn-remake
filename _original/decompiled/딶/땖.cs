// Decompiled with JetBrains decompiler
// Type: 딶.땖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땖
  {
    public const int 딟 = 2;
    public const int 땄 = 6;
    public const int 딧 = 10;
    public const bool 딟 = true;
    public Type 딟;
    public 땶 딟 = new 땶();
    private bool 땄;

    public 땖([In] string obj0, [In] 딹 obj1, [In] 땶 obj2, [In] 땿 obj3, [In] 딢.땽 obj4)
    {
      // ISSUE: reference to a compiler-generated method
      this.딢(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땙>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땓.딲>());
      // ISSUE: reference to a compiler-generated method
      this.딟(obj4.딟);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj4.딟);
      this.딟 = obj2;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj4.딟);
      // ISSUE: reference to a compiler-generated method
      this.딟(GlobalAppData.땼().딟(obj2.딟));
      // ISSUE: reference to a compiler-generated method
      this.딟(new 딶.딛(this));
      // ISSUE: reference to a compiler-generated method
      this.딟(new 떄[2]);
      this.땜()[0] = new 떄();
      this.땜()[1] = new 떄();
      // ISSUE: reference to a compiler-generated method
      this.딦(this.땻().Count);
      this.딟();
      // ISSUE: reference to a compiler-generated method
      this.땤(this.땻().Count - this.딣());
      // ISSUE: reference to a compiler-generated method
      this.땽(this.땻().Count);
      if (obj3.땄()[0] != null)
        this.딟(0, obj3.땄()[0].딟(), obj3.땄()[0].땄());
      // ISSUE: reference to a compiler-generated method
      this.땋(this.땻().Count - this.땁());
      // ISSUE: reference to a compiler-generated method
      this.땲(this.땻().Count);
      if (obj3.땄()[1] != null)
        this.딟(1, obj3.땄()[1].딟(), obj3.땄()[1].땄());
      // ISSUE: reference to a compiler-generated method
      this.떏(this.땻().Count - this.딸());
      if (obj3.딧().Count == 0)
      {
        땙 땙 = this.떔().떎() == -1 ? new 땙(this) : new 땙(this, this.떔().떎());
        this.딥().Add(땙);
        땙.딟(this, (땃.땧) new 땃.땮(), (땓.떒) this.땈())?.땄(false);
      }
      else
      {
        for (int index = 0; index < obj3.딧().Count - 1; ++index)
          this.딥().Add(new 땙(this, obj3.딧()[index].딟(), obj3.딧()[index].딢(), index));
        int count = this.딥().Count;
        땙 땙 = count <= 0 ? new 땙(this, 딧.땾.딟<TacticsGameStateTurnData>(obj3.딧()[0].딟()).StartSeed) : new 땙(this, this.딥()[count - 1]);
        this.딥().Add(땙);
        땙.딟(this, obj3.딧()[count].딟(), obj3.딧()[count].딢(), count);
      }
      this.땈().딟().딟();
      Debug.Log((object) ("Lootdrop turn: " + (object) obj2.땃));
    }

    public void 딟([In] 땓.떀 obj0) => this.딟(obj0, true);

    public void 딟([In] 땓.떀 obj0, [In] bool obj1)
    {
      int count = this.땻().Count;
      obj0.딟(count);
      this.땻().Add((땓.딲) obj0);
      obj0.딟(this);
      if (!obj1)
        return;
      obj0.딟(this, this.땻(), count);
    }

    public bool 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      땓.땊 땊1 = obj0.땺()[obj1];
      땓.땊 땊2 = obj0.땺()[obj2];
      return this.딟(obj0, obj1, 땊1.땃, 땊1.딶, obj2, 땊2.땃, 땊2.딶, obj3, obj4);
    }

    public bool 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] bool obj5, [In] bool obj6)
    {
      땓.땊 땊 = obj0.땺()[obj1];
      return this.딟(obj0, obj1, 땊.땃, 땊.딶, obj2, obj3, obj4, obj5, obj6);
    }

    public bool 딟(
      [In] 땙 obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] bool obj7,
      [In] bool obj8)
    {
      땓.땊 땊1 = obj0.땺()[obj1];
      if (!this.땋() && !땊1.딶())
        return false;
      땓.딲 딲1 = this.땻()[obj1];
      땓.땊 땊2 = obj0.땺()[obj4];
      땓.딲 딲2 = this.땻()[obj4];
      return 땊2.땓() && (!땊2.땺() || obj8) && (땊2.땄 == 땊1.땄 || 딲2.딟(딲1, 땊1, 땊2) && (!obj7 || this.땹().TestLineOfSight(this, obj0, obj2, obj3, obj5, obj6, 0)));
    }

    public bool 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] bool obj5)
    {
      땓.땊 땊 = obj0.땺()[obj1];
      if (!땊.딶() || !obj5 && 땊.땺())
        return false;
      if (땊.땄 == obj4)
        return true;
      for (int index = 0; index < obj0.땺().Count; ++index)
      {
        if (obj0.땺()[index].땄 == obj4 && this.딟(obj0, index, obj1, obj2, obj3, false, obj5))
          return true;
      }
      return this.땄;
    }

    private void 딟([In] GameObject obj0)
    {
    }

    private void 딟()
    {
      this.딢();
      if (this.떔() != null)
        this.떔().딟(this);
      this.땓();
    }

    public void 딟([In] 딡 obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      ((Component) this.땹()).gameObject.SetActive(true);
      obj0.떁().딟();
      obj0.떁().땄();
      if (this.딷() || this.떔() is 딖)
        obj0.딟.Init();
      this.딧();
      this.떔().딟(this, obj0.땢());
    }

    public void 땄() => this.땄((딡) null);

    private void 딧()
    {
      List<SpawnPointComponent> gameComponents = this.땃().GetGameComponents<SpawnPointComponent>();
      if (gameComponents.Count <= 0)
        return;
      GameTileComponent component = ((Component) gameComponents[0]).GetComponent<GameTileComponent>();
      this.땹().SetUpNonAttackableTiles(component, this, this.떂());
    }

    private static List<땓.떀> 딟([In] string obj0)
    {
      List<땓.떀> 떀List = new List<땓.떀>();
      if (obj0 != null)
      {
        foreach (UnitCharacterData unitCharacterData in 딧.땾.딟<UnitCharacterData>(딧.땾.딟<TacticsTurnStateUnits>(obj0).Units))
        {
          땓.떀 떀 = new 땓.떀(-1, unitCharacterData);
          떀.땠();
          if (Object.op_Equality((Object) 떀.땁(), (Object) null))
            throw new 딫("Failed to load character!");
          떀List.Add(떀);
        }
      }
      return 떀List;
    }

    public void 딟([In] int obj0, [In] string obj1, [In] Dictionary<string, int> obj2)
    {
      foreach (땓.떀 떀 in 땖.딟(obj1))
        this.딟(떀);
      this.땜()[obj0].딟 = obj2;
    }

    public static List<딟.땩> 딟([In] 땄.땞 obj0)
    {
      땓.딿 딟 = obj0.딟 as 땓.딿;
      string str = GlobalAppData.땼().땄(딟.땄());
      if (string.IsNullOrEmpty(str))
      {
        Debug.LogWarning((object) ("Couldn't get LevelId for level hash " + (object) 딟.땄()));
        return (List<딟.땩>) null;
      }
      List<딟.땩> 땩List1 = GlobalAppData.땼().딟(str, 딢.딛.딣.땄 | 딢.딛.딣.딢);
      if (땩List1 == null)
      {
        Debug.LogWarning((object) ("Couldn't get items for level " + str));
        return (List<딟.땩>) null;
      }
      List<딟.땩> 땩List2 = new List<딟.땩>();
      땩List2.AddRange((IEnumerable<딟.땩>) 땩List1);
      try
      {
        땿 땿 = new 땿(obj0);
        for (int index = 0; index < 2; ++index)
        {
          if (땿.땄()[index] != null)
          {
            foreach (땓.떀 떀 in 땖.딟(땿.땄()[index].딟()))
              떀.딟(땩List2, 땓.땾.딢);
          }
        }
      }
      catch (딫 ex)
      {
        Debug.LogWarning((object) "Invalid Game State, cannot build required asset list");
        return (List<딟.땩>) null;
      }
      return 땩List2;
    }

    public static bool 땄([In] 땄.땞 obj0)
    {
      List<딟.땩> 땩List = 땖.딟(obj0);
      return 땩List != null && GlobalAppData.땼().딟((IEnumerable<딟.땩>) 땩List);
    }

    private void 딢()
    {
      ScenarioComponent scenarioComponent = this.땃();
      if (Object.op_Equality((Object) scenarioComponent, (Object) null))
        return;
      switch (scenarioComponent.Rules)
      {
        case 땨.땄:
          throw new NotImplementedException();
        case 땨.딧:
          throw new NotImplementedException();
        case 땨.딢:
          // ISSUE: reference to a compiler-generated method
          this.딟((땛) new 딮());
          break;
        case 땨.땃:
          // ISSUE: reference to a compiler-generated method
          this.딟((땛) new 딖());
          break;
        case 땨.딶:
          // ISSUE: reference to a compiler-generated method
          this.딟((땛) new 딴());
          break;
        default:
          // ISSUE: reference to a compiler-generated method
          this.딟((땛) new 떍());
          break;
      }
    }

    public ScenarioComponent 땃()
    {
      if (Object.op_Equality((Object) this.땝(), (Object) null))
        return (ScenarioComponent) null;
      if (this.딟.땄 >= 0 && this.딟.땄 < this.땝().Scenarios.Length)
        return this.땝().Scenarios[this.딟.땄];
      Debug.LogError((object) ("Scenario Index " + (object) this.딟.땄 + " Is Out Of Range (" + (object) this.땝().Scenarios.Length + ")"));
      return (ScenarioComponent) null;
    }

    public void 딶()
    {
      this.딥().Clear();
      땙 땙 = this.떔().떎() == -1 ? new 땙(this) : new 땙(this, this.떔().떎());
      this.딥().Add(땙);
      땙.딟(this, (땃.땧) new 땃.땮(), (땓.떒) this.땈())?.땄(false);
      this.떔().딦();
    }

    public static 땶 땄([In] string obj0) => new 땶(딧.땾.딟<TacticsSessionStateData>(딧.땾.딟<TacticsGameStateData>(딢.떇.딟(obj0)).Session));

    public static 땿 딧([In] string obj0) => new 땿(딧.땾.딟<string>(딧.땾.딟<TacticsGameStateData>(딢.떇.딟(obj0)).Turns));

    private void 땓()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<GameTileComponent>());
      ScenarioComponent scenarioComponent = this.땃();
      if (Object.op_Equality((Object) scenarioComponent, (Object) null))
        return;
      foreach (GameRulesComponent gameComponent in scenarioComponent.GameComponents)
      {
        SpawnPointComponent spawnPointComponent = gameComponent as SpawnPointComponent;
        if (!Object.op_Equality((Object) spawnPointComponent, (Object) null))
        {
          GameTileComponent component = ((Component) spawnPointComponent).GetComponent<GameTileComponent>();
          this.딳().Add(component);
        }
      }
    }

    public void 땺()
    {
      if (땃.딗.딟 || !this.떔().땃() || this.떓() == 딹.딧)
        return;
      string str = 딧.땾.땄((object) this.땥());
      딢.떇.딟(this.딛(), str);
    }

    public static string 딟([In] IEnumerable<땓.떀> obj0_1) => 딧.땾.땄((object) new TacticsTurnStateUnits()
    {
      Units = obj0_1.Select<땓.떀, UnitCharacterData>((Func<땓.떀, UnitCharacterData>) (obj0_2 => obj0_2.땻())).ToArray<UnitCharacterData>()
    });

    public string 딟([In] int obj0_1) => 땖.딟((IEnumerable<땓.떀>) this.딧(obj0_1).Select<int, 땓.떀>((Func<int, 땓.떀>) (obj0_2 => this.땻()[obj0_2] as 땓.떀)).ToArray<땓.떀>());

    public TacticsGameStateData 땥()
    {
      TacticsGameStateData tacticsGameStateData = new TacticsGameStateData();
      tacticsGameStateData.Session = this.딟.딟();
      땿 땿 = new 땿();
      땿.땄()[0] = new 딙(this.딟(0));
      땿.땄()[1] = new 딙(this.딟(1));
      for (int index = 0; index < this.딥().Count; ++index)
      {
        땙 땙 = this.딥()[index];
        if (땙.떎() != null)
        {
          땿.딧().Add(new 딙(땙.떎()));
        }
        else
        {
          string str = 딧.땾.땄((object) 땙.딟());
          if (index != this.딥().Count - 1)
            땙.딟(str);
          땿.딧().Add(new 딙(str));
        }
      }
      tacticsGameStateData.Turns = 땿.딟();
      return tacticsGameStateData;
    }

    [SpecialName]
    public int 딝() => this.떂().땃();

    [SpecialName]
    public List<땓.땊> 떎() => this.떂().땺();

    [SpecialName]
    public 땙 떂() => this.딥().Count > 0 ? this.딥()[this.딥().Count - 1] : (땙) null;

    [SpecialName]
    public 땙 땭() => this.딥().Count > 1 ? this.딥()[this.딥().Count - 2] : (땙) null;

    [SpecialName]
    public 땙 딦() => this.딥().Count > 2 ? this.딥()[this.딥().Count - 3] : (땙) null;

    public 땙 땤() => this.딥().Count < 2 ? new 땙(this, this.딥()[0].딶()) : new 땙(this, this.딥()[this.딥().Count - 2]);

    public 땙 땽() => this.딥().Count < 3 ? new 땙(this, this.딥()[0].딶()) : new 땙(this, this.딥()[this.딥().Count - 3]);

    public bool 땋() => this.딥().Count < 3;

    public bool 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5) => this.땄(obj0, obj1, obj2, obj3, obj4, obj5) != -1;

    public int 땄([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5)
    {
      List<땓.땊> 땊List = obj0.땺();
      for (int index = 0; index < 땊List.Count; ++index)
      {
        if (index != obj5 && 땊List[index].땃 == obj2 && 땊List[index].딶 == obj3 && (this.땻()[index].딧(땊List[index]) || this.땄(obj0, obj1, obj2, obj3, obj4) == -1))
          return index;
      }
      return -1;
    }

    public bool 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      List<땓.땊> 땊List = obj0.땺();
      for (int index = 0; index < 땊List.Count; ++index)
      {
        if (땊List[index].땃 == obj2 && 땊List[index].딶 == obj3 && (!땊List[index].땺() && 땊List[index].땄 == obj4 || this.딟(obj0, index, obj2, obj3, obj4, false) && (this.땻()[index].딧(땊List[index]) || this.땄(obj0, obj1, obj2, obj3, obj4) == -1)))
          return true;
      }
      return false;
    }

    public int 땄([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      List<땓.땊> 땊List = obj0.땺();
      int num1 = 0;
      for (int index = 0; index < 땊List.Count; ++index)
      {
        if (땊List[index].땃 == obj2 && 땊List[index].딶 == obj3)
        {
          bool flag = this.딟(obj0, index, obj2, obj3, obj4, false);
          int num2 = this.땻()[index].딟(obj0, this.땻()[obj1], obj4, this.땼(), flag);
          if (num2 == -1)
            return -1;
          num1 = Mathf.Max(num1, num2);
        }
      }
      return num1;
    }

    public string 딟([In] int obj0, [In] bool obj1)
    {
      List<땓.떀> 떀List = new List<땓.떀>();
      bool flag = false;
      int num = 0;
      foreach (int index in this.딧(obj0))
      {
        땓.떀 떀 = this.땻()[index] as 땓.떀;
        떀.땠();
        if (Object.op_Equality((Object) 떀.땁(), (Object) null))
          return "Character (" + 떀.떔() + ") could not be loaded";
        if (떀.땁().ClassType == 땓.땅.땃)
        {
          if (flag)
            return "Multiple commanders found on team " + (object) obj0;
          flag = true;
        }
        WeaponGameplayData weaponGameplayData = this.땞().딟(떀.딸());
        if (Object.op_Equality((Object) weaponGameplayData, (Object) null))
          return "Weapon data could not be found (" + 떀.딸() + ")";
        if (!weaponGameplayData.딟(떀))
          return "Invalid weapon (" + 떀.딸() + ") used by character (" + 떀.떔() + ")";
        떀List.Add(떀);
        ++num;
      }
      Dictionary<string, int> dictionary = 딢.딛.딟(떀List);
      if (!딟.딗.딟(this.땜()[obj0].딟, dictionary))
        return "User did not supply valid required inventory";
      if (obj1)
      {
        if (num < 2 || num > 6)
          return "Invalid number of characters (" + (object) num + ") for level on team " + (object) obj0;
        if (Object.op_Equality((Object) this.땞().GenericData.땃(this.딟.딢), (Object) null))
          return "Invalid Squad Points Tier Specified";
        string str = 딞.딟((IEnumerable<땓.떀>) 떀List, this.땞(), this.딟.딢);
        if (str != null)
          return str;
      }
      return (string) null;
    }

    public string 땲()
    {
      if (this.딥().Count == 0)
        return (string) null;
      땙 땙1 = new 땙(this, this.딥()[0].딶());
      for (int index1 = 0; index1 < this.딥().Count; ++index1)
      {
        땙 땙2 = this.딥()[index1];
        bool flag = false;
        for (int index2 = 0; index2 < 땙2.땥().Count; ++index2)
        {
          땃.땧 땧 = 땙2.땥()[index2];
          if (index2 == 0)
          {
            if (!(땧 is 땃.땮))
              return "Pre-turn was not the first action on turn " + (object) index1;
          }
          else if (index2 == 땙2.땥().Count - 1)
          {
            if (!(땧 is 땃.떒))
            {
              if (index1 != this.딥().Count - 1)
                return "Post-turn was not the last action on turn " + (object) index1 + "(" + 땧.ToString() + ")";
            }
            else
              flag = true;
          }
          else
          {
            switch (땧)
            {
              case 땃.땮 _:
                return "Post-turn found on non-end action " + (object) index2 + " of " + (object) 땙2.땥().Count;
              case 땃.떒 _:
                return "Post-turn found on non-end action " + (object) index2 + " of " + (object) 땙2.땥().Count;
              default:
                continue;
            }
          }
        }
        if (땙2.땺().Count != this.땻().Count)
          return "Incorrect number of units in turn " + (object) index1 + " of " + (object) this.딥().Count;
        if (index1 <= 2)
        {
          for (int index3 = 0; index3 < 땙2.땥().Count; ++index3)
          {
            땃.땧 땧 = 땙2.땥()[index3];
            if (!(땧 is 땃.땮) && !(땧 is 땃.땬) && !this.딟(땙2, index1))
              return "An action (" + 땙2.땥()[index3].ToString() + ") on turn " + (object) index1 + " was added before all units were placed";
          }
        }
        for (int index4 = 0; index4 < 땙2.땥().Count; ++index4)
        {
          땓.딟 딟 = 땙1.딟(this, 땙2.땥()[index4], (땓.떒) this.땈());
          if (딟 == null)
            return "An action (" + 땙2.땥()[index4].ToString() + ") on turn " + (object) index1 + " failed to apply";
          딟.땄(false);
        }
        땙1.땄().땄(false);
        if (!땙1.딟(땙2, this))
          return "Turn State does not match at end of turn " + (object) index1;
        if (index1 < 2 && flag)
        {
          for (int index5 = 0; index5 < this.땻().Count; ++index5)
          {
            if (this.땻()[index5].땺() && 땙1.땺()[index5].땄 == 땙1.땃() && !땙1.땺()[index5].딶())
              return "Unit which should be placed is not";
          }
        }
        땙1 = new 땙(this, 땙1);
      }
      return (string) null;
    }

    public string 떏() => this.딟(new 딟.땾[2]);

    public string 딟(params 딟.땾[] TeamOutcomes)
    {
      for (int index = 0; index < 2; ++index)
      {
        string str = this.딟(index, this.딥().Count > 2);
        if (str != null)
          return str;
      }
      string str1 = this.땲();
      if (str1 != null)
        return str1;
      if (TeamOutcomes[0] != 딟.땾.딟 || TeamOutcomes[1] != 딟.땾.딟)
      {
        int index1 = this.땂();
        int index2 = (index1 + 1) % 2;
        int index3;
        int index4;
        if (TeamOutcomes[index1] == 딟.땾.딧 && TeamOutcomes[index2] == 딟.땾.딶)
        {
          index3 = index1;
          index4 = index2;
        }
        else if (this.딟.딢())
        {
          if (TeamOutcomes[0] == 딟.땾.땓)
          {
            if (TeamOutcomes[1] != 딟.땾.딧)
              return "Invalid Expiry Outcomes (0)";
            index3 = 1;
            index4 = 0;
          }
          else
          {
            if (TeamOutcomes[0] != 딟.땾.딧)
              return "Invalid Expiry Outcomes (1)";
            index3 = 0;
            index4 = 1;
          }
        }
        else
        {
          if (!this.떔().딢(this))
            return "Game wasn't complete, as claimed";
          index3 = this.떔().땃(this);
          index4 = (index3 + 1) % 2;
          if (TeamOutcomes[index3] != 딟.땾.딧)
            return "Incorrect winning team set";
          if (TeamOutcomes[index4] != 딟.땾.딢)
            return "Incorrect losing team set";
        }
        int num1;
        int num2;
        this.딟(index3, index4, out num1, out num2);
        땄.땉[] 딟 = this.딟.딟.딟;
        땄.땉 땉 = 딟[딟.Length - 1];
        TurnOp_AddToInventory[] array = ((IEnumerable<TurnOp_AddToInventory>) (!this.딟.딢() ? (IEnumerable<딟.떀>) 땉.땓() : (IEnumerable<딟.떀>) 땉.땺()).Select<딟.떀, TurnOp_AddToInventory>((Func<딟.떀, TurnOp_AddToInventory>) (obj0 => obj0 as TurnOp_AddToInventory)).Where<TurnOp_AddToInventory>((Func<TurnOp_AddToInventory, bool>) (obj0 => obj0 != null)).ToArray<TurnOp_AddToInventory>()).Where<TurnOp_AddToInventory>((Func<TurnOp_AddToInventory, bool>) (obj0 => obj0.ItemId == GlobalAppData.딧().GameSettings.CurrencyCoinsId)).ToArray<TurnOp_AddToInventory>();
        for (int index5 = 0; index5 < 2; ++index5)
        {
          int num3 = index5 != index3 ? num2 : num1;
          int num4 = 0;
          string str2 = this.딟.딟.딟[index5].딧();
          foreach (TurnOp_AddToInventory opAddToInventory in array)
          {
            if (!(opAddToInventory.UserId != str2))
            {
              ++num4;
              if (num4 > 1)
                return "Multiple coin rewards given for the same user";
              if (opAddToInventory.Quantity != num3)
                return "Invalid number of coins given";
            }
          }
          if (num4 == 0 && num3 != 0)
            return "No coin reward was given where one was expected.";
        }
      }
      else if (this.떔().딢(this))
        return "Game was complete, but wasn't claimed as such";
      return (string) null;
    }

    public 땓.딟 딟([In] bool obj0, [In] bool obj1)
    {
      if (this.땉() != null && this.땉().땺())
        return (땓.딟) null;
      땙 땙1 = (땙) null;
      땙 땙2;
      if (this.딥().Count == 0)
      {
        땙2 = new 땙(this);
      }
      else
      {
        if (this.땻().Count != this.딥()[0].땺().Count)
          return (땓.딟) null;
        땙1 = this.떂();
        땙2 = new 땙(this, this.딥()[this.딥().Count - 1]);
      }
      this.땈().딟().딟(땙1);
      땓.딟 딟 = (땓.딟) null;
      if (this.떓() == 딹.딧)
      {
        if (!obj0)
          this.딥().Add(땙2);
        if (땙1 != null && obj0)
          this.땉().딟(땙1, 땙2, obj1);
      }
      else
      {
        this.딥().Add(땙2);
        딟 = 땙2.딟(this, (땃.땧) new 땃.땮(), (땓.떒) this.땈());
        if (!this.땼())
        {
          this.땺();
          if (this.땉() != null)
            this.땉().딟.SaveSettings();
        }
        if (this.땉() != null)
          this.땉().딢();
      }
      return 딟;
    }

    public 땓.딟 딟([In] 땃.땧 obj0, [In] 땙 obj1, [In] 땓.떒 obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj1);
      this.딟 = obj0.GetType();
      return obj0.딟(this, obj1, obj2);
    }

    public 땓.딟 딟([In] 땃.땧 obj0)
    {
      땓.딟 딟 = this.떂().딟(this, obj0, (땓.떒) this.땈());
      if (딟 == null)
        return (땓.딟) null;
      if (this.땉() != null)
        this.땉().딧();
      return 딟;
    }

    public 땓.땊 딟([In] bool obj0)
    {
      땓.땊 땊 = (땓.땊) null;
      땙 땙1 = this.떂();
      int index1 = 0;
      while (index1 < 땙1.땥().Count && (땙1.땥()[index1] is 땃.땮 || 땙1.땥()[index1] is 땃.땬))
        ++index1;
      if (땙1.땥().Count == index1)
        return 땊;
      int index2 = !obj0 ? 땙1.땥().Count - 1 : index1;
      땙 땙2 = this.땭() != null ? new 땙(this, this.땭()) : new 땙(this, 땙1.딶());
      this.딥()[this.딥().Count - 1] = 땙2;
      this.땈().딟().딟();
      for (int index3 = 0; index3 < index2; ++index3)
        땙2.딟(this, 땙1.땥()[index3], (땓.떒) this.땈()).땄(true);
      if (땙1.땥().Count == index2 + 1)
      {
        int index4 = 땙1.땥()[index2].땄();
        if (index4 != -1)
          땊 = 땙2.땺()[index4];
      }
      return 땊;
    }

    public int 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] 땚 obj3)
    {
      for (int index = 0; index < obj0.땺().Count; ++index)
      {
        땓.땊 땊 = obj0.땺()[index];
        if (땊.땃 == obj1 && 땊.딶 == obj2 && obj3.딟(obj0, index))
          return index;
      }
      return -1;
    }

    public int 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] 딢.딴 obj4)
    {
      int index1 = -1;
      for (int index2 = 0; index2 < obj0.땺().Count; ++index2)
      {
        if (index2 != obj3 && this.땻()[index2].딶())
        {
          땓.땊 땊 = obj0.땺()[index2];
          if (!땊.땺() && (index1 == -1 || (obj0.땺()[index1].땄 != obj0.땃() || 땊.땄 == obj0.땃()) && ((obj0.땺()[index1].땄 != obj0.땃() || 땊.땄 != obj0.땃()) && (obj0.땺()[index1].땄 == obj0.땃() || 땊.땄 == obj0.땃()) || this.땻()[index1].딟(obj4) <= this.땻()[index2].딟(obj4))) && 땊.땃 == obj1 && 땊.딶 == obj2)
            index1 = index2;
        }
      }
      return index1;
    }

    public int 딟([In] 땙 obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      for (int index = 0; index < obj0.땺().Count; ++index)
      {
        if (index != obj3)
        {
          땓.땊 땊 = obj0.땺()[index];
          if (땊.땃 == obj1 && 땊.딶 == obj2)
            return index;
        }
      }
      return -1;
    }

    public int 딟([In] 땙 obj0, [In] 딶.땩 obj1, [In] int obj2, [In] int obj3, [In] bool obj4, [In] bool obj5)
    {
      int index1 = -1;
      for (int index2 = 0; index2 < obj0.땺().Count; ++index2)
      {
        if (index2 != obj3)
        {
          땓.땊 땊 = obj0.땺()[index2];
          if (!땊.땺() && (obj2 == -1 || 땊.땄 == obj2))
          {
            땓.딲 딲 = this.땻()[index2];
            if ((!obj4 || 딲.땽()) && 땊.딟(obj5) == obj1)
            {
              if (index1 != -1)
              {
                if (this.땻()[index2].땓() > this.땻()[index1].땓())
                  index1 = index2;
              }
              else
                index1 = index2;
            }
          }
        }
      }
      return index1;
    }

    public bool 땼() => this.땉() != null && this.땉().떁().딟(this.딝(), this.떓());

    public void 땄([In] int obj0)
    {
      for (int index = 0; index < this.떎().Count; ++index)
      {
        땓.땊 땊 = this.떎()[index];
        if (땊.땓() && 땊.땄 == obj0)
          땊.딧 = 0;
      }
    }

    [SpecialName]
    public IEnumerable<int> 땢() => (IEnumerable<int>) new 땵<땓.떀>(this.땻(), 0, this.땻().Count);

    public IEnumerable<int> 딧([In] int obj0) => obj0 == 0 ? (IEnumerable<int>) new 땵<땓.떀>(this.땻(), this.땁(), this.땷()) : (IEnumerable<int>) new 땵<땓.떀>(this.땻(), this.딸(), this.땘());

    public 땓.떀[] 딢([In] int obj0_1)
    {
      int count1;
      int count2;
      if (obj0_1 == 0)
      {
        count1 = this.땁();
        count2 = this.땷();
      }
      else
      {
        count1 = this.딸();
        count2 = this.땘();
      }
      return this.땻().Skip<땓.딲>(count1).Take<땓.딲>(count2).Select<땓.딲, 땓.떀>((Func<땓.딲, 땓.떀>) (obj0_2 => obj0_2 as 땓.떀)).Where<땓.떀>((Func<땓.떀, bool>) (obj0_3 => obj0_3 != null)).ToArray<땓.떀>();
    }

    public int 땃([In] int obj0)
    {
      int num1 = 0;
      int num2 = 0;
      this.딟(obj0, out num1, out num2);
      return num2;
    }

    public int 딶([In] int obj0)
    {
      int num1 = 0;
      int num2 = 0;
      this.딟(obj0, out num1, out num2);
      return num1;
    }

    public void 딟([In] int obj0, [In] 땙 obj1, out int _param3, out int _param4)
    {
      if (obj1 == null)
        obj1 = this.떂();
      _param3 = 0;
      _param4 = 0;
      if (obj1 == null)
        return;
      foreach (int index in this.딧(obj0))
      {
        땓.떀 떀 = (this.땻()[index] as 땓.떀).땳();
        떀.땠();
        _param3 += 떀.딱();
        땓.땊 땊 = obj1.땺()[index];
        if (!땊.땺())
        {
          if (this.딟(땊))
            _param4 += obj1.땺()[index].딧;
          else
            _param4 += 떀.딱();
        }
      }
    }

    public bool 딟([In] 땓.땊 obj0)
    {
      if (obj0.땺())
        return false;
      return this.딝() == obj0.땄 || obj0.딢(딢.떍.딢) == -1;
    }

    public void 딟([In] int obj0, out int _param2, out int _param3) => this.딟(obj0, this.떂(), out _param2, out _param3);

    public float 딟([In] int obj0, [In] 땙 obj1)
    {
      int num1 = 0;
      int num2 = 0;
      this.딟(obj0, obj1, out num1, out num2);
      return num1 == 0 ? 0.0f : (float) num2 / (float) num1;
    }

    public float 땓([In] int obj0) => this.딟(obj0, this.떂());

    public int 땺([In] int obj0) => this.땄(obj0, this.떂());

    public int 땄([In] int obj0, [In] 땙 obj1)
    {
      if (obj1 == null)
        obj1 = this.떂();
      int num = -1;
      for (int index = 0; index < this.땻().Count; ++index)
      {
        if (this.땻()[index] is 딶.딸)
        {
          num = index;
          break;
        }
      }
      return 딮.딟(this, obj0, num, obj1);
    }

    public bool 딟([In] 땙 obj0, [In] int obj1)
    {
      for (int index = 0; index < this.땻().Count; ++index)
      {
        if (this.땻()[index].땺())
        {
          땓.땊 땊 = obj0.땺()[index];
          if (땊.땄 == obj1 && !땊.딶())
            return false;
        }
      }
      return true;
    }

    [SpecialName]
    public bool 딷() => this.딟(this.떂(), this.딝());

    private bool 땥([In] int obj0) => obj0 < 2;

    public bool 딟([In] 땙 obj0) => obj0 == null ? this.떁() : this.땥(obj0.딧());

    [SpecialName]
    public bool 떁() => this.땥(this.딥().Count - 1);

    public List<딟.땩> 땟()
    {
      List<딟.땩> 땩List = new List<딟.땩>();
      for (int index = 0; index < this.땻().Count; ++index)
        this.땻()[index].딟(땩List, 땓.땾.딢);
      this.떔().딟(땩List);
      땩List.AddRange((IEnumerable<딟.땩>) GlobalAppData.땼().딟(this.딟.땄, 딢.딛.딣.딢));
      return 땩List;
    }

    public int 땂() => this.떓() == 딹.딧 ? GlobalAppData.떏().땃(this.딟.딟) : 0;

    public int 딝([In] int obj0)
    {
      int num = 0;
      땙 땙 = this.떂();
      foreach (int index in this.딧(obj0))
      {
        if (!땙.땺()[index].땺())
          ++num;
      }
      return num;
    }

    private bool 딟([In] int obj0, [In] string obj1)
    {
      foreach (땙 땙 in this.딥())
      {
        if (땙.땃() == obj0 && 땙.딝() != null)
        {
          foreach (딟.떀 떀 in 땙.딝())
          {
            if (떀 is TurnOp_Consume turnOpConsume3 && turnOpConsume3.ItemId == obj1)
              return true;
          }
        }
      }
      return false;
    }

    public bool 떎([In] int obj0)
    {
      EnvironmentSettings_Game gameSettings = GlobalAppData.딧().GameSettings;
      return this.딟(obj0, gameSettings.XPBoostId);
    }

    public bool 떂([In] int obj0)
    {
      EnvironmentSettings_Game gameSettings = GlobalAppData.딧().GameSettings;
      return this.딟(obj0, gameSettings.CoinsBoostId);
    }

    public int 딱()
    {
      bool flag1 = (double) this.땓(0) >= 0.5;
      bool flag2 = true;
      foreach (int index in this.딧(0))
      {
        if (this.떂().땺()[index].땺())
        {
          flag2 = false;
          break;
        }
      }
      int num = 0;
      if (this.떔().땃(this) == 0)
        num = !flag2 ? (!flag1 ? 1 : 2) : 3;
      return num;
    }

    [SpecialName]
    public int 때() => this.땞().GenericData.딶(this.떂().딢());

    public int 땭([In] int obj0)
    {
      BuildManifestMissionRewardsData missionRewardsData = GlobalAppData.땼().땉(this.딟.딧);
      if (missionRewardsData == null)
        return 0;
      int num1 = Mathf.Min(missionRewardsData.Rewards.Length, this.딱());
      int num2 = 0;
      for (int index = obj0; index < num1; ++index)
        num2 += missionRewardsData.Rewards[index].Coins;
      return num2;
    }

    private void 딟(out int _param1, out int _param2)
    {
      _param1 = Mathf.RoundToInt(0.8f * (float) this.때());
      _param2 = 0;
    }

    public void 딟([In] int obj0, [In] int obj1, out int _param3, out int _param4)
    {
      if (this.떓() != 딹.땄)
      {
        if (this.딟.딢())
        {
          this.딟(out _param3, out _param4);
        }
        else
        {
          float num1;
          float num2;
          this.떔().딟(this, out num1, out num2);
          int num3 = this.때();
          if (this.떂(obj0))
            num1 *= this.땞().GenericData.CoinsBoostScale;
          if (this.떂(obj1))
            num2 *= this.땞().GenericData.CoinsBoostScale;
          _param3 = Mathf.RoundToInt(num1 * (float) num3);
          _param4 = Mathf.RoundToInt(num2 * (float) num3);
        }
      }
      else
      {
        _param4 = 0;
        int num = GlobalAppData.땽().떎(this.딟.딧);
        _param3 = this.땭(num);
      }
    }

    public bool 땩() => !this.땉().딟.get_clearCinematics() && EventTimelineManager.딟().IsCurrentTimelineSkippable();

    public SinglePlayerMissionAsset 땠() => this.떓() == 딹.땄 ? GlobalAppData.땃(this.딟.딧) : (SinglePlayerMissionAsset) null;

    [SpecialName]
    public bool 땴() => this.땞().GenericData.PlayFirstTurnImmediately && this.딟.땓 < 2;

    public List<딟.떀> 땄([In] bool obj0, [In] bool obj1)
    {
      EnvironmentSettings_Game gameSettings = GlobalAppData.딧().GameSettings;
      List<딟.떀> 떀List = new List<딟.떀>();
      int index1 = this.땂();
      int index2 = (index1 + 1) % 2;
      int num1;
      int num2;
      this.딟(out num1, out num2);
      if (num1 != 0)
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.땄[index1], gameSettings.CurrencyCoinsId, num1));
      if (num2 != 0)
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.땄[index2], gameSettings.CurrencyCoinsId, num2));
      if (this.떂(index1) || obj0)
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.땄[index1], gameSettings.CoinsBoostId, 1));
      if (this.떎(index1) || obj1)
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.땄[index1], gameSettings.XPBoostId, 1));
      if (this.떂(index2))
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.땄[index2], gameSettings.CoinsBoostId, 1));
      if (this.떎(index2))
        떀List.Add((딟.떀) new TurnOp_AddToInventory(this.딟.땄[index2], gameSettings.XPBoostId, 1));
      return 떀List;
    }

    public bool 땄([In] int obj0, [In] int obj1, out int _param3, out int _param4)
    {
      if (this.떓() == 딹.땄)
      {
        SinglePlayerMissionAsset playerMissionAsset = this.땠();
        if (Object.op_Inequality((Object) playerMissionAsset, (Object) null) && obj0 == obj1)
        {
          _param3 = playerMissionAsset.XPOnLoss;
          _param4 = _param3;
          return false;
        }
      }
      땺.땃 땃 = new 땺.땃(this);
      _param3 = 0;
      foreach (int num in this.딧(obj0))
        _param3 += 땃.딢(num);
      _param3 += 땃.땃(obj0);
      _param4 = _param3;
      bool flag = this.떎(obj0);
      if (flag)
        _param4 = Mathf.RoundToInt((float) _param4 * this.땞().GenericData.XPBoostScale);
      return flag;
    }

    public bool 딗()
    {
      foreach (땓.땊 땊 in this.떂().땺())
      {
        if (땊.딢(딢.떍.딟) > 0)
          return true;
      }
      return false;
    }

    public bool 땳() => this.떂().딧() == this.딟.땃;

    [CompilerGenerated]
    [SpecialName]
    public List<땓.딲> 땻() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<땙> 딥() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딹 떓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딛() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 딣() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public int 땔() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public int 땁() => this.딶;

    [CompilerGenerated]
    [SpecialName]
    public int 땷() => this.땓;

    [CompilerGenerated]
    [SpecialName]
    public int 딸() => this.땺;

    [CompilerGenerated]
    [SpecialName]
    public int 땘() => this.땥;

    [CompilerGenerated]
    [SpecialName]
    public 땛 떔() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<GameTileComponent> 딳() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public ScenarioManagerComponent 땝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public GameGridComponent 땹() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public CameraAnimationWrapper 떇() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딡 땉() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딶.딛 땈() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public VersionedGameData 땞() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 떄[] 땜() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땓.떒 땪() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땙 땕() => this.딟;
  }
}
