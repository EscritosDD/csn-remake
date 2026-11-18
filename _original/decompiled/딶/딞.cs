// Decompiled with JetBrains decompiler
// Type: 딶.딞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 딞
  {
    private SquadPointsTierEntry 딟;
    private VersionedGameData 딟;
    private List<땓.떀> 딟 = new List<땓.떀>();
    private List<딢.딴> 딟 = new List<딢.딴>();

    public 딞([In] VersionedGameData obj0, [In] int obj1)
    {
      this.딟 = obj0.GenericData.땃(obj1);
      this.딟 = obj0;
    }

    public int 딟()
    {
      int num = 0;
      foreach (딢.딴 딴 in this.딟)
      {
        PlayerAbilityEntry playerAbilityEntry = this.딟.GenericData.딟(딴);
        if (playerAbilityEntry != null)
          num += playerAbilityEntry.SquadPoints;
      }
      return num;
    }

    public int 땄()
    {
      int num = 0;
      foreach (땓.떀 떀 in this.딟)
        num += 떀.딟(this.딟);
      return num;
    }

    public List<땓.떀> 딧()
    {
      List<땓.떀> 떀List = new List<땓.떀>();
      for (int index = 0; index < this.딟.Count; ++index)
      {
        떀List.Add(this.딟[index].땳());
        if (떀List[index].땁().ClassType == 땓.땅.땃)
        {
          떀List[index].떓().Clear();
          foreach (딢.딴 딴 in this.딟)
            떀List[index].떓().Add(딴);
        }
      }
      return 떀List;
    }

    private bool 딟([In] 딢.딴 obj0, [In] bool obj1)
    {
      PlayerAbilityEntry playerAbilityEntry = this.딟.GenericData.딟(obj0);
      if (playerAbilityEntry == null || this.딟() + playerAbilityEntry.SquadPoints > this.딟.MaxAbilitySquadPoints)
        return false;
      if (obj1)
        this.딟.Add(obj0);
      return true;
    }

    public bool 딟([In] 딢.딴 obj0) => this.딟(obj0, false);

    public bool 땄([In] 딢.딴 obj0) => this.딟(obj0, true);

    private int 딢()
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index].땁().ClassType == 땓.땅.땃)
          return index;
      }
      return -1;
    }

    public bool 딟([In] 땓.떀 obj0, [In] bool obj1)
    {
      bool flag = obj0.땁().ClassType == 땓.땅.땃;
      int index = -1;
      if (flag)
        index = this.딢();
      int num = this.땄();
      if (index != -1)
        num -= this.딟[index].딟(this.딟);
      if (num + obj0.딟(this.딟) > this.딟.MaxUnitSquadPoints)
        return false;
      if (obj1)
      {
        if (index != -1)
          this.딟.RemoveAt(index);
        this.딟.Add(obj0);
      }
      return true;
    }

    public bool 딟([In] 땓.떀 obj0) => this.딟(obj0, false);

    public bool 땄([In] 땓.떀 obj0) => this.딟(obj0, true);

    public void 딧([In] 땓.떀 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (obj0.딳() == this.딟[index].딳())
        {
          this.딟.RemoveAt(index);
          break;
        }
      }
    }

    public void 딟([In] bool obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (!obj0 || this.딟[index].땁().ClassType != 땓.땅.땃)
          this.딟.RemoveAt(index--);
      }
    }

    public void 딧([In] 딢.딴 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (obj0 == this.딟[index])
        {
          this.딟.RemoveAt(index);
          break;
        }
      }
    }

    public void 땃() => this.딟.Clear();

    public bool 딢([In] 땓.떀 obj0)
    {
      foreach (땓.떀 떀 in this.딟)
      {
        if (떀.딳() == obj0.딳())
          return true;
      }
      return false;
    }

    public bool 딢([In] 딢.딴 obj0) => this.딟.Contains(obj0);

    public bool 딟([In] SquadPointsTierEntry obj0) => obj0.Tier == this.딟.Tier && obj0.MaxAbilitySquadPoints == this.딟.MaxAbilitySquadPoints && obj0.MaxAbilitySquadPoints == this.딟.MaxAbilitySquadPoints;

    public int 딶() => this.딟.MaxUnitSquadPoints;

    public int 땓() => this.딟.MaxAbilitySquadPoints;

    public static string 딟([In] IEnumerable<땓.떀> obj0, [In] VersionedGameData obj1, [In] int obj2)
    {
      딞 딞 = new 딞(obj1, obj2);
      foreach (땓.떀 떀 in obj0)
      {
        if (떀.땁().ClassType == 땓.땅.땃)
        {
          foreach (딢.딴 딴 in 떀.떓())
          {
            if (!딞.땄(딴))
              return "Invalid ability selected for this squad points tier";
          }
        }
        else if (떀.떓().Count > 0)
          return "Ability specified on non-commander";
        if (!딞.땄(떀))
          return "Invalid unit selected for this squad points tier";
      }
      return (string) null;
    }

    public void 딟([In] IEnumerable<땓.떀> obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
      {
        foreach (땓.떀 떀 in obj0)
        {
          if (this.딟[index].딳() == 떀.딳())
          {
            this.딟[index] = 떀;
            this.딟[index].땠();
            break;
          }
        }
      }
    }

    [SpecialName]
    public int 땺() => this.딟.Count;
  }
}
