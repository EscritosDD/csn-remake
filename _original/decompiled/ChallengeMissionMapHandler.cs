// Decompiled with JetBrains decompiler
// Type: ChallengeMissionMapHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class ChallengeMissionMapHandler : MonoBehaviour
{
  public GameObject MapPrefab;
  public ChallengeNodeHandler[] MissionNodes;
  public ChallengePathHandler[] ChallengePaths;
  public float MissionMapLength;
  public string LevelDisplayID;

  public void Init()
  {
    for (int Index = 0; Index < this.MissionNodes.Length; ++Index)
      this.MissionNodes[Index].Init(Index);
  }

  private void OnDestroy()
  {
    this.MissionNodes = (ChallengeNodeHandler[]) null;
    this.ChallengePaths = (ChallengePathHandler[]) null;
    this.MapPrefab = (GameObject) null;
  }
}
