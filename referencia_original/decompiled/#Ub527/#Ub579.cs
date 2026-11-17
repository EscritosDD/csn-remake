// Decompiled with JetBrains decompiler
// Type: 딧.땹
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace 딧
{
  public class 땹
  {
    internal static string 딟([In] Type obj0_1)
    {
      if (obj0_1.IsArray)
        return 땹.딟(obj0_1.GetElementType()) + "[]";
      if (obj0_1.GetGenericArguments().Length == 0)
        return obj0_1.FullName;
      Type[] genericArguments = obj0_1.GetGenericArguments();
      string fullName = obj0_1.FullName;
      return fullName.Substring(0, fullName.IndexOf("`")) + "<" + string.Join(",", ((IEnumerable<Type>) genericArguments).Select<Type, string>((Func<Type, string>) (obj0_2 => 땹.딟(obj0_2))).ToArray<string>()) + ">";
    }

    internal static string 딟([In] int obj0) => new string('\t', obj0);

    private static bool 딟([In] Type obj0, [In] object obj1) => obj0.IsDefined(typeof (딷), false);

    public static Assembly 딟([In] string obj0) => Assembly.LoadFile(Path.GetFullPath(obj0));

    public static Type[] 딟([In] Assembly obj0_1) => ((IEnumerable<Module>) obj0_1.GetModules()).SelectMany<Module, Type>((Func<Module, IEnumerable<Type>>) (obj0_2 => (IEnumerable<Type>) obj0_2.FindTypes(new TypeFilter(땹.딟), (object) null))).ToArray<Type>();

    public static Type[] 딟([In] IEnumerable<string> obj0_1) => ((IEnumerable<Assembly>) obj0_1.Select<string, Assembly>((Func<string, Assembly>) (obj0_2 => 땹.딟(obj0_2))).ToArray<Assembly>()).SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (obj0_3 => (IEnumerable<Type>) 땹.딟(obj0_3))).ToArray<Type>();

    public static void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] IEnumerable<Type> obj3)
    {
    }

    public static void 땄([In] string obj0, [In] string obj1, [In] string obj2, [In] IEnumerable<Type> obj3)
    {
    }
  }
}
