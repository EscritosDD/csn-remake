// Decompiled with JetBrains decompiler
// Type: StoreBundleNameDividerHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class StoreBundleNameDividerHandler : MonoBehaviour
{
  public GuiText3D NameText;
  public float Spacing = 44f;

  public void Init(string BundleName)
  {
    this.NameText.Text = BundleName;
    this.NameText.UpdateMesh();
  }
}
