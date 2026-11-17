// Decompiled with JetBrains decompiler
// Type: 딟.땉
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireline.Data;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 땉
  {
    public 땉([In] AccessTokenData obj0)
    {
      if (obj0 == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(string.Empty);
        // ISSUE: reference to a compiler-generated method
        this.땄(string.Empty);
        // ISSUE: reference to a compiler-generated method
        this.딧(string.Empty);
        // ISSUE: reference to a compiler-generated method
        this.딟(DateTime.MinValue);
        // ISSUE: reference to a compiler-generated method
        this.딟(Guid.Empty);
        // ISSUE: reference to a compiler-generated method
        this.땄(Guid.Empty);
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(obj0.딟);
        // ISSUE: reference to a compiler-generated method
        this.땄(obj0.땄);
        // ISSUE: reference to a compiler-generated method
        this.딧(obj0.딧);
        // ISSUE: reference to a compiler-generated method
        this.딟(obj0.딢);
        // ISSUE: reference to a compiler-generated method
        this.딟(obj0.땃);
        // ISSUE: reference to a compiler-generated method
        this.땄(obj0.딶);
      }
    }

    public AccessTokenData 딟() => new AccessTokenData()
    {
      딟 = this.딧(),
      땄 = this.딢(),
      딧 = this.땃(),
      딢 = this.딶(),
      땃 = this.땓(),
      딶 = this.땺()
    };

    [SpecialName]
    public bool 땄() => this.딶() != DateTime.MinValue && !string.IsNullOrEmpty(this.딧());

    [CompilerGenerated]
    [SpecialName]
    public string 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딢() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public DateTime 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Guid 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Guid 땺() => this.땄;
  }
}
