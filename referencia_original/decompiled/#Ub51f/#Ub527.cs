// Decompiled with JetBrains decompiler
// Type: 딟.딧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using System;
using System.Runtime.InteropServices;

namespace 딟
{
  public static class 딧
  {
    public static 땄 딟([In] string obj0) => (땄) new 딟.딧.딶(obj0);

    private class 딢 : 땄
    {
      public 딢([In] string obj0)
      {
      }

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] double obj3)
      {
      }

      public void 딟([In] string obj0)
      {
      }

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3)
      {
      }

      public void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3)
      {
      }
    }

    private class 땃 : 땄
    {
      private string 딟;

      public 땃([In] string obj0)
      {
        this.딟 = obj0;
        땭.딟(obj0);
      }

      public void 딟([In] string obj0) => 땭.딟(this.딟, obj0);

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3)
      {
        double result;
        if (!double.TryParse(obj2, out result))
        {
          result = 0.0;
          딧.떀.딟("Invalid price '{0}'", (object) obj2);
        }
        땭.딟(this.딟, obj0, obj1, result, obj3);
      }

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] double obj3) => 땭.딟(this.딟, obj0, obj1, obj2, (int) obj3);

      public void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 땭.딟(this.딟, obj0, obj1, obj2, obj3);
    }

    public class 딶 : 땄
    {
      public 딶([In] string obj0) => 딧.땓.딟("unity_ga_init", obj0, (Action<object>) null);

      public void 딟([In] string obj0) => 딧.땓.딟("track_ga_screen", 딧.땾.땄((object) new GAEvent()
      {
        Category = obj0
      }), (Action<object>) null);

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3) => 딧.땓.딟("track_ga_ecommerce", 딧.땾.땄((object) new GAPurchase()
      {
        딟 = obj0,
        땄 = obj1,
        딧 = obj2,
        딢 = obj3
      }), (Action<object>) null);

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] double obj3) => 딧.땓.딟("track_ga_event", 딧.땾.땄((object) new GAEvent()
      {
        Action = obj1,
        Category = obj0,
        Label = obj2,
        Value = obj3
      }), (Action<object>) null);

      public void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 딧.땓.딟("track_ga_timing", 딧.땾.땄((object) new GATiming()
      {
        딟 = obj0,
        땄 = obj1,
        딧 = obj2,
        딢 = obj3
      }), (Action<object>) null);
    }

    public class 땓 : 땄
    {
      public 땓([In] string obj0) => 딧.떂.땄(딧.떎.땭, "init", string.Format("({0}){1}", (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0);

      public void 딟([In] string obj0) => 딧.떂.땄(딧.떎.땭, "sendScreen", string.Format("({0}){1}", (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0);

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3)
      {
        double result;
        if (!double.TryParse(obj2, out result))
        {
          result = 0.0;
          딧.떀.딟("Invalid price '{0}'", (object) obj2);
        }
        딧.떂.땄(딧.떎.땭, "sendECommerce", string.Format("({0}{1}{2}{3}){4}", (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.땥, (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0, (object) obj1, (object) result, (object) obj3);
      }

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] double obj3) => 딧.떂.땄(딧.떎.땭, "sendEvent", string.Format("({0}{1}{2}{3}){4}", (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.딝, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0, (object) obj1, (object) obj2, (object) (long) obj3);

      public void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 딧.떂.땄(딧.떎.땭, "sendTiming", string.Format("({0}{1}{2}{3}){4}", (object) 딧.떎.딟, (object) 딧.떎.딝, (object) 딧.떎.딟, (object) 딧.떎.딟, (object) 딧.떎.딶), (IntPtr[]) null, (object) obj0, (object) (long) obj1, (object) obj2, (object) obj3);
    }
  }
}
