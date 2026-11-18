// Decompiled with JetBrains decompiler
// Type: 땄.떇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 떇
  {
    public 떇([In] SessionUserData obj0, [In] Dictionary<string, 딟.땾> obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.UserId);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Flags);
      딟.땾 땾;
      if (obj1 == null || !obj1.TryGetValue(this.딧(), out 땾))
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(땾);
    }

    [SpecialName]
    public bool 딟() => (this.땄() & 딟.떑.딧) == (딟.떑) 0;

    [CompilerGenerated]
    [SpecialName]
    public 딟.떑 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딟.땾 딢() => this.딟;
  }
}
