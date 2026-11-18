// Decompiled with JetBrains decompiler
// Type: TutorialIntroAnimHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class TutorialIntroAnimHandler : MonoBehaviour
{
  public void ShowPopupText(string Key) => ((Component) this).SendMessageUpwards("OnShowPopupText", (object) Key);

  public void ClearPopupText() => ((Component) this).SendMessageUpwards("OnClearPopupText");
}
