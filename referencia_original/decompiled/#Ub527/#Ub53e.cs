// Decompiled with JetBrains decompiler
// Type: 딧.딾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  public class 딾
  {
    private Dictionary<Type, 딾.땚> 딟 = new Dictionary<Type, 딾.땚>();

    public 딾()
    {
      this.딟(typeof (bool), (Action<StringBuilder, object>) ((obj0, obj1) => 딾.딟(obj0, (bool) obj1)));
      this.딟(typeof (double), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((double) obj1)));
      this.딟(typeof (float), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((float) obj1)));
      this.딟(typeof (byte), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((byte) obj1)));
      this.딟(typeof (ushort), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((ushort) obj1)));
      this.딟(typeof (uint), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((uint) obj1)));
      this.딟(typeof (ulong), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((ulong) obj1)));
      this.딟(typeof (sbyte), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((sbyte) obj1)));
      this.딟(typeof (short), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((short) obj1)));
      this.딟(typeof (int), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((int) obj1)));
      this.딟(typeof (long), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((long) obj1)));
      this.딟(typeof (char), (Action<StringBuilder, object>) ((obj0, obj1) => obj0.Append((char) obj1)));
      this.딟(typeof (string), (Action<StringBuilder, object>) ((obj0, obj1) => 딾.딟(obj0, obj1 as string)));
      this.딟(typeof (Guid), (Action<StringBuilder, object>) ((obj0, obj1) => this.딟(obj0, (Guid) obj1)));
    }

    private void 딟([In] StringBuilder obj0, [In] Guid obj1) => obj0.AppendFormat("\"{0}\"", (object) obj1);

    protected void 딟([In] StringBuilder obj0, [In] object obj1, [In] Action<StringBuilder, object> obj2)
    {
      if (!(obj1 is IDictionary dictionary))
      {
        obj0.Append("null");
      }
      else
      {
        obj0.Append("{");
        bool flag = true;
        foreach (DictionaryEntry dictionaryEntry in dictionary)
        {
          if (!flag)
            obj0.Append(",");
          flag = false;
          obj0.AppendFormat("\"{0}\":", dictionaryEntry.Key);
          obj2(obj0, dictionaryEntry.Value);
        }
        obj0.Append("}");
      }
    }

    internal static bool 딟([In] Type obj0) => obj0.IsPrimitive ? (object) obj0 != (object) typeof (UIntPtr) && (object) obj0 != (object) typeof (IntPtr) : obj0.IsSerializable || typeof (IEnumerable).IsAssignableFrom(obj0) || typeof (IDictionary).IsAssignableFrom(obj0);

    internal static void 딟([In] StringBuilder obj0, [In] object obj1) => obj0.Append(Convert.ToInt32(obj1));

    internal static void 땄([In] StringBuilder obj0, [In] object obj1) => obj0.Append(Convert.ToInt64(obj1));

    internal static void 딧([In] StringBuilder obj0, [In] object obj1) => 딾.딟(obj0, obj1.ToString());

    private 딾.땚 땄([In] Type obj0)
    {
      딾.땚 땚1;
      if (this.딟.TryGetValue(obj0, out 땚1))
        return 땚1;
      딾.땚 땚2 = new 딾.땚();
      this.딟.Add(obj0, 땚2);
      땚2.딟(this.딢(obj0));
      return 땚2;
    }

    internal 딾.땚 딧([In] Type obj0) => obj0.IsSealed ? this.땄(obj0) : throw new InvalidOperationException();

    private Action<StringBuilder, object> 딢([In] Type obj0_1)
    {
      if (obj0_1.IsEnum)
        return (object) Enum.GetUnderlyingType(obj0_1) == (object) typeof (long) ? new Action<StringBuilder, object>(딾.땄) : new Action<StringBuilder, object>(딾.딟);
      if (obj0_1.IsValueType)
        return new Action<StringBuilder, object>(딾.딧);
      Type type1 = obj0_1.GetInterface(typeof (IDictionary<,>).FullName);
      if ((object) type1 != null && (object) type1.GetGenericArguments()[0] == (object) typeof (string))
      {
        Type genericArgument = type1.GetGenericArguments()[1];
        if (!genericArgument.IsSealed)
          return (Action<StringBuilder, object>) ((obj0_5, obj1) => this.딟(obj0_5, obj1, new Action<StringBuilder, object>(this.딢)));
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        return new Action<StringBuilder, object>(new 딾.딮()
        {
          딟 = this,
          딟 = this.딧(genericArgument)
        }.딟);
      }
      Type type2 = obj0_1.GetInterface(typeof (IEnumerable<>).FullName);
      if ((object) type2 != null)
      {
        Type genericArgument = type2.GetGenericArguments()[0];
        if (!genericArgument.IsSealed)
          return (Action<StringBuilder, object>) ((obj0_9, obj1) => this.땄(obj0_9, obj1, new Action<StringBuilder, object>(this.딢)));
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        return new Action<StringBuilder, object>(new 딾.딯()
        {
          딟 = this,
          딟 = this.딧(genericArgument)
        }.딟);
      }
      if (typeof (IDictionary).IsAssignableFrom(obj0_1))
        return (Action<StringBuilder, object>) ((obj0_11, obj1) => this.딟(obj0_11, obj1, new Action<StringBuilder, object>(this.딢)));
      if (typeof (IEnumerable).IsAssignableFrom(obj0_1))
        return (Action<StringBuilder, object>) ((obj0_13, obj1) => this.땄(obj0_13, obj1, new Action<StringBuilder, object>(this.딢)));
      return obj0_1.IsSerializable ? new Action<StringBuilder, object>(new 땉(obj0_1, this).딟) : throw new InvalidOperationException();
    }

    public void 딢([In] StringBuilder obj0, [In] object obj1)
    {
      if (obj1 == null)
        obj0.Append("null");
      else
        this.땄(obj1.GetType()).딟()(obj0, obj1);
    }

    protected void 땄([In] StringBuilder obj0, [In] object obj1, [In] Action<StringBuilder, object> obj2)
    {
      if (!(obj1 is IEnumerable enumerable))
      {
        obj0.Append("null");
      }
      else
      {
        bool flag = true;
        foreach (object obj in enumerable)
        {
          obj0.Append(!flag ? "," : "[");
          flag = false;
          obj2(obj0, obj);
        }
        obj0.Append(!flag ? "]" : "[]");
      }
    }

    protected static void 딟([In] StringBuilder obj0, [In] string obj1)
    {
      if (obj1 == null)
      {
        obj0.Append("null");
      }
      else
      {
        obj0.Append('"');
        for (int index = 0; index < obj1.Length; ++index)
        {
          char ch = obj1[index];
          switch (ch)
          {
            case '\b':
              obj0.Append("\\b");
              break;
            case '\t':
              obj0.Append("\\t");
              break;
            case '\n':
              obj0.Append("\\n");
              break;
            case '\f':
              obj0.Append("\\f");
              break;
            case '\r':
              obj0.Append("\\r");
              break;
            default:
              switch (ch)
              {
                case '"':
                  obj0.Append("\\\"");
                  continue;
                case '\\':
                  obj0.Append("\\\\");
                  continue;
                default:
                  if (obj1[index] > '\u007F')
                  {
                    ushort num = (ushort) obj1[index];
                    obj0.AppendFormat("\\u{0:X4}", (object) num);
                    continue;
                  }
                  obj0.Append(obj1[index]);
                  continue;
              }
          }
        }
        obj0.Append('"');
      }
    }

    protected void 딟<딟>([In] StringBuilder obj0, [In] 딟 obj1, [In] Action<딟, StringBuilder> obj2)
    {
      if ((object) obj1 == null)
        obj0.Append("null");
      else
        obj2(obj1, obj0);
    }

    protected void 딟<딟, 땄>(
      [In] StringBuilder obj0,
      [In] IDictionary<딟, 땄> obj1,
      [In] Action<StringBuilder, 땄> obj2)
    {
      if (obj1 == null)
      {
        obj0.Append("null");
      }
      else
      {
        obj0.Append("{");
        bool flag = true;
        foreach (KeyValuePair<딟, 땄> keyValuePair in (IEnumerable<KeyValuePair<딟, 땄>>) obj1)
        {
          if (!flag)
            obj0.Append(",");
          flag = false;
          obj0.AppendFormat("\"{0}\":", (object) keyValuePair.Key);
          obj2(obj0, keyValuePair.Value);
        }
        obj0.Append("}");
      }
    }

    protected void 딟<딟>([In] StringBuilder obj0, [In] IEnumerable<딟> obj1, [In] Action<StringBuilder, 딟> obj2)
    {
      if (obj1 == null)
      {
        obj0.Append("null");
      }
      else
      {
        obj0.Append("[");
        bool flag = true;
        foreach (딟 딟 in obj1)
        {
          if (!flag)
            obj0.Append(",");
          else
            flag = false;
          obj2(obj0, 딟);
        }
        obj0.Append("]");
      }
    }

    protected void 딟<딟>([In] StringBuilder obj0, [In] 딟[] obj1, [In] Action<StringBuilder, 딟> obj2)
    {
      if (obj1 == null)
      {
        obj0.Append("null");
      }
      else
      {
        obj0.Append("[");
        bool flag = true;
        for (int index = 0; index < obj1.Length; ++index)
        {
          if (!flag)
            obj0.Append(",");
          else
            flag = false;
          obj2(obj0, obj1[index]);
        }
        obj0.Append("]");
      }
    }

    protected static void 딟([In] StringBuilder obj0, [In] bool obj1) => obj0.Append(!obj1 ? "false" : "true");

    protected void 딟([In] Type obj0, [In] Action<StringBuilder, object> obj1)
    {
      딾.땚 땚 = new 딾.땚();
      땚.딟(obj1);
      this.딟.Add(obj0, 땚);
    }

    internal class 땚
    {
      [CompilerGenerated]
      [SpecialName]
      public Action<StringBuilder, object> 딟() => this.딟;

      [CompilerGenerated]
      [SpecialName]
      public void 딟([In] Action<StringBuilder, object> obj0) => this.딟 = obj0;
    }
  }
}
