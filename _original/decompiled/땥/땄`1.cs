// Decompiled with JetBrains decompiler
// Type: 땥.땄`1
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
  public struct 땄<딟> : IEnumerable, IEnumerable<딟> where 딟 : class
  {
    public 딟 딟;
    public 딟 땄;
    public 딟 딧;

    IEnumerator IEnumerable.딟() => (IEnumerator) this.GetEnumerator();

    [SpecialName]
    public 딟 딟([In] int obj0)
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
    public void 딟([In] int obj0, [In] 딟 obj1)
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

    public IEnumerator<딟> GetEnumerator() => this.딧().GetEnumerator();

    public bool 딟([In] 딟 obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if ((object) this.딟(index) == (object) obj0)
          return true;
      }
      return false;
    }

    public int 땄([In] 딟 obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if ((object) this.딟(index) == (object) obj0)
          return index;
      }
      return -1;
    }

    public void 땄() => this.딟 = this.땄 = this.딧 = (딟) null;

    public void 딧([In] 딟 obj0)
    {
      for (int index = 0; index < 3; ++index)
      {
        if ((object) this.딟(index) == (object) obj0)
          this.딟(index, (딟) null);
      }
    }

    [DebuggerHidden]
    private IEnumerable<딟> 딧()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땥.땄<딟>.\u003CEnumerate\u003Ec__Iterator22 enumerateCIterator22 = new 땥.땄<딟>.\u003CEnumerate\u003Ec__Iterator22()
      {
        딟 = (int) this
      };
      // ISSUE: reference to a compiler-generated field
      enumerateCIterator22.땄 = -2;
      return (IEnumerable<딟>) enumerateCIterator22;
    }
  }
}
