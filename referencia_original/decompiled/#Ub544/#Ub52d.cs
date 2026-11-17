// Decompiled with JetBrains decompiler
// Type: 땄.딭
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 땄
{
  internal class 딭 : 땷
  {
    private new string 딟;
    private string 땄;
    private 딤 딟;

    public 딭([In] 딟.땇 obj0, [In] 딤 obj1, [In] string obj2, [In] string obj3)
      : base(obj0)
    {
      this.딟 = obj1;
      this.땄 = obj0.땓();
      this.딟 = obj2;
      byte[] numArray = (byte[]) null;
      if (!string.IsNullOrEmpty(obj2) && !string.IsNullOrEmpty(obj3))
        numArray = Encoding.UTF8.GetBytes(string.Format("email_address={0}&password={1}", (object) Uri.EscapeDataString(obj2), (object) Uri.EscapeDataString(obj3)));
      else if (!string.IsNullOrEmpty(obj2))
        numArray = Encoding.UTF8.GetBytes(string.Format("email_address={0}", (object) Uri.EscapeDataString(obj2)));
      else if (!string.IsNullOrEmpty(obj3))
        numArray = Encoding.UTF8.GetBytes(string.Format("password={0}", (object) Uri.EscapeDataString(obj3)));
      this.딟("POST", obj0.땋() + "/users/me?extended=true", numArray, 땷.딸.딟);
      this.딧("PATCH");
      ((딧.땋) this).딧();
    }

    public override void 딟()
    {
      if (this.딝().땄() == HttpStatusCode.NoContent)
      {
        if (!string.IsNullOrEmpty(this.딟))
          this.딶().딢(this.땄, this.딟);
        this.딟.딧(true);
      }
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땘 딧() => (땘) this.딟;
  }
}
