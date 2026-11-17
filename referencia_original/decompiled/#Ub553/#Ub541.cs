// Decompiled with JetBrains decompiler
// Type: 땓.땁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땁
  {
    public 땁()
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(new int[2]);
      // ISSUE: reference to a compiler-generated method
      this.딟(new int[2]);
    }

    public 땁([In] bool[] obj0, [In] bool[] obj1) => this.딟(obj0, obj1, new int[2]);

    public void 딟([In] bool[] obj0, [In] bool[] obj1, [In] int[] obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj1);
      if (this.땓() == null || this.딶() == null)
        return;
      Array.Copy((Array) this.땓(), (Array) this.딶(), this.땓().Length);
      Array.Copy((Array) obj2, (Array) this.땓(), this.땓().Length);
    }

    public bool 딟() => this.딢()[0] != this.땃()[0] || this.딢()[1] != this.땃()[1];

    public bool 딟([In] int obj0) => this.땓()[obj0] > this.딶()[obj0];

    public bool 땄([In] int obj0)
    {
      int index = obj0 != 0 ? 0 : 1;
      return this.딢()[obj0] && !this.딢()[index];
    }

    public bool 땄() => this.딢()[0] && this.딢()[1];

    public void 딧() => Debug.Log((object) ("Current: " + (object) this.딢()[0] + "/" + (object) this.딢()[1] + " - Previous: " + (object) this.땃()[0] + "/" + (object) this.땃()[1]));

    [CompilerGenerated]
    [SpecialName]
    public bool[] 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool[] 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public int[] 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public int[] 땓() => this.땄;
  }
}
