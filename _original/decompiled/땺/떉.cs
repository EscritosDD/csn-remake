// Decompiled with JetBrains decompiler
// Type: 땺.떉
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땥;

namespace 땺
{
  public class 떉 : 떌
  {
    private const int 딟 = -1;
    private int[] 딟;
    private int 땄;
    private int 딧;
    private 떄[] 딟;
    private int 딢;
    private int 땃;
    private int 딶;
    private Func<int, bool> 딟;
    private int 땓;
    private 땒<땥.딲> 딟 = new 땒<땥.딲>();

    public 떉()
    {
      this.딟 = new Func<int, bool>(this.딶);
      this.딶 = 0;
      this.딢 = 16;
      this.땃 = 0;
      this.딟 = new 떄[this.딢];
      this.땄 = 16;
      this.딧 = 0;
      this.딟 = new int[this.땄];
    }

    [SpecialName]
    public int 딟() => this.딶;

    public int 딟([In] ref 땥.딲 obj0)
    {
      int num = this.딟.딟(ref obj0.딟, obj0);
      ++this.딶;
      this.딢(num);
      return num;
    }

    public void 딟([In] int obj0)
    {
      this.땃(obj0);
      --this.딶;
      this.딟.땄(obj0);
    }

    public void 딟([In] int obj0, [In] ref AABB obj1, [In] 떁 obj2)
    {
      if (!this.딟.딟(obj0, ref obj1, obj2))
        return;
      this.딢(obj0);
    }

    public void 땄([In] int obj0) => this.딢(obj0);

    private void 딢([In] int obj0)
    {
      if (this.딧 == this.땄)
      {
        int[] 딟 = this.딟;
        this.땄 *= 2;
        this.딟 = new int[this.땄];
        Array.Copy((Array) 딟, (Array) this.딟, this.딧);
      }
      this.딟[this.딧] = obj0;
      ++this.딧;
    }

    private void 땃([In] int obj0)
    {
      for (int index = 0; index < this.딧; ++index)
      {
        if (this.딟[index] == obj0)
          this.딟[index] = -1;
      }
    }

    private bool 딶([In] int obj0)
    {
      if (obj0 == this.땓)
        return true;
      if (this.땃 == this.딢)
      {
        떄[] 딟 = this.딟;
        this.딢 *= 2;
        this.딟 = new 떄[this.딢];
        Array.Copy((Array) 딟, (Array) this.딟, this.땃);
      }
      this.딟[this.땃].딟 = Math.Min(obj0, this.땓);
      this.딟[this.땃].땄 = Math.Max(obj0, this.땓);
      ++this.땃;
      return true;
    }

    public void 딟([In] int obj0, out AABB _param2) => this.딟.딟(obj0, out _param2);

    public 땥.딲 딧([In] int obj0) => this.딟.딧(obj0);

    public bool 딟([In] int obj0, [In] int obj1)
    {
      AABB aabb1;
      this.딟.딟(obj0, out aabb1);
      AABB aabb2;
      this.딟.딟(obj1, out aabb2);
      return AABB.땄(ref aabb1, ref aabb2);
    }

    public void 딟([In] 딝.떓 obj0)
    {
      this.땃 = 0;
      for (int index = 0; index < this.딧; ++index)
      {
        this.땓 = this.딟[index];
        if (this.땓 != -1)
        {
          AABB aabb;
          this.딟.딟(this.땓, out aabb);
          this.딟.딟(this.딟, ref aabb);
        }
      }
      this.딧 = 0;
      Array.Sort<떄>(this.딟, 0, this.땃);
      int index1 = 0;
      while (index1 < this.땃)
      {
        떄 떄1 = this.딟[index1];
        땥.딲 딲1 = this.딟.딧(떄1.딟);
        땥.딲 딲2 = this.딟.딧(떄1.땄);
        obj0(ref 딲1, ref 딲2);
        for (++index1; index1 < this.땃; ++index1)
        {
          떄 떄2 = this.딟[index1];
          if (떄2.딟 != 떄1.딟 || 떄2.땄 != 떄1.땄)
            break;
        }
      }
    }

    public void 딟([In] Func<int, bool> obj0, [In] ref AABB obj1) => this.딟.딟(obj0, ref obj1);

    public void 딟([In] Func<딮, int, float> obj0, [In] ref 딮 obj1) => this.딟.딟(obj0, ref obj1);

    [SpecialName]
    public int 땄() => this.딟.딧();
  }
}
