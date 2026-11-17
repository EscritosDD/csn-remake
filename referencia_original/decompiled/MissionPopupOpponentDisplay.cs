// Decompiled with JetBrains decompiler
// Type: MissionPopupOpponentDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class MissionPopupOpponentDisplay : MonoBehaviour
{
  public GameObject AvatarImage;

  public void Init(떀 Unit) => this.AvatarImage.renderer.sharedMaterial = Unit.땁().CharacterIcon;
}
