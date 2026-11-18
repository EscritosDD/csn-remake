// Decompiled with JetBrains decompiler
// Type: 딧.땃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  public abstract class 땃
  {
    protected List<땋> 딟 = new List<땋>();

    public 땃([In] bool obj0) => this.딟(obj0);

    public virtual void 딟()
    {
      int index = 0;
      while (index < this.딟.Count)
      {
        땋 땋 = this.딟[index];
        if (!땋.땺())
        {
          if (땋.떎())
          {
            딟.딦.딟("Timeout", new Dictionary<string, string>()
            {
              {
                "uri",
                땋.땥()
              },
              {
                "reach",
                this.딢().ToString()
              }
            });
            땋.땄();
            this.딟.RemoveAt(index);
          }
          else
            ++index;
        }
        else
        {
          땋.딢();
          if (땋.딝() == null || this.딟(땋))
          {
            땋.땄();
            this.딟.RemoveAt(index);
          }
          else
          {
            if (!this.땄())
              ;
            땋.딟();
            this.딟.RemoveAt(index);
          }
        }
      }
    }

    protected virtual bool 딟([In] 땋 obj0) => false;

    public virtual void 딧([In] 땋 obj0) => this.딟.Add(obj0);

    public abstract int 딢();

    public abstract void 땄([In] 땋 obj0);

    public abstract string 땃();

    [CompilerGenerated]
    [SpecialName]
    public bool 땄() => this.딟;
  }
}
