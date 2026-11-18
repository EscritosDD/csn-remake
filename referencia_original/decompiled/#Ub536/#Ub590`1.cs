// Decompiled with JetBrains decompiler
// Type: 딶.떐`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 떐<딟> : IDisposable, IEnumerator, IEnumerator<int> where 딟 : class, 땓.딲
  {
    private List<땓.딲> 딟;
    private int 딟;
    private int 땄;
    private int 딧 = -1;

    public 떐([In] List<땓.딲> obj0, [In] int obj1, [In] int obj2)
    {
      this.딟 = obj0;
      this.딟 = (List<땓.딲>) obj1;
      this.땄 = obj2;
      this.Reset();
    }

    [SpecialName]
    object IEnumerator.딟() => (object) this.get_Current();

    public void Dispose() => this.딟 = (List<땓.딲>) null;

    [SpecialName]
    public int get_Current() => this.딧;

    public bool MoveNext()
    {
      // ISSUE: unable to decompile the method.
    }

    public void Reset()
    {
      // ISSUE: unable to decompile the method.
    }
  }
}
