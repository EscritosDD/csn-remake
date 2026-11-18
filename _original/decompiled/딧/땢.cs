// Decompiled with JetBrains decompiler
// Type: 딧.땢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  public struct 땢
  {
    private List<KeyValuePair<string, string>> 딟;

    public static 땢 딟() => new 땢()
    {
      딟 = new List<KeyValuePair<string, string>>()
    };

    public 땢 딟([In] string obj0, [In] string obj1)
    {
      this.딟.Add(new KeyValuePair<string, string>(obj0, obj1));
      return this;
    }

    public string 땄() => this.딟(false);

    public byte[] 딧() => Encoding.UTF8.GetBytes(this.딟(true));

    private string 딟([In] bool obj0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string format = "{0}={1}";
      foreach (KeyValuePair<string, string> keyValuePair in this.딟)
      {
        string str1 = !obj0 ? Uri.EscapeUriString(keyValuePair.Key) : Uri.EscapeDataString(keyValuePair.Key);
        string str2 = !obj0 ? Uri.EscapeUriString(keyValuePair.Value) : Uri.EscapeDataString(keyValuePair.Value);
        stringBuilder.AppendFormat(format, (object) str1, (object) str2);
        format = "&{0}={1}";
      }
      return stringBuilder.ToString();
    }
  }
}
