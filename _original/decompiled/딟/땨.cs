// Decompiled with JetBrains decompiler
// Type: 딟.땨
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace 딟
{
  internal abstract class 땨 : 땄.땷
  {
    public 땨([In] 땇 obj0, [In] string obj1, [In] string obj2)
      : base(obj0)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(string.Format("grant_type=password&username={0}&password={1}", (object) Uri.EscapeDataString(obj1), (object) Uri.EscapeDataString(obj2)));
      this.딟("POST", obj0.땋() + "/auth/token", bytes, (땄.땷.딸) 0);
      this.땄("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(obj0.땤() + ":" + obj0.땽())));
      ((딧.땋) this).딧();
    }

    protected bool 딟() => this.딝().땄() == HttpStatusCode.OK;

    protected bool 땄()
    {
      if (this.딝().땄() == HttpStatusCode.BadRequest)
      {
        ErrorData errorData = this.땓<ErrorData>();
        if (errorData != null && errorData.Error != null && errorData.Error == "invalid_grant")
          return true;
      }
      return false;
    }
  }
}
