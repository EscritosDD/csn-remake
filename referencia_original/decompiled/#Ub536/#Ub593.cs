// Decompiled with JetBrains decompiler
// Type: 딶.떓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떓
  {
    private float 딟;
    private float 땄;
    private float[] 딟;
    private int 딟;
    public float 딧;
    public float 딢;
    private int 땄;

    public 떓([In] string obj0, [In] int obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      this.딟 = new float[obj1];
    }

    public void 딟()
    {
      float num = Mathf.Abs(Input.GetAxis(this.딢()));
      this.딟[this.딟++] = num;
      if (this.딟 >= this.딟.Length)
        this.딟 = 0;
      this.땄 = 0.0f;
      for (int index = 0; index < this.딟.Length; ++index)
        this.땄 += this.딟[index];
      this.땄 /= (float) this.딟.Length;
      if ((double) num > 0.0)
      {
        this.딧 += num;
        this.딢 = this.딧 / (float) ++this.땄;
      }
      if ((double) this.땄 > (double) this.딟)
        this.딟 = this.땄;
      // ISSUE: reference to a compiler-generated method
      this.딟((float) (0.25 * (double) this.딟 + (double) this.딢 * 0.75));
    }

    public float 땄()
    {
      float num = (double) this.딧() <= 0.100000001490116 ? 0.1f : this.딧();
      return Mathf.Clamp(Input.GetAxis(this.딢()), -num, num) / num;
    }

    [CompilerGenerated]
    [SpecialName]
    public float 딧() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public string 딢() => this.딟;
  }
}
