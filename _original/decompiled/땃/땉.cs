// Decompiled with JetBrains decompiler
// Type: 땃.땉
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땃
{
  public class 땉 : 땁
  {
    public 땉([In] 딢.딴 obj0)
      : base(obj0)
    {
    }

    public override 땻 딟([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2) => this.땄(obj0, obj1, obj2);

    protected virtual 땻 땄([In] 딶.딡 obj0, [In] 딡 obj1, [In] 딶.땙 obj2)
    {
      int index = 딶.딢.딟(obj0.땼(), obj2, obj1.딟.땔(), this.딟());
      if (index == -1)
        return 땻.딢;
      if (obj2.땺()[obj1.딟.땔()].딢 >= (obj0.땼().땻()[index] as 딶.땚).땃())
      {
        땁.딟(new 딶.떏(obj1.딟.땔(), this.딟(), obj1.딟.땔()).딟(), obj0);
        obj1.딟(this.딟());
      }
      return 땻.딧;
    }
  }
}
