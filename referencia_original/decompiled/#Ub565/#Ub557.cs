// Decompiled with JetBrains decompiler
// Type: 땥.땗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 땗
  {
    public 딽 딟;
    public 딵[] 딟;
    public 땰[] 딟;
    public 땡[] 딟;
    public 딜[] 딟;
    public 떆[] 딟;
    public int 딟;

    public void 딟([In] 딽 obj0, [In] int obj1, [In] 떆[] obj2, [In] 딵[] obj3, [In] 땰[] obj4)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj3;
      this.딟 = obj4;
      this.딟 = obj2;
      if (this.딟 == null || this.딟.Length < obj1)
      {
        this.딟 = new 딜[obj1 * 2];
        this.딟 = new 땡[obj1 * 2];
        for (int index = 0; index < this.딟.Length; ++index)
          this.딟[index] = new 딜();
        for (int index = 0; index < this.딟.Length; ++index)
          this.딟[index] = new 땡();
      }
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        떆 떆 = obj2[index1];
        떀 딟1 = 떆.딟;
        떀 땄 = 떆.땄;
        땺.땏 땏1 = 딟1.땃();
        땺.땏 땏2 = 땄.땃();
        float num1 = 땏1.딶();
        float num2 = 땏2.딶();
        딺 딺1 = 딟1.땓();
        딺 딺2 = 땄.땓();
        땺.따 딟2 = 떆.딟;
        int 딟3 = 딟2.딟;
        딜 딜 = this.딟[index1];
        딜.땃 = 떆.딟();
        딜.딶 = 떆.땄();
        딜.땓 = 떆.딧();
        딜.딟 = 딺1.딧;
        딜.땄 = 딺2.딧;
        딜.딟 = 딺1.딧;
        딜.땄 = 딺2.딧;
        딜.딧 = 딺1.땄;
        딜.딢 = 딺2.땄;
        딜.딢 = index1;
        딜.딧 = 딟3;
        딜.땄.딧();
        딜.딟.딧();
        땡 땡 = this.딟[index1];
        땡.딟 = 딺1.딧;
        땡.땄 = 딺2.딧;
        땡.딟 = 딺1.딧;
        땡.땄 = 딺2.딧;
        땡.딧 = 딺1.딟.딧;
        땡.딢 = 딺2.딟.딧;
        땡.딧 = 딺1.땄;
        땡.딢 = 딺2.땄;
        땡.딟 = 딟2.딟;
        땡.땄 = 딟2.땄;
        땡.딧 = 딟3;
        땡.땃 = num1;
        땡.딶 = num2;
        땡.딟 = 딟2.딟;
        for (int index2 = 0; index2 < 딟3; ++index2)
        {
          땺.땕 땕 = 딟2.딟.딟(index2);
          딻 딻 = 딜.딟[index2];
          if (딝.땥.딧)
          {
            딻.딟 = this.딟.땄 * 땕.딟;
            딻.땄 = this.딟.땄 * 땕.땄;
          }
          else
          {
            딻.딟 = 0.0f;
            딻.땄 = 0.0f;
          }
          딻.딟 = 떁.딟();
          딻.땄 = 떁.딟();
          딻.딧 = 0.0f;
          딻.딢 = 0.0f;
          딻.땃 = 0.0f;
          땡.딟[index2] = 땕.딟;
        }
      }
    }

    public void 딟()
    {
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        딜 딜 = this.딟[index1];
        땡 땡 = this.딟[index1];
        float 땃 = 땡.땃;
        float 딶 = 땡.딶;
        땺.따 딟1 = this.딟[딜.딢].딟;
        int 딟2 = 딜.딟;
        int 땄1 = 딜.땄;
        float 딟3 = 딜.딟;
        float 땄2 = 딜.땄;
        float 딧1 = 딜.딧;
        float 딢1 = 딜.딢;
        떁 딧2 = 땡.딧;
        떁 딢2 = 땡.딢;
        떁 딟4 = this.딟[딟2].딟;
        float 딟5 = this.딟[딟2].딟;
        떁 딟6 = this.딟[딟2].딟;
        float 딟7 = this.딟[딟2].딟;
        떁 딟8 = this.딟[땄1].딟;
        float 딟9 = this.딟[땄1].딟;
        떁 딟10 = this.딟[땄1].딟;
        float 딟11 = this.딟[땄1].딟;
        떓 떓1 = new 떓();
        떓 떓2 = new 떓();
        떓1.딟.딟(딟5);
        떓2.딟.딟(딟9);
        떓1.딟 = 딟4 - 땴.딟(떓1.딟, 딧2);
        떓2.딟 = 딟8 - 땴.딟(떓2.딟, 딢2);
        떁 떁1;
        땂<떁> 땂;
        땗.딪.딟(ref 딟1, ref 떓1, 땃, ref 떓2, 딶, out 떁1, out 땂);
        딜.딟 = 떁1;
        int 딧3 = 딜.딧;
        for (int index2 = 0; index2 < 딧3; ++index2)
        {
          딻 딻 = 딜.딟[index2];
          딻.딟 = 땂.딟(index2) - 딟4;
          딻.땄 = 땂.딟(index2) - 딟8;
          float num1 = 땴.딟(딻.딟, 딜.딟);
          float num2 = 땴.딟(딻.땄, 딜.딟);
          float num3 = (float) ((double) 딟3 + (double) 땄2 + (double) 딧1 * (double) num1 * (double) num1 + (double) 딢1 * (double) num2 * (double) num2);
          딻.딧 = (double) num3 <= 0.0 ? 0.0f : 1f / num3;
          떁 떁2 = 땴.딟(딜.딟, 1f);
          float num4 = 땴.딟(딻.딟, 떁2);
          float num5 = 땴.딟(딻.땄, 떁2);
          float num6 = (float) ((double) 딟3 + (double) 땄2 + (double) 딧1 * (double) num4 * (double) num4 + (double) 딢1 * (double) num5 * (double) num5);
          딻.딢 = (double) num6 <= 0.0 ? 0.0f : 1f / num6;
          딻.땃 = 0.0f;
          float num7 = 떁.딶(딜.딟, 딟10 + 땴.딟(딟11, 딻.땄) - 딟6 - 땴.딟(딟7, 딻.딟));
          if ((double) num7 < -1.0)
            딻.땃 = -딜.딶 * num7;
        }
        if (딜.딧 == 2)
        {
          딻 딻1 = 딜.딟[0];
          딻 딻2 = 딜.딟[1];
          float num8 = 땴.딟(딻1.딟, 딜.딟);
          float num9 = 땴.딟(딻1.땄, 딜.딟);
          float num10 = 땴.딟(딻2.딟, 딜.딟);
          float num11 = 땴.딟(딻2.땄, 딜.딟);
          float num12 = (float) ((double) 딟3 + (double) 땄2 + (double) 딧1 * (double) num8 * (double) num8 + (double) 딢1 * (double) num9 * (double) num9);
          float num13 = (float) ((double) 딟3 + (double) 땄2 + (double) 딧1 * (double) num10 * (double) num10 + (double) 딢1 * (double) num11 * (double) num11);
          float num14 = (float) ((double) 딟3 + (double) 땄2 + (double) 딧1 * (double) num8 * (double) num10 + (double) 딢1 * (double) num9 * (double) num11);
          if ((double) num12 * (double) num12 < 1000.0 * ((double) num12 * (double) num13 - (double) num14 * (double) num14))
          {
            딜.땄.딟 = new 떁(num12, num14);
            딜.땄.땄 = new 떁(num14, num13);
            딜.딟 = 딜.땄.딟();
          }
          else
            딜.딧 = 1;
        }
      }
    }

    public void 땄()
    {
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        딜 딜 = this.딟[index1];
        int 딟1 = 딜.딟;
        int 땄1 = 딜.땄;
        float 딟2 = 딜.딟;
        float 딧1 = 딜.딧;
        float 땄2 = 딜.땄;
        float 딢 = 딜.딢;
        int 딧2 = 딜.딧;
        떁 딟3 = this.딟[딟1].딟;
        float 딟4 = this.딟[딟1].딟;
        떁 딟5 = this.딟[땄1].딟;
        float 딟6 = this.딟[땄1].딟;
        떁 딟7 = 딜.딟;
        떁 떁1 = 땴.딟(딟7, 1f);
        for (int index2 = 0; index2 < 딧2; ++index2)
        {
          딻 딻 = 딜.딟[index2];
          떁 떁2 = 딻.딟 * 딟7 + 딻.땄 * 떁1;
          딟4 -= 딧1 * 땴.딟(딻.딟, 떁2);
          딟3 -= 딟2 * 떁2;
          딟6 += 딢 * 땴.딟(딻.땄, 떁2);
          딟5 += 땄2 * 떁2;
        }
        this.딟[딟1].딟 = 딟3;
        this.딟[딟1].딟 = 딟4;
        this.딟[땄1].딟 = 딟5;
        this.딟[땄1].딟 = 딟6;
      }
    }

    public void 딧()
    {
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        딜 딜 = this.딟[index1];
        int 딟1 = 딜.딟;
        int 땄1 = 딜.땄;
        float 딟2 = 딜.딟;
        float 딧1 = 딜.딧;
        float 땄2 = 딜.땄;
        float 딢 = 딜.딢;
        int 딧2 = 딜.딧;
        떁 딟3 = this.딟[딟1].딟;
        float 딟4 = this.딟[딟1].딟;
        떁 딟5 = this.딟[땄1].딟;
        float 딟6 = this.딟[땄1].딟;
        떁 딟7 = 딜.딟;
        떁 떁1 = 땴.딟(딟7, 1f);
        float 땃 = 딜.땃;
        for (int index2 = 0; index2 < 딧2; ++index2)
        {
          딻 딻 = 딜.딟[index2];
          float num1 = 떁.딶(딟5 + 땴.딟(딟6, 딻.땄) - 딟3 - 땴.딟(딟4, 딻.딟), 떁1) - 딜.땓;
          float num2 = 딻.딢 * -num1;
          float num3 = 땃 * 딻.딟;
          float num4 = 땴.딟(딻.땄 + num2, -num3, num3);
          float num5 = num4 - 딻.땄;
          딻.땄 = num4;
          떁 떁2 = num5 * 떁1;
          딟3 -= 딟2 * 떁2;
          딟4 -= 딧1 * 땴.딟(딻.딟, 떁2);
          딟5 += 땄2 * 떁2;
          딟6 += 딢 * 땴.딟(딻.땄, 떁2);
        }
        if (딜.딧 == 1)
        {
          딻 딻 = 딜.딟[0];
          float num6 = 떁.딶(딟5 + 땴.딟(딟6, 딻.땄) - 딟3 - 땴.딟(딟4, 딻.딟), 딟7);
          float num7 = (float) (-(double) 딻.딧 * ((double) num6 - (double) 딻.땃));
          float num8 = Math.Max(딻.딟 + num7, 0.0f);
          float num9 = num8 - 딻.딟;
          딻.딟 = num8;
          떁 떁3 = num9 * 딟7;
          딟3 -= 딟2 * 떁3;
          딟4 -= 딧1 * 땴.딟(딻.딟, 떁3);
          딟5 += 땄2 * 떁3;
          딟6 += 딢 * 땴.딟(딻.땄, 떁3);
        }
        else
        {
          딻 딻1 = 딜.딟[0];
          딻 딻2 = 딜.딟[1];
          떁 떁4 = new 떁(딻1.딟, 딻2.딟);
          떁 떁5 = 딟5 + 땴.딟(딟6, 딻1.땄) - 딟3 - 땴.딟(딟4, 딻1.딟);
          떁 떁6 = 딟5 + 땴.딟(딟6, 딻2.땄) - 딟3 - 땴.딟(딟4, 딻2.딟);
          float num10 = 떁.딶(떁5, 딟7);
          float num11 = 떁.딶(떁6, 딟7);
          떁 떁7 = new 떁();
          떁7.딟 = num10 - 딻1.땃;
          떁7.땄 = num11 - 딻2.땃;
          떁7 -= 땴.딟(ref 딜.땄, 떁4);
          떁 떁8 = -땴.딟(ref 딜.딟, 떁7);
          if ((double) 떁8.딟 >= 0.0 && (double) 떁8.땄 >= 0.0)
          {
            떁 떁9 = 떁8 - 떁4;
            떁 떁10 = 떁9.딟 * 딟7;
            떁 떁11 = 떁9.땄 * 딟7;
            딟3 -= 딟2 * (떁10 + 떁11);
            딟4 -= 딧1 * (땴.딟(딻1.딟, 떁10) + 땴.딟(딻2.딟, 떁11));
            딟5 += 땄2 * (떁10 + 떁11);
            딟6 += 딢 * (땴.딟(딻1.땄, 떁10) + 땴.딟(딻2.땄, 떁11));
            딻1.딟 = 떁8.딟;
            딻2.딟 = 떁8.땄;
          }
          else
          {
            떁8.딟 = -딻1.딧 * 떁7.딟;
            떁8.땄 = 0.0f;
            float num12 = 딜.땄.딟.땄 * 떁8.딟 + 떁7.땄;
            if ((double) 떁8.딟 >= 0.0 && (double) num12 >= 0.0)
            {
              떁 떁12 = 떁8 - 떁4;
              떁 떁13 = 떁12.딟 * 딟7;
              떁 떁14 = 떁12.땄 * 딟7;
              딟3 -= 딟2 * (떁13 + 떁14);
              딟4 -= 딧1 * (땴.딟(딻1.딟, 떁13) + 땴.딟(딻2.딟, 떁14));
              딟5 += 땄2 * (떁13 + 떁14);
              딟6 += 딢 * (땴.딟(딻1.땄, 떁13) + 땴.딟(딻2.땄, 떁14));
              딻1.딟 = 떁8.딟;
              딻2.딟 = 떁8.땄;
            }
            else
            {
              떁8.딟 = 0.0f;
              떁8.땄 = -딻2.딧 * 떁7.땄;
              float num13 = 딜.땄.땄.딟 * 떁8.땄 + 떁7.딟;
              if ((double) 떁8.땄 >= 0.0 && (double) num13 >= 0.0)
              {
                떁 떁15 = 떁8 - 떁4;
                떁 떁16 = 떁15.딟 * 딟7;
                떁 떁17 = 떁15.땄 * 딟7;
                딟3 -= 딟2 * (떁16 + 떁17);
                딟4 -= 딧1 * (땴.딟(딻1.딟, 떁16) + 땴.딟(딻2.딟, 떁17));
                딟5 += 땄2 * (떁16 + 떁17);
                딟6 += 딢 * (땴.딟(딻1.땄, 떁16) + 땴.딟(딻2.땄, 떁17));
                딻1.딟 = 떁8.딟;
                딻2.딟 = 떁8.땄;
              }
              else
              {
                떁8.딟 = 0.0f;
                떁8.땄 = 0.0f;
                float 딟8 = 떁7.딟;
                float 땄3 = 떁7.땄;
                if ((double) 딟8 >= 0.0 && (double) 땄3 >= 0.0)
                {
                  떁 떁18 = 떁8 - 떁4;
                  떁 떁19 = 떁18.딟 * 딟7;
                  떁 떁20 = 떁18.땄 * 딟7;
                  딟3 -= 딟2 * (떁19 + 떁20);
                  딟4 -= 딧1 * (땴.딟(딻1.딟, 떁19) + 땴.딟(딻2.딟, 떁20));
                  딟5 += 땄2 * (떁19 + 떁20);
                  딟6 += 딢 * (땴.딟(딻1.땄, 떁19) + 땴.딟(딻2.땄, 떁20));
                  딻1.딟 = 떁8.딟;
                  딻2.딟 = 떁8.땄;
                }
              }
            }
          }
        }
        this.딟[딟1].딟 = 딟3;
        this.딟[딟1].딟 = 딟4;
        this.딟[땄1].딟 = 딟5;
        this.딟[땄1].딟 = 딟6;
      }
    }

    public void 딢()
    {
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        딜 딜 = this.딟[index1];
        땺.따 딟 = this.딟[딜.딢].딟;
        for (int index2 = 0; index2 < 딜.딧; ++index2)
        {
          땺.땕 땕 = 딟.딟.딟(index2);
          땕.딟 = 딜.딟[index2].딟;
          땕.땄 = 딜.딟[index2].땄;
          딟.딟.딟(index2, 땕);
        }
        this.딟[딜.딢].딟 = 딟;
      }
    }

    public bool 땃()
    {
      float val1 = 0.0f;
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        땡 땡 = this.딟[index1];
        int 딟1 = 땡.딟;
        int 땄1 = 땡.땄;
        떁 딧1 = 땡.딧;
        float 딟2 = 땡.딟;
        float 딧2 = 땡.딧;
        떁 딢1 = 땡.딢;
        float 땄2 = 땡.땄;
        float 딢2 = 땡.딢;
        int 딧3 = 땡.딧;
        떁 딟3 = this.딟[딟1].딟;
        float 딟4 = this.딟[딟1].딟;
        떁 딟5 = this.딟[땄1].딟;
        float 딟6 = this.딟[땄1].딟;
        for (int index2 = 0; index2 < 딧3; ++index2)
        {
          떓 떓1 = new 떓();
          떓 떓2 = new 떓();
          떓1.딟.딟(딟4);
          떓2.딟.딟(딟6);
          떓1.딟 = 딟3 - 땴.딟(떓1.딟, 딧1);
          떓2.딟 = 딟5 - 땴.딟(떓2.딟, 딢1);
          떁 떁1;
          떁 떁2;
          float val2;
          땗.떕.딟(땡, 떓1, 떓2, index2, out 떁1, out 떁2, out val2);
          떁 떁3 = 떁2 - 딟3;
          떁 떁4 = 떁2 - 딟5;
          val1 = Math.Min(val1, val2);
          float num1 = 땴.딟((float) (0.200000002980232 * ((double) val2 + 0.00499999988824129)), -0.2f, 0.0f);
          float num2 = 땴.딟(떁3, 떁1);
          float num3 = 땴.딟(떁4, 떁1);
          float num4 = (float) ((double) 딟2 + (double) 땄2 + (double) 딧2 * (double) num2 * (double) num2 + (double) 딢2 * (double) num3 * (double) num3);
          떁 떁5 = ((double) num4 <= 0.0 ? 0.0f : -num1 / num4) * 떁1;
          딟3 -= 딟2 * 떁5;
          딟4 -= 딧2 * 땴.딟(떁3, 떁5);
          딟5 += 땄2 * 떁5;
          딟6 += 딢2 * 땴.딟(떁4, 떁5);
        }
        this.딟[딟1].딟 = 딟3;
        this.딟[딟1].딟 = 딟4;
        this.딟[땄1].딟 = 딟5;
        this.딟[땄1].딟 = 딟6;
      }
      return (double) val1 >= -0.0149999996647239;
    }

    public bool 딟([In] int obj0, [In] int obj1)
    {
      float val1 = 0.0f;
      for (int index1 = 0; index1 < this.딟; ++index1)
      {
        땡 땡 = this.딟[index1];
        int 딟1 = 땡.딟;
        int 땄1 = 땡.땄;
        떁 딧1 = 땡.딧;
        떁 딢1 = 땡.딢;
        int 딧2 = 땡.딧;
        float num1 = 0.0f;
        float num2 = 0.0f;
        if (딟1 == obj0 || 딟1 == obj1)
        {
          num1 = 땡.딟;
          num2 = 땡.딧;
        }
        float 땄2 = 땡.땄;
        float 딢2 = 땡.딢;
        if (땄1 == obj0 || 땄1 == obj1)
        {
          땄2 = 땡.땄;
          딢2 = 땡.딢;
        }
        떁 딟2 = this.딟[딟1].딟;
        float 딟3 = this.딟[딟1].딟;
        떁 딟4 = this.딟[땄1].딟;
        float 딟5 = this.딟[땄1].딟;
        for (int index2 = 0; index2 < 딧2; ++index2)
        {
          떓 떓1 = new 떓();
          떓 떓2 = new 떓();
          떓1.딟.딟(딟3);
          떓2.딟.딟(딟5);
          떓1.딟 = 딟2 - 땴.딟(떓1.딟, 딧1);
          떓2.딟 = 딟4 - 땴.딟(떓2.딟, 딢1);
          떁 떁1;
          떁 떁2;
          float val2;
          땗.떕.딟(땡, 떓1, 떓2, index2, out 떁1, out 떁2, out val2);
          떁 떁3 = 떁2 - 딟2;
          떁 떁4 = 떁2 - 딟4;
          val1 = Math.Min(val1, val2);
          float num3 = 땴.딟((float) (0.200000002980232 * ((double) val2 + 0.00499999988824129)), -0.2f, 0.0f);
          float num4 = 땴.딟(떁3, 떁1);
          float num5 = 땴.딟(떁4, 떁1);
          float num6 = (float) ((double) num1 + (double) 땄2 + (double) num2 * (double) num4 * (double) num4 + (double) 딢2 * (double) num5 * (double) num5);
          떁 떁5 = ((double) num6 <= 0.0 ? 0.0f : -num3 / num6) * 떁1;
          딟2 -= num1 * 떁5;
          딟3 -= num2 * 땴.딟(떁3, 떁5);
          딟4 += 땄2 * 떁5;
          딟5 += 딢2 * 땴.딟(떁4, 떁5);
        }
        this.딟[딟1].딟 = 딟2;
        this.딟[딟1].딟 = 딟3;
        this.딟[땄1].딟 = 딟4;
        this.딟[땄1].딟 = 딟5;
      }
      return (double) val1 >= -0.00749999983236194;
    }

    public static class 딪
    {
      public static void 딟(
        [In] ref 땺.따 obj0,
        [In] ref 떓 obj1,
        [In] float obj2,
        [In] ref 떓 obj3,
        [In] float obj4,
        out 떁 _param5,
        out 땂<떁> _param6)
      {
        _param5 = 떁.딟();
        _param6 = new 땂<떁>();
        if (obj0.딟 == 0)
          return;
        switch (obj0.딟)
        {
          case 땺.딚.딟:
            _param5 = new 떁(1f, 0.0f);
            떁 떁1 = 땴.딟(ref obj1, obj0.땄);
            떁 떁2 = 땴.딟(ref obj3, obj0.딟.딟(0).딟);
            if ((double) 떁.딢(떁1, 떁2) > 1.4210854715202E-14)
            {
              _param5 = 떁2 - 떁1;
              _param5.땓();
            }
            떁 떁3 = 떁1 + obj2 * _param5;
            떁 떁4 = 떁2 - obj4 * _param5;
            _param6.딟(0, 0.5f * (떁3 + 떁4));
            break;
          case 땺.딚.땄:
            _param5 = 땴.딟(obj1.딟, obj0.딟);
            떁 떁5 = 땴.딟(ref obj1, obj0.땄);
            for (int index = 0; index < obj0.딟; ++index)
            {
              떁 떁6 = 땴.딟(ref obj3, obj0.딟.딟(index).딟);
              떁 떁7 = 떁6 + (obj2 - 떁.딶(떁6 - 떁5, _param5)) * _param5;
              떁 떁8 = 떁6 - obj4 * _param5;
              _param6.딟(index, 0.5f * (떁7 + 떁8));
            }
            break;
          case 땺.딚.딧:
            _param5 = 땴.딟(obj3.딟, obj0.딟);
            떁 떁9 = 땴.딟(ref obj3, obj0.땄);
            for (int index = 0; index < obj0.딟; ++index)
            {
              떁 떁10 = 땴.딟(ref obj1, obj0.딟.딟(index).딟);
              떁 떁11 = 떁10 + (obj4 - 떁.딶(떁10 - 떁9, _param5)) * _param5;
              떁 떁12 = 떁10 - obj2 * _param5;
              _param6.딟(index, 0.5f * (떁12 + 떁11));
            }
            _param5 = -_param5;
            break;
        }
      }
    }

    private static class 떕
    {
      public static void 딟(
        [In] 땡 obj0,
        [In] 떓 obj1,
        [In] 떓 obj2,
        [In] int obj3,
        out 떁 _param4,
        out 떁 _param5,
        out float _param6)
      {
        switch (obj0.딟)
        {
          case 땺.딚.딟:
            떁 떁1 = 땴.딟(ref obj1, obj0.땄);
            떁 떁2 = 땴.딟(ref obj2, obj0.딟[0]);
            _param4 = 떁2 - 떁1;
            _param4.땓();
            _param5 = 0.5f * (떁1 + 떁2);
            _param6 = 떁.딶(떁2 - 떁1, _param4) - obj0.땃 - obj0.딶;
            break;
          case 땺.딚.땄:
            _param4 = 땴.딟(obj1.딟, obj0.딟);
            떁 떁3 = 땴.딟(ref obj1, obj0.땄);
            떁 떁4 = 땴.딟(ref obj2, obj0.딟[obj3]);
            _param6 = 떁.딶(떁4 - 떁3, _param4) - obj0.땃 - obj0.딶;
            _param5 = 떁4;
            break;
          case 땺.딚.딧:
            _param4 = 땴.딟(obj2.딟, obj0.딟);
            떁 떁5 = 땴.딟(ref obj2, obj0.땄);
            떁 떁6 = 땴.딟(ref obj1, obj0.딟[obj3]);
            _param6 = 떁.딶(떁6 - 떁5, _param4) - obj0.땃 - obj0.딶;
            _param5 = 떁6;
            _param4 = -_param4;
            break;
          default:
            _param4 = 떁.딟();
            _param5 = 떁.딟();
            _param6 = 0.0f;
            break;
        }
      }
    }
  }
}
