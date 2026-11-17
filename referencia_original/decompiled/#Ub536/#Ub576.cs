// Decompiled with JetBrains decompiler
// Type: 딶.땶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 땶
  {
    public string 딟;
    public int 딟;
    public int 땄;
    public int 딧;
    public int 딢;
    public int 땃 = -1;
    public string[] 딟;
    public string[] 땄;
    public string 땄;
    public string 딧;
    public int 딶;
    public 땄.땞 딟;
    public int 땓;
    public 딟.땾[] 딟;

    public 땶() => this.딟 = new 딟.땾[2];

    public 땶([In] TacticsSessionStateData obj0)
    {
      this.딟 = obj0.GameDataVersion;
      this.땄 = obj0.LevelName;
      this.땄 = obj0.ScenarioIndex;
      this.딧 = obj0.Id;
      this.딢 = obj0.SquadPointsTier;
      this.딟 = obj0.Players;
      this.땃 = obj0.LootDropTurn;
    }

    public TacticsSessionStateData 딟() => new TacticsSessionStateData()
    {
      GameDataVersion = this.딟,
      LevelName = this.땄,
      ScenarioIndex = this.땄,
      Id = this.딧,
      SquadPointsTier = this.딢,
      Players = this.딟,
      LootDropTurn = this.땃
    };

    [SpecialName]
    public bool 땄() => this.딟 != null && this.딟.딟 == 딟.딺.땃;

    [SpecialName]
    public bool 딧()
    {
      if (this.딟 == null)
        return false;
      return this.딟[0] == 딟.땾.딶 || this.딟[1] == 딟.땾.딶;
    }

    [SpecialName]
    public bool 딢()
    {
      if (this.딟 == null)
        return false;
      return this.딟[0] == 딟.땾.땓 || this.딟[1] == 딟.땾.땓;
    }
  }
}
