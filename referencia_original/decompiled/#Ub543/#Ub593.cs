// Decompiled with JetBrains decompiler
// Type: 땃.떓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 떓
  {
    public int 딟;
    public int 땄;
    public int 딧;
    public int 딢;
    public int 땃;
    public int 딶;
    public int 땓;
    public float 딟;
    public int 땺;
    public bool 딟;
    public int 땥;
    public float 땄;
    public float 딧;
    public float 딢;
    public float 땃;
    public 딥[] 딟 = new 딥[8];

    public 떓([In] int obj0, [In] int obj1, [In] int obj2, [In] 땓.땦 obj3)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.땓 = obj2;
      this.딟 = -1f;
      this.딧 = -1;
      this.딢 = -1;
      this.땺 = -1;
      this.땃 = -1;
      this.딶 = -1;
      this.땥 = -1;
      this.딟 = false;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj3);
    }

    public 떓([In] 떓 obj0)
    {
      this.딟 = obj0.딟;
      this.땄 = obj0.땄;
      this.딧 = obj0.딧;
      this.딢 = obj0.딢;
      this.땃 = obj0.땃;
      this.딶 = obj0.딶;
      this.땓 = obj0.땓;
      this.딟 = obj0.딟;
      this.땺 = obj0.땺;
      this.딟 = obj0.딟;
      this.땥 = obj0.땥;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.딧());
      this.땃 = obj0.땃;
      this.딟 = new 딥[obj0.딟.Length];
      for (int index = 0; index < this.딟.Length; ++index)
        this.딟[index] = obj0.딟[index];
    }

    public bool 딟() => this.딧 != -1 && this.딢 != -1;

    public bool 땄() => this.딟 != -1 && this.땄 != -1;

    public void 딟([In] 딥 obj0)
    {
      if (obj0.딟 >= this.딟.Length)
        return;
      this.딟[obj0.딟] = obj0;
    }

    [CompilerGenerated]
    [SpecialName]
    public 땓.땦 딧() => this.딟;
  }
}
