// Decompiled with JetBrains decompiler
// Type: 땃.딩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딩
  {
    public static int 딟 = 2;
    public int 땄 = -1;
    public 떍[] 딟 = new 떍[딩.딟];

    public 딩()
    {
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index] = new 떍();
    }

    public void 딟()
    {
      this.땄 = -1;
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index].딟();
    }

    public int 딟(
      [In] 딢.딴 obj0,
      [In] int obj1,
      [In] GameTileComponent obj2,
      [In] GameTileComponent obj3,
      [In] WeaponGameplayData obj4,
      [In] int obj5)
    {
      int num = -1;
      if (땓.땊.딟(obj2.TileIndexX, obj2.TileIndexY, obj3.TileIndexX, obj3.TileIndexY) <= obj4.SplashRange)
        return num;
      int index1 = -1;
      for (int index2 = 0; index2 < this.딟.Length; ++index2)
      {
        if (Object.op_Equality((Object) this.딟[index2].딟, (Object) null))
        {
          index1 = index2;
          break;
        }
        if (this.딟[index2].딟 == obj0 && obj1 > this.딟[index2].딟)
        {
          this.딟[index2].딟 = obj2;
          this.딟[index2].딟 = obj1;
          this.딟[index2].땄 = obj3;
          this.딟[index2].땄 = obj5;
          num = index2;
          break;
        }
      }
      if (index1 != -1)
      {
        this.딟[index1].딟 = obj0;
        this.딟[index1].딟 = obj2;
        this.딟[index1].딟 = obj1;
        this.딟[index1].땄 = obj3;
        this.딟[index1].땄 = obj5;
        num = index1;
      }
      return num;
    }

    public 떍 딟([In] 딢.딴 obj0)
    {
      int index1 = -1;
      for (int index2 = 0; index2 < this.딟.Length && !Object.op_Equality((Object) this.딟[index2].딟, (Object) null); ++index2)
      {
        if (this.딟[index2].딟 == obj0)
        {
          index1 = index2;
          break;
        }
      }
      return index1 != -1 ? this.딟[index1] : (떍) null;
    }
  }
}
