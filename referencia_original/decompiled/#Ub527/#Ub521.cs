// Decompiled with JetBrains decompiler
// Type: 딧.딡
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
  internal class 딡 : 떍
  {
    public override void 딟([In] 딠 obj0, [In] StringBuilder obj1, [In] int obj2) => obj1.AppendLine(땹.딟(obj2) + string.Format("{0} = ( sb, v ) => SerializeClass( sb, v, {1} );", (object) this.딢(), (object) this.딧()));

    public override void 땄([In] 딠 obj0_1, [In] StringBuilder obj1, [In] int obj2)
    {
      obj0_1.딟((떍) this);
      obj1.AppendLine(땹.딟(obj2) + string.Format("private void {0}( {1} obj, {2} stringBuilder )", (object) this.딧(), (object) 땹.딟(this.딟()), (object) typeof (StringBuilder).FullName));
      obj1.AppendLine(땹.딟(obj2) + "{");
      땞[] array = ((IEnumerable<땞>) ((IEnumerable<FieldInfo>) this.딟().GetFields(BindingFlags.Instance | BindingFlags.Public)).Where<FieldInfo>((Func<FieldInfo, bool>) (obj0_2 => 딾.딟(obj0_2.FieldType))).Select<FieldInfo, 땞>((Func<FieldInfo, 땞>) (obj0_3 => new 땞((MemberInfo) obj0_3, obj0_3.FieldType, false))).ToArray<땞>()).Concat<땞>((IEnumerable<땞>) ((IEnumerable<PropertyInfo>) this.딟().GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (obj0_4 => 딾.딟(obj0_4.PropertyType) && (object) obj0_4.GetGetMethod() != null)).Select<PropertyInfo, 땞>((Func<PropertyInfo, 땞>) (obj0_5 => new 땞((MemberInfo) obj0_5, obj0_5.PropertyType, true))).ToArray<땞>()).OrderBy<땞, bool>((Func<땞, bool>) (obj0_6 => obj0_6.딢())).ToArray<땞>();
      obj1.AppendLine(땹.딟(obj2 + 1) + "stringBuilder.Append( \"{\" );");
      bool flag1 = true;
      bool flag2 = false;
      bool flag3 = true;
      foreach (땞 땞 in array)
      {
        bool flag4 = false;
        string str1 = (string) null;
        if (땞.딢())
        {
          if (땞.땃().IsPrimitive)
          {
            str1 = Convert.ChangeType(땞.딧(), 땞.땃()).ToString();
            flag4 = true;
          }
          else if (땞.땃().IsEnum)
          {
            object obj = Convert.ChangeType(땞.딧(), 땞.땃());
            str1 = string.Format("{0}.{1}", (object) 땹.딟(땞.땃()), (object) obj.ToString());
            flag4 = true;
          }
          else if (!땞.땃().IsValueType && 땞.딧() == null)
          {
            str1 = "null";
            flag4 = true;
          }
        }
        string str2 = string.Format("\\\"{0}\\\":", (object) 땞.딟());
        string str3 = string.Format("obj.{0}", (object) 땞.땄());
        int num;
        if (flag4)
        {
          if (flag3)
            obj1.AppendLine(땹.딟(obj2 + 1) + "bool first = true;");
          obj1.AppendLine(땹.딟(obj2 + 1) + string.Format("if ( {0} != {1} )", (object) str3, (object) str1));
          obj1.AppendLine(땹.딟(obj2 + 1) + "{");
          num = obj2 + 2;
        }
        else
          num = obj2 + 1;
        if (!flag1)
        {
          if (!flag2)
          {
            obj1.AppendLine(땹.딟(num) + "if ( first )");
            obj1.AppendLine(땹.딟(num) + "{");
            obj1.AppendLine(땹.딟(num + 1) + "first = false;");
            obj1.AppendLine(땹.딟(num + 1) + "stringBuilder.Append( \",\" );");
            obj1.AppendLine(땹.딟(num) + "}");
          }
          else
            str2 = "," + str2;
        }
        obj1.AppendLine(땹.딟(num) + string.Format("stringBuilder.Append( \"{0}\" );", (object) str2));
        obj1.AppendLine(땹.딟(num) + string.Format("{0}( stringBuilder, {1} );", (object) obj0_1.딟(땞.땃(), false), (object) str3));
        if (flag4)
          obj1.AppendLine(땹.딟(obj2 + 1) + "}");
        flag3 = false;
        flag2 |= !flag4;
        flag1 = false;
      }
      obj1.AppendLine(땹.딟(obj2 + 1) + "stringBuilder.Append( \"}\" );");
      obj1.AppendLine(땹.딟(obj2) + "}");
      obj1.AppendLine();
    }
  }
}
