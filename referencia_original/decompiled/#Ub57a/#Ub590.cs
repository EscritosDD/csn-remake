// Decompiled with JetBrains decompiler
// Type: 땺.떐
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 떐 : 떌
  {
    private const int 딟 = 10000;
    private int 땄;
    private Dictionary<int, 땛<땥.딲>> 딟;
    private List<땛<땥.딲>> 딟;
    private List<떄> 딟;
    private 땵<땥.딲> 딟;
    private int 딧;

    public 떐([In] AABB obj0)
    {
      this.딟 = new 땵<땥.딲>(obj0, 5, 10);
      this.딟 = new Dictionary<int, 땛<땥.딲>>();
      this.딟 = new List<땛<땥.딲>>();
      this.딟 = new List<떄>();
    }

    [SpecialName]
    public int 딟() => this.딟.Count;

    public void 딟([In] int obj0, out AABB _param2)
    {
      if (!this.딟.ContainsKey(obj0))
        throw new KeyNotFoundException("proxyID not found in register");
      _param2 = (AABB) this.딟[obj0].딟;
    }

    public void 딟([In] 딝.떓 obj0)
    {
      this.딟.Clear();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      떐.떈 떈 = new 떐.떈();
      // ISSUE: reference to a compiler-generated field
      떈.딟 = this;
      foreach (땛<땥.딲> 땛 in this.딟)
      {
        // ISSUE: reference to a compiler-generated field
        떈.딟 = 땛;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated field
        // ISSUE: cast to a reference type
        this.딟(new Func<int, bool>(떈.딟), (AABB&) ref 떈.딟.딟);
      }
      this.딟.Clear();
      this.딟.Sort();
      int index = 0;
label_10:
      while (index < this.딟.Count)
      {
        떄 떄 = this.딟[index];
        땥.딲 딲1 = this.딧(떄.딟);
        땥.딲 딲2 = this.딧(떄.땄);
        obj0(ref 딲1, ref 딲2);
        ++index;
        while (true)
        {
          if (index < this.딟.Count && this.딟[index].딟 == 떄.딟 && this.딟[index].땄 == 떄.땄)
            ++index;
          else
            goto label_10;
        }
      }
    }

    public bool 딟([In] int obj0, [In] int obj1)
    {
      AABB aabb1;
      this.딟(obj0, out aabb1);
      AABB aabb2;
      this.딟(obj1, out aabb2);
      return AABB.땄(ref aabb1, ref aabb2);
    }

    public int 딟([In] ref 땥.딲 obj0)
    {
      int key = this.땄++;
      obj0.땄 = key;
      AABB aabb = this.딟(ref obj0.딟);
      땛<땥.딲> 땛 = new 땛<땥.딲>(obj0, aabb);
      this.딟.Add(key, 땛);
      this.딟.딟(땛);
      return key;
    }

    public void 딟([In] int obj0)
    {
      땛<땥.딲> 땛 = this.딟.ContainsKey(obj0) ? this.딟[obj0] : throw new KeyNotFoundException("proxyID not found in register");
      this.딧(땛);
      this.딟.Remove(obj0);
      this.딟.땄(땛);
    }

    public void 딟([In] int obj0, [In] ref AABB obj1, [In] 떁 obj2)
    {
      AABB aabb1;
      this.딟(obj0, out aabb1);
      if (aabb1.땄(ref obj1))
        return;
      AABB aabb2 = obj1;
      떁 떁1 = new 떁(0.1f, 0.1f);
      aabb2.LowerBound -= 떁1;
      aabb2.UpperBound += 떁1;
      떁 떁2 = 2f * obj2;
      if ((double) 떁2.딟 < 0.0)
        aabb2.LowerBound.딟 += 떁2.딟;
      else
        aabb2.UpperBound.딟 += 떁2.딟;
      if ((double) 떁2.땄 < 0.0)
        aabb2.LowerBound.땄 += 떁2.땄;
      else
        aabb2.UpperBound.땄 += 떁2.땄;
      땛<땥.딲> 땛 = this.딟[obj0];
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      (^(땥.딲&) ref 땛.딟).딟 = aabb2;
      땛.딟 = (땵<땥.딲>) aabb2;
      this.딟(땛);
      this.땄(땛);
    }

    public 땥.딲 딧([In] int obj0)
    {
      if (this.딟.ContainsKey(obj0))
        return (땥.딲) this.딟[obj0].딟;
      throw new KeyNotFoundException("proxyID not found in register");
    }

    public void 땄([In] int obj0)
    {
      if (!this.딟.ContainsKey(obj0))
        throw new KeyNotFoundException("proxyID not found in register");
      this.땄(this.딟[obj0]);
    }

    public void 딟([In] Func<int, bool> obj0, [In] ref AABB obj1) => this.딟.딟(this.딟(obj0), ref obj1);

    public void 딟([In] Func<딮, int, float> obj0, [In] ref 딮 obj1) => this.딟.딟(this.딟(obj0), ref obj1);

    private AABB 딟([In] ref AABB obj0)
    {
      떁 떁 = new 떁(0.1f, 0.1f);
      return new AABB(obj0.LowerBound - 떁, obj0.UpperBound + 떁);
    }

    private Func<땛<땥.딲>, bool> 딟([In] Func<int, bool> obj0) => new Func<땛<땥.딲>, bool>(new 떐.딹()
    {
      딟 = obj0
    }.딟);

    private Func<딮, 땛<땥.딲>, float> 딟([In] Func<딮, int, float> obj0) => new Func<딮, 땛<땥.딲>, float>(new 떐.딙()
    {
      딟 = obj0
    }.딟);

    private bool 땄([In] int obj0, [In] int obj1)
    {
      if (obj0 == obj1)
        return true;
      this.딟.Add(new 떄()
      {
        딟 = Math.Min(obj0, obj1),
        땄 = Math.Max(obj0, obj1)
      });
      return true;
    }

    private void 땄()
    {
      this.딟.딧();
      foreach (땛<땥.딲> 땛 in this.딟.Values)
        this.딟.딟(땛);
    }

    private void 딟([In] 땛<땥.딲> obj0)
    {
      this.딟.땄(obj0);
      this.딟.딟(obj0);
      if (++this.딧 <= 10000)
        return;
      this.땄();
      this.딧 = 0;
    }

    private void 땄([In] 땛<땥.딲> obj0) => this.딟.Add(obj0);

    private void 딧([In] 땛<땥.딲> obj0) => this.딟.Remove(obj0);
  }
}
