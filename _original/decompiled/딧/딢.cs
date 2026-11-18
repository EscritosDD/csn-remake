// Decompiled with JetBrains decompiler
// Type: 딧.딢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 딢 : 땥
  {
    private List<byte[]> 딟;
    private Dictionary<string, List<string>> 딟 = new Dictionary<string, List<string>>();

    public 딢()
    {
      this.딟(HttpStatusCode.OK);
      // ISSUE: reference to a compiler-generated method
      this.땄("OK");
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

    private string 딟([In] Stream obj0)
    {
      List<byte> byteList = new List<byte>();
      while (true)
      {
        byte num = (byte) obj0.ReadByte();
        if ((int) num != (int) 딧.딧.땄[1])
          byteList.Add(num);
        else
          break;
      }
      return Encoding.ASCII.GetString(byteList.ToArray()).Trim();
    }

    private string[] 땄([In] Stream obj0)
    {
      string str = this.딟(obj0);
      if (str == string.Empty)
        return (string[]) null;
      int length = str.IndexOf(':');
      if (length == -1)
        return (string[]) null;
      return new string[2]
      {
        str.Substring(0, length).Trim(),
        str.Substring(length + 1).Trim()
      };
    }

    public byte[] 딢()
    {
      lock (this.딟)
      {
        if (this.딟.Count > 0)
        {
          byte[] numArray = this.딟[0];
          this.딟.RemoveAt(0);
          return numArray;
        }
      }
      return (byte[]) null;
    }

    public void 딧([In] Stream obj0)
    {
      string[] strArray1 = this.딟(obj0).Split(' ');
      int result;
      if (!int.TryParse(strArray1[1], out result))
        throw new 딶("Bad Status Code");
      this.딟((HttpStatusCode) result);
      // ISSUE: reference to a compiler-generated method
      this.땄(string.Join(" ", strArray1, 2, strArray1.Length - 2));
      this.딟.Clear();
      while (true)
      {
        string[] strArray2 = this.땄(obj0);
        if (strArray2 != null)
          this.딟(strArray2[0], strArray2[1]);
        else
          break;
      }
      if (this.딟("transfer-encoding") == "chunked")
      {
        this.딟 = new List<byte[]>();
        while (true)
        {
          string s = this.딟(obj0);
          if (!(s == "0"))
          {
            int count = int.Parse(s, NumberStyles.AllowHexSpecifier);
            byte[] buffer = new byte[count];
            obj0.Read(buffer, 0, count);
            lock (this.딟)
              this.딟.Add(buffer);
            obj0.ReadByte();
            obj0.ReadByte();
          }
          else
            break;
        }
        lock (this.딟)
          this.딟.Add(new byte[0]);
        while (true)
        {
          string[] strArray3 = this.땄(obj0);
          if (strArray3 != null)
            this.딟(strArray3[0], strArray3[1]);
          else
            break;
        }
        List<byte> byteList = new List<byte>();
        foreach (byte[] numArray in this.딟)
          byteList.AddRange((IEnumerable<byte>) numArray);
        this.딟(byteList.ToArray());
      }
      else
      {
        int length;
        try
        {
          length = int.Parse(this.딟("content-length"));
        }
        catch
        {
          length = 0;
        }
        if (length <= 0)
          return;
        int count = length;
        this.딟(new byte[length]);
        while (count > 0)
          count -= obj0.Read(this.딧(), length - count, count);
      }
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
