// Decompiled with JetBrains decompiler
// Type: ScrollingUVs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Rendering/Scrolling UVs")]
public class ScrollingUVs : MonoBehaviour
{
  private Vector2 딟 = Vector2.zero;
  public int MaterialIndex;
  public Vector2 UVAnimationRate = new Vector2(1f, 0.0f);
  public string TextureName = "_MainTex";

  private void LateUpdate()
  {
    if (!Object.op_Inequality((Object) ((Component) this).renderer, (Object) null))
      return;
    ScrollingUVs scrollingUvs = this;
    scrollingUvs.딟 = Vector2.op_Addition(scrollingUvs.딟, Vector2.op_Multiply(this.UVAnimationRate, Time.deltaTime));
    if (!((Component) this).renderer.enabled)
      return;
    ((Component) this).renderer.materials[this.MaterialIndex].SetTextureOffset(this.TextureName, this.딟);
  }
}
