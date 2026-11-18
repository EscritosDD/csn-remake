// Decompiled with JetBrains decompiler
// Type: 딟.땘
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 땘
  {
    private bool 딟;
    public IEnumerator 딟;
    private static 땘 딟 = new 땘();
    private Action 딟;
    private Action 땄;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딧([In] Action obj0) => this.땄 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딢([In] Action obj0) => this.땄 -= obj0;

    public void 딟() => this.딟 = true;

    public static IEnumerator 딟([In] IEnumerator obj0) => 땘.딟.딧(obj0);

    public static 땘 땄([In] IEnumerator obj0)
    {
      땘 땘 = new 땘();
      땘.딟 = 땘.딧(obj0);
      return 땘;
    }

    [DebuggerHidden]
    private IEnumerator 딧([In] IEnumerator obj0) => (IEnumerator) new 땘.\u003CExecute\u003Ec__Iterator13()
    {
      딟 = obj0,
      땄 = obj0,
      딟 = this
    };
  }
}
