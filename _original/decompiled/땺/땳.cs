// Decompiled with JetBrains decompiler
// Type: 땺.땳
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땺
{
  public static class 땳
  {
    private const string 딟 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string 딟([In] this string obj0)
    {
      int num = 0;
      for (int index = obj0.Length - 1; index >= 0; --index)
      {
        char ch = obj0[index];
        if (ch.딟() || ch == '%')
          ++num;
        else
          break;
      }
      if (num > 0)
        obj0 = obj0.Substring(0, obj0.Length - num);
      return obj0;
    }

    public static string[] 딟([In] this string[] obj0)
    {
      List<string> stringList = new List<string>();
      foreach (string str in obj0)
      {
        if (str != null && !(str == string.Empty))
          stringList.Add(str);
      }
      return stringList.ToArray();
    }

    public static bool 딟([In] this char obj0) => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(string.Empty + (object) obj0);

    public static float 땄([In] this string obj0)
    {
      float result;
      float.TryParse(땳.딟(obj0), out result);
      return result;
    }

    public static string 딟([In] this string obj0, [In] int obj1, [In] int obj2)
    {
      switch (obj1)
      {
        case 0:
          return obj0.PadRight(obj2);
        case 1:
          return obj0.PadRight(obj2);
        case 2:
          return obj0.PadLeft(obj2);
        default:
          return obj0;
      }
    }
  }
}
