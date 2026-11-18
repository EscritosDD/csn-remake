// Decompiled with JetBrains decompiler
// Type: 딟.땐
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땄;

namespace 딟
{
  internal class 땐 : 땷
  {
    private 떆 딟;

    public 땐([In] 땇 obj0, [In] 떆 obj1, [In] string obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟("GET", obj0.땋() + "/files", (땷.딸) 0);
      this.딟(obj2);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
      {
        this.딟.딟 = this.땓<FileList>();
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
