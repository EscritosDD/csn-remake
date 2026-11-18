// Decompiled with JetBrains decompiler
// Type: 딧.땭
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.HTTP;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace 딧
{
  public class 땭 : IDisposable, 딝
  {
    public byte[] 딟;
    public string 딟;
    private Uri 딟;
    private Dictionary<string, List<string>> 딟 = new Dictionary<string, List<string>>();
    private static Dictionary<string, 땭> 딟 = new Dictionary<string, 땭>();

    public 땭([In] string obj0, [In] string obj1, [In] byte[] obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      this.딟 = new Uri(obj1);
      this.딟 = obj2;
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
      this.딟 = Guid.NewGuid().ToString();
      땭.딟.Add(this.딟, this);
    }

    public string 딟([In] string obj0)
    {
      obj0 = obj0.ToLower().Trim();
      return !this.딟.ContainsKey(obj0) ? string.Empty : this.딟[obj0][0];
    }

    public void 딟([In] string obj0, [In] string obj1)
    {
      obj0 = obj0.ToLower().Trim();
      obj1 = obj1.Trim();
      if (!this.딟.ContainsKey(obj0))
        this.딟[obj0] = new List<string>();
      this.딟[obj0].Clear();
      this.딟[obj0].Add(obj1);
    }

    public void 딟()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
      JSRequest jsRequest = new JSRequest();
      jsRequest.UniqueId = this.딟;
      jsRequest.Method = this.땃();
      jsRequest.Body = this.딟 != null ? Convert.ToBase64String(this.딟) : (string) null;
      jsRequest.Url = this.땄();
      jsRequest.Headers = new List<JSRequestHeader>();
      foreach (KeyValuePair<string, List<string>> keyValuePair in this.딟)
      {
        foreach (string str in keyValuePair.Value)
          jsRequest.Headers.Add(new JSRequestHeader()
          {
            Key = keyValuePair.Key,
            Value = str
          });
      }
      땓.딟("unity_http_send", 땾.땄((object) jsRequest), new Action<object>(땭.딟));
    }

    public static bool 딟([In] object obj0, [In] X509Certificate obj1, [In] X509Chain obj2, [In] SslPolicyErrors obj3) => true;

    public void Dispose() => 땭.딟.Remove(this.딟);

    [SpecialName]
    public string 땄() => this.딟.ToString();

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public bool 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땥 딢() => this.딟;

    public static void 딟([In] object obj0)
    {
      JSResponse jsResponse = 땾.딟<JSResponse>(obj0);
      땭 땭;
      if (!땭.딟.TryGetValue(jsResponse.UniqueId, out 땭))
        return;
      // ISSUE: reference to a compiler-generated method
      땭.딟((땥) new 딦(jsResponse));
      // ISSUE: reference to a compiler-generated method
      땭.딟(true);
    }
  }
}
