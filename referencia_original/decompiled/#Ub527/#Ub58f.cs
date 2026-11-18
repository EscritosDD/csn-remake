// Decompiled with JetBrains decompiler
// Type: 딧.떏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  internal class 떏 : 땥
  {
    private Dictionary<string, string> 딟;

    public 떏([In] WWW obj0)
    {
      if (!string.IsNullOrEmpty(obj0.error))
        return;
      this.딟(obj0.bytes);
      this.딟 = obj0.responseHeaders;
      string[] strArray = this.딟("STATUS").Split(' ');
      int result;
      if (int.TryParse(strArray[1], out result))
        this.딟((HttpStatusCode) result);
      else
        this.딟(HttpStatusCode.BadRequest);
      // ISSUE: reference to a compiler-generated method
      this.땄(strArray[2]);
    }

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public HttpStatusCode 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] HttpStatusCode obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public byte[] 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] byte[] obj0) => this.딟 = obj0;

    public string 딟([In] string obj0)
    {
      string str;
      return this.딟.TryGetValue(obj0, out str) ? str : (string) null;
    }
  }
}
