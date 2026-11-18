// Decompiled with JetBrains decompiler
// Type: DebugRenderer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

public class DebugRenderer : MonoBehaviour
{
  public Vector3[] Points;
  public Material LineMaterial;
  public string RendererId;

  public static void 딟([In] Vector3 obj0, [In] Vector3 obj1, [In] string obj2)
  {
  }

  public static void 딟([In] Vector3[] obj0, [In] string obj1)
  {
  }

  private static Material 딟()
  {
    Material material = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {     Blend SrcAlpha OneMinusSrcAlpha     ZWrite Off Cull Off Fog { Mode Off }     BindChannels {      Bind \"vertex\", vertex Bind \"color\", color }} } }");
    ((Object) material).hideFlags = (HideFlags) 13;
    ((Object) material.shader).hideFlags = (HideFlags) 13;
    return material;
  }

  private void OnPostRender()
  {
  }

  private void OnDestroy()
  {
    if (!Object.op_Inequality((Object) this.LineMaterial, (Object) null))
      return;
    if (Object.op_Inequality((Object) this.LineMaterial.shader, (Object) null))
      Object.Destroy((Object) this.LineMaterial.shader);
    GlobalAppData.딟(this.LineMaterial);
  }
}
