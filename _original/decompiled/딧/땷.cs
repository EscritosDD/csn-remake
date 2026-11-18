// Decompiled with JetBrains decompiler
// Type: 딧.땷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 땷 : 떓
  {
    public override void 딟([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      Type genericArgument = this.딟().GetGenericArguments()[1];
      string str = obj0.땄(genericArgument);
      obj1.AppendLine(땹.딟(3) + string.Format("{0} = (source) => ConvertToDictionary<{1}, {2}>( source, {3} );", (object) this.딢(), (object) 땹.딟(this.딟()), (object) 땹.딟(genericArgument), (object) str));
    }

    public override void 땄([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      Type genericArgument = this.딟().GetGenericArguments()[1];
      obj0.땄(genericArgument);
    }
  }
}
