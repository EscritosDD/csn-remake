// Decompiled with JetBrains decompiler
// Type: 딢.딘
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  internal class 딘
  {
    private 땄.땚 딟;
    private 땄.땣 딟;
    private 땄.땣 땄;
    private 땄.딚 딟;
    private int 딟;
    private 땄.딽 딟;
    private 땄.딽 땄;
    private List<딟.땩> 딟;
    private 딘.땑 딟;
    private 딳.땝 딟;
    private Action<땄.딽> 딟;
    private Action<땄.딽> 땄;
    private Action 딟;
    private Action 땄;
    private Action<딶.땖> 딟;
    private Action 딧;
    private Action<땄.땞> 딟;

    public 딘([In] string obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딟 = GlobalAppData.떏().땟(obj0);
      this.딟 = 딘.땑.땄;
    }

    public 딘([In] 땄.땞 obj0)
    {
      땓.딿 딟 = obj0.딟 as 땓.딿;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.딟);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      if (Object.op_Equality((Object) GlobalAppData.땼().딟(딟.딟()), (Object) null))
      {
        this.딟 = 딘.땑.땓;
        // ISSUE: reference to a compiler-generated method
        this.딟(딺.딟);
      }
      else
        this.딟 = 딘.땑.딧;
    }

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<땄.딽> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<땄.딽> obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딧([In] Action<땄.딽> obj0) => this.땄 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딢([In] Action<땄.딽> obj0) => this.땄 -= obj0;

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

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<딶.땖> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<딶.땖> obj0) => this.딟 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땃([In] Action obj0) => this.딧 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딶([In] Action obj0) => this.딧 -= obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 딟([In] Action<땄.땞> obj0) => this.딟 += obj0;

    [SpecialName]
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void 땄([In] Action<땄.땞> obj0) => this.딟 -= obj0;

    private void 딟() => this.딟 = ((딟.땇) GlobalAppData.떏()).딟(this.딦());

    private void 땄()
    {
      땓.딿 딟 = this.딦().딟 as 땓.딿;
      // ISSUE: reference to a compiler-generated method
      this.딟(-1);
      // ISSUE: reference to a compiler-generated method
      this.땄(-1);
      for (int index = 0; index < this.딦().딟.Length; ++index)
      {
        string str = this.딦().딟[index].딧();
        if (!string.IsNullOrEmpty(str))
        {
          if (str != ((딟.땇) GlobalAppData.떏()).땓())
          {
            this.딟 = GlobalAppData.떏().땄(str, false);
            // ISSUE: reference to a compiler-generated method
            this.딟(index);
            ++this.딟;
          }
          else
          {
            this.땄 = GlobalAppData.떏().땄(str, false);
            // ISSUE: reference to a compiler-generated method
            this.땄(index);
            ++this.딟;
          }
        }
      }
      if (this.딟 != null)
        return;
      if (!string.IsNullOrEmpty(딟.땃()))
      {
        this.딟 = GlobalAppData.떏().땄(딟.땃(), false);
        ++this.딟;
      }
      else
      {
        if (this.딟 == null)
          return;
        this.딟((땄.딽) null);
      }
    }

    public void 딧()
    {
      switch (this.딟)
      {
        case 딘.땑.땄:
          this.딶();
          break;
        case 딘.땑.딧:
          this.딟();
          this.땄();
          this.딟 = 딘.땑.딢;
          break;
        case 딘.땑.딢:
          this.땓();
          break;
        case 딘.땑.땃:
          this.땃();
          break;
        case 딘.땑.딶:
          this.딢();
          break;
      }
    }

    private void 딢()
    {
      if (!this.딟.땄())
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(this.딟.딟());
      if (this.땽() == null)
      {
        this.딝();
      }
      else
      {
        this.딟 = 딘.땑.땓;
        // ISSUE: reference to a compiler-generated method
        this.딟(!this.땽().땴() ? 딺.딧 : 딺.땄);
        if (this.딟 == null)
          return;
        this.딟(this.땽());
      }
    }

    private void 땃()
    {
      if (!this.떎())
        return;
      this.땥();
    }

    private void 딶()
    {
      if (!this.딟.땄())
        return;
      if (!this.딟.딧())
      {
        this.딝();
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(this.딟.딟);
        this.딟();
        this.땄();
        this.딟 = 딘.땑.딢;
        if (this.딟 == null)
          return;
        this.딟(this.딦());
      }
    }

    private void 땓()
    {
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          this.딟 = this.딟.딟;
          if (this.딟 != null)
            this.딟(this.딟);
        }
        --this.딟;
        this.딟 = (땄.땣) null;
      }
      if (this.땄 != null && this.땄.땄())
      {
        if (!this.땄.딧())
        {
          this.딝();
          return;
        }
        this.땄 = this.땄.딟;
        --this.딟;
        this.땄 = (땄.땣) null;
        if (this.땄 != null)
          this.땄(this.땄);
      }
      if (this.딟 != null && this.딟.땄())
      {
        if (!this.딟.딧())
        {
          this.딝();
          return;
        }
        this.떂();
        this.딟 = (땄.땚) null;
      }
      if (this.딟 != null || this.딟 != 0)
        return;
      this.땺();
    }

    private void 땺()
    {
      if (this.떎())
      {
        this.땥();
      }
      else
      {
        this.딟 = 딘.땑.땃;
        if (this.딟 == null)
          return;
        this.딟();
      }
    }

    private void 땥()
    {
      string[] strArray = new string[2]
      {
        string.Empty,
        string.Empty
      };
      if (this.떏() != -1)
        strArray[this.떏()] = this.딟.땄();
      if (this.땼() != -1)
        strArray[this.땼()] = this.땄.땄();
      this.딟 = 딳.딟(this.딦(), strArray);
      if (this.딟 == null)
      {
        this.딝();
      }
      else
      {
        this.딟 = 딘.땑.딶;
        if (this.땄 == null)
          return;
        this.땄();
      }
    }

    private void 딝()
    {
      this.딟 = 딘.땑.땓;
      // ISSUE: reference to a compiler-generated method
      this.딟(딺.딟);
      if (this.딧 == null)
        return;
      this.딧();
    }

    private bool 떎() => GlobalAppData.땼().딟((IEnumerable<딟.땩>) this.딟);

    private void 떂() => this.딟 = 딶.땖.딟(this.딦());

    [CompilerGenerated]
    [SpecialName]
    public string 땭() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땄.땞 딦() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딺 땤() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딶.땖 땽() => this.딟;

    [SpecialName]
    public bool 땋() => this.딟 == 딘.땑.땃;

    [SpecialName]
    public bool 땲() => this.딟 == 딘.땑.땓;

    [CompilerGenerated]
    [SpecialName]
    public int 떏() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public int 땼() => this.딧;

    private enum 땑
    {
      딟,
      땄,
      딧,
      딢,
      땃,
      딶,
      땓,
    }
  }
}
