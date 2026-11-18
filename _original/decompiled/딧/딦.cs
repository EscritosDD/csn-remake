// Decompiled with JetBrains decompiler
// Type: 딧.딦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.HTTP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  internal class 딦 : 땥
  {
    private Dictionary<string, List<string>> 딟 = new Dictionary<string, List<string>>();
    private static string[] 딟 = new string[1]{ "\r\n" };

    public 딦([In] JSResponse obj0)
    {
      this.딟((HttpStatusCode) obj0.Status);
      // ISSUE: reference to a compiler-generated method
      this.딧(obj0.StatusText);
      this.땄(obj0.HeadersText);
      this.딟(Convert.FromBase64String(obj0.Response));
    }

    public void 땄([In] string obj0)
    {
      foreach (string str in obj0.Split(딦.딟, StringSplitOptions.None))
      {
        int length = str.IndexOf(':');
        if (length != -1)
          this.딟(str.Substring(0, length).Trim(), str.Substring(length + 1).Trim());
      }
    }

    private void 딟([In] string obj0, [In] string obj1)
    {
      obj0 = obj0.ToLower().Trim();
      obj1 = obj1.Trim();
      if (!this.딟.ContainsKey(obj0))
        this.딟[obj0] = new List<string>();
      this.딟[obj0].Add(obj1);
    }

    public string 딟([In] string obj0)
    {
      obj0 = obj0.ToLower().Trim();
      return !this.딟.ContainsKey(obj0) ? string.Empty : this.딟[obj0][this.딟[obj0].Count - 1];
    }

    [CompilerGenerated]
    [SpecialName]
    public HttpStatusCode 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] HttpStatusCode obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public byte[] 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] byte[] obj0) => this.딟 = obj0;
  }
}
