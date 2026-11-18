// Decompiled with JetBrains decompiler
// Type: 딧.땂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace 딧
{
  internal class 땂
  {
    private ConstructorInfo 딟;
    private 딗.땳 딟;

    public 땂([In] Type obj0, [In] 딗 obj1)
    {
      this.딟 = obj0.GetConstructor(Type.EmptyTypes);
      this.딟 = obj1.딟(obj0.GetGenericArguments()[1]);
    }

    public object 딟([In] object obj0)
    {
      if (!(obj0 is IDictionary<string, object> dictionary1))
        return (object) null;
      IDictionary dictionary2 = this.딟.Invoke((object[]) null) as IDictionary;
      foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) dictionary1)
        dictionary2.Add((object) keyValuePair.Key, this.딟.딟()(keyValuePair.Value));
      return (object) dictionary2;
    }
  }
}
