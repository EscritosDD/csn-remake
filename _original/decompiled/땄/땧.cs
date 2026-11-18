// Decompiled with JetBrains decompiler
// Type: 땄.땧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땧 : 땷
  {
    private 딼 딟;

    public 땧([In] 딟.땇 obj0, [In] 딼 obj1, [In] string obj2, [In] string obj3)
      : base(obj0)
    {
      this.딟 = obj1;
      string str1 = 딧.땾.땄((object) new Dictionary<string, object>()
      {
        {
          "private",
          (object) true
        },
        {
          "data",
          (object) 딟.딥.딟(obj2)
        }
      });
      string str2 = string.Format("/users/{0}/files/profile.data", (object) obj3);
      this.딟("PUT", obj0.땋() + str2, str1, 땷.딸.딟);
      ((딧.땋) this).땃();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.OK)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
