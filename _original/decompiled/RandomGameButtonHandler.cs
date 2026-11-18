// Decompiled with JetBrains decompiler
// Type: RandomGameButtonHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class RandomGameButtonHandler : MonoBehaviour
{
  public GameObject NewUserIcon;

  private void Awake() => this.NewUserIcon.SetActive(false);

  public void UpdateNUFIcon(bool ShouldDisplayIcon)
  {
    if (ShouldDisplayIcon)
      this.NewUserIcon.SetActive(true);
    else
      this.NewUserIcon.SetActive(false);
  }
}
