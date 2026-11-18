// Decompiled with JetBrains decompiler
// Type: 딟.땆
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  internal class 땆 : IDisposable
  {
    private 땫 딟;
    private Action 딟;
    private Action<Texture2D> 딟;

    public 땆([In] 땫 obj0) => this.딟 = obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<Texture2D> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<Texture2D> obj0) => this.딟 -= obj0;

    public void 딟([In] string obj0) => this.딟.딧().딟(obj0, new Action(this.땄), new Action<Texture2D>(this.땄));

    [CompilerGenerated]
    [SpecialName]
    public Texture2D 딟() => this.딟;

    private void 땄()
    {
      this.딟.땄(this);
      this.딧();
    }

    private void 땄([In] Texture2D obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딟.딟(this);
      this.딧();
    }

    private void 딧()
    {
      if (Object.op_Inequality((Object) this.딟(), (Object) null))
      {
        if (this.딟 == null)
          return;
        this.딟(this.딟());
        this.딟 = (Action<Texture2D>) null;
      }
      else
      {
        if (this.딟 == null)
          return;
        this.딟();
        this.딟 = (Action) null;
      }
    }

    public void Dispose()
    {
      if (!Object.op_Inequality((Object) this.딟(), (Object) null))
        return;
      Object.Destroy((Object) this.딟());
      // ISSUE: reference to a compiler-generated method
      this.딟((Texture2D) null);
    }
  }
}
