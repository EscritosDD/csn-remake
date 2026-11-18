// Decompiled with JetBrains decompiler
// Type: 딧.땉
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 땉
  {
    private 땜[] 딟;

    public 땉([In] Type obj0_1, [In] 딾 obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땉.땈 땈 = new 땉.땈();
      // ISSUE: reference to a compiler-generated field
      땈.딟 = obj1;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.딟 = ((IEnumerable<땜>) ((IEnumerable<FieldInfo>) obj0_1.GetFields(BindingFlags.Instance | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (obj0_2 => 딾.딟(obj0_2.FieldType))).Select<FieldInfo, 땜>(new Func<FieldInfo, 땜>(땈.딟)).ToArray<땜>()).Concat<땜>((IEnumerable<땜>) ((IEnumerable<PropertyInfo>) obj0_1.GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (obj0_3 => 딾.딟(obj0_3.PropertyType) && obj0_3.CanRead)).Select<PropertyInfo, 땜>(new Func<PropertyInfo, 땜>(땈.딟)).ToArray<땜>()).ToArray<땜>();
    }

    public void 딟([In] StringBuilder obj0, [In] object obj1)
    {
      if (obj1 == null)
      {
        obj0.Append("null");
      }
      else
      {
        obj0.Append("{");
        bool flag = true;
        foreach (땜 땜 in this.딟)
        {
          if (!flag)
            obj0.Append(",");
          flag = false;
          obj0.AppendFormat("\"{0}\":", (object) ((땞) 땜).딟());
          땜.딟()(obj0, obj1);
        }
        obj0.Append("}");
      }
    }
  }
}
