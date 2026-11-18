// Decompiled with JetBrains decompiler
// Type: 딶.떈
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떈
  {
    public 떈() => this.딟(Random.seed);

    public 떈([In] int obj0) => this.딟(obj0);

    public int 딟([In] int obj0, [In] int obj1)
    {
      Random.seed = this.땄();
      int num = Random.Range(obj0, obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(Random.seed);
      return num;
    }

    public float 딟([In] float obj0, [In] float obj1)
    {
      Random.seed = this.땄();
      float num = Random.Range(obj0, obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(Random.seed);
      return num;
    }

    [SpecialName]
    public float 딟()
    {
      Random.seed = this.땄();
      float num = Random.value;
      // ISSUE: reference to a compiler-generated method
      this.딟(Random.seed);
      return num;
    }

    [CompilerGenerated]
    [SpecialName]
    public int 땄() => this.딟;
  }
}
