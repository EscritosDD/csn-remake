// Decompiled with JetBrains decompiler
// Type: DestroyOnLoad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyOnLoad : MonoBehaviour
{
  public DestroyOnLoad() => this.set_Objects(new List<GameObject>());

  private void OnDestroy() => this.Flush();

  public void Flush()
  {
    foreach (Object @object in this.get_Objects())
      Object.Destroy(@object);
    this.get_Objects().Clear();
  }

  [CompilerGenerated]
  [SpecialName]
  public List<GameObject> get_Objects() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_Objects(List<GameObject> value) => this.딟 = value;
}
