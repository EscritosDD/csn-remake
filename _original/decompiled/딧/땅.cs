// Decompiled with JetBrains decompiler
// Type: 딧.땅
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 땅
  {
    private const int 딟 = 0;
    private const int 땄 = 1;
    private const int 딧 = 2;
    private const int 딢 = 3;
    private const int 땃 = 4;
    private const int 딶 = 5;
    private const int 땓 = 6;
    private const int 땺 = 7;
    private const int 땥 = 8;
    private const int 딝 = 9;
    private const int 떎 = 10;
    private const int 떂 = 11;
    private const int 땭 = 2000;
    protected static int 딦 = -1;
    protected static string 딟 = string.Empty;

    public static object 딟([In] string obj0)
    {
      땅.딟 = obj0;
      if (obj0 == null)
        return (object) null;
      char[] charArray = obj0.ToCharArray();
      int num = 0;
      bool flag = true;
      object obj = 땅.딟(charArray, ref num, ref flag);
      땅.딦 = !flag ? num : -1;
      return obj;
    }

    public static string 딟([In] object obj0)
    {
      StringBuilder stringBuilder = new StringBuilder(2000);
      return 땅.땄(obj0, stringBuilder) ? stringBuilder.ToString() : (string) null;
    }

    public static bool 딟() => 땅.딦 == -1;

    public static int 땄() => 땅.딦;

    public static string 딧()
    {
      if (땅.딦 == -1)
        return string.Empty;
      int startIndex = 땅.딦 - 5;
      int num = 땅.딦 + 15;
      if (startIndex < 0)
        startIndex = 0;
      if (num >= 땅.딟.Length)
        num = 땅.딟.Length - 1;
      return 땅.딟.Substring(startIndex, num - startIndex + 1);
    }

    protected static Hashtable 딟([In] char[] obj0, [In] ref int obj1)
    {
      Hashtable hashtable = new Hashtable();
      땅.딶(obj0, ref obj1);
      bool flag1 = false;
      while (!flag1)
      {
        switch (땅.땄(obj0, obj1))
        {
          case 0:
            return (Hashtable) null;
          case 2:
            땅.딶(obj0, ref obj1);
            return hashtable;
          case 6:
            땅.딶(obj0, ref obj1);
            continue;
          default:
            string str = 땅.딧(obj0, ref obj1);
            if (str == null)
              return (Hashtable) null;
            if (땅.딶(obj0, ref obj1) != 5)
              return (Hashtable) null;
            bool flag2 = true;
            object obj = 땅.딟(obj0, ref obj1, ref flag2);
            if (!flag2)
              return (Hashtable) null;
            hashtable[(object) str] = obj;
            continue;
        }
      }
      return hashtable;
    }

    protected static ArrayList 땄([In] char[] obj0, [In] ref int obj1)
    {
      ArrayList arrayList = new ArrayList();
      땅.딶(obj0, ref obj1);
      bool flag1 = false;
      while (!flag1)
      {
        switch (땅.땄(obj0, obj1))
        {
          case 0:
            return (ArrayList) null;
          case 4:
            땅.딶(obj0, ref obj1);
            goto label_9;
          case 6:
            땅.딶(obj0, ref obj1);
            continue;
          default:
            bool flag2 = true;
            object obj = 땅.딟(obj0, ref obj1, ref flag2);
            if (!flag2)
              return (ArrayList) null;
            arrayList.Add(obj);
            continue;
        }
      }
label_9:
      return arrayList;
    }

    protected static object 딟([In] char[] obj0, [In] ref int obj1, [In] ref bool obj2)
    {
      switch (땅.땄(obj0, obj1))
      {
        case 1:
          return (object) 땅.딟(obj0, ref obj1);
        case 3:
          return (object) 땅.땄(obj0, ref obj1);
        case 7:
          return (object) 땅.딧(obj0, ref obj1);
        case 8:
          return (object) 땅.딢(obj0, ref obj1);
        case 9:
          땅.딶(obj0, ref obj1);
          return (object) bool.Parse("TRUE");
        case 10:
          땅.딶(obj0, ref obj1);
          return (object) bool.Parse("FALSE");
        case 11:
          땅.딶(obj0, ref obj1);
          return (object) null;
        default:
          obj2 = false;
          return (object) null;
      }
    }

    protected static string 딧([In] char[] obj0, [In] ref int obj1)
    {
      string empty = string.Empty;
      땅.땃(obj0, ref obj1);
      char[] chArray1 = obj0;
      int num1;
      obj1 = (num1 = obj1) + 1;
      int index1 = num1;
      char ch1 = chArray1[index1];
      bool flag = false;
      while (!flag && obj1 != obj0.Length)
      {
        char[] chArray2 = obj0;
        int num2;
        obj1 = (num2 = obj1) + 1;
        int index2 = num2;
        char ch2 = chArray2[index2];
        switch (ch2)
        {
          case '"':
            flag = true;
            goto label_17;
          case '\\':
            if (obj1 != obj0.Length)
            {
              char[] chArray3 = obj0;
              int num3;
              obj1 = (num3 = obj1) + 1;
              int index3 = num3;
              switch (chArray3[index3])
              {
                case '"':
                  empty += (string) (object) '"';
                  continue;
                case '/':
                  empty += (string) (object) '/';
                  continue;
                case '\\':
                  empty += (string) (object) '\\';
                  continue;
                case 'b':
                  empty += (string) (object) '\b';
                  continue;
                case 'f':
                  empty += (string) (object) '\f';
                  continue;
                case 'n':
                  empty += (string) (object) '\n';
                  continue;
                case 'r':
                  empty += (string) (object) '\r';
                  continue;
                case 't':
                  empty += (string) (object) '\t';
                  continue;
                case 'u':
                  if (obj0.Length - obj1 >= 4)
                  {
                    char[] chArray4 = new char[4];
                    Array.Copy((Array) obj0, obj1, (Array) chArray4, 0, 4);
                    uint num4 = uint.Parse(new string(chArray4), NumberStyles.HexNumber);
                    empty += char.ConvertFromUtf32((int) num4);
                    obj1 += 4;
                    continue;
                  }
                  goto label_17;
                default:
                  continue;
              }
            }
            else
              goto label_17;
          default:
            empty += (string) (object) ch2;
            continue;
        }
      }
label_17:
      return !flag ? (string) null : empty;
    }

    protected static double 딢([In] char[] obj0, [In] ref int obj1)
    {
      땅.땃(obj0, ref obj1);
      int num = 땅.딟(obj0, obj1);
      int length = num - obj1 + 1;
      char[] chArray = new char[length];
      Array.Copy((Array) obj0, obj1, (Array) chArray, 0, length);
      obj1 = num + 1;
      return double.Parse(new string(chArray));
    }

    protected static int 딟([In] char[] obj0, [In] int obj1)
    {
      int index = obj1;
      while (index < obj0.Length && "0123456789+-.eE".IndexOf(obj0[index]) != -1)
        ++index;
      return index - 1;
    }

    protected static void 땃([In] char[] obj0, [In] ref int obj1)
    {
      while (obj1 < obj0.Length && " \t\n\r".IndexOf(obj0[obj1]) != -1)
        ++obj1;
    }

    protected static int 땄([In] char[] obj0, [In] int obj1)
    {
      int num = obj1;
      return 땅.딶(obj0, ref num);
    }

    protected static int 딶([In] char[] obj0, [In] ref int obj1)
    {
      땅.땃(obj0, ref obj1);
      if (obj1 == obj0.Length)
        return 0;
      char ch1 = obj0[obj1];
      ++obj1;
      char ch2 = ch1;
      switch (ch2)
      {
        case '"':
          return 7;
        case ',':
          return 6;
        case '-':
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
          return 8;
        case ':':
          return 5;
        default:
          switch (ch2)
          {
            case '[':
              return 3;
            case ']':
              return 4;
            default:
              switch (ch2)
              {
                case '{':
                  return 1;
                case '}':
                  return 2;
                default:
                  --obj1;
                  int num = obj0.Length - obj1;
                  if (num >= 5 && obj0[obj1] == 'f' && obj0[obj1 + 1] == 'a' && obj0[obj1 + 2] == 'l' && obj0[obj1 + 3] == 's' && obj0[obj1 + 4] == 'e')
                  {
                    obj1 += 5;
                    return 10;
                  }
                  if (num >= 4 && obj0[obj1] == 't' && obj0[obj1 + 1] == 'r' && obj0[obj1 + 2] == 'u' && obj0[obj1 + 3] == 'e')
                  {
                    obj1 += 4;
                    return 9;
                  }
                  if (num < 4 || obj0[obj1] != 'n' || obj0[obj1 + 1] != 'u' || obj0[obj1 + 2] != 'l' || obj0[obj1 + 3] != 'l')
                    return 0;
                  obj1 += 4;
                  return 11;
              }
          }
      }
    }

    protected static bool 딟([In] object obj0, [In] StringBuilder obj1)
    {
      switch (obj0)
      {
        case Hashtable _:
          return 땅.딟((Hashtable) obj0, obj1);
        case ArrayList _:
          return 땅.딟((ArrayList) obj0, obj1);
        default:
          return false;
      }
    }

    protected static bool 딟([In] Hashtable obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      IDictionaryEnumerator enumerator = obj0.GetEnumerator();
      bool flag = true;
      while (enumerator.MoveNext())
      {
        string str = enumerator.Key.ToString();
        object obj = enumerator.Value;
        if (!flag)
          obj1.Append(", ");
        땅.딟(str, obj1);
        obj1.Append(":");
        if (!땅.땄(obj, obj1))
          return false;
        flag = false;
      }
      obj1.Append("}");
      return true;
    }

    protected static bool 딟([In] Dictionary<string, string> obj0, [In] StringBuilder obj1)
    {
      obj1.Append("{");
      bool flag = true;
      foreach (KeyValuePair<string, string> keyValuePair in obj0)
      {
        if (!flag)
          obj1.Append(", ");
        땅.딟(keyValuePair.Key, obj1);
        obj1.Append(":");
        땅.딟(keyValuePair.Value, obj1);
        flag = false;
      }
      obj1.Append("}");
      return true;
    }

    protected static bool 딟([In] ArrayList obj0, [In] StringBuilder obj1)
    {
      obj1.Append("[");
      bool flag = true;
      for (int index = 0; index < obj0.Count; ++index)
      {
        object obj = obj0[index];
        if (!flag)
          obj1.Append(", ");
        if (!땅.땄(obj, obj1))
          return false;
        flag = false;
      }
      obj1.Append("]");
      return true;
    }

    protected static bool 땄([In] object obj0, [In] StringBuilder obj1)
    {
      if (obj0 == null)
        obj1.Append("null");
      else if (obj0.GetType().IsArray)
      {
        땅.딟(new ArrayList((ICollection) obj0), obj1);
      }
      else
      {
        switch (obj0)
        {
          case string _:
            땅.딟((string) obj0, obj1);
            break;
          case char ch3:
            땅.딟(Convert.ToString(ch3), obj1);
            break;
          case Decimal num3:
            땅.딟(Convert.ToString(num3), obj1);
            break;
          case Hashtable _:
            땅.딟((Hashtable) obj0, obj1);
            break;
          case Dictionary<string, string> _:
            땅.딟((Dictionary<string, string>) obj0, obj1);
            break;
          case ArrayList _:
            땅.딟((ArrayList) obj0, obj1);
            break;
          case bool flag5 when flag5:
            obj1.Append("true");
            break;
          case bool flag6 when !flag6:
            obj1.Append("false");
            break;
          default:
            if (!obj0.GetType().IsPrimitive)
              return false;
            땅.딟(Convert.ToDouble(obj0), obj1);
            break;
        }
      }
      return true;
    }

    protected static void 딟([In] string obj0, [In] StringBuilder obj1)
    {
      obj1.Append("\"");
      foreach (char ch in obj0.ToCharArray())
      {
        switch (ch)
        {
          case '\b':
            obj1.Append("\\b");
            break;
          case '\t':
            obj1.Append("\\t");
            break;
          case '\n':
            obj1.Append("\\n");
            break;
          case '\f':
            obj1.Append("\\f");
            break;
          case '\r':
            obj1.Append("\\r");
            break;
          case '"':
            obj1.Append("\\\"");
            break;
          case '\\':
            obj1.Append("\\\\");
            break;
          default:
            int int32 = Convert.ToInt32(ch);
            if (int32 >= 32 && int32 <= 126)
            {
              obj1.Append(ch);
              break;
            }
            obj1.Append("\\u" + Convert.ToString(int32, 16).PadLeft(4, '0'));
            break;
        }
      }
      obj1.Append("\"");
    }

    protected static void 딟([In] double obj0, [In] StringBuilder obj1) => obj1.Append(Convert.ToString(obj0));
  }
}
