// Decompiled with JetBrains decompiler
// Type: 땥.떆
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 떆
  {
    private static 땺.땖 딟 = new 땺.땖();
    private static 떆.땐[,] 딟 = new 떆.땐[4, 4]
    {
      {
        떆.땐.딢,
        떆.땐.딶,
        떆.땐.딧,
        떆.땐.땺
      },
      {
        떆.땐.딶,
        떆.땐.딟,
        떆.땐.땃,
        떆.땐.딟
      },
      {
        떆.땐.딧,
        떆.땐.땃,
        떆.땐.땄,
        떆.땐.땓
      },
      {
        떆.땐.땺,
        떆.땐.딟,
        떆.땐.땓,
        떆.땐.딟
      }
    };
    public 떀 딟;
    public 떀 땄;
    internal 땏 딟;
    public 땺.따 딟;
    internal 땙 딟 = new 땙();
    internal 땙 땄 = new 땙();
    public float 딟;
    internal int 딟;
    private 떆.땐 딟;

    private 떆([In] 떀 obj0, [In] int obj1, [In] 떀 obj2, [In] int obj3) => this.딟(obj0, obj1, obj2, obj3);

    [CompilerGenerated]
    [SpecialName]
    public float 딟() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] float obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 땄() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] float obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] float obj0) => this.딢 = obj0;

    public void 딢() => this.땄(딝.땥.땄(this.딟.떂(), this.땄.떂()));

    public void 땃() => this.딟(딝.땥.딟(this.딟.떎(), this.땄.떎()));

    [SpecialName]
    public void 딟([In] bool obj0)
    {
      if (obj0)
        this.딟 |= 땏.딢;
      else
        this.딟 &= ~땏.딢;
    }

    [SpecialName]
    public bool 딶() => (this.딟 & 땏.딢) == 땏.딢;

    public void 땓() => this.딟 |= 땏.딢;

    public void 땺() => this.딟 &= ~땏.딢;

    [CompilerGenerated]
    [SpecialName]
    public int 땥() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    internal void 딟([In] int obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 딝() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    internal void 땄([In] int obj0) => this.딧 = obj0;

    public void 딟(out 땺.따 _param1) => _param1 = this.딟;

    public void 딟(out 떁 _param1, out 땂<떁> _param2)
    {
      딺 딺1 = this.딟.땓();
      딺 딺2 = this.땄.땓();
      땺.땏 땏1 = this.딟.땃();
      땺.땏 땏2 = this.땄.땃();
      땗.딪.딟(ref this.딟, ref 딺1.딟, 땏1.딶(), ref 딺2.딟, 땏2.딶(), out _param1, out _param2);
    }

    public bool 떎() => (this.딟 & 땏.딧) == 땏.딧;

    public void 떂() => this.딟 |= 땏.땃;

    private void 딟([In] 떀 obj0, [In] int obj1, [In] 떀 obj2, [In] int obj3)
    {
      this.딟 = 땏.딢;
      this.딟 = obj0;
      this.땄 = obj2;
      this.딟(obj1);
      this.땄(obj3);
      this.딟.딟 = 0;
      this.딟.딟 = (떆) null;
      this.딟.땄 = (땙) null;
      this.딟.딟 = (땙) null;
      this.딟.딟 = (딺) null;
      this.땄.딟 = (떆) null;
      this.땄.땄 = (땙) null;
      this.땄.딟 = (땙) null;
      this.땄.딟 = (딺) null;
      this.딟 = 0;
      if (this.딟 != null && this.땄 != null)
      {
        this.딟(딝.땥.딟(this.딟.떎(), this.땄.떎()));
        this.땄(딝.땥.땄(this.딟.떂(), this.땄.떂()));
      }
      this.딧(0.0f);
    }

    internal void 딟([In] 딘 obj0)
    {
      땺.따 딟1 = this.딟;
      this.딟 |= 땏.딢;
      bool flag1 = (this.딟 & 땏.딧) == 땏.딧;
      bool flag2 = this.딟.딶() || this.땄.딶();
      딺 딺1 = this.딟.땓();
      딺 딺2 = this.땄.땓();
      bool flag3;
      if (flag2)
      {
        땺.땏 땏1 = this.딟.땃();
        땺.땏 땏2 = this.땄.땃();
        flag3 = AABB.딟(땏1, this.땥(), 땏2, this.딝(), ref 딺1.딟, ref 딺2.딟);
        this.딟.딟 = 0;
      }
      else
      {
        this.딟(ref this.딟, ref 딺1.딟, ref 딺2.딟);
        flag3 = this.딟.딟 > 0;
        for (int index1 = 0; index1 < this.딟.딟; ++index1)
        {
          땺.땕 땕1 = this.딟.딟.딟(index1);
          땕1.딟 = 0.0f;
          땕1.땄 = 0.0f;
          땺.땪 딟2 = 땕1.딟;
          for (int index2 = 0; index2 < 딟1.딟; ++index2)
          {
            땺.땕 땕2 = 딟1.딟.딟(index2);
            if ((int) 땕2.딟.딟 == (int) 딟2.딟)
            {
              땕1.딟 = 땕2.딟;
              땕1.땄 = 땕2.땄;
              break;
            }
          }
          this.딟.딟.딟(index1, 땕1);
        }
        if (flag3 != flag1)
        {
          딺1.딧(true);
          딺2.딧(true);
        }
      }
      if (flag3)
        this.딟 |= 땏.딧;
      else
        this.딟 &= ~땏.딧;
      if (!flag1)
      {
        if (flag3)
        {
          bool flag4 = this.딟.딟 == null || this.딟.딟(this.딟, this.땄, this);
          bool flag5 = this.땄.딟 == null || this.땄.딟(this.땄, this.딟, this);
          this.딟(flag4 && flag5);
          if (flag4 && flag5 && obj0.딟 != null)
            this.딟(obj0.딟(this));
          if (!this.딶())
            this.딟 &= ~땏.딧;
        }
      }
      else if (!flag3)
      {
        if (this.딟 != null && this.딟.딟 != null)
          this.딟.딟(this.딟, this.땄);
        if (this.땄 != null && this.땄.딟 != null)
          this.땄.딟(this.땄, this.딟);
        if (obj0.딟 != null)
          obj0.딟(this);
      }
      if (flag2 || obj0.딟 == null)
        return;
      obj0.딟(this, ref 딟1);
    }

    private void 딟([In] ref 땺.따 obj0, [In] ref 떓 obj1, [In] ref 떓 obj2)
    {
      switch (this.딟)
      {
        case 떆.땐.땄:
          땺.딩.딟(ref obj0, (땺.떅) this.딟.땃(), ref obj1, (땺.떅) this.땄.땃(), ref obj2);
          break;
        case 떆.땐.딧:
          땺.딩.딟(ref obj0, (땺.떅) this.딟.땃(), ref obj1, (땺.땶) this.땄.땃(), ref obj2);
          break;
        case 떆.땐.딢:
          땺.딩.딟(ref obj0, (땺.땶) this.딟.땃(), ref obj1, (땺.땶) this.땄.땃(), ref obj2);
          break;
        case 떆.땐.땃:
          땺.딩.딟(ref obj0, (땺.땖) this.딟.땃(), ref obj1, (땺.떅) this.땄.땃(), ref obj2);
          break;
        case 떆.땐.딶:
          땺.딩.딟(ref obj0, (땺.땖) this.딟.땃(), ref obj1, (땺.땶) this.땄.땃(), ref obj2);
          break;
        case 떆.땐.땓:
          ((땺.땿) this.딟.땃()).딟(ref 떆.딟, this.땥());
          땺.딩.딟(ref obj0, 떆.딟, ref obj1, (땺.떅) this.땄.땃(), ref obj2);
          break;
        case 떆.땐.땺:
          ((땺.땿) this.딟.땃()).딟(ref 떆.딟, this.땥());
          땺.딩.딟(ref obj0, 떆.딟, ref obj1, (땺.땶) this.땄.땃(), ref obj2);
          break;
      }
    }

    internal static 떆 땄([In] 떀 obj0, [In] int obj1, [In] 떀 obj2, [In] int obj3)
    {
      땺.땙 땙1 = obj0.딢();
      땺.땙 땙2 = obj2.딢();
      Queue<떆> 딟 = obj0.땓().딟.딟;
      떆 떆;
      if (딟.Count > 0)
      {
        떆 = 딟.Dequeue();
        if ((땙1 >= 땙2 || 땙1 == 땺.땙.딧 && 땙2 == 땺.땙.딢) && (땙2 != 땺.땙.딧 || 땙1 != 땺.땙.딢))
          떆.딟(obj0, obj1, obj2, obj3);
        else
          떆.딟(obj2, obj3, obj0, obj1);
      }
      else
        떆 = 땙1 < 땙2 && (땙1 != 땺.땙.딧 || 땙2 != 땺.땙.딢) || 땙2 == 땺.땙.딧 && 땙1 == 땺.땙.딢 ? new 떆(obj2, obj3, obj0, obj1) : new 떆(obj0, obj1, obj2, obj3);
      떆.딟 = 떆.딟[(int) 땙1, (int) 땙2];
      return 떆;
    }

    internal void 땭()
    {
      this.딟.땓().딟.딟.Enqueue(this);
      this.딟((떀) null, 0, (떀) null, 0);
    }

    private enum 땐
    {
      딟,
      땄,
      딧,
      딢,
      땃,
      딶,
      땓,
      땺,
    }
  }
}
