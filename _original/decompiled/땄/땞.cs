// Decompiled with JetBrains decompiler
// Type: 땄.땞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 땞
  {
    public int 딟;
    public int 땄;
    public int 딧;
    public DateTime 딟;
    public 떇 딟;
    public string 딟;
    public 딟.딺 딟;
    public 떇[] 딟;
    public 땉[] 딟;
    public 땈 딟;

    public 땞([In] TurnBasedSessionData obj0, [In] Func<Dictionary<string, object>, 땈> obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땞.땜 땜 = new 땞.땜();
      // ISSUE: reference to a compiler-generated field
      땜.딟 = obj0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      // ISSUE: reference to a compiler-generated field
      this.딟 = 땜.딟.FilledPublicSlots;
      // ISSUE: reference to a compiler-generated field
      this.땄 = 땜.딟.FilledPrivateSlots;
      // ISSUE: reference to a compiler-generated field
      this.딟 = 땜.딟.State;
      // ISSUE: reference to a compiler-generated field
      this.딧 = 땜.딟.NumTurns;
      // ISSUE: reference to a compiler-generated field
      this.딟 = 땜.딟.Id;
      // ISSUE: reference to a compiler-generated field
      this.딟 = 땜.딟.UpdatedAtTime;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.딟 = ((IEnumerable<SessionUserData>) 땜.딟.Users).Select<SessionUserData, 떇>(new Func<SessionUserData, 떇>(땜.딟)).ToArray<떇>();
      // ISSUE: reference to a compiler-generated method
      this.딟 = ((IEnumerable<떇>) this.딟).Where<떇>(new Func<떇, bool>(땜.딟)).FirstOrDefault<떇>();
      // ISSUE: reference to a compiler-generated field
      this.딟 = obj1(땜.딟.Attributes);
    }

    public bool 딟([In] string obj0) => ((IEnumerable<떇>) this.딟).Where<떇>(new Func<떇, bool>(new 땞.땪()
    {
      딟 = obj0
    }.딟)).Any<떇>();
  }
}
