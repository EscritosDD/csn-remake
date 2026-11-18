// Decompiled with JetBrains decompiler
// Type: 딧.땵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딧
{
  public class 땵
  {
    public static 땛 딟([In] string obj0, [In] string[] obj1) => (땛) new 땵.떐(obj0, obj1);

    private class 떐 : 땛
    {
      private string 딟;
      private string 땄;
      private bool 딟;
      private string 딧;
      private string 딢;

      public 떐([In] string obj0, [In] string[] obj1)
      {
        this.딧 = obj0;
        this.딢 = string.Join(",", obj1);
      }

      [SpecialName]
      public string 땄() => this.땄;

      [SpecialName]
      public string 딧() => this.딟;

      [SpecialName]
      public bool 딢() => !string.IsNullOrEmpty(this.딧());

      public void 딟([In] 떌 obj0, [In] Action<떄> obj1)
      {
        if (this.딟)
        {
          obj1(떄.딧);
        }
        else
        {
          this.딟 = true;
          땓.딟("unity_facebook_apprequest", 땾.땄((object) new Dictionary<string, object>()
          {
            ["client_id"] = (object) this.딧,
            ["message"] = (object) obj0.딟()
          }), (Action<object>) (o => this.땄(o, obj1)));
        }
      }

      public void 딟()
      {
        this.딟 = (string) null;
        this.땄 = (string) null;
        땓.딟("unity_facebook_logout", string.Empty, (Action<object>) null);
      }

      public void 딟([In] bool obj0, [In] Action<떄> obj1)
      {
        if (this.딟)
        {
          obj1(떄.딧);
        }
        else
        {
          this.딟 = true;
          땓.딟("unity_facebook_init", 땾.땄((object) new Dictionary<string, object>()
          {
            ["api_scope"] = (object) this.딢,
            ["client_id"] = (object) this.딧,
            ["interactive"] = (object) obj0
          }), (Action<object>) (o => this.딟(o, obj1)));
        }
      }

      public void 딟([In] 떉 obj0, [In] Action<떄> obj1)
      {
        if (this.딟)
        {
          obj1(떄.딧);
        }
        else
        {
          this.딟 = true;
          땓.딟("unity_facebook_post_message", 땾.땄((object) new Dictionary<string, object>()
          {
            ["client_id"] = (object) this.딧,
            ["name"] = (object) obj0.딧(),
            ["link"] = (object) obj0.땄(),
            ["caption"] = (object) obj0.땃(),
            ["description"] = (object) obj0.딟()
          }), (Action<object>) (o => this.딧(o, obj1)));
        }
      }

      private void 딟([In] object obj0, [In] Action<떄> obj1)
      {
        this.딟 = false;
        땵.떐.FacebookLoginInfo facebookLoginInfo = 땾.딟<땵.떐.FacebookLoginInfo>(obj0);
        if (string.IsNullOrEmpty(facebookLoginInfo.AccessToken) || string.IsNullOrEmpty(facebookLoginInfo.FacebookId))
        {
          this.딟 = (string) null;
          this.땄 = (string) null;
          obj1(떄.딧);
        }
        else
        {
          if (this.딟 == facebookLoginInfo.AccessToken && this.땄 == facebookLoginInfo.FacebookId)
            return;
          this.딟 = facebookLoginInfo.AccessToken;
          this.땄 = facebookLoginInfo.FacebookId;
          obj1(떄.딟);
        }
      }

      private void 땄([In] object obj0, [In] Action<떄> obj1)
      {
        this.딟 = false;
        string key = 땾.딟<string>(obj0);
        if (key == null)
          return;
        // ISSUE: reference to a compiler-generated field
        if (땵.떐.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땵.떐.딟 = new Dictionary<string, int>(3)
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
        if (!땵.떐.딟.TryGetValue(key, out num))
          return;
        switch (num)
        {
          case 0:
            obj1(떄.딟);
            break;
          case 1:
            obj1(떄.땄);
            break;
          case 2:
            obj1(떄.딧);
            break;
        }
      }

      private void 딧([In] object obj0, [In] Action<떄> obj1)
      {
        this.딟 = false;
        string key = 땾.딟<string>(obj0);
        if (key == null)
          return;
        // ISSUE: reference to a compiler-generated field
        if (땵.떐.땄 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땵.떐.땄 = new Dictionary<string, int>(3)
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
        if (!땵.떐.땄.TryGetValue(key, out num))
          return;
        switch (num)
        {
          case 0:
            obj1(떄.딟);
            break;
          case 1:
            obj1(떄.땄);
            break;
          case 2:
            obj1(떄.딧);
            break;
        }
      }

      public void 딟([In] Action<떄, string[]> obj0) => obj0(떄.딢, (string[]) null);

      [딷]
      private class FacebookLoginInfo
      {
        [떁(Name = "accessToken")]
        public string AccessToken { get; set; }

        [떁(Name = "facebookId")]
        public string FacebookId { get; set; }
      }
    }

    public class 떈 : 땛
    {
      public void 딟()
      {
      }

      public void 딟([In] bool obj0, [In] Action<떄> obj1) => obj1(떄.딢);

      [SpecialName]
      public string 땄() => (string) null;

      [SpecialName]
      public string 딧() => (string) null;

      [SpecialName]
      public bool 딢() => false;

      public void 딟([In] 떉 obj0, [In] Action<떄> obj1) => obj1(떄.딢);

      public void 딟([In] 떌 obj0, [In] Action<떄> obj1) => obj1(떄.딢);

      public void 딟([In] Action<떄, string[]> obj0) => obj0(떄.딢, (string[]) null);
    }
  }
}
