// Decompiled with JetBrains decompiler
// Type: 딧.딱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace 딧
{
  internal class 딱
  {
    private ConstructorInfo 딟;
    private 땩[] 딟;

    public 딱([In] Type obj0_1, [In] 딗 obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딱.때 때 = new 딱.때();
      // ISSUE: reference to a compiler-generated field
      때.딟 = obj1;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.딟 = ((IEnumerable<땩>) ((IEnumerable<FieldInfo>) obj0_1.GetFields(BindingFlags.Instance | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (obj0_2 => 딾.딟(obj0_2.FieldType))).Select<FieldInfo, 땩>(new Func<FieldInfo, 땩>(때.딟)).ToArray<땩>()).Concat<땩>((IEnumerable<땩>) ((IEnumerable<PropertyInfo>) obj0_1.GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (obj0_3 => 딾.딟(obj0_3.PropertyType))).Select<PropertyInfo, 땩>(new Func<PropertyInfo, 땩>(때.딟)).ToArray<땩>()).ToArray<땩>();
      this.딟 = obj0_1.GetConstructor(Type.EmptyTypes);
    }

    public object 딟([In] object obj0)
    {
      if (!(obj0 is IDictionary<string, object> dictionary))
        return (object) null;
      object obj1 = this.딟.Invoke((object[]) null);
      foreach (땩 땩 in this.딟)
      {
        object obj2;
        if (dictionary.TryGetValue(((땞) 땩).딟(), out obj2))
          땩.딟()(obj1, obj2);
      }
      return obj1;
    }
  }
}
