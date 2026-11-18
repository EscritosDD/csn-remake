// Decompiled with JetBrains decompiler
// Type: 딧.딗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  public class 딗
  {
    private Dictionary<Type, 딧.딗.땳> 딟 = new Dictionary<Type, 딧.딗.땳>();

    public 딗()
    {
      this.딟(typeof (bool), (Func<object, object>) (obj0 => (object) this.땃(obj0)));
      this.딟(typeof (double), (Func<object, object>) (obj0 => (object) this.땺(obj0)));
      this.딟(typeof (float), (Func<object, object>) (obj0 => (object) this.땓(obj0)));
      this.딟(typeof (byte), (Func<object, object>) (obj0 => (object) this.딝(obj0)));
      this.딟(typeof (ushort), (Func<object, object>) (obj0 => (object) this.떎(obj0)));
      this.딟(typeof (uint), (Func<object, object>) (obj0 => (object) this.떂(obj0)));
      this.딟(typeof (ulong), (Func<object, object>) (obj0 => (object) this.땭(obj0)));
      this.딟(typeof (sbyte), (Func<object, object>) (obj0 => (object) this.딦(obj0)));
      this.딟(typeof (short), (Func<object, object>) (obj0 => (object) this.땤(obj0)));
      this.딟(typeof (int), (Func<object, object>) (obj0 => (object) this.땽(obj0)));
      this.딟(typeof (long), (Func<object, object>) (obj0 => (object) this.땋(obj0)));
      this.딟(typeof (char), (Func<object, object>) (obj0 => (object) this.땥(obj0)));
      this.딟(typeof (string), (Func<object, object>) (obj0 => (object) (obj0 as string)));
      this.딟(typeof (DateTime), new Func<object, object>(this.딧));
      this.딟(typeof (Guid), new Func<object, object>(this.땄));
    }

    public object 딟([In] Type obj0, [In] string obj1)
    {
      object obj = 떇.딟(obj1);
      return obj == null ? (object) null : this.딟(obj0, obj);
    }

    public 딟 딟<딟>([In] object obj0) => (딟) this.딟(typeof (딟), obj0);

    public 딟 딟<딟>([In] string obj0) => (딟) this.딟(typeof (딟), obj0);

    private object 딟([In] Type obj0, [In] object obj1) => this.딟(obj0).딟()(obj1);

    private object 땄([In] Type obj0, [In] object obj1) => Enum.ToObject(obj0, this.땽(obj1));

    private object 딧([In] Type obj0, [In] object obj1) => Enum.ToObject(obj0, this.땋(obj1));

    private object 땄([In] object obj0)
    {
      Guid empty;
      if (obj0 is string str)
        딺.딟(str, out empty);
      else
        empty = Guid.Empty;
      return (object) empty;
    }

    private object 딧([In] object obj0)
    {
      DateTime result;
      if (obj0 is string s)
        DateTime.TryParse(s, out result);
      else
        result = new DateTime();
      return (object) result;
    }

    internal object 딟([In] Type obj0, [In] object obj1, [In] Func<object, object> obj2)
    {
      if (!(obj1 is ICollection<object> objects))
        return (object) null;
      Array instance = Array.CreateInstance(obj0, objects.Count);
      int index = 0;
      foreach (object obj in (IEnumerable<object>) objects)
      {
        instance.SetValue(obj2(obj), index);
        ++index;
      }
      return (object) instance;
    }

    internal 딧.딗.땳 딟([In] Type obj0)
    {
      딧.딗.땳 땳1;
      if (this.딟.TryGetValue(obj0, out 땳1))
        return 땳1;
      딧.딗.땳 땳2 = new 딧.딗.땳();
      this.딟.Add(obj0, 땳2);
      땳2.딟(this.땄(obj0));
      return 땳2;
    }

    protected void 딟([In] Type obj0, [In] Func<object, object> obj1)
    {
      딧.딗.땳 땳 = new 딧.딗.땳();
      땳.딟(obj1);
      this.딟.Add(obj0, 땳);
    }

    private Func<object, object> 땄([In] Type obj0_1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딧.딗.땻 땻 = new 딧.딗.땻();
      // ISSUE: reference to a compiler-generated field
      땻.딟 = obj0_1;
      // ISSUE: reference to a compiler-generated field
      땻.딟 = this;
      // ISSUE: reference to a compiler-generated field
      if ((object) 땻.딟 == (object) typeof (object))
        return (Func<object, object>) (obj0_3 => obj0_3);
      // ISSUE: reference to a compiler-generated field
      if (땻.딟.IsEnum)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        return (object) Enum.GetUnderlyingType(땻.딟) == (object) typeof (int) ? new Func<object, object>(땻.딟) : new Func<object, object>(땻.땄);
      }
      // ISSUE: reference to a compiler-generated field
      if (땻.딟.IsArray)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        return new Func<object, object>(new 딧.딗.딥()
        {
          딟 = 땻,
          딟 = this,
          딟 = this.딟(땻.딟.GetElementType())
        }.딟);
      }
      // ISSUE: reference to a compiler-generated field
      Type type = 땻.딟.GetInterface(typeof (IDictionary<,>).FullName);
      if ((object) type != null && (object) type.GetGenericArguments()[0] == (object) typeof (string))
      {
        // ISSUE: reference to a compiler-generated field
        return new Func<object, object>(new 딧.땂(땻.딟, this).딟);
      }
      // ISSUE: reference to a compiler-generated field
      if ((object) 땻.딟.GetInterface(typeof (ICollection<>).FullName) != null)
      {
        // ISSUE: reference to a compiler-generated field
        return new Func<object, object>(new 딧.땟(땻.딟, this).딟);
      }
      // ISSUE: reference to a compiler-generated field
      if (땻.딟.IsSerializable)
      {
        // ISSUE: reference to a compiler-generated field
        return new Func<object, object>(new 딧.딱(땻.딟, this).딟);
      }
      throw new NotSupportedException();
    }

    protected 딟 딢<딟>([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return default (딟);
      try
      {
        return (딟) Enum.ToObject(typeof (딟), convertible.ToInt32((IFormatProvider) null));
      }
      catch (Exception ex)
      {
        return default (딟);
      }
    }

    protected bool 땃([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return false;
      try
      {
        return convertible.ToBoolean((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    protected DateTime 딶([In] object obj0)
    {
      DateTime result;
      return obj0 is string s && DateTime.TryParse(s, out result) ? result : new DateTime();
    }

    protected float 땓([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0.0f;
      try
      {
        return convertible.ToSingle((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0.0f;
      }
    }

    protected double 땺([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0.0;
      try
      {
        return convertible.ToDouble((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0.0;
      }
    }

    protected char 땥([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return char.MinValue;
      try
      {
        return convertible.ToChar((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return char.MinValue;
      }
    }

    protected byte 딝([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToByte((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected ushort 떎([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToUInt16((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected uint 떂([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToUInt32((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected ulong 땭([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToUInt64((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected sbyte 딦([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToSByte((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected short 땤([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToInt16((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected int 땽([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToInt32((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected long 땋([In] object obj0)
    {
      if (!(obj0 is IConvertible convertible))
        return 0;
      try
      {
        return convertible.ToInt64((IFormatProvider) null);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    protected string 땲([In] object obj0) => obj0 as string;

    protected 딟 딟<딟>([In] IDictionary<string, object> obj0, [In] string obj1, [In] Func<object, 딟> obj2, [In] 딟 obj3)
    {
      object obj;
      return obj0.TryGetValue(obj1, out obj) ? obj2(obj) : obj3;
    }

    protected 딟 딟<딟>([In] object obj0, [In] Func<ICollection<object>, 딟> obj1) => obj0 is ICollection<object> objects ? obj1(objects) : default (딟);

    protected 딟 딟<딟>([In] object obj0, [In] Func<IDictionary<string, object>, 딟> obj1) => !(obj0 is IDictionary<string, object> dictionary) ? default (딟) : obj1(dictionary);

    protected 딟[] 딟<딟>([In] object obj0, [In] Func<object, 딟> obj1)
    {
      if (!(obj0 is ICollection<object> objects))
        return (딟[]) null;
      딟[] 딟Array = new 딟[objects.Count];
      int index = 0;
      foreach (object obj in (IEnumerable<object>) objects)
      {
        딟Array[index] = obj1(obj);
        ++index;
      }
      return 딟Array;
    }

    protected 딟 딟<딟, 땄>([In] object obj0, [In] Func<object, 땄> obj1) where 딟 : ICollection<땄>, new()
    {
      if (!(obj0 is ICollection<object> objects))
        return default (딟);
      딟 딟 = new 딟();
      foreach (object obj in (IEnumerable<object>) objects)
        딟.Add(obj1(obj));
      return 딟;
    }

    protected 딟 땄<딟, 땄>([In] object obj0, [In] Func<object, 땄> obj1) where 딟 : IDictionary<string, 땄>, new()
    {
      IDictionary<string, object> dictionary = obj0 as IDictionary<string, object>;
      if (obj0 == null)
        return default (딟);
      딟 딟 = new 딟();
      foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) dictionary)
        딟.Add(keyValuePair.Key, obj1(keyValuePair.Value));
      return 딟;
    }

    internal class 땳
    {
      [CompilerGenerated]
      [SpecialName]
      public Func<object, object> 딟() => this.딟;

      [CompilerGenerated]
      [SpecialName]
      public void 딟([In] Func<object, object> obj0) => this.딟 = obj0;
    }
  }
}
