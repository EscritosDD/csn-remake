// Decompiled with JetBrains decompiler
// Type: 딧.딞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 딞 : 떍
  {
    public override void 딟([In] 딠 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      Type genericArgument = this.딟().GetGenericArguments()[1];
      string str = obj0.딟(genericArgument, false);
      obj1.AppendLine(땹.딟(obj2) + string.Format("{0} = ( sb, v ) => SerializeDictionary<{2},{3}>( sb, v, {1} );", (object) this.딢(), (object) str, (object) 땹.딟(typeof (string)), (object) 땹.딟(genericArgument)));
    }

    public override void 땄([In] 딠 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      Type genericArgument = this.딟().GetGenericArguments()[1];
      obj0.딟(genericArgument, false);
    }
  }
}
