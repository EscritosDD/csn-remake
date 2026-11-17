// Decompiled with JetBrains decompiler
// Type: TutorialEditorStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class TutorialEditorStage
{
  public GameObject TutorialPopUp;
  public bool AllowUserControl;
  public float PreActionPauseTime = 1f;
  public float PostActionPauseTime = 1f;
  public TacticsUserActionEditorBase[] Actions;
}
