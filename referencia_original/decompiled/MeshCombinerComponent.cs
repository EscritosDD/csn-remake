// Decompiled with JetBrains decompiler
// Type: MeshCombinerComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;
using 땓;

public class MeshCombinerComponent : MonoBehaviour
{
  public Transform Target;
  public Transform MeshPrefab;

  private void Start() => 딯.딟(((Component) this.Target).gameObject, this.MeshPrefab);

  private void Update()
  {
  }
}
