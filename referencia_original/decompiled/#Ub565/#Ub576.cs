// Decompiled with JetBrains decompiler
// Type: 땥.땶
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땶 : 떄
  {
    [CompilerGenerated]
    [SpecialName]
    public 떁 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public new void 딟([In] 떁 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public new void 땄([In] float obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] bool obj0) => this.딟 = obj0;

    public override void 딟([In] float obj0, [In] float obj1)
    {
      foreach (딺 딺 in ((딹) this).딟.떂())
      {
        float num1 = this.땄(딺);
        if ((double) num1 != 0.0)
        {
          떁 떁;
          if (base.딟 == 떄.떌.딟)
          {
            떁 = 딺.땼() - base.땄();
          }
          else
          {
            this.딟().땓();
            떁 = this.딟();
            if ((double) 떁.땃() == 0.0)
              떁 = new 떁(0.0f, 1f);
          }
          if ((double) this.땥() != 0.0)
          {
            float num2 = (float) base.딟.NextDouble() * 딣.딟(this.땥(), 0.0f, 1f);
            떁.땓();
            딺.딢(떁 * obj1 * num1 * num2);
          }
          else
          {
            떁.땓();
            딺.딢(떁 * obj1 * num1);
          }
        }
      }
    }
  }
}
