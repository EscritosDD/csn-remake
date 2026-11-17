// Decompiled with JetBrains decompiler
// Type: 땃.딧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  internal class 딧 : 딢.딬
  {
    private 땄.따 딟;
    private 땄.딚 딟;
    private 땄.땚 딟;
    private SquadSelectionScreenHandlerNew 딟;
    private 딧.땧 딟;
    private List<땓.떀> 딟;

    public 딧([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] List<땓.떀> obj2)
    {
      this.딟 = obj0;
      this.딟 = obj1.딟();
      this.딟 = obj2;
      this.딟 = GlobalAppData.떏().딟(obj1.딝().딟, obj1.떎());
    }

    public void 딧()
    {
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          this.딟 = GlobalAppData.떏().땟(this.딟.딝().딟);
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(딢.땍.딧);
          this.딟.OnNetworkError((땄.땘) this.딟);
        }
        this.딟 = (땄.따) null;
      }
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          this.딟.딟(this.딟.딟);
          this.딟 = ((딟.땇) GlobalAppData.떏()).딟(this.딟.딝());
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(딢.땍.딧);
          this.딟.OnNetworkError((땄.땘) this.딟);
        }
        this.딟 = (땄.딚) null;
      }
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(딢.땍.땄);
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(딢.땍.딧);
        this.딟.OnNetworkError((땄.땘) this.딟);
      }
      this.딟 = (땄.땚) null;
    }

    [CompilerGenerated]
    [SpecialName]
    public 딢.땍 딟() => this.딟;

    [SpecialName]
    public 딢.딬 땄() => (딢.딬) new 땃.딢(this.딟, this.딟, this.딟);
  }
}
