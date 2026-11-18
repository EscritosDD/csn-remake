// Decompiled with JetBrains decompiler
// Type: 딧.떃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  public static class 떃
  {
    public static 땦 딟() => (땦) new 떃.땆();

    public static 땦 땄() => (땦) new 떃.땫();

    private class 땆 : 땦
    {
      [SpecialName]
      public bool 딟() => true;

      public void 딟([In] string obj0, [In] Action<string> obj1) => 땓.딟("unity_chrome_sync_get_string", obj0, (Action<object>) (obj => obj1(obj as string)));

      public void 딟([In] string obj0, [In] string obj1, [In] Action obj2) => 땓.딟("unity_chrome_sync_set_string", 땾.땄((object) new Dictionary<string, string>()
      {
        {
          "key",
          obj0
        },
        {
          "value",
          obj1
        }
      }), (Action<object>) (obj => obj2()));

      public void 딟([In] string obj0, [In] Action obj1) => 땓.딟("unity_chrome_sync_delete_string", obj0, (Action<object>) (obj => obj1()));
    }

    private class 땫 : 땦
    {
      [SpecialName]
      public bool 딟() => false;

      public void 딟([In] string obj0, [In] Action<string> obj1) => throw new NotImplementedException();

      public void 딟([In] string obj0, [In] string obj1, [In] Action obj2) => throw new NotImplementedException();

      public void 딟([In] string obj0, [In] Action obj1) => throw new NotImplementedException();
    }
  }
}
