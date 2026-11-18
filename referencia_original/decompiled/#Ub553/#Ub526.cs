// Decompiled with JetBrains decompiler
// Type: 땓.딦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using 딶;

namespace 땓
{
  public class 딦 : 딶.땏
  {
    protected 딶.땖 딟;
    protected 딶.땙 딟;
    protected 떒 딟;

    public 딦([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3, [In] 땩 obj4)
      : base(obj3, obj4)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
    }

    public 딦([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2, [In] int obj3)
      : this(obj0, obj1, obj2, obj3, 땩.딟)
    {
    }

    public 딦([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떒 obj2)
      : this(obj0, obj1, obj2, -1, 땩.딟)
    {
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if (this.딟.땉() == null || this.딟.땉().딷() == null || base.딟 < 0)
        return;
      this.딟.땉().딷().딟(base.딟).땓(true);
    }
  }
}
