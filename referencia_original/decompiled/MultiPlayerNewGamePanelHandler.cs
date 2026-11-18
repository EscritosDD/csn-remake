// Decompiled with JetBrains decompiler
// Type: MultiPlayerNewGamePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 딢;

[AddComponentMenu("Gui3D/Panels/MultiPlayer New Game")]
public class MultiPlayerNewGamePanelHandler : MonoBehaviour
{
  public GameObject NewUserFlowHighlight;

  private void Start()
  {
    if (땚.딢())
      this.NewUserFlowHighlight.SetActive(true);
    else
      this.NewUserFlowHighlight.SetActive(false);
  }
}
