// Decompiled with JetBrains decompiler
// Type: ScoreBoardDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using 딢;

public class ScoreBoardDisplay : MonoBehaviour
{
  public ScoreBoardEntryDisplay[] entries;
  public float maxUserNameLength = 0.3f;

  public void Init(땫 scoreBoard)
  {
    List<딢.땆> 땆List = scoreBoard.땄();
    for (int index = 0; index < this.entries.Length; ++index)
    {
      if (index < 땆List.Count && 땆List[index] != null)
      {
        this.entries[index].userName.Text = 땆List[index].땄;
        string str = 땓.땞.딟(this.entries[index].userName, 땆List[index].땄, this.maxUserNameLength);
        this.entries[index].userName.Text = str;
        this.entries[index].userName.UpdateMesh();
        this.entries[index].score.Text = 땆List[index].딟.ToString();
        this.entries[index].score.UpdateMesh();
        this.entries[index].Avatar.renderer.sharedMaterial = 땆List[index].딟;
      }
    }
  }
}
