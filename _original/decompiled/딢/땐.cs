// Decompiled with JetBrains decompiler
// Type: 딢.땐
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  public class 땐
  {
    private DateTime 딟;
    private 땄.떐 딟;
    private 땄.딽[] 딟;
    private DateTime 땄;
    private 딟.딤 딟;
    private 땄.딽[] 땄;
    private DateTime 딧;
    private 땄.딱 딟;
    private 딟.떊[] 딟;

    public void 딟()
    {
      if (!GlobalAppData.떏().땥())
        return;
      this.땺();
      this.땥();
      this.딝();
    }

    public void 땄()
    {
      if (!GlobalAppData.떏().땥())
        return;
      this.딶();
      this.땃();
      this.딢();
    }

    public void 딧()
    {
      this.딟 = DateTime.MinValue;
      this.딟 = (땄.떐) null;
      this.딟 = (땄.딽[]) null;
      this.땄 = DateTime.MinValue;
      this.딟 = (딟.딤) null;
      this.땄 = (땄.딽[]) null;
      this.딧 = DateTime.MinValue;
      this.딟 = (땄.딱) null;
      this.딟 = (딟.떊[]) null;
    }

    private void 딢()
    {
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
      {
        this.딟 = this.딟.딟;
        this.딧 = DateTime.Now.AddMinutes(1.0);
      }
      this.딟 = (땄.딱) null;
    }

    private void 땃()
    {
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
      {
        this.땄 = this.딟.딟;
        this.땄 = DateTime.Now.AddMinutes(1.0);
      }
      this.딟 = (딟.딤) null;
    }

    private void 딶()
    {
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
      {
        this.딟 = this.딟.딟;
        this.딟 = DateTime.Now.AddMinutes(1.0);
      }
      this.딟 = (땄.떐) null;
    }

    private bool 땓() => !string.IsNullOrEmpty(GlobalAppData.딷().딧()) && !string.IsNullOrEmpty(GlobalAppData.딷().딢());

    private void 땺()
    {
      if (DateTime.Now < this.땄)
        return;
      this.딟 = GlobalAppData.떏().떁();
    }

    private void 땥()
    {
      if (DateTime.Now < this.딧)
        return;
      this.딟 = GlobalAppData.떏().땂();
    }

    private void 딝()
    {
      if (!this.땓() || DateTime.Now < this.딟)
        return;
      this.딟 = GlobalAppData.떏().땥(GlobalAppData.딷().딧(), GlobalAppData.딷().딢());
    }

    public 땄.딽[] 떎()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땐.땡 땡 = new 땐.땡();
      // ISSUE: reference to a compiler-generated field
      땡.딟 = this.딟 != null ? this.딟 : new 땄.딽[0];
      // ISSUE: reference to a compiler-generated method
      IEnumerable<땄.딽> second = (this.땄 != null ? (IEnumerable<땄.딽>) this.땄 : (IEnumerable<땄.딽>) new 땄.딽[0]).Where<땄.딽>(new Func<땄.딽, bool>(땡.딟));
      // ISSUE: reference to a compiler-generated field
      return ((IEnumerable<땄.딽>) 땡.딟).Concat<땄.딽>(second).OrderBy<땄.딽, string>((Func<땄.딽, string>) (obj0 => obj0.땄())).ToArray<땄.딽>();
    }

    [SpecialName]
    public bool 떂() => this.딟 != null || this.딟 != null;

    [SpecialName]
    public bool 땭() => this.딟 != null;

    [SpecialName]
    public bool 딦() => this.딟 != null || this.땄 != null;

    [SpecialName]
    public bool 땤() => (!this.땓() || this.딟 != null) && this.땄 != null;

    [SpecialName]
    public bool 땽() => this.딟 != null;

    [SpecialName]
    public 딟.떊[] 땋() => this.딟;

    public void 딟([In] string obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땐.딻 딻 = new 땐.딻();
      // ISSUE: reference to a compiler-generated field
      딻.딟 = obj0;
      if (this.땄 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.땄 = ((IEnumerable<땄.딽>) this.땄).Where<땄.딽>(new Func<땄.딽, bool>(딻.딟)).ToArray<땄.딽>();
    }

    public void 땄([In] string obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땐.딜 딜 = new 땐.딜();
      // ISSUE: reference to a compiler-generated field
      딜.딟 = obj0;
      if (this.딟 == null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟 = ((IEnumerable<딟.떊>) this.딟).Where<딟.떊>(new Func<딟.떊, bool>(딜.딟)).ToArray<딟.떊>();
    }
  }
}
