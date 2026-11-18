// Decompiled with JetBrains decompiler
// Type: 딶.땏
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딶
{
  public abstract class 땏
  {
    private 떆 딟;
    public bool 딟 = true;
    protected int 딟;
    protected 땩 딟;

    public 땏([In] int obj0, [In] 땩 obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딢() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    protected void 땄([In] bool obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땃() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    protected void 딧([In] bool obj0) => this.딧 = obj0;

    protected virtual void 딟()
    {
      this.딧(this.딟);
      this.땄(!this.딟);
    }

    public virtual void 딶()
    {
      switch (this.딟)
      {
        case 떆.딟:
          this.딟();
          if (this.땃())
          {
            this.딟(false);
            this.딟 = 떆.딧;
            break;
          }
          this.딟 = 떆.땄;
          break;
        case 떆.땄:
          this.땄();
          if (!this.땃())
            break;
          this.딟(false);
          this.딟 = 떆.딧;
          goto case 떆.딧;
        case 떆.딧:
          this.딧();
          break;
      }
    }

    protected virtual void 땄() => this.딧(true);

    protected virtual void 딧()
    {
    }

    public void 땓()
    {
      this.딧(true);
      this.딟(true);
      this.딧();
    }

    public virtual void 딟([In] bool obj0)
    {
    }
  }
}
