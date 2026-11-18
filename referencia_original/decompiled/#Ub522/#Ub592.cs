// Decompiled with JetBrains decompiler
// Type: 딢.떒
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  internal class 떒 : 땬
  {
    private 땄.땞 딟;
    private 땄.땞 땄;
    private 땄.따 딟;
    private 땄.딚 딟;
    private 땄.땚 딟;

    public 떒([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] 땄.땞[] obj2, [In] List<땓.떀> obj3)
      : base(obj0, obj1, obj2, obj3)
    {
    }

    public override void 딧()
    {
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          this.땄 = this.딟.딟;
          this.딟 = ((딟.땇) GlobalAppData.떏()).딟(this.땄);
        }
        else
        {
          this.딟(땍.딧);
          base.딟.OnNetworkError((땄.땘) this.딟);
        }
        this.딟 = (땄.딚) null;
      }
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          base.딟.딟(this.땄);
          this.딟(땍.땄);
        }
        else
        {
          this.딟(땍.딧);
          base.딟.OnNetworkError((땄.땘) this.딟);
        }
        this.딟 = (땄.땚) null;
      }
      if (this.딟 != null && this.딟.땄())
      {
        if (this.딟.딧())
        {
          땚.딟((string) null);
          base.딟.딟(this.딟);
          base.딟.딧(false);
          this.딟 = GlobalAppData.떏().땟(this.딟.딟);
        }
        this.딟 = (땄.따) null;
      }
      if (this.딟 != null || this.딟 != null || this.딟 != null || this.딟() != 땍.딟)
        return;
      this.딢();
    }

    [SpecialName]
    public override 딬 땄() => base.딟.딝() == null ? (딬) new 땃.딟(base.딟, base.딟, base.딟) : (딬) new 땃.딢(base.딟, base.딟, base.딟);

    protected override void 딟([In] 땄.땞 obj0, [In] string obj1, [In] Dictionary<string, int> obj2)
    {
      this.딟 = obj0;
      this.딟 = GlobalAppData.떏().딟(obj0.딟, false);
    }
  }
}
