// Decompiled with JetBrains decompiler
// Type: 딧.땇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  public class 땇
  {
    public static 딨 딟([In] string obj0, [In] string[] obj1) => (딨) new 땇.땨(obj0, obj1);

    private abstract class 땯 : 딨
    {
      private Action<Hashtable> 딟;
      private Action<string> 딟;
      private Action 딟;
      private Action 땄;
      private Action<string> 땄;
      private Action 딧;
      private Action<string> 딧;

      public 땯([In] string obj0, [In] string[] obj1)
      {
        // ISSUE: reference to a compiler-generated method
        this.땄(obj0);
        // ISSUE: reference to a compiler-generated method
        this.딟(obj1);
      }

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딟([In] Action<Hashtable> obj0) => this.딟 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땄([In] Action<Hashtable> obj0) => this.딟 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딟([In] Action<string> obj0) => this.딟 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땄([In] Action<string> obj0) => this.딟 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딟([In] Action obj0) => this.딟 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땄([In] Action obj0) => this.딟 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딧([In] Action obj0) => this.땄 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딢([In] Action obj0) => this.땄 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딧([In] Action<string> obj0) => this.땄 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딢([In] Action<string> obj0) => this.땄 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땃([In] Action obj0) => this.딧 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딶([In] Action obj0) => this.딧 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땃([In] Action<string> obj0) => this.딧 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딶([In] Action<string> obj0) => this.딧 -= obj0;

      [CompilerGenerated]
      [SpecialName]
      protected string 딶() => this.딟;

      [CompilerGenerated]
      [SpecialName]
      protected string[] 땓() => this.딟;

      public abstract void 딟();

      public abstract void 딟([In] bool obj0);

      public abstract void 땄();

      [SpecialName]
      public abstract string 딧();

      [SpecialName]
      public abstract string 딢();

      [SpecialName]
      public abstract bool 땃();

      public abstract void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3, [In] string obj4);

      public abstract void 딟([In] string obj0);

      protected void 딟([In] bool obj0, [In] string obj1, [In] string obj2)
      {
        if (obj0)
          딟.딦.딟("Facebook_CompletedAssociation");
        if (this.딟 == null)
          return;
        this.딟(new Hashtable()
        {
          [(object) "id"] = (object) obj2
        });
      }

      protected void 땄([In] bool obj0)
      {
        if (obj0)
          딟.딦.딟("Facebook_LoginFailed");
        if (this.딟 == null)
          return;
        this.딟((string) null);
      }

      protected void 땺()
      {
        딟.딦.딟("Facebook_MessageDialogCompleted");
        if (this.딟 == null)
          return;
        this.딟();
      }

      protected void 땥()
      {
        딟.딦.딟("Facebook_MessageDialogDidntComplete");
        if (this.땄 == null)
          return;
        this.땄();
      }

      protected void 딝()
      {
        딟.딦.딟("Facebook_MessageDialogFailed");
        if (this.땄 == null)
          return;
        this.땄((string) null);
      }

      protected void 떎()
      {
        딟.딦.딟("Facebook_PostCompleted");
        if (this.딧 == null)
          return;
        this.딧();
      }

      protected void 떂()
      {
        딟.딦.딟("Facebook_PostDidntComplete");
        if (this.땄 == null)
          return;
        this.땄((string) null);
      }

      protected void 땭()
      {
        딟.딦.딟("Facebook_PostFailed");
        if (this.딧 == null)
          return;
        this.딧((string) null);
      }
    }

    private class 땨 : 땇.땯
    {
      private bool 딟;
      private string 딟;
      private string 땄;

      public 땨([In] string obj0, [In] string[] obj1)
        : base(obj0, obj1)
      {
      }

      [SpecialName]
      public override string 딧() => this.땄;

      [SpecialName]
      public override string 딢() => this.딟;

      [SpecialName]
      public override bool 땃() => !string.IsNullOrEmpty(this.딢());

      public override void 땄() => this.딟(true);

      public override void 딟([In] string obj0)
      {
        if (this.딟)
          return;
        this.딟 = true;
        GlobalAppData.딟("unity_facebook_apprequest", 땾.땄((object) new Dictionary<string, object>()
        {
          ["client_id"] = (object) this.딶(),
          ["message"] = (object) obj0
        }), new Action<object>(this.딟));
      }

      public override void 딟()
      {
        this.딟 = (string) null;
        this.땄 = (string) null;
        GlobalAppData.딟("unity_facebook_logout");
      }

      public override void 딟([In] bool obj0)
      {
        if (this.딟)
          return;
        this.딟 = true;
        string str = string.Join(",", this.땓());
        GlobalAppData.딟("unity_facebook_init", 땾.땄((object) new Dictionary<string, object>()
        {
          ["api_scope"] = (object) str,
          ["client_id"] = (object) this.딶(),
          ["interactive"] = (object) obj0
        }), (Action<object>) (o => this.딟(obj0, o)));
      }

      public override void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3, [In] string obj4)
      {
        if (this.딟)
          return;
        this.딟 = true;
        GlobalAppData.딟("unity_facebook_post_message", 땾.땄((object) new Dictionary<string, object>()
        {
          ["client_id"] = (object) this.딶(),
          ["name"] = (object) obj2,
          ["link"] = (object) obj1,
          ["caption"] = (object) obj4,
          ["description"] = (object) obj0
        }), new Action<object>(this.땄));
      }

      private void 딟([In] bool obj0, [In] object obj1)
      {
        this.딟 = false;
        global::FacebookLoginInfo facebookLoginInfo = 땾.딟<global::FacebookLoginInfo>(obj1);
        if (string.IsNullOrEmpty(facebookLoginInfo.딟) || string.IsNullOrEmpty(facebookLoginInfo.땄))
        {
          this.딟 = (string) null;
          this.땄 = (string) null;
          this.땄(obj0);
        }
        else
        {
          if (this.딟 == facebookLoginInfo.딟 && this.땄 == facebookLoginInfo.땄)
            return;
          this.딟 = facebookLoginInfo.딟;
          this.땄 = facebookLoginInfo.땄;
          this.딟(obj0, this.딟, this.땄);
        }
      }

      private void 딟([In] object obj0)
      {
        this.딟 = false;
        string key = 땾.딟<string>(obj0);
        if (key == null)
          return;
        // ISSUE: reference to a compiler-generated field
        if (땇.땨.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땇.땨.딟 = new Dictionary<string, int>(3)
          {
            {
              "complete",
              0
            },
            {
              "not_complete",
              1
            },
            {
              "failed",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (!땇.땨.딟.TryGetValue(key, out num))
          return;
        switch (num)
        {
          case 0:
            this.땺();
            break;
          case 1:
            this.땥();
            break;
          case 2:
            this.딝();
            break;
        }
      }

      private void 땄([In] object obj0)
      {
        this.딟 = false;
        string key = 땾.딟<string>(obj0);
        if (key == null)
          return;
        // ISSUE: reference to a compiler-generated field
        if (땇.땨.땄 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땇.땨.땄 = new Dictionary<string, int>(3)
          {
            {
              "complete",
              0
            },
            {
              "not_complete",
              1
            },
            {
              "failed",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (!땇.땨.땄.TryGetValue(key, out num))
          return;
        switch (num)
        {
          case 0:
            this.떎();
            break;
          case 1:
            this.떂();
            break;
          case 2:
            this.땭();
            break;
        }
      }
    }

    public class 땒 : 딨
    {
      private Action<Hashtable> 딟;
      private Action<string> 딟;
      private Action 딟;
      private Action 땄;
      private Action<string> 땄;
      private Action 딧;
      private Action<string> 딧;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딟([In] Action<Hashtable> obj0) => this.딟 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땄([In] Action<Hashtable> obj0) => this.딟 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딟([In] Action<string> obj0) => this.딟 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땄([In] Action<string> obj0) => this.딟 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딟([In] Action obj0) => this.딟 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땄([In] Action obj0) => this.딟 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딧([In] Action obj0) => this.땄 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딢([In] Action obj0) => this.땄 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딧([In] Action<string> obj0) => this.땄 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딢([In] Action<string> obj0) => this.땄 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땃([In] Action obj0) => this.딧 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딶([In] Action obj0) => this.딧 -= obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 땃([In] Action<string> obj0) => this.딧 += obj0;

      [SpecialName]
      [MethodImpl(MethodImplOptions.Synchronized)]
      public void 딶([In] Action<string> obj0) => this.딧 -= obj0;

      public void 딟()
      {
      }

      public void 딟([In] bool obj0)
      {
        if (this.딟 == null)
          return;
        this.딟("unsupported");
      }

      public void 땄()
      {
        if (this.딟 == null)
          return;
        this.딟("unsupported");
      }

      [SpecialName]
      public string 딧() => (string) null;

      [SpecialName]
      public string 딢() => (string) null;

      [SpecialName]
      public bool 땃() => false;

      public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3, [In] string obj4)
      {
        if (this.딧 == null)
          return;
        this.딧("unsupported");
      }

      public void 딟([In] string obj0)
      {
        if (this.땄 == null)
          return;
        this.땄("unsupported");
      }
    }
  }
}
