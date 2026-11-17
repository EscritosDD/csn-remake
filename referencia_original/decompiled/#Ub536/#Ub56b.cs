// Decompiled with JetBrains decompiler
// Type: 딶.땫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땫 : 떒
  {
    protected 땓.딘 딟;
    protected new float 딟;
    protected new float 땄;
    protected AudioShader2 딟;
    protected new 땩 딟;

    public 땫([In] int obj0, [In] 땓.딘 obj1, [In] float obj2, [In] float obj3)
    {
      ((땏) this).딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.땄 = Mathf.Min(obj3, obj2);
      this.딟 = 땩.딟;
    }

    public 땫([In] int obj0, [In] 땓.딘 obj1)
      : this(obj0, obj1, -1f, -1f)
    {
    }

    public 땫([In] int obj0, [In] AudioShader2 obj1)
    {
      ((땏) this).딟 = obj0;
      this.딟 = obj1;
      this.딟 = 땩.딟;
    }

    public 땫([In] AudioShader2 obj0, [In] 땩 obj1, [In] float obj2)
      : base(obj2)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      ((땏) this).딟 = -1;
    }

    protected override void 딟()
    {
      땇 땇 = (땇) 딡.땴().딷();
      if (Object.op_Equality((Object) this.딟, (Object) null))
      {
        땓.땦 땦 = 땇.딟(((땏) this).딟);
        this.딟 = 딡.땴().땼().땻()[((땏) this).딟].딟(this.딟);
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          if ((double) this.딟 < 0.0)
            땦.딟(this.딟);
          else
            땦.딟(this.딟, this.딟, this.땄, this.딟 - this.땄);
        }
      }
      else if (((땏) this).딟 < 0)
      {
        double num = (double) this.딟.PlayOneShot(((Component) 땇.딟().땓().GetTile(this.딟.딟, this.딟.땄)).gameObject);
      }
      else
        땇.딟(((땏) this).딟).딟(this.딟);
      base.딟();
    }

    public override string ToString() => string.Format("[PlaySoundCinematicEvent]: Playing Sound {0}", (object) this.딟.ToString());
  }
}
