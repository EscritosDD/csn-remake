// Decompiled with JetBrains decompiler
// Type: 땓.땷
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땷
  {
    public int 딟;
    private 땷.딸 딟;
    private bool 딟;

    public 땷([In] Color obj0, [In] CaptutrePointBackground[] obj1, [In] int obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      this.딟 = 땷.딸.딟;
      for (int index = 0; index < obj1.Length; ++index)
      {
        if (index < obj2)
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(1f);
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(0.0f);
        }
        this.딟(index);
      }
    }

    public void 딟([In] bool obj0) => this.딧(obj0);

    public void 땄([In] bool obj0) => this.딟 = obj0;

    public bool 딟([In] float obj0, [In] float obj1, [In] int obj2)
    {
      if (obj2 < this.딢().Length)
        this.딟(obj2);
      return this.딟(obj0, obj1);
    }

    private void 딟([In] int obj0)
    {
      Color color;
      // ISSUE: explicit constructor call
      ((Color) ref color).\u002Ector((float) this.딟().r, (float) this.딟().g, (float) this.딟().b, this.땄());
      this.딢()[obj0].딟(true);
      this.딢()[obj0].딟(color);
    }

    private bool 딟([In] float obj0, [In] float obj1)
    {
      switch (this.딟)
      {
        case 땷.딸.딟:
          땷 땷1 = this;
          double num1;
          float num2 = (float) (num1 = (double) 땷1.땄() + (double) obj0 * (double) Time.deltaTime);
          // ISSUE: reference to a compiler-generated method
          땷1.딟((float) num1);
          // ISSUE: reference to a compiler-generated method
          this.딟(num2);
          break;
        case 땷.딸.땄:
          땷 땷2 = this;
          double num3;
          float num4 = (float) (num3 = (double) 땷2.땄() - (double) obj0 * (double) Time.deltaTime);
          // ISSUE: reference to a compiler-generated method
          땷2.딟((float) num3);
          // ISSUE: reference to a compiler-generated method
          this.딟(num4);
          break;
      }
      if ((double) this.땄() <= 0.0)
        this.딟 = !this.딟 ? 땷.딸.딟 : 땷.딸.딧;
      else if ((double) this.땄() >= (double) obj1)
        this.딟 = 땷.딸.땄;
      // ISSUE: reference to a compiler-generated method
      this.딟(Mathf.Clamp(this.땄(), 0.0f, obj1));
      if (this.딟 != 땷.딸.딧)
        return false;
      this.딟 = 땷.딸.딟;
      return true;
    }

    [CompilerGenerated]
    [SpecialName]
    public Color 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public float 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public CaptutrePointBackground[] 딢() => this.딟;

    private enum 딸
    {
      딟,
      땄,
      딧,
    }
  }
}
