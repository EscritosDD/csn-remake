// Decompiled with JetBrains decompiler
// Type: 땃.땔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땃
{
  public class 땔
  {
    public List<딣> 딟;

    public 땔() => this.딟 = new List<딣>();

    public 땔([In] 땔 obj0)
    {
      this.딟 = new List<딣>((IEnumerable<딣>) obj0.딟);
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟[index] = new 딣(obj0.딟[index]);
    }

    public void 딟([In] 딣 obj0)
    {
      bool flag = false;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        if (this.딟[index].딟 == obj0.딟 && this.딟[index].땄 == obj0.땄)
        {
          flag = true;
          this.딟(index, obj0);
          break;
        }
      }
      if (flag)
        return;
      this.딟.Add(obj0);
    }

    private void 딟([In] int obj0, [In] 딣 obj1)
    {
      this.딟[obj0].땄 = (double) obj1.땄 < 0.0 ? this.딟[obj0].땄 : obj1.땄;
      this.딟[obj0].딢 = (double) obj1.딢 < 0.0 ? this.딟[obj0].딢 : obj1.딢;
      this.딟[obj0].딟 = (double) obj1.딟 < 0.0 ? this.딟[obj0].딟 : obj1.딟;
      this.딟[obj0].딧 = (double) obj1.딧 < 0.0 ? this.딟[obj0].딧 : obj1.딧;
    }
  }
}
