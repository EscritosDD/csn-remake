// Decompiled with JetBrains decompiler
// Type: 딧.땟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace 딧
{
  internal sealed class 땟
  {
    [ThreadStatic]
    private static object[] 딟;
    private MethodInfo 딟;
    private ConstructorInfo 딟;
    private 딗.땳 딟;

    public 땟([In] Type obj0, [In] 딗 obj1)
    {
      this.딟 = obj0.GetConstructor(Type.EmptyTypes);
      this.딟 = obj0.GetMethod("Add");
      this.딟 = obj1.딟(obj0.GetGenericArguments()[0]);
    }

    public object 딟([In] object obj0)
    {
      if (!(obj0 is ICollection<object> objects))
        return (object) null;
      if (땟.딟 == null)
        땟.딟 = new object[1];
      object obj1 = this.딟.Invoke((object[]) null);
      foreach (object obj2 in (IEnumerable<object>) objects)
      {
        땟.딟[0] = this.딟.딟()(obj2);
        this.딟.Invoke(obj1, 땟.딟);
      }
      return obj1;
    }
  }
}
