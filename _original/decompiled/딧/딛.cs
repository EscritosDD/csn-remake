// Decompiled with JetBrains decompiler
// Type: 딧.딛
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
  internal class 딛 : 떓
  {
    public override void 딟([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2) => obj1.AppendLine(땹.딟(3) + string.Format("{0} = (source) => ConvertToClass<{2}>( source, {1} );", (object) this.딢(), (object) this.딧(), (object) 땹.딟(this.딟())));

    public override void 땄([In] 떔 obj0_1, [In] StringBuilder obj1, [In] int obj2)
    {
      obj0_1.딟((떓) this);
      string str1 = 땹.딟(typeof (IDictionary<string, object>));
      obj1.AppendLine(땹.딟(obj2) + string.Format("private {2} {0}( {1} source )", (object) this.딧(), (object) str1, (object) 땹.딟(this.딟())));
      obj1.AppendLine(땹.딟(obj2) + "{");
      땞[] array = ((IEnumerable<땞>) ((IEnumerable<FieldInfo>) this.딟().GetFields(BindingFlags.Instance | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (obj0_2 => 딾.딟(obj0_2.FieldType))).Select<FieldInfo, 땞>((Func<FieldInfo, 땞>) (obj0_3 => new 땞((MemberInfo) obj0_3, obj0_3.FieldType, false))).ToArray<땞>()).Concat<땞>((IEnumerable<땞>) ((IEnumerable<PropertyInfo>) this.딟().GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (obj0_4 => obj0_4.CanWrite)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (obj0_5 => 딾.딟(obj0_5.PropertyType))).Select<PropertyInfo, 땞>((Func<PropertyInfo, 땞>) (obj0_6 => new 땞((MemberInfo) obj0_6, obj0_6.PropertyType, true))).ToArray<땞>()).ToArray<땞>();
      obj1.AppendLine(땹.딟(obj2 + 1) + string.Format("{0} obj = new {0}();", (object) 땹.딟(this.딟())));
      foreach (땞 땞 in array)
      {
        string str2 = string.Format("default({0})", (object) 땹.딟(땞.땃()));
        if (땞.딢())
        {
          if (땞.땃().IsPrimitive)
            str2 = Convert.ChangeType(땞.딧(), 땞.땃()).ToString();
          else if (땞.땃().IsEnum)
          {
            object obj = Convert.ChangeType(땞.딧(), 땞.땃());
            str2 = string.Format("{0}.{1}", (object) 땹.딟(땞.땃()), (object) obj.ToString());
          }
        }
        string str3 = string.Format("obj.{0}", (object) 땞.땄());
        string str4 = string.Format("\"{0}\"", (object) 땞.딟());
        string str5 = obj0_1.땄(땞.땃());
        obj1.AppendLine(땹.딟(obj2 + 1) + string.Format("{0} = ReadField( source, {1}, {2}, {3} );", (object) str3, (object) str4, (object) str5, (object) str2));
      }
      obj1.AppendLine(땹.딟(obj2 + 1) + "return obj;");
      obj1.AppendLine(땹.딟(obj2) + "}");
      obj1.AppendLine();
    }
  }
}
