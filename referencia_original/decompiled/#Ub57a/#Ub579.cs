// Decompiled with JetBrains decompiler
// Type: 땺.땹
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 땺
{
  public class 땹 : 땥.딫, IDisposable
  {
    private const int 딟 = 2048;
    public const int 땄 = 32;
    private List<땈> 딟;
    private List<땈> 땄;
    private 떁[] 딟 = new 떁[딝.땥.땺];
    private List<땹.땉> 딟;
    private 땥.딷 딟;
    private 땥.딷 땄;
    public Color 딟 = new Color(0.9f, 0.7f, 0.7f);
    public Color 땄 = new Color(0.5f, 0.5f, 0.3f);
    public Color 딧 = new Color(0.5f, 0.5f, 0.9f);
    public Color 딢 = new Color(0.6f, 0.6f, 0.6f);
    public Color 땃 = new Color(0.5f, 0.9f, 0.5f);
    public Color 딶 = Color.white;
    private int 딧;
    private 땹.떇[] 딟 = new 땹.떇[2048];
    public 떁 딟 = new 떁(400f, 300f);
    private int 딢;
    private int 땃;
    private int 딶;
    public bool 딟 = true;
    public int 땓 = 500;
    public int 땺;
    public int 땥 = 1000;
    private List<float> 딟 = new List<float>();
    public Rect 딟 = new Rect(35f, 13f, 8f, 4f);
    private 떁[] 땄 = new 떁[4];
    public bool 땄 = true;

    public 땹([In] 땥.땱 obj0)
      : base(obj0)
    {
      this.딟 = new List<땈>();
      this.땄 = new List<땈>();
      obj0.떎().딟 += new 딝.땩(this.딟);
      this.땄(땥.떅.딟);
      this.땄(땥.떅.떎);
      this.땄(땥.떅.땄);
    }

    public void 딟([In] ref 땥.딷 obj0, [In] ref 땥.딷 obj1)
    {
    }

    public void 딟()
    {
    }

    public void Dispose() => base.딟().떎().딟 -= new 딝.땩(this.딟);

    private void 딟([In] 땥.떆 obj0, [In] ref 따 obj1)
    {
      if ((base.땄() & 땥.떅.땓) != 땥.떅.땓)
        return;
      따 딟1 = obj0.딟;
      if (딟1.딟 == 0)
        return;
      땥.떀 딟2 = obj0.딟;
      땂<딾> 땂1;
      딩.딟(out 땂<딾> _, out 땂1, ref obj1, ref 딟1);
      떁 떁;
      땂<떁> 땂2;
      obj0.딟(out 떁, out 땂2);
      for (int index = 0; index < 딟1.딟 && this.딧 < 2048; ++index)
      {
        if (딟2 == null)
          this.딟[index] = new 땹.떇();
        땹.떇 떇 = this.딟[this.딧];
        떇.땄 = 땂2.딟(index);
        떇.딟 = 떁;
        떇.딟 = 땂1.딟(index);
        this.딟[this.딧] = 떇;
        ++this.딧;
      }
    }

    private void 땄()
    {
      if ((base.땄() & 땥.떅.딟) == 땥.떅.딟)
      {
        foreach (땥.딺 딺 in base.딟().떂())
        {
          땥.떓 떓;
          딺.딟(out 떓);
          foreach (땥.떀 떀 in 딺.딦())
          {
            if (!딺.떎())
              this.딟(떀, 떓, this.땄);
            else if (딺.딧() == 땥.땎.딟)
              this.딟(떀, 떓, this.땃);
            else if (딺.딧() == 땥.땎.땄)
              this.딟(떀, 떓, this.딧);
            else if (!딺.딝())
              this.딟(떀, 떓, this.딢);
            else
              this.딟(떀, 떓, this.딟);
          }
        }
      }
      if ((base.땄() & 땥.떅.땓) == 땥.떅.땓)
      {
        for (int index = 0; index < this.딧; ++index)
        {
          땹.떇 떇 = this.딟[index];
          if (떇.딟 == 딾.땄)
            this.땄(떇.땄, 0.1f, new Color(0.3f, 0.95f, 0.3f));
          else if (떇.딟 == 딾.딧)
            this.땄(떇.땄, 0.1f, new Color(0.3f, 0.3f, 0.95f));
          if ((base.땄() & 땥.떅.땺) == 땥.떅.땺)
          {
            떁 땄 = 떇.땄;
            떁 떁 = 땄 + 0.3f * 떇.딟;
            this.딟(땄, 떁, new Color(0.4f, 0.9f, 0.4f));
          }
        }
        this.딧 = 0;
      }
      if ((base.땄() & 땥.떅.땥) == 땥.떅.땥)
      {
        foreach (땥.딺 딺 in base.딟().떂())
        {
          foreach (땥.떀 떀 in 딺.딦())
          {
            if (떀.땃() is 떅 떅3)
            {
              땥.떓 떓;
              딺.딟(out 떓);
              for (int index = 0; index < 떅3.땄.Count; ++index)
                this.땄(땥.땴.딟(ref 떓, 떅3.땄[index]), 0.1f, Color.red);
            }
          }
        }
      }
      if ((base.땄() & 땥.떅.땄) == 땥.떅.땄)
      {
        foreach (딝.땺 땺 in base.딟().땭())
          this.딟(땺);
      }
      if ((base.땄() & 땥.떅.딢) == 땥.떅.딢)
      {
        Color color;
        // ISSUE: explicit constructor call
        ((Color) ref color).\u002Ector(0.3f, 0.9f, 0.9f);
        for (int index = 0; index < base.딟().떎().딟.Count; ++index)
        {
          땥.떆 떆 = base.딟().떎().딟[index];
          땥.떀 딟 = 떆.딟;
          땥.떀 땄 = 떆.땄;
          AABB aabb1;
          딟.딟(out aabb1, 0);
          AABB aabb2;
          땄.딟(out aabb2, 0);
          this.딟(aabb1.딟(), aabb2.딟(), color);
        }
      }
      if ((base.땄() & 땥.떅.딧) == 땥.떅.딧)
      {
        Color color;
        // ISSUE: explicit constructor call
        ((Color) ref color).\u002Ector(0.9f, 0.3f, 0.9f);
        떌 딟 = base.딟().떎().딟;
        foreach (땥.딺 딺 in base.딟().떂())
        {
          if (딺.떎())
          {
            foreach (땥.떀 떀 in 딺.딦())
            {
              for (int index = 0; index < 떀.땄; ++index)
              {
                땥.딲 딲 = 떀.딟[index];
                AABB aabb;
                딟.딟(딲.땄, out aabb);
                this.딟(ref aabb, color);
              }
            }
          }
        }
      }
      if ((base.땄() & 땥.떅.땃) == 땥.떅.땃)
      {
        foreach (땥.딺 딺 in base.딟().떂())
        {
          땥.떓 떓;
          딺.딟(out 떓);
          떓.딟 = 딺.땟();
          this.딟(ref 떓);
        }
      }
      if ((base.땄() & 땥.떅.떎) != 땥.떅.떎)
        return;
      for (int index = 0; index < base.딟().딟().Count; ++index)
      {
        if (base.딟().딟()[index] is 땵 땵1)
        {
          AABB aabb = 땵1.딟();
          this.딟(ref aabb, new Color(0.3f, 0.5f, 1f));
        }
      }
    }

    public void 딟([In] Camera obj0)
    {
      if ((base.땄() & 땥.떅.딶) != 땥.떅.딶)
        return;
      this.땄(obj0);
    }

    private void 딧()
    {
      this.딟.Add(base.딟().딧());
      if (this.딟.Count > this.땓 + 1)
        this.딟.RemoveAt(0);
      float x = ((Rect) ref this.딟).x;
      float num1 = ((Rect) ref this.딟).width / (float) this.땓;
      float num2 = ((Rect) ref this.딟).yMax - ((Rect) ref this.딟).yMin;
      if (this.딟.Count > 2)
      {
        this.딢 = (int) this.딟.Max();
        this.땃 = (int) this.딟.Average();
        this.딶 = (int) this.딟.Min();
        if (this.딟)
        {
          this.땥 = this.딢;
          this.땺 = 0;
        }
        for (int index = this.딟.Count - 1; index > 0; --index)
        {
          float num3 = ((Rect) ref this.딟).yMax - this.딟[index] / (float) (this.땥 - this.땺) * num2;
          float num4 = ((Rect) ref this.딟).yMax - this.딟[index - 1] / (float) (this.땥 - this.땺) * num2;
          this.딟(new 떁(땥.딣.딟(x, ((Rect) ref this.딟).xMin, ((Rect) ref this.딟).xMax), 땥.딣.딟(num3, ((Rect) ref this.딟).yMin, ((Rect) ref this.딟).yMax)), new 떁(땥.딣.딟(x + num1, ((Rect) ref this.딟).xMin, ((Rect) ref this.딟).xMax), 땥.딣.딟(num4, ((Rect) ref this.딟).yMin, ((Rect) ref this.딟).yMax)), new Color(0.5f, 1f, 0.3f));
          x += num1;
        }
      }
      this.딟((int) ((Rect) ref this.딟).xMax + 10, (int) ((Rect) ref this.딟).yMin, "Max: " + this.딢.ToString());
      this.딟((int) ((Rect) ref this.딟).xMax + 10, (int) ((Rect) ref this.딟).yMin + (int) ((Rect) ref this.딟).height / 2 - 7, "Avg: " + this.땃.ToString());
      this.딟((int) ((Rect) ref this.딟).xMax + 10, (int) ((Rect) ref this.딟).yMax - 15, "Min: " + this.딶.ToString());
      this.땄[0] = new 떁(((Rect) ref this.딟).x, ((Rect) ref this.딟).y);
      this.땄[1] = new 떁(((Rect) ref this.딟).x, ((Rect) ref this.딟).y + ((Rect) ref this.딟).height);
      this.땄[2] = new 떁(((Rect) ref this.딟).x + ((Rect) ref this.딟).width, ((Rect) ref this.딟).y + ((Rect) ref this.딟).height);
      this.땄[3] = new 떁(((Rect) ref this.딟).x + ((Rect) ref this.딟).width, ((Rect) ref this.딟).y);
      this.딟(this.땄, 4, new Color(0.3f, 0.3f, 0.3f), true);
    }

    private void 땄([In] Camera obj0)
    {
      int num1 = 0;
      for (int index = 0; index < base.딟().떂().Count; ++index)
        num1 += base.딟().떂()[index].딦().Count;
      int num2 = 0;
      int num3 = 0;
      Vector3 worldPoint = obj0.ScreenToWorldPoint(new Vector3(obj0.pixelWidth - 210f, obj0.pixelHeight - 120f, 0.0f));
      GUI.BeginGroup(new Rect((float) worldPoint.x, (float) worldPoint.y, 210f, 120f), GUI.skin.box);
      this.딟(num2, num3, "Objects:\n- Bodies: " + (object) base.딟().떂().Count + "\n- Fixtures: " + (object) num1 + "\n- Contacts: " + (object) base.딟().딦().Count + "\n- Joints: " + (object) base.딟().땭().Count + "\n- Controllers: " + (object) base.딟().딟().Count + "\n- Proxies: " + (object) base.딟().땥());
      this.딟(num2 + 110, num3, "Update time:\n- Body: " + (object) base.딟().땺() + "\n- Contact: " + (object) base.딟().땓() + "\n- CCD: " + (object) base.딟().딢() + "\n- Joint: " + (object) base.딟().딟.딧 + "\n- Controller: " + (object) base.딟().땃() + "\n- Total: " + (object) base.딟().딧());
      GUI.EndGroup();
    }

    public void 딟([In] ref AABB obj0, [In] Color obj1) => this.딟(new 떁[4]
    {
      new 떁(obj0.LowerBound.딟, obj0.LowerBound.땄),
      new 떁(obj0.UpperBound.딟, obj0.LowerBound.땄),
      new 떁(obj0.UpperBound.딟, obj0.UpperBound.땄),
      new 떁(obj0.LowerBound.딟, obj0.UpperBound.땄)
    }, 4, obj1);

    private void 딟([In] 딝.땺 obj0)
    {
      if (!obj0.딟)
        return;
      땥.딺 딺1 = obj0.딢();
      땥.딺 딺2 = obj0.땃();
      땥.떓 떓1;
      딺1.딟(out 떓1);
      떁 떁1 = 떁.딟();
      if (!obj0.딝())
      {
        땥.떓 떓2;
        딺2.딟(out 떓2);
        떁1 = 떓2.딟;
      }
      떁 떁2 = obj0.딟();
      떁 떁3 = obj0.땄();
      떁 딟1 = 떓1.딟;
      Color color;
      // ISSUE: explicit constructor call
      ((Color) ref color).\u002Ector(0.5f, 0.8f, 0.8f);
      switch (obj0.딧())
      {
        case 딝.딢.딟:
          this.딟(떁3, 떁2, color);
          this.딟(떁3, 0.1f, 떁.딟(), Color.red);
          this.딟(떁2, 0.1f, 떁.딟(), Color.blue);
          break;
        case 딝.딢.딧:
          this.딟(떁2, 떁3, color);
          break;
        case 딝.딢.딢:
          땥.떊 떊 = (땥.떊) obj0;
          떁 딟2 = 떊.딟;
          떁 땄 = 떊.땄;
          this.딟(딟2, 떁2, color);
          this.딟(땄, 떁3, color);
          this.딟(딟2, 땄, color);
          break;
        case 딝.딢.땃:
          this.딟(딟1, 떁1, color);
          break;
        case 딝.딢.떂:
          this.땄(떁2, 0.5f, new Color(0.0f, 1f, 0.0f));
          this.딟(떁2, 떁3, new Color(0.8f, 0.8f, 0.8f));
          break;
        case 딝.딢.땭:
          this.딟(딟1, 떁2, color);
          this.딟(떁2, 0.1f, 떁.딟(), new Color(1f, 0.5f, 1f));
          break;
        case 딝.딢.딦:
          this.딟(딟1, 떁2, color);
          this.딟(떁2, 떁3, color);
          break;
        case 딝.딢.땤:
          this.딟(딟1, 떁2, color);
          this.딟(떁2, 떁3, color);
          break;
        case 딝.딢.땽:
          this.딟(딟1, 떁2, color);
          this.딟(떁2, 떁3, color);
          break;
        case 딝.딢.땋:
          break;
        default:
          this.딟(딟1, 떁2, color);
          this.딟(떁2, 떁3, color);
          this.딟(떁1, 떁3, color);
          break;
      }
    }

    public void 딟([In] 땥.떀 obj0, [In] 땥.떓 obj1, [In] Color obj2)
    {
      switch (obj0.딢())
      {
        case 땙.땄:
          땶 땶 = (땶) obj0.땃();
          this.딟(땥.땴.딟(ref obj1, 땶.딢()), 땶.딶(), 땥.땴.딟(obj1.딟, new 떁(1f, 0.0f)), obj2);
          break;
        case 땙.딧:
          땖 땖 = (땖) obj0.땃();
          this.딟(땥.땴.딟(ref obj1, 땖.딢()), 땥.땴.딟(ref obj1, 땖.땃()), obj2);
          break;
        case 땙.딢:
          떅 떅 = (떅) obj0.땃();
          int count1 = 떅.땄.Count;
          for (int index = 0; index < count1; ++index)
            this.딟[index] = 땥.땴.딟(ref obj1, 떅.땄[index]);
          this.땄(this.딟, count1, obj2);
          break;
        case 땙.땃:
          땿 땿 = (땿) obj0.땃();
          int count2 = 땿.딟.Count;
          떁 떁1 = 땥.땴.딟(ref obj1, 땿.딟[count2 - 1]);
          this.딟(떁1, 0.05f, obj2);
          for (int index = 0; index < count2; ++index)
          {
            떁 떁2 = 땥.땴.딟(ref obj1, 땿.딟[index]);
            this.딟(떁1, 떁2, obj2);
            떁1 = 떁2;
          }
          break;
      }
    }

    public override void 딟([In] 떁[] obj0, [In] int obj1, [In] float obj2, [In] float obj3, [In] float obj4) => this.딟(obj0, obj1, new Color(obj2, obj3, obj4));

    public void 딟([In] 떁[] obj0, [In] int obj1, [In] Color obj2)
    {
      for (int index = 0; index < obj1 - 1; ++index)
        this.딟.Add(땈.딟(obj0[index], obj0[index + 1], obj2));
      this.딟.Add(땈.딟(obj0[obj1 - 1], obj0[0], obj2));
    }

    public override void 땄([In] 떁[] obj0, [In] int obj1, [In] float obj2, [In] float obj3, [In] float obj4) => this.딟(obj0, obj1, new Color(obj2, obj3, obj4), true);

    public void 땄([In] 떁[] obj0, [In] int obj1, [In] Color obj2) => this.딟(obj0, obj1, obj2, true);

    public void 딟([In] 떁[] obj0, [In] int obj1, [In] Color obj2, [In] bool obj3)
    {
      if (obj1 == 2)
      {
        this.딟(obj0, obj1, obj2);
      }
      else
      {
        Color color = Color.op_Multiply(obj2, !obj3 ? 1f : 0.5f);
        for (int index = 1; index < obj1 - 1; ++index)
          this.땄.Add(땈.딟(obj0[0], obj0[index], obj0[index + 1], color));
        if (!obj3)
          return;
        this.딟(obj0, obj1, obj2);
      }
    }

    public override void 딟([In] 떁 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4) => this.딟(obj0, obj1, new Color(obj2, obj3, obj4));

    public void 딟([In] 떁 obj0, [In] float obj1, [In] Color obj2)
    {
      double num = 0.0;
      for (int index = 0; index < 32; ++index)
      {
        this.딟.Add(땈.딟(obj0 + obj1 * new 떁((float) Math.Cos(num), (float) Math.Sin(num)), obj0 + obj1 * new 떁((float) Math.Cos(num + Math.PI / 16.0), (float) Math.Sin(num + Math.PI / 16.0)), obj2));
        num += Math.PI / 16.0;
      }
    }

    public override void 딟([In] 떁 obj0, [In] float obj1, [In] 떁 obj2, [In] float obj3, [In] float obj4, [In] float obj5) => this.딟(obj0, obj1, obj2, new Color(obj3, obj4, obj5));

    public void 딟([In] 떁 obj0, [In] float obj1, [In] 떁 obj2, [In] Color obj3)
    {
      double num1 = 0.0;
      Color color = Color.op_Multiply(obj3, 0.5f);
      떁 떁1 = obj0 + obj1 * new 떁((float) Math.Cos(num1), (float) Math.Sin(num1));
      double num2 = num1 + Math.PI / 16.0;
      for (int index = 1; index < 31; ++index)
      {
        떁 떁2 = obj0 + obj1 * new 떁((float) Math.Cos(num2), (float) Math.Sin(num2));
        떁 떁3 = obj0 + obj1 * new 떁((float) Math.Cos(num2 + Math.PI / 16.0), (float) Math.Sin(num2 + Math.PI / 16.0));
        this.땄.Add(땈.딟(떁1, 떁2, 떁3, color));
        num2 += Math.PI / 16.0;
      }
      this.딟(obj0, obj1, obj3);
      this.딟(obj0, obj0 + obj2 * obj1, obj3);
    }

    public override void 딟([In] 떁 obj0, [In] 떁 obj1, [In] float obj2, [In] float obj3, [In] float obj4) => this.딟(obj0, obj1, new Color(obj2, obj3, obj4));

    public void 딟([In] 떁 obj0, [In] 떁 obj1, [In] Color obj2) => this.딟.Add(땈.딟(obj0, obj1, obj2));

    public override void 딟([In] ref 땥.떓 obj0)
    {
      떁 딟 = obj0.딟;
      떁 떁1 = 딟 + 0.4f * obj0.딟.딧();
      this.딟(딟, 떁1, Color.red);
      떁 떁2 = 딟 + 0.4f * obj0.딟.딢();
      this.딟(딟, 떁2, Color.green);
    }

    public void 땄([In] 떁 obj0, [In] float obj1, [In] Color obj2)
    {
      떁[] 떁Array = new 떁[4];
      float num = obj1 / 2f;
      떁Array[0] = obj0 + new 떁(-num, -num);
      떁Array[1] = obj0 + new 떁(num, -num);
      떁Array[2] = obj0 + new 떁(num, num);
      떁Array[3] = obj0 + new 떁(-num, num);
      this.딟(떁Array, 4, obj2, true);
    }

    public void 딟([In] int obj0, [In] int obj1, [In] string obj2, params object[] args) => GUI.Label(new Rect((float) obj0, (float) obj1, (float) obj2.Length * 15f, 120f), obj2);

    public void 딟([In] 떁 obj0, [In] 떁 obj1, [In] float obj2, [In] float obj3, [In] bool obj4, [In] Color obj5)
    {
      this.딟(obj0, obj1, obj5);
      float num = obj3 / 2f;
      떁 떁 = obj0 - obj1;
      떁.땓();
      땥.딷 딷1 = 땥.딷.딧((float) Math.Atan2((double) 떁.딟, -(double) 떁.땄));
      땥.딷 딷2 = 땥.딷.땄(obj1.딟, obj1.땄, 0.0f);
      떁[] 떁Array1 = new 떁[3]
      {
        new 떁(0.0f, 0.0f),
        new 떁(-num, -obj2),
        new 떁(num, -obj2)
      };
      떁.딟(떁Array1, ref 딷1, 떁Array1);
      떁.딟(떁Array1, ref 딷2, 떁Array1);
      this.딟(떁Array1, 3, obj5, false);
      if (!obj4)
        return;
      땥.딷 딷3 = 땥.딷.땄(obj0.딟, obj0.땄, 0.0f);
      떁[] 떁Array2 = new 떁[4]
      {
        new 떁(-num, obj2 / 4f),
        new 떁(num, obj2 / 4f),
        new 떁(num, 0.0f),
        new 떁(-num, 0.0f)
      };
      떁.딟(떁Array2, ref 딷1, 떁Array2);
      떁.딟(떁Array2, ref 딷3, 떁Array2);
      this.딟(떁Array2, 4, obj5, false);
    }

    public void 딟([In] ref Matrix4x4 obj0, [In] ref Matrix4x4 obj1, [In] Material obj2)
    {
      if (!this.땄 || base.땄() == (땥.떅) 0)
        return;
      this.딟.Clear();
      this.땄.Clear();
      this.땄();
      if ((base.땄() & 땥.떅.딝) == 땥.떅.딝)
        this.딧();
      GL.PushMatrix();
      obj2.SetPass(0);
      GL.Begin(1);
      int count1 = this.딟.Count;
      for (int index = 0; index < count1; ++index)
      {
        GL.Color(this.딟[index].딟);
        GL.Vertex(this.딟[index].딟[0]);
        GL.Vertex(this.딟[index].딟[1]);
      }
      GL.End();
      GL.Begin(4);
      int count2 = this.땄.Count;
      for (int index = 0; index < count2; ++index)
      {
        GL.Color(this.땄[index].딟);
        GL.Vertex(this.땄[index].딟[0]);
        GL.Vertex(this.땄[index].딟[1]);
        GL.Vertex(this.땄[index].딟[2]);
      }
      GL.End();
      GL.PopMatrix();
    }

    public void 딟([In] ref Matrix4x4 obj0, [In] Material obj1)
    {
      if (!this.땄)
        return;
      Matrix4x4 identity = Matrix4x4.identity;
      this.딟(ref obj0, ref identity, obj1);
    }

    private struct 떇
    {
      public 떁 딟;
      public 떁 땄;
      public 딾 딟;
    }

    private struct 땉
    {
      public object[] 딟;
      public Color 딟;
      public string 딟;
      public int 딟;
      public int 땄;

      public 땉([In] int obj0, [In] int obj1, [In] string obj2, [In] object[] obj3, [In] Color obj4)
      {
        this.딟 = obj0;
        this.땄 = obj1;
        this.딟 = obj2;
        this.딟 = obj3;
        this.딟 = obj4;
      }
    }
  }
}
