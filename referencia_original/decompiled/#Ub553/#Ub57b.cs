// Decompiled with JetBrains decompiler
// Type: 땓.땻
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땻
  {
    private int 딟;
    private 땻.딥 딟;
    private 땻.떓 딟;

    public 땻([In] 땻.딥 obj0, [In] int obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
    }

    public 땻([In] 땻.떓 obj0) => this.딟 = obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void 딟([In] 땻.딥 obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void 땄([In] 땻.딥 obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void 딟([In] 땻.떓 obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void 땄([In] 땻.떓 obj0) => this.딟 -= obj0;

    public bool 딟([In] float obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딧(Time.realtimeSinceStartup + obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
      return this.땄();
    }

    public void 딟()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
      // ISSUE: reference to a compiler-generated method
      this.딧(-1f);
    }

    public bool 땄([In] float obj0)
    {
      bool flag = false;
      if (this.딧() && (double) Time.realtimeSinceStartup > (double) this.딢())
      {
        flag = this.땄();
        // ISSUE: reference to a compiler-generated method
        this.딧(Time.realtimeSinceStartup + obj0 * 0.1f);
      }
      return flag;
    }

    private bool 땄() => this.딟 != null ? this.딟(this.딟) : this.딟();

    [CompilerGenerated]
    [SpecialName]
    public bool 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public float 딢() => this.딟;

    public delegate bool 딥([In] int obj0);

    public delegate bool 떓();
  }
}
