// Decompiled with JetBrains decompiler
// Type: 딧.딸
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 딸 : 떓
  {
    public override void 딟([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      Type elementType = this.딟().GetElementType();
      string str = obj0.땄(elementType);
      obj1.AppendLine(땹.딟(3) + string.Format("{0} = (source) => ConvertToArray<{2}>( source, {1} );", (object) this.딢(), (object) str, (object) 땹.딟(elementType)));
    }

    public override void 땄([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
      Type elementType = this.딟().GetElementType();
      obj0.땄(elementType);
    }
  }
}
