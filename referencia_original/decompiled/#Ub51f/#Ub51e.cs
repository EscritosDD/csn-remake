// Decompiled with JetBrains decompiler
// Type: 딟.딞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace 딟
{
  public static class 딞
  {
    public static 딩 딟([In] IEnumerable<딖> obj0_1) => new 딩(new object[2]
    {
      (object) "object",
      (object) new Dictionary<string, object>()
      {
        {
          "fields",
          (object) obj0_1.Select<딖, object>((Func<딖, object>) (obj0_2 => obj0_2.딟())).ToArray<object>()
        }
      }
    });

    public static 딩 딟([In] string obj0) => new 딩(new object[2]
    {
      (object) "reference",
      (object) new Dictionary<string, string>()
      {
        {
          "namespace",
          obj0
        }
      }
    });

    public static 딩 딟([In] 딩 obj0) => new 딩(new object[2]
    {
      (object) "optional",
      (object) new Dictionary<string, object>()
      {
        {
          "type",
          obj0.딟()
        }
      }
    });

    public static 딩 딟([In] string obj0, [In] 딩 obj1, [In] object obj2) => new 딩(new object[2]
    {
      (object) "optional",
      (object) new Dictionary<string, object>()
      {
        {
          "type",
          obj1.딟()
        },
        {
          "default",
          obj2
        }
      }
    });

    public static 딖 딟([In] string obj0, [In] 딩 obj1) => new 딖(obj0, obj1);
  }
}
