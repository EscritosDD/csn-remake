// Decompiled with JetBrains decompiler
// Type: 땥.땔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace 땥
{
  [XmlRoot("Path")]
  public class 땔
  {
    [XmlElement("ControlPoints")]
    public List<떁> 딟;
    private float 딟;

    public 땔() => this.딟 = new List<떁>();

    public 땔([In] 떁[] obj0)
    {
      this.딟 = new List<떁>(obj0.Length);
      for (int index = 0; index < obj0.Length; ++index)
        this.딟(obj0[index]);
    }

    public 땔([In] IList<떁> obj0)
    {
      this.딟 = new List<떁>(obj0.Count);
      for (int index = 0; index < obj0.Count; ++index)
        this.딟(obj0[index]);
    }

    [XmlElement("Closed")]
    public bool 딟 { get; [param: In] set; }

    public int 딟([In] int obj0) => obj0 == this.딟.Count - 1 ? 0 : obj0 + 1;

    public int 땄([In] int obj0) => obj0 == 0 ? this.딟.Count - 1 : obj0 - 1;

    public void 딟([In] ref 떁 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟[index] = 떁.땄(this.딟[index], obj0);
    }

    public void 땄([In] ref 떁 obj0)
    {
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟[index] = 떁.땥(this.딟[index], obj0);
    }

    public void 딟([In] float obj0)
    {
      딷 딷;
      딷.딧(obj0, out 딷);
      for (int index = 0; index < this.딟.Count; ++index)
        this.딟[index] = 떁.딟(this.딟[index], 딷);
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this.딟.Count; ++index)
      {
        stringBuilder.Append(this.딟[index].ToString());
        if (index < this.딟.Count - 1)
          stringBuilder.Append(" ");
      }
      return stringBuilder.ToString();
    }

    public 땨 딧([In] int obj0)
    {
      땨 땨 = new 땨();
      float num1 = 1f / (float) obj0;
      for (float num2 = 0.0f; (double) num2 < 1.0; num2 += num1)
        땨.Add(this.땄(num2));
      return 땨;
    }

    public 떁 땄([In] float obj0)
    {
      if (this.딟.Count < 2)
        throw new Exception("You need at least 2 control points to calculate a position.");
      떁 떁;
      if (this.딟)
      {
        this.딟(this.딟[0]);
        this.딟 = 1f / (float) (this.딟.Count - 1);
        int num1 = (int) ((double) obj0 / (double) this.딟);
        int index1 = num1 - 1;
        if (index1 < 0)
          index1 += this.딟.Count - 1;
        else if (index1 >= this.딟.Count - 1)
          index1 -= this.딟.Count - 1;
        int index2 = num1;
        if (index2 < 0)
          index2 += this.딟.Count - 1;
        else if (index2 >= this.딟.Count - 1)
          index2 -= this.딟.Count - 1;
        int index3 = num1 + 1;
        if (index3 < 0)
          index3 += this.딟.Count - 1;
        else if (index3 >= this.딟.Count - 1)
          index3 -= this.딟.Count - 1;
        int index4 = num1 + 2;
        if (index4 < 0)
          index4 += this.딟.Count - 1;
        else if (index4 >= this.딟.Count - 1)
          index4 -= this.딟.Count - 1;
        float num2 = (obj0 - this.딟 * (float) num1) / this.딟;
        떁 = 떁.딟(this.딟[index1], this.딟[index2], this.딟[index3], this.딟[index4], num2);
        this.딢(this.딟.Count - 1);
      }
      else
      {
        int num3 = (int) ((double) obj0 / (double) this.딟);
        int index5 = num3 - 1;
        if (index5 < 0)
          index5 = 0;
        else if (index5 >= this.딟.Count - 1)
          index5 = this.딟.Count - 1;
        int index6 = num3;
        if (index6 < 0)
          index6 = 0;
        else if (index6 >= this.딟.Count - 1)
          index6 = this.딟.Count - 1;
        int index7 = num3 + 1;
        if (index7 < 0)
          index7 = 0;
        else if (index7 >= this.딟.Count - 1)
          index7 = this.딟.Count - 1;
        int index8 = num3 + 2;
        if (index8 < 0)
          index8 = 0;
        else if (index8 >= this.딟.Count - 1)
          index8 = this.딟.Count - 1;
        float num4 = (obj0 - this.딟 * (float) num3) / this.딟;
        떁 = 떁.딟(this.딟[index5], this.딟[index6], this.딟[index7], this.딟[index8], num4);
      }
      return 떁;
    }

    public 떁 딧([In] float obj0)
    {
      float num = obj0 + 0.0001f;
      떁 떁1 = this.땄(obj0);
      떁 떁2 = this.땄(num);
      떁 떁3;
      떁.땓(ref 떁1, ref 떁2, out 떁3);
      떁 떁4;
      떁4.딟 = -떁3.땄;
      떁4.땄 = 떁3.딟;
      떁.땄(ref 떁4, out 떁4);
      return 떁4;
    }

    public void 딟([In] 떁 obj0)
    {
      this.딟.Add(obj0);
      this.딟 = 1f / (float) (this.딟.Count - 1);
    }

    public void 땄([In] 떁 obj0)
    {
      this.딟.Remove(obj0);
      this.딟 = 1f / (float) (this.딟.Count - 1);
    }

    public void 딢([In] int obj0)
    {
      this.딟.RemoveAt(obj0);
      this.딟 = 1f / (float) (this.딟.Count - 1);
    }

    public float 땄()
    {
      List<떁> 떁List = (List<떁>) this.딧(this.딟.Count * 25);
      float num = 0.0f;
      for (int index = 1; index < 떁List.Count; ++index)
        num += 떁.딧(떁List[index - 1], 떁List[index]);
      if (this.딟)
        num += 떁.딧(떁List[this.딟.Count - 1], 떁List[0]);
      return num;
    }

    public List<땟> 땃([In] int obj0)
    {
      List<땟> 땟List = new List<땟>();
      float num1 = (float) ((double) this.땄() / (double) obj0 + 1.0 / 1000.0);
      float num2 = 0.0f;
      떁 떁1 = this.딟[0];
      떁 떁2 = this.땄(num2);
      while ((double) num1 * 0.5 >= (double) 떁.딧(떁1, 떁2))
      {
        떁2 = this.땄(num2);
        num2 += 0.0001f;
        if ((double) num2 >= 1.0)
          break;
      }
      떁 떁3 = 떁2;
      for (int index = 1; index < obj0; ++index)
      {
        떁 떁4 = this.딧(num2);
        float num3 = (float) Math.Atan2((double) 떁4.땄, (double) 떁4.딟);
        땟List.Add(new 땟(떁2, num3));
        while ((double) num1 >= (double) 떁.딧(떁3, 떁2))
        {
          떁2 = this.땄(num2);
          num2 += 1E-05f;
          if ((double) num2 >= 1.0)
            break;
        }
        if ((double) num2 < 1.0)
          떁3 = 떁2;
        else
          break;
      }
      return 땟List;
    }
  }
}
