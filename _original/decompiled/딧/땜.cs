// Decompiled with JetBrains decompiler
// Type: 딧.땜
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 땜 : 땞
  {
    public 땜([In] PropertyInfo obj0, [In] 딾 obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땜.땪 땪 = new 땜.땪();
      // ISSUE: reference to a compiler-generated field
      땪.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      땪.딟 = obj1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: explicit constructor call
      base.\u002Ector((MemberInfo) 땪.딟, 땪.딟.PropertyType, true);
      // ISSUE: reference to a compiler-generated field
      Type propertyType = 땪.딟.PropertyType;
      if (propertyType.IsSealed)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.딟(new Action<StringBuilder, object>(new 땜.땕()
        {
          딟 = 땪,
          딟 = 땪.딟.딧(propertyType)
        }.딟));
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.딟(new Action<StringBuilder, object>(땪.딟));
      }
    }

    public 땜([In] FieldInfo obj0, [In] 딾 obj1)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땜.딚 딚 = new 땜.딚();
      // ISSUE: reference to a compiler-generated field
      딚.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      딚.딟 = obj1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: explicit constructor call
      base.\u002Ector((MemberInfo) 딚.딟, 딚.딟.FieldType, false);
      // ISSUE: reference to a compiler-generated field
      Type fieldType = 딚.딟.FieldType;
      if (fieldType.IsSealed)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.딟(new Action<StringBuilder, object>(new 땜.따()
        {
          딟 = 딚,
          딟 = 딚.딟.딧(fieldType)
        }.딟));
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.딟(new Action<StringBuilder, object>(딚.딟));
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public Action<StringBuilder, object> 딟() => this.딟;
  }
}
