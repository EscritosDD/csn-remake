// Decompiled with JetBrains decompiler
// Type: 땄.땵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땵 : 땷
  {
    private 땛 딟;

    public 땵([In] 딟.땇 obj0, [In] 땛 obj1, [In] string obj2, [In] string obj3, [In] string obj4)
      : base(obj0)
    {
      this.딟 = obj1;
      this.딟.딟 = obj3;
      this.딟("PUT", obj0.땋() + string.Format("/users/{0}/facebook", (object) obj2), string.Format("auth_data.id={0}&auth_data.access_token={1}", (object) obj3, (object) obj4), 땷.딸.딟);
      ((딧.땋) this).딧();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.Created)
      {
        if (this.딶().땺() != this.딟.딟)
        {
          this.딟.딟 = true;
          this.딶().딧(this.딟.딟);
        }
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
