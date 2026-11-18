// Decompiled with JetBrains decompiler
// Type: 딟.떅`1
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
  public class 떅<딟>
  {
    public 떅([In] EchoEventListJson obj0_1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0_1.AppId);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0_1.SessionId);
      EchoEventJson[] events = obj0_1.Events;
      // ISSUE: reference to a compiler-generated field
      if (떅<딟>.딟 == null)
      {
        // ISSUE: reference to a compiler-generated field
        떅<딟>.딟 = (string) (obj0_3 => new 땖<딟>(obj0_3));
      }
      // ISSUE: reference to a compiler-generated field
      string 딟 = 떅<딟>.딟;
      // ISSUE: reference to a compiler-generated method
      this.딟(((IEnumerable<EchoEventJson>) events).Select<EchoEventJson, 땖<딟>>((Func<EchoEventJson, 땖<딟>>) 딟).ToArray<땖<딟>>());
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 땖<딟>[] 딧() => (땖<딟>[]) this.딟;
  }
}
