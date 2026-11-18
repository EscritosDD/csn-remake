// Decompiled with JetBrains decompiler
// Type: 땄.땗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 땗
  {
    public 땗([In] CatalogEntry obj0, [In] Func<Dictionary<string, object>, 딻> obj1, [In] Func<string, 딜> obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Id);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0.Name);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj2(obj0.Description));
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1(obj0.Data));
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Items);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Type);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Flags);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Tags);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0.Dependencies);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Offers);
    }

    [CompilerGenerated]
    [SpecialName]
    public OfferData[] 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 딜 딢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딻 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string[] 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string[] 땓() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 딟.딪 땺() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딟.떕 땥() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<string, int> 딝() => this.딟;
  }
}
