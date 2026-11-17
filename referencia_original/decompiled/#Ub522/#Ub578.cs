// Decompiled with JetBrains decompiler
// Type: 딢.땸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  internal class 땸 : 딬
  {
    private SquadSelectionScreenHandlerNew 딟;
    private 딧.땧 딟;
    private List<땓.떀> 딟;
    private 땄.땞[] 딟;
    private 땄.땕 딟;

    public 땸([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] List<땓.떀> obj2)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟 = GlobalAppData.떏().딟(!obj1.딶() ? obj1.딧() : (string) null, 0, obj1.떂(), obj1.땓(), obj1.땃());
    }

    public void 딧()
    {
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(땍.땄);
        this.딟 = this.딟.딟;
        GlobalAppData.딟<땄.땞>(this.딟.딟);
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(땍.딧);
        this.딟.OnNetworkError((땄.땘) this.딟);
      }
      this.딟 = (땄.땕) null;
    }

    [CompilerGenerated]
    [SpecialName]
    public 땍 딟() => this.딟;

    [SpecialName]
    public 딬 땄() => GlobalAppData.딢().GenericData.PlayFirstTurnImmediately ? (딬) new 떒(this.딟, this.딟, this.딟, this.딟) : (딬) new 떊(this.딟, this.딟, this.딟, this.딟);
  }
}
