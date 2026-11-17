// Decompiled with JetBrains decompiler
// Type: FacebookActionButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class FacebookActionButton : MonoBehaviour
{
  public Shader DisabledShader;
  public GuiButton3D Button;
  public GameObject[] Parts;
  private Material[] 딟 = new Material[3];
  private Material[] 땄 = new Material[3];

  public void Activate()
  {
    this.UpdateCachedMaterials();
    this.SetMaterials(this.땄);
    this.Button.Disabled = false;
  }

  public void Deactivate()
  {
    this.UpdateCachedMaterials();
    this.SetMaterials(this.딟);
    this.Button.Disabled = true;
  }

  private void SetMaterials(Material[] Materials)
  {
    for (int index = 0; index < this.Parts.Length; ++index)
      this.Parts[index].renderer.sharedMaterial = Materials[index];
  }

  private void UpdateCachedMaterials()
  {
    for (int index = 0; index < this.땄.Length; ++index)
    {
      if (Object.op_Equality((Object) this.땄[index], (Object) null))
        this.땄[index] = new Material(this.Parts[index].renderer.sharedMaterial);
    }
    for (int index = 0; index < this.딟.Length; ++index)
    {
      if (Object.op_Equality((Object) this.딟[index], (Object) null))
        this.딟[index] = GlobalAppData.땲().딟(this.Parts[index].renderer.sharedMaterial, this.DisabledShader);
    }
  }

  private void OnDestroy()
  {
    for (int index = 0; index < this.땄.Length; ++index)
      GlobalAppData.딟(this.땄[index]);
    for (int index = 0; index < this.딟.Length; ++index)
      GlobalAppData.딟(this.딟[index]);
  }

  private enum 떆
  {
    딟,
    땄,
    딧,
    딢,
  }
}
