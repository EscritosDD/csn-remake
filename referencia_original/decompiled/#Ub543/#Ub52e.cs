// Decompiled with JetBrains decompiler
// Type: 땃.딮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 딮
  {
    public static int 딟 = 16;
    public 딾[] 딟 = new 딾[딮.딟];

    public 딮()
    {
      this.딟 = new 딾[딮.딟];
      for (int index = 0; index < 딮.딟; ++index)
        this.딟[index] = new 딾();
    }

    public void 딟()
    {
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index].딟();
    }

    public void 딟([In] int obj0, [In] int obj1, [In] int obj2) => this.딟[obj1].딟[obj2].딟 = obj0;

    public void 딟([In] int obj0, [In] int obj1) => this.딟[obj1].땄 = obj0;

    public bool 땄([In] int obj0, [In] int obj1, [In] int obj2)
    {
      if (obj2 >= this.딟[obj1].딟.Length)
      {
        Debug.LogError((object) "AttackOnEnemyData.MaxAttacks isn't high enough to handle max number of attacks in the game");
        return false;
      }
      if (obj0 <= this.딟[obj1].딟[obj2].딟)
        return false;
      this.딟(obj0, obj1, obj2);
      return true;
    }

    public void 딧([In] int obj0, [In] int obj1, [In] int obj2) => this.딟(this.딟[obj1].딟[obj2].딟 + obj0, obj1, obj2);
  }
}
