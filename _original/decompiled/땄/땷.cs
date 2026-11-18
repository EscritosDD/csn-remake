// Decompiled with JetBrains decompiler
// Type: 땄.땷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 땄
{
  public abstract class 땷 : 딧.땋
  {
    public const string 딟 = "x-fireteam-aes";

    public 땷([In] 딟.땇 obj0)
      : base((딧.땃) obj0)
    {
    }

    [SpecialName]
    public 딟.땇 딶() => base.딟 as 딟.땇;

    public 딟.땑 땓()
    {
      ErrorData errorData = this.땓<ErrorData>();
      return errorData != null ? errorData.Code : 딟.땑.딟;
    }

    protected void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] 땷.딸 obj3) => this.딟(obj0, obj1, Encoding.UTF8.GetBytes(obj2), obj3);

    protected void 딟([In] string obj0, [In] string obj1, [In] 땷.딸 obj2) => this.딟(obj0, obj1, (byte[]) null, obj2);

    protected void 딟([In] string obj0, [In] string obj1, [In] byte[] obj2, [In] 땷.딸 obj3)
    {
      bool flag1 = (obj3 & 땷.딸.딧) != (땷.딸) 0;
      bool flag2 = (obj3 & 땷.딸.땄) == (땷.딸) 0 && !flag1;
      bool flag3 = (obj3 & 땷.딸.딟) != (땷.딸) 0;
      bool flag4 = flag2 && obj2 != null;
      if (flag4)
        obj2 = 딟.떓.딟(this.딶().땢(), obj2);
      this.딟(obj0, obj1, obj2, flag1);
      base.딟.딟("Accept-Language", 딧.딪.딟(딧.딪.땄()));
      if (flag4)
        base.딟.딟("Content-Encoding", "x-fireteam-aes");
      if (flag2)
        base.딟.딟("X-Fireteam-Accept-Encoding", "x-fireteam-aes");
      if (!flag3)
        return;
      base.딟.땄((딧.땋) this);
    }

    public override void 딢()
    {
      if (base.딟.딢() == null)
        return;
      this.딟((딧.땽) new 땁(this.딶(), base.딟.딢()));
    }

    [SpecialName]
    public abstract 땘 딧();

    [SpecialName]
    public virtual bool 땃() => false;

    [Flags]
    public enum 딸
    {
      딟 = 1,
      땄 = 2,
      딧 = 4,
    }
  }
}
