// Decompiled with JetBrains decompiler
// Type: 딶.땵`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 딶
{
  public class 땵<딟> : IEnumerable, IEnumerable<int> where 딟 : class, 땓.딲
  {
    private List<땓.딲> 딟;
    private int 딟;
    private int 땄;

    public 땵([In] List<땓.딲> obj0, [In] int obj1, [In] int obj2)
    {
      this.딟 = obj0;
      this.딟 = (List<땓.딲>) obj1;
      this.땄 = obj2;
    }

    IEnumerator IEnumerable.딟() => (IEnumerator) this.GetEnumerator();

    public IEnumerator<int> GetEnumerator() => (IEnumerator<int>) new 떐<딟>(this.딟, (int) this.딟, this.땄);
  }
}
