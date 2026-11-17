// Decompiled with JetBrains decompiler
// Type: 딧.떇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  public class 떇
  {
    private static StringBuilder 딟 = new StringBuilder(128);

    private static bool 딟([In] char obj0) => obj0 == ' ' || obj0 == '\t' || obj0 == '\r' || obj0 == '\n';

    private static bool 딟([In] string obj0, [In] ref int obj1)
    {
      while (obj1 < obj0.Length && 떇.딟(obj0[obj1]))
        ++obj1;
      return obj1 < obj0.Length;
    }

    private static bool 딟([In] string obj0, [In] ref int obj1, out List<object> _param2)
    {
      _param2 = (List<object>) null;
      if (!떇.딟(obj0, ref obj1) || obj0[obj1] != '[')
        return false;
      ++obj1;
      if (!떇.딟(obj0, ref obj1))
        return false;
      _param2 = new List<object>();
      if (obj0[obj1] == ']')
      {
        ++obj1;
      }
      else
      {
        object obj;
        while (떇.딟(obj0, ref obj1, out obj))
        {
          _param2.Add(obj);
          if (!떇.딟(obj0, ref obj1))
            return false;
          if (obj0[obj1] == ',')
          {
            ++obj1;
          }
          else
          {
            if (obj0[obj1] != ']')
              return false;
            ++obj1;
            break;
          }
        }
      }
      return true;
    }

    private static bool 땄([In] string obj0, [In] ref int obj1)
    {
      if (!떇.딟(obj0, ref obj1) || obj0[obj1] != '"')
        return false;
      ++obj1;
      떇.딟.Length = 0;
      while (obj1 != obj0.Length)
      {
        if (obj0[obj1] == '\\')
        {
          ++obj1;
          if (obj1 == obj0.Length)
            return false;
          if (obj0[obj1] == '"')
          {
            떇.딟.Append('"');
            ++obj1;
          }
          else if (obj0[obj1] == '\\')
          {
            떇.딟.Append('\\');
            ++obj1;
          }
          else if (obj0[obj1] == '/')
          {
            떇.딟.Append('/');
            ++obj1;
          }
          else if (obj0[obj1] == 'b')
          {
            떇.딟.Append('\b');
            ++obj1;
          }
          else if (obj0[obj1] == 'f')
          {
            떇.딟.Append('\f');
            ++obj1;
          }
          else if (obj0[obj1] == 'n')
          {
            떇.딟.Append('\n');
            ++obj1;
          }
          else if (obj0[obj1] == 'r')
          {
            떇.딟.Append('\r');
            ++obj1;
          }
          else if (obj0[obj1] == 't')
          {
            떇.딟.Append('\t');
            ++obj1;
          }
          else
          {
            if (obj0[obj1] != 'u')
              return false;
            ++obj1;
            if (obj0.Length - obj1 < 4)
              return false;
            uint result = 0;
            if (!uint.TryParse(obj0.Substring(obj1, 4), NumberStyles.HexNumber, (IFormatProvider) null, out result))
              return false;
            떇.딟.Append((char) result);
            obj1 += 4;
          }
        }
        else
        {
          if (obj0[obj1] == '"')
          {
            ++obj1;
            return true;
          }
          떇.딟.Append(obj0[obj1]);
          ++obj1;
        }
      }
      return false;
    }

    private static bool 딟([In] string obj0, [In] ref int obj1, out object _param2)
    {
      _param2 = (object) null;
      if (!떇.딟(obj0, ref obj1))
        return false;
      if (떇.땄(obj0, ref obj1))
      {
        _param2 = (object) 떇.딟.ToString();
        return true;
      }
      if (떇.땄(obj0, ref obj1, out _param2))
        return true;
      _param2 = (object) 떇.딧(obj0, ref obj1);
      if (_param2 != null)
        return true;
      List<object> objectList;
      if (떇.딟(obj0, ref obj1, out objectList))
      {
        _param2 = (object) objectList;
        return true;
      }
      int num = obj0.Length - obj1;
      if (num >= 4)
      {
        if (obj0[obj1] == 't' && obj0[obj1 + 1] == 'r' && obj0[obj1 + 2] == 'u' && obj0[obj1 + 3] == 'e')
        {
          _param2 = (object) "True";
          obj1 += 4;
          return true;
        }
        if (obj0[obj1] == 'n' && obj0[obj1 + 1] == 'u' && obj0[obj1 + 2] == 'l' && obj0[obj1 + 3] == 'l')
        {
          _param2 = (object) null;
          obj1 += 4;
          return true;
        }
        if (num >= 5 && obj0[obj1] == 'f' && obj0[obj1 + 1] == 'a' && obj0[obj1 + 2] == 'l' && obj0[obj1 + 3] == 's' && obj0[obj1 + 4] == 'e')
        {
          _param2 = (object) "false";
          obj1 += 5;
          return true;
        }
      }
      return false;
    }

    private static bool 땄([In] string obj0, [In] ref int obj1, out object _param2)
    {
      _param2 = (object) null;
      if (!떇.딟(obj0, ref obj1))
        return false;
      int startIndex = obj1;
      if (obj0[obj1] == '-')
        ++obj1;
      if (obj0.Length == obj1)
        return false;
      if (obj0[obj1] == '0')
      {
        ++obj1;
      }
      else
      {
        if (!char.IsDigit(obj0[obj1]))
          return false;
        ++obj1;
        while (obj0.Length != obj1)
        {
          if (char.IsDigit(obj0[obj1]))
            ++obj1;
          else
            goto label_15;
        }
        return false;
      }
label_15:
      if (obj0.Length == obj1)
        return false;
      bool flag = true;
      if (obj0[obj1] == '.')
      {
        flag = false;
        ++obj1;
        if (!char.IsDigit(obj0[obj1]))
          return false;
        while (obj0.Length != obj1)
        {
          if (char.IsDigit(obj0[obj1]))
            ++obj1;
          else
            goto label_24;
        }
        return false;
      }
label_24:
      if (obj0.Length == obj1)
        return false;
      if (obj0[obj1] == 'e' || obj0[obj1] == 'E')
      {
        ++obj1;
        if (obj0.Length == obj1)
          return false;
        if (obj0[obj1] == '+' || obj0[obj1] == '-')
          ++obj1;
        if (obj0.Length == obj1 || !char.IsDigit(obj0[obj1]))
          return false;
        while (obj0.Length != obj1)
        {
          if (char.IsDigit(obj0[obj1]))
            ++obj1;
          else
            goto label_37;
        }
        return false;
      }
label_37:
      string s = obj0.Substring(startIndex, obj1 - startIndex);
      _param2 = !flag ? (object) double.Parse(s) : (object) long.Parse(s);
      return true;
    }

    public static object 딟([In] string obj0)
    {
      int num = 0;
      object obj;
      return !떇.딟(obj0, ref num, out obj) ? (object) null : obj;
    }

    private static Dictionary<string, object> 딧([In] string obj0, [In] ref int obj1)
    {
      if (!떇.딟(obj0, ref obj1))
        return (Dictionary<string, object>) null;
      if (obj0[obj1] != '{')
        return (Dictionary<string, object>) null;
      ++obj1;
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      if (!떇.딟(obj0, ref obj1))
        return (Dictionary<string, object>) null;
      if (obj0[obj1] == '}')
      {
        ++obj1;
      }
      else
      {
        while (떇.땄(obj0, ref obj1))
        {
          string key = 떇.딟.ToString();
          if (!떇.딟(obj0, ref obj1))
            return (Dictionary<string, object>) null;
          if (obj0[obj1] != ':')
            return (Dictionary<string, object>) null;
          ++obj1;
          object obj;
          if (!떇.딟(obj0, ref obj1, out obj))
            return (Dictionary<string, object>) null;
          dictionary[key] = obj;
          if (!떇.딟(obj0, ref obj1))
            return (Dictionary<string, object>) null;
          if (obj0[obj1] == ',')
          {
            ++obj1;
          }
          else
          {
            if (obj0[obj1] != '}')
              return (Dictionary<string, object>) null;
            ++obj1;
            goto label_23;
          }
        }
        return (Dictionary<string, object>) null;
      }
label_23:
      return dictionary;
    }
  }
}
