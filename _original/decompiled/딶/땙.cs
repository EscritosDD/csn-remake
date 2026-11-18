// Decompiled with JetBrains decompiler
// Type: 딶.땙
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땙
  {
    public string 딟;
    private 땓.딟 딟 = new 땓.딟();

    public 땙([In] 땖 obj0) => this.딟(obj0, new 떈().땄());

    public 땙([In] 땖 obj0, [In] int obj1) => this.딟(obj0, obj1);

    public 땙([In] 땖 obj0, [In] 땙 obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딧(obj1.땃() + 1 & 1);
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땓.땊>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땃.땧>());
      // ISSUE: reference to a compiler-generated method
      this.딢(obj1.땓().땄());
      // ISSUE: reference to a compiler-generated method
      this.딟(new 떈(this.딶()));
      this.땄(obj1.딢());
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1.딧() + 1);
      for (int index = 0; index < obj1.땺().Count; ++index)
        this.땺().Add(obj1.땺()[index].딧());
      for (int count = obj1.땺().Count; count < obj0.땻().Count; ++count)
        this.땄(obj0, count);
    }

    public 땙([In] 땖 obj0_1, [In] string obj1_1, [In] List<딟.떀> obj2, [In] int obj3)
    {
      TacticsGameStateTurnData gameStateTurnData = 딧.땾.딟<TacticsGameStateTurnData>(obj1_1);
      // ISSUE: reference to a compiler-generated method
      this.딧(gameStateTurnData.ActiveTeam);
      // ISSUE: reference to a compiler-generated method
      this.딢(gameStateTurnData.StartSeed);
      // ISSUE: reference to a compiler-generated method
      this.딟(new 떈(gameStateTurnData.Seed));
      this.땄(gameStateTurnData.RatingValue);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj3);
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<UnitTurnDataJson>) gameStateTurnData.Units).Select<UnitTurnDataJson, 땓.땊>((Func<UnitTurnDataJson, int, 땓.땊>) ((obj0_2, obj1_2) => new 땓.땊(obj1_2, obj0_2))).ToList<땓.땊>());
      this.딟 = gameStateTurnData.chatLine;
      for (int length = gameStateTurnData.Units.Length; length < obj0_1.땻().Count; ++length)
        this.땄(obj0_1, length);
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<TacticsActionData>) gameStateTurnData.Actions).Select<TacticsActionData, 땃.땧>((Func<TacticsActionData, 땃.땧>) (obj0_3 => this.딟(obj0_3))).ToList<땃.땧>());
      this.딟(obj1_1);
    }

    private void 딟([In] 땖 obj0, [In] int obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딧(0);
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땓.땊>());
      // ISSUE: reference to a compiler-generated method
      this.딟(new List<땃.땧>());
      // ISSUE: reference to a compiler-generated method
      this.딢(obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(new 떈(this.딶()));
      // ISSUE: reference to a compiler-generated method
      this.딟(0);
      for (int index = 0; index < obj0.땻().Count; ++index)
        this.땄(obj0, index);
    }

    private void 땄([In] 땖 obj0, [In] int obj1)
    {
      땓.딲 딲 = obj0.땻()[obj1];
      int num = obj1 < obj0.땁() || obj1 >= obj0.땁() + obj0.땷() ? (obj1 < obj0.딸() || obj1 >= obj0.딸() + obj0.땘() ? (!(딲 is 땹) ? -1 : 0) : 1) : 0;
      땓.땊 땊 = new 땓.땊(obj1, 0, -1, -1, num, 0, 딢.딯.딧);
      딲.딢(땊);
      obj0.떔().딟(obj1, 땊);
      this.땺().Add(땊);
    }

    public void 딟([In] 땖 obj0, [In] string obj1, [In] List<딟.떀> obj2, [In] int obj3)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj3);
      TacticsGameStateTurnData gameStateTurnData = 딧.땾.딟<TacticsGameStateTurnData>(obj1);
      for (int index = 0; index < gameStateTurnData.Actions.Length; ++index)
      {
        땃.땧 땧 = this.딟(gameStateTurnData.Actions[index]);
        this.딟(obj0, 땧, (땓.떒) 딣.딟)?.땄(false);
      }
      if (this.땥().Count > 0 && this.땥()[this.땥().Count - 1] is 땃.떒)
        this.딟.땄(false);
      this.딟 = gameStateTurnData.chatLine;
    }

    private 땃.땧 딟([In] TacticsActionData obj0)
    {
      switch (obj0.Action)
      {
        case 딢.땀.딟:
          return (땃.땧) new 땃.딼(obj0);
        case 딢.땀.땄:
          return (땃.땧) new 땃.땸(obj0);
        case 딢.땀.딧:
          return (땃.땧) new 땃.땬(obj0);
        case 딢.땀.딢:
          return (땃.땧) new 땃.떊(obj0);
        case 딢.땀.땃:
          return (땃.땧) new 땃.떒(obj0);
        case 딢.땀.딶:
          return (땃.땧) new 땃.땮(obj0);
        case 딢.땀.땓:
          return (땃.땧) new 딶.딢(obj0);
        default:
          throw new 떅();
      }
    }

    public 땓.딟 딟([In] 땖 obj0, [In] 땃.땧 obj1, [In] 땓.떒 obj2)
    {
      땓.딟 딟 = obj0.딟(obj1, this, obj2);
      this.땥().Add(obj1);
      return 딟;
    }

    public void 딟([In] 땓.딟 obj0) => this.딟.딟(obj0);

    public void 딟([In] 땏 obj0) => this.딟.딟(obj0);

    public TacticsGameStateTurnData 딟() => new TacticsGameStateTurnData()
    {
      ActiveTeam = this.땃(),
      StartSeed = this.딶(),
      Seed = this.땓().땄(),
      RatingValue = this.딢(),
      Units = this.땺().Select<땓.땊, UnitTurnDataJson>((Func<땓.땊, UnitTurnDataJson>) (obj0 => obj0.땄())).ToArray<UnitTurnDataJson>(),
      Actions = this.땥().Select<땃.땧, TacticsActionData>((Func<땃.땧, TacticsActionData>) (obj0 => obj0.딟())).ToArray<TacticsActionData>(),
      chatLine = this.딟
    };

    public bool 딟([In] 땙 obj0, [In] 땖 obj1)
    {
      if (this.딶() != obj0.딶())
      {
        Debug.LogError((object) "StartSeed != GameTurn.StartSeed");
        return false;
      }
      if (this.땓().땄() != obj0.땓().땄())
      {
        Debug.LogError((object) "Random.Seed != GameTurn.Random.Seed");
        return false;
      }
      if (this.딢() != obj0.딢())
      {
        Debug.LogError((object) "RatingValue != GameTurn.RatingValue");
        return false;
      }
      if (this.땃() != obj0.땃())
      {
        Debug.LogError((object) "ActiveTeam != GameTurn.ActiveTeam");
        return false;
      }
      if (this.땺().Count != obj0.땺().Count)
      {
        Debug.LogError((object) "Units.Count != GameTurn.Units.Count");
        return false;
      }
      for (int index = 0; index < this.땺().Count; ++index)
      {
        if (!this.땺()[index].딟(obj0.땺()[index]))
        {
          string str = obj1.땻()[index].ToString();
          if (obj1.땻()[index] is 땓.떀)
          {
            땓.떀 떀 = obj1.땻()[index] as 땓.떀;
            str = str + " " + (object) 떀.땁().DefaultName;
          }
          Debug.LogError((object) ("Unit " + (object) index + " doesn't match. Object: " + str));
          return false;
        }
      }
      return true;
    }

    public static void 딟([In] 땙 obj0)
    {
      string str = "ACTIONS ON INVALID TURN\n";
      for (int index = 0; index < obj0.땥().Count; ++index)
        str = str + obj0.땥()[index].ToString() + "\n";
      Debug.Log((object) str);
    }

    public 땓.딟 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int 딢() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] int obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 땃() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public int 딶() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public 떈 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<땓.땊> 땺() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<땃.땧> 땥() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딟.떀> 딝() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 떎() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string obj0) => this.땄 = obj0;
  }
}
