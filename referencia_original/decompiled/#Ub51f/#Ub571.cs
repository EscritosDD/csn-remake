// Decompiled with JetBrains decompiler
// Type: 딟.땱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using 땄;

namespace 딟
{
  internal class 땱 : 땷
  {
    private 땣 딟;

    public 땱([In] 땇 obj0, [In] string obj1, [In] string obj2, [In] 땣 obj3)
      : base(obj0)
    {
      this.딟 = obj3;
      this.딟("PUT", obj0.땋() + string.Format("/users/{0}/friends/{1}", (object) obj1, (object) obj2), 땷.딸.딟);
      this.땄("Content-Length", "0");
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
        this.딟.딧(true);
      else if (this.딝().땄() == HttpStatusCode.Forbidden)
      {
        switch (((땄.땘) this.딟).딟)
        {
          case 땑.땓:
            this.딟.땄 = true;
            break;
          case 땑.땺:
            this.딟.딟 = true;
            break;
          case 땑.땥:
            this.딟.딧 = true;
            break;
        }
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
