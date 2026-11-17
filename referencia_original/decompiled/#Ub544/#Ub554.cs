// Decompiled with JetBrains decompiler
// Type: 땄.땔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  internal class 땔 : 땷
  {
    private 딣 딟;

    public 땔([In] 딟.땇 obj0, [In] string obj1, [In] string obj2, [In] 딥 obj3, [In] 딣 obj4, [In] bool obj5)
      : base(obj0)
    {
      this.딟 = obj4;
      string stringToEscape = !obj5 ? obj2 : "sandbox:" + obj2;
      this.딟("DELETE", obj0.땋() + string.Format("/users/{0}/push_targets/{1}/{2}", (object) obj1, (object) (int) obj3, (object) Uri.EscapeUriString(stringToEscape)), 땷.딸.딟);
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
        this.딟.딧(true);
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
