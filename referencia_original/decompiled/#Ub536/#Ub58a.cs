// Decompiled with JetBrains decompiler
// Type: 딶.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떊 : 떒
  {
    public 떊([In] int obj0)
      : this(obj0, 0.0f)
    {
    }

    public 떊([In] int obj0, [In] float obj1)
      : base(obj1)
    {
      ((땏) this).딟 = obj0;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      떊.딟(((땏) this).딟);
    }

    public static void 딟([In] int obj0)
    {
      if (딡.땴() == null)
        return;
      땓.땦 땦 = 딡.땴().딷().딟(obj0);
      if (땦 == null)
      {
        Debug.LogError((object) string.Format("Unit '{0}' doesn't exist", (object) obj0));
      }
      else
      {
        땓.땊 땊 = 땦.땴();
        if (땊.땺())
        {
          땦.떁();
        }
        else
        {
          땦.딟(!땦.딥(), true);
          딡.땴().딷().딟(obj0, 땊.땃, 땊.딶);
        }
      }
    }

    public override string ToString() => string.Format("[UpdateUnitVisibilityCinematicEvent]: Updating Unit {0}", (object) ((땏) this).딟);
  }
}
