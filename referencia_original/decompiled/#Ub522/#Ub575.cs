// Decompiled with JetBrains decompiler
// Type: 딢.땵
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
  public class 땵
  {
    private Action 딟;
    private Action 땄;
    private 떉[] 딟;
    private 땵.떐 딟;

    public 땵([In] ChallengePackAsset obj0, [In] Action obj1, [In] Action obj2)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땵.떈 떈 = new 땵.떈();
      // ISSUE: reference to a compiler-generated field
      떈.딟 = obj0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      if (obj1 == null)
        throw new ArgumentNullException("onError");
      if (obj2 == null)
        throw new ArgumentNullException("onReady");
      // ISSUE: reference to a compiler-generated method
      딢.땃 땃 = GlobalAppData.땼().딷().FirstOrDefault<딢.땃>(new Func<딢.땃, bool>(떈.딟));
      if (땃 != null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(땃.딧());
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.딟(떈.딟);
      this.딟 = obj1;
      this.땄 = obj2;
      this.딟 = 땵.떐.딟;
    }

    public void 딟()
    {
      switch (this.딟)
      {
        case 땵.떐.딟:
          this.땄();
          break;
        case 땵.떐.땄:
          this.딧();
          break;
      }
    }

    private void 땄()
    {
      if (!this.딶().땄())
      {
        this.딟 = 땵.떐.딢;
        this.딟();
      }
      else
        this.딟 = 땵.떐.땄;
    }

    private void 딧()
    {
      if (!this.딶().딧())
        return;
      // ISSUE: reference to a compiler-generated method
      this.땄(this.딶().딶());
      this.딟 = ((IEnumerable<string>) this.딶().ChallengeIds).Select<string, 떉>((Func<string, int, 떉>) ((obj0, obj1) => new 떉(obj0, obj1))).ToArray<떉>();
      this.딟 = 땵.떐.딧;
      this.땄();
    }

    [SpecialName]
    public 떉[] 딢() => this.딟;

    public 떉 딟([In] int obj0) => ((IEnumerable<떉>) this.딢()).FirstOrDefault<떉>(new Func<떉, bool>(new 땵.딹()
    {
      딟 = obj0
    }.딟));

    [CompilerGenerated]
    [SpecialName]
    public int 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public ChallengePackAsset 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땓() => this.딟;

    private enum 떐
    {
      딟,
      땄,
      딧,
      딢,
    }
  }
}
