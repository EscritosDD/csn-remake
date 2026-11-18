// Decompiled with JetBrains decompiler
// Type: 딧.땁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace 딧
{
  internal class 땁 : 떓
  {
    public override void 딟([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2) => obj1.AppendLine(땹.딟(obj2) + string.Format("{0} = (source) => ConvertToEnum{1}<{2}>( source );", (object) this.딢(), (object) Enum.GetUnderlyingType(this.딟()).Name, (object) 땹.딟(this.딟())));

    public override void 땄([In] 떔 obj0, [In] StringBuilder obj1, [In] int obj2)
    {
    }
  }
}
