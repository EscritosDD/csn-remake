// Decompiled with JetBrains decompiler
// Type: 땥.딱`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  [DefaultMember("Item")]
  public struct 딱<딟>
  {
    private 딟 딟;
    private 딟 땄;
    private 딟 딧;

    [SpecialName]
    public 딟 딟([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
          return this.딟;
        case 1:
          return this.땄;
        case 2:
          return this.딧;
        default:
          throw new IndexOutOfRangeException();
      }
    }

    [SpecialName]
    public void 딟([In] int obj0, [In] 딟 obj1)
    {
      switch (obj0)
      {
        case 0:
          this.딟 = obj1;
          break;
        case 1:
          this.땄 = obj1;
          break;
        case 2:
          this.딧 = obj1;
          break;
        default:
          throw new IndexOutOfRangeException();
      }
    }
  }
}
