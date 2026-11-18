// Decompiled with JetBrains decompiler
// Type: 딢.땖
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 딢
{
  public class 땖 : IDisposable
  {
    private Action 딟;
    private Action<bool> 딟;

    public 땖([In] Action obj0, [In] Action<bool> obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
    }

    public void 딟() => this.딟();

    public void 땄()
    {
    }

    public void Dispose()
    {
    }
  }
}
