// Decompiled with JetBrains decompiler
// Type: 땓.떎
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 떎 : 딦
  {
    public 떎([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3)
      : base(obj0, obj1, obj2, obj3)
    {
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      int index = this.딟(this.딟.땺()[((딶.땏) this).딟]);
      if (index == -1)
        return;
      this.딟.땺()[index].딟(딢.떍.땲, ((딶.땏) this).딟);
    }

    private int 딟([In] 땊 obj0)
    {
      for (int index = 0; index < this.딟.땻().Count; ++index)
      {
        if (this.딟.땺()[index].땄 != obj0.땄 && this.딟.땻()[index].딟(this.딟.땺()[index], false) && this.딟.땻()[index].딟(this.딟, ((딶.땏) this).딟) == 딢.딴.땟)
          return index;
      }
      return -1;
    }

    public override string ToString() => string.Format("[TargetBuffLogicEvent] Unit: {0}", (object) ((딶.땏) this).딟);
  }
}
