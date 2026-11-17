// Decompiled with JetBrains decompiler
// Type: 땥.딧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  [DefaultMember("Item")]
  public struct 딧 : IEnumerable, IEnumerable<bool>
  {
    public bool 딟;
    public bool 땄;
    public bool 딧;

    IEnumerator IEnumerable.딟() => (IEnumerator) this.GetEnumerator();

    [SpecialName]
    public bool 딟([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
          return this.딟;
        case 1:
          return this.땄;
        case 2:
          return this.딧;
        default:
          throw new IndexOutOfRangeException();
      }
    }

    [SpecialName]
    public void 딟([In] int obj0, [In] bool obj1)
    {
      switch (obj0)
      {
        case 0:
          this.딟 = obj1;
          break;
        case 1:
          this.땄 = obj1;
          break;
        case 2:
          this.딧 = obj1;
          break;
        default:
          throw new IndexOutOfRangeException();
      }
    }

    public IEnumerator<bool> GetEnumerator() => this.딧().GetEnumerator();

    public bool 딟([In] bool obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.딟(index) == obj0)
          return true;
      }
      return false;
    }

    public int 땄([In] bool obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.딟(index) == obj0)
          return index;
      }
      return -1;
    }

    public void 땄() => this.딟 = this.땄 = this.딧 = false;

    public void 딧([In] bool obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.딟(index) == obj0)
          this.딟(index, false);
      }
    }

    [DebuggerHidden]
    private IEnumerable<bool> 딧()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땥.딧.\u003CEnumerate\u003Ec__Iterator23 enumerateCIterator23 = new 땥.딧.\u003CEnumerate\u003Ec__Iterator23()
      {
        딟 = this
      };
      // ISSUE: reference to a compiler-generated field
      enumerateCIterator23.땄 = -2;
      return (IEnumerable<bool>) enumerateCIterator23;
    }
  }
}
