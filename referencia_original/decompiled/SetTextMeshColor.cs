// Decompiled with JetBrains decompiler
// Type: SetTextMeshColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class SetTextMeshColor : MonoBehaviour
{
  public Color TextColor = Color.black;
  private Material 딟;

  private void OnEnable()
  {
    this.딟 = ((Renderer) ((Component) this).GetComponent<MeshRenderer>()).sharedMaterials[0];
    this.딟.color = this.TextColor;
  }

  private void Update()
  {
    if (Application.isPlaying)
      return;
    this.딟.color = this.TextColor;
  }
}
