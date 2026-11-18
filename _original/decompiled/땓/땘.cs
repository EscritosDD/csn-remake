// Decompiled with JetBrains decompiler
// Type: 땓.땘
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 땓
{
  public class 땘
  {
    private 땁 딟;
    private 땷[] 딟 = new 땷[2];
    private float 딟 = 0.75f;
    private float 땄 = 3f;
    private int 딟;
    private 땘.떔 딟;
    private int 땄;
    public float 딧;

    public void 딟(
      [In] int obj0,
      [In] 땁 obj1,
      [In] CaptutrePointBackground[] obj2,
      [In] CaptutrePointBackground[] obj3,
      [In] int[] obj4)
    {
      this.딟(obj0, obj1.딢(), obj1.땃(), obj2, obj3, obj4);
    }

    public void 딟(
      [In] int obj0,
      [In] bool[] obj1,
      [In] bool[] obj2,
      [In] CaptutrePointBackground[] obj3,
      [In] CaptutrePointBackground[] obj4,
      [In] int[] obj5)
    {
      this.딟 = new 땁(obj1, obj2);
      this.땄 = obj0;
      this.딟[0] = new 땷(GlobalAppData.딟.GameAssets.Blue, obj3, obj5[0]);
      this.딟[1] = new 땷(GlobalAppData.딟.GameAssets.Red, obj4, obj5[1]);
      if (this.딟.땄())
      {
        this.딟 = obj0;
        this.딟 = 땘.떔.딢;
      }
      else if (obj1[0])
      {
        this.딟 = 0;
        this.딟 = 땘.떔.땄;
      }
      else if (obj1[1])
      {
        this.딟 = 1;
        this.딟 = 땘.떔.땄;
      }
      else
      {
        this.딟 = -1;
        this.딟 = 땘.떔.딢;
      }
    }

    public void 딟([In] int[] obj0)
    {
      if (this.딟 == null)
        return;
      this.딟[0].딟 = -1;
      this.딟[1].딟 = -1;
      this.땄(obj0);
    }

    private void 땄([In] int[] obj0)
    {
      switch (this.딟)
      {
        case 땘.떔.딟:
          if (!this.딟(this.딟, obj0))
            break;
          this.딟 = this.딟 != 0 ? 0 : 1;
          break;
        case 땘.떔.땄:
          this.딟(this.딟, obj0);
          break;
        case 땘.떔.딧:
          for (int index = 0; index < 2; ++index)
            this.딟(index, obj0);
          break;
      }
    }

    private float 딧([In] int[] obj0)
    {
      int index = this.땄 != 0 ? 0 : 1;
      return this.딟.땄(index) && obj0[index] == this.딟[index].딢().Length - 1 ? this.땄 : 1f;
    }

    private bool 딟([In] int obj0, [In] int[] obj1)
    {
      float num = this.딧 * this.딧(obj1);
      return this.딟[obj0].딟(num, this.딟, obj1[obj0]);
    }

    public enum 떔
    {
      딟,
      땄,
      딧,
      딢,
    }
  }
}
