// Decompiled with JetBrains decompiler
// Type: RageLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class RageLayer : MonoBehaviour
{
  public int Zorder;
  public bool ForceRefresh;
  private bool 딟;
  [SerializeField]
  private Material _material;

  public void Update()
  {
    if (!this.ForceRefresh || this.딟)
      return;
    this.SetMaterialRenderQueue();
    this.딟 = true;
  }

  public void SetMaterialRenderQueue()
  {
    this.ForceRefresh = true;
    if (Object.op_Equality((Object) this._material, (Object) null))
      this._material = new Material(((Component) this).renderer.material)
      {
        renderQueue = this.Zorder
      };
    else
      this._material.renderQueue = this.Zorder;
    ((Component) this).renderer.material = this._material;
  }

  public void OffsetMaterialRenderQueue(int offset)
  {
    this.Zorder += offset;
    this.ForceRefresh = true;
    this._material = new Material(((Component) this).renderer.material)
    {
      renderQueue = this.Zorder
    };
    ((Component) this).renderer.material = this._material;
  }

  public void SetMaterialRenderQueue(int zOrder) => ((Component) this).renderer.material.renderQueue = zOrder;
}
