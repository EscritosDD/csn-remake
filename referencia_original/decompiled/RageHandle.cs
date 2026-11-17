// Decompiled with JetBrains decompiler
// Type: RageHandle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("RageTools/Rage Handle")]
public class RageHandle : MonoBehaviour
{
  public string GizmoFile = string.Empty;
  public bool Live = true;

  public void OnDrawGizmos()
  {
    if (!this.Live || string.IsNullOrEmpty(this.GizmoFile))
      return;
    Gizmos.DrawIcon(((Component) this).transform.position, this.GizmoFile);
  }
}
