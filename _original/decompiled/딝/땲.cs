// Decompiled with JetBrains decompiler
// Type: 딝.땲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 딝
{
  public class 땲
  {
    protected const float 딟 = 30f;
    protected Transform 딟;
    protected 땥.땍 딟;
    protected string 딟 = "Test";
    public static float 땄;
    public static float 딧;
    protected 땥.떁 딟 = new 땥.떁();

    public 땲([In] Transform obj0) => this.딟 = obj0;

    public virtual void 딟()
    {
      딺 딺 = new 딺(FSWorldComponent.딟());
      float num1 = 0.0f;
      float num2 = 640f;
      float num3 = 0.0f;
      float num4 = -360f;
      땥.떁 떁1 = new 땥.떁(num1 / 30f, num3 / 30f);
      땥.떁 떁2 = new 땥.떁(num2 / 30f, num3 / 30f);
      떎.딟(떁1, 떁2, 딺);
      떁1 = new 땥.떁(num2 / 30f, num3 / 30f);
      떁2 = new 땥.떁(num2 / 30f, num4 / 30f);
      떎.딟(떁1, 떁2, 딺);
      떁1 = new 땥.떁(num1 / 30f, num4 / 30f);
      떁2 = new 땥.떁(num2 / 30f, num4 / 30f);
      떎.딟(떁1, 떁2, 딺);
      떁1 = new 땥.떁(num1 / 30f, num3 / 30f);
      떁2 = new 땥.떁(num1 / 30f, num4 / 30f);
      떎.딟(떁1, 떁2, 딺);
    }

    public virtual void 땄()
    {
      this.딢();
      this.딶();
    }

    public virtual void 딧() => FSWorldComponent.딟().딷();

    public virtual void 딢()
    {
      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      땲.땄 = (float) worldPoint.x;
      땲.딧 = (float) worldPoint.y;
    }

    public virtual 딺 땃() => this.딟(false);

    public virtual 딺 딟([In] bool obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땲.떏 떏 = new 땲.떏();
      // ISSUE: reference to a compiler-generated field
      떏.딟 = obj0;
      // ISSUE: reference to a compiler-generated field
      떏.딟 = this;
      this.딟.딟 = 땲.땄;
      this.딟.땄 = 땲.딧;
      AABB aabb = new AABB(new 땥.떁(땲.땄 - 1f / 1000f, 땲.딧 - 1f / 1000f), new 땥.떁(땲.땄 + 1f / 1000f, 땲.딧 + 1f / 1000f));
      // ISSUE: reference to a compiler-generated field
      떏.딟 = (딺) null;
      // ISSUE: reference to a compiler-generated method
      Func<떀, bool> func = new Func<떀, bool>(떏.딟);
      FSWorldComponent.딟().딟(func, ref aabb);
      // ISSUE: reference to a compiler-generated field
      return 떏.딟;
    }

    public virtual void 딶()
    {
      if (Input.GetMouseButtonDown(0) && this.딟 == null)
      {
        딺 딺 = this.땃();
        if (딺 != null)
        {
          땥.떁 떁 = new 땥.떁(땲.땄, 땲.딧);
          this.딟 = 떂.딟(FSWorldComponent.딟(), 딺, 떁);
          this.딟.딟(true);
          this.딟.딧(300f * 딺.딱());
          딺.딧(true);
        }
      }
      if (Input.GetMouseButtonUp(0) && this.딟 != null)
      {
        FSWorldComponent.딟().땄((땺) this.딟);
        this.딟 = (땥.땍) null;
      }
      if (this.딟 == null)
        return;
      this.딟.딟(new 땥.떁(땲.땄, 땲.딧));
    }

    public virtual void 땓()
    {
      GUI.BeginGroup(new Rect(400f, 10f, 240f, 120f), GUI.skin.box);
      GUI.Label(new Rect(10f, 5f, 220f, 20f), this.딟);
      GUI.Label(new Rect(10f, 25f, 220f, 90f), "Left/Right Arrow: change test.\n\nClick & drag to interact.");
      GUI.EndGroup();
    }
  }
}
