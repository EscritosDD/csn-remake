// Decompiled with JetBrains decompiler
// Type: 딟.딹`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 딹<딟>
  {
    public 딹([In] EchoSessionListJson obj0_1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0_1.UserName);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0_1.AppId);
      EchoSessionJson[] sessions = obj0_1.Sessions;
      // ISSUE: reference to a compiler-generated field
      if (딹<딟>.딟 == null)
      {
        // ISSUE: reference to a compiler-generated field
        딹<딟>.딟 = (string) (obj0_3 => new 떈<딟>(obj0_3));
      }
      // ISSUE: reference to a compiler-generated field
      string 딟 = 딹<딟>.딟;
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<EchoSessionJson>) sessions).Select<EchoSessionJson, 떈<딟>>((Func<EchoSessionJson, 떈<딟>>) 딟).ToArray<떈<딟>>());
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 떈<딟>[] 딧() => (떈<딟>[]) this.딟;
  }
}
