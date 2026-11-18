// Decompiled with JetBrains decompiler
// Type: 땥.땩`1
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
  public struct 땩<딟>
  {
    private 딟 딟;
    private 딟 땄;
    private 딟 딧;
    private 딟 딢;
    private 딟 땃;
    private 딟 딶;
    private 딟 땓;
    private 딟 땺;

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
        case 3:
          return this.딢;
        case 4:
          return this.땃;
        case 5:
          return this.딶;
        case 6:
          return this.땓;
        case 7:
          return this.땺;
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
        case 3:
          this.딢 = obj1;
          break;
        case 4:
          this.땃 = obj1;
          break;
        case 5:
          this.딶 = obj1;
          break;
        case 6:
          this.땓 = obj1;
          break;
        case 7:
          this.땺 = obj1;
          break;
        default:
          throw new IndexOutOfRangeException();
      }
    }
  }
}
