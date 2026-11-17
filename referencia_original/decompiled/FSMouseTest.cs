// Decompiled with JetBrains decompiler
// Type: FSMouseTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System;
using UnityEngine;
using 땥;

[AddComponentMenu("FarseerUnity/Debug/Mouse Test Component")]
public class FSMouseTest : MonoBehaviour
{
  protected 땥.땍 딟;
  public float MaxForce = 300f;
  public static float 딟;
  public static float 땄;
  protected 땥.떁 딟;

  public virtual void Update()
  {
    this.UpdateMouseWorld();
    this.MouseDrag();
  }

  public virtual void UpdateMouseWorld()
  {
    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    FSMouseTest.딟 = (float) worldPoint.x;
    FSMouseTest.땄 = (float) worldPoint.y;
  }

  public virtual 딺 GetBodyAtMouse() => this.GetBodyAtMouse(false);

  public virtual 딺 GetBodyAtMouse(bool includeStatic)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    FSMouseTest.떁 떁 = new FSMouseTest.떁();
    // ISSUE: reference to a compiler-generated field
    떁.딟 = includeStatic;
    // ISSUE: reference to a compiler-generated field
    떁.딟 = this;
    this.딟.딟 = FSMouseTest.딟;
    this.딟.땄 = FSMouseTest.땄;
    AABB aabb = new AABB(new 땥.떁(FSMouseTest.딟 - 1f / 1000f, FSMouseTest.땄 - 1f / 1000f), new 땥.떁(FSMouseTest.딟 + 1f / 1000f, FSMouseTest.땄 + 1f / 1000f));
    // ISSUE: reference to a compiler-generated field
    떁.딟 = (딺) null;
    // ISSUE: reference to a compiler-generated method
    Func<떀, bool> func = new Func<떀, bool>(떁.딟);
    FSWorldComponent.딟().딟(func, ref aabb);
    // ISSUE: reference to a compiler-generated field
    return 떁.딟;
  }

  public virtual void MouseDrag()
  {
    if (Input.GetMouseButtonDown(0) && this.딟 == null)
    {
      딺 bodyAtMouse = this.GetBodyAtMouse();
      if (bodyAtMouse != null)
      {
        땥.떁 떁 = new 땥.떁(FSMouseTest.딟, FSMouseTest.땄);
        this.딟 = 딝.떂.딟(FSWorldComponent.딟(), bodyAtMouse, 떁);
        this.딟.딟(false);
        this.딟.딧(this.MaxForce * bodyAtMouse.딱());
        this.딟.땃(0.1f);
        bodyAtMouse.딧(true);
      }
    }
    if (Input.GetMouseButtonUp(0) && this.딟 != null)
    {
      FSWorldComponent.딟().땄((딝.땺) this.딟);
      this.딟 = (땥.땍) null;
    }
    if (this.딟 == null)
      return;
    this.딟.딟(new 땥.떁(FSMouseTest.딟, FSMouseTest.땄));
  }
}
