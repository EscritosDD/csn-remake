// Decompiled with JetBrains decompiler
// Type: 딧.땩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  internal class 땩 : 땞
  {
    public 땩([In] FieldInfo obj0, [In] 딗 obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땩.땠 땠 = new 땩.땠();
      // ISSUE: reference to a compiler-generated field
      땠.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: explicit constructor call
      base.\u002Ector((MemberInfo) 땠.딟, 땠.딟.FieldType, false);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      땠.딟 = obj1.딟(땠.딟.FieldType);
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.딟(new Action<object, object>(땠.딟));
    }

    public 땩([In] PropertyInfo obj0, [In] 딗 obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땩.땴 땴 = new 땩.땴();
      // ISSUE: reference to a compiler-generated field
      땴.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: explicit constructor call
      base.\u002Ector((MemberInfo) 땴.딟, 땴.딟.PropertyType, true);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      땴.딟 = obj1.딟(땴.딟.PropertyType);
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.딟(new Action<object, object>(땴.딟));
    }

    [CompilerGenerated]
    [SpecialName]
    public Action<object, object> 딟() => this.딟;
  }
}
