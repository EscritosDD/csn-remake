// Decompiled with JetBrains decompiler
// Type: 딢.땿
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 땿
  {
    public 땿() => this.땄(0.0f);

    public void 딟([In] float obj0) => this.땄(obj0);

    public void 딟()
    {
      땿 땿 = this;
      // ISSUE: reference to a compiler-generated method
      땿.땄(땿.딧() - Time.deltaTime);
      // ISSUE: reference to a compiler-generated method
      this.땄(Mathf.Max(this.딧(), 0.0f));
    }

    public bool 땄() => (double) this.딧() == 0.0;

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.딟;
  }
}
