// Decompiled with JetBrains decompiler
// Type: AIDeployComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

public class AIDeployComponent : GameRulesComponent
{
  public 딶.떁[] DeployTypes;
  public 딶.땂 Team;
  private int 딟 = -1;

  public void Call(int Index) => this.딟 = Index;

  public void Uncall() => this.딟 = -1;

  public bool IsCalled(int Index) => this.딟 != -1 && this.딟 != Index;
}
