// Decompiled with JetBrains decompiler
// Type: FSDebugDrawComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("FarseerUnity/Camera/GL DebugDraw Component")]
public class FSDebugDrawComponent : MonoBehaviour
{
  public Material GLMaterial;
  protected 땺.땹 딟;
  protected Camera 딟;
  protected Matrix4x4 딟;

  private void Start()
  {
    this.딟 = ((Component) this).GetComponent<Camera>();
    if (Object.op_Equality((Object) this.딟, (Object) null))
    {
      Debug.LogWarning((object) "This component must be attached to a camera");
    }
    else
    {
      this.딟 = this.딟.projectionMatrix;
      this.딟 = new 땺.땹(FSWorldComponent.딟());
      this.딟.땄(땥.떅.땓);
      this.딟.땄(땥.떅.땃);
      this.딟.땄(땥.떅.딶);
    }
  }

  private void Update()
  {
  }

  private void OnPostRender()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = this.딟.projectionMatrix;
    this.딟.딟(ref this.딟, this.GLMaterial);
  }

  private void OnGUI()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟.딟(this.딟);
  }
}
