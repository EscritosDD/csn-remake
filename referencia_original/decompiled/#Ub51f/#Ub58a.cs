// Decompiled with JetBrains decompiler
// Type: 딟.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 떊
  {
    public 떊([In] NotificationData obj0_1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0_1.Id);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0_1.ReceiverId);
      // ISSUE: reference to a compiler-generated method
      this.딧(obj0_1.AppId);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0_1.IsRealmLevel);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0_1.DeletionPolicy);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0_1.Read);
      // ISSUE: reference to a compiler-generated method
      this.딧(obj0_1.Cancelled);
      // ISSUE: reference to a compiler-generated method
      this.딟(new DateTime?(obj0_1.Expires));
      // ISSUE: reference to a compiler-generated method
      this.땄(new DateTime?(obj0_1.SentDate));
      딽 딽 = 딧.땾.딟<딽>(obj0_1.Declaration[0]);
      object obj = obj0_1.Declaration[1];
      switch (딽)
      {
        case 딽.딟:
          this.딟<SessionInviteNotificationParams>((Func<SessionInviteNotificationParams, 떒>) (obj0_23 => (떒) new 땄.땭(obj0_23)), obj);
          break;
        case 딽.땄:
          this.딟<SessionInviteNotificationParams>((Func<SessionInviteNotificationParams, 떒>) (obj0_24 => (떒) new 땄.딦(obj0_24)), obj);
          break;
        case 딽.딧:
          this.딟<SessionInviteNotificationParams>((Func<SessionInviteNotificationParams, 떒>) (obj0_25 => (떒) new 땄.땤(obj0_25)), obj);
          break;
        case 딽.딢:
          this.딟<SessionUserEventNotificationParams>((Func<SessionUserEventNotificationParams, 떒>) (obj0_26 => (떒) new 땄.땋(obj0_26)), obj);
          break;
        case 딽.땃:
          this.딟<SessionUserEventNotificationParams>((Func<SessionUserEventNotificationParams, 떒>) (obj0_27 => (떒) new 땄.땲(obj0_27)), obj);
          break;
        case 딽.딶:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_28 => (떒) new 땄.딢(obj0_28)), obj);
          break;
        case 딽.땓:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_29 => (떒) new 땄.딟(obj0_29)), obj);
          break;
        case 딽.땺:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_30 => (떒) new 땄.땄(obj0_30)), obj);
          break;
        case 딽.땥:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_31 => (떒) new 땄.딧(obj0_31)), obj);
          break;
        case 딽.딝:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_32 => (떒) new 땄.땃(obj0_32)), obj);
          break;
        case 딽.떎:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_33 => (떒) new 땄.딶(obj0_33)), obj);
          break;
        case 딽.떂:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_34 => (떒) new 땄.땓(obj0_34)), obj);
          break;
        case 딽.땭:
          this.딟<SessionActionSubmitTurnNotificationParams>((Func<SessionActionSubmitTurnNotificationParams, 떒>) (obj0_35 => (떒) new 땄.땂(obj0_35)), obj);
          break;
        case 딽.딦:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_36 => (떒) new 땄.땺(obj0_36)), obj);
          break;
        case 딽.땤:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_37 => (떒) new 땄.땥(obj0_37)), obj);
          break;
        case 딽.땽:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_38 => (떒) new 땄.딝(obj0_38)), obj);
          break;
        case 딽.땋:
          this.딟<SessionEventNotificationParams>((Func<SessionEventNotificationParams, 떒>) (obj0_39 => (떒) new 땄.떎(obj0_39)), obj);
          break;
        case 딽.땲:
          this.딟<RelationFriendNotificationParams>((Func<RelationFriendNotificationParams, 떒>) (obj0_40 => (떒) new 땄.땼(obj0_40)), obj);
          break;
        case 딽.떏:
          this.딟<RelationFriendNotificationParams>((Func<RelationFriendNotificationParams, 떒>) (obj0_41 => (떒) new 땄.땢(obj0_41)), obj);
          break;
        case 딽.땼:
          this.딟<RelationFriendNotificationParams>((Func<RelationFriendNotificationParams, 떒>) (obj0_42 => (떒) new 땄.딷(obj0_42)), obj);
          break;
        case 딽.땢:
          this.딟<RelationFriendNotificationParams>((Func<RelationFriendNotificationParams, 떒>) (obj0_43 => (떒) new 땄.떁(obj0_43)), obj);
          break;
        default:
          딧.떀.딧("Unknown notification type: " + (object) 딽);
          break;
      }
    }

    private void 딟<딟>([In] Func<딟, 떒> obj0, [In] object obj1) => this.딟(obj0(딧.땾.딟<딟>(obj1)));

    [SpecialName]
    public bool 딟() => (this.딶() & (땅.딟 | 땅.딢)) != (땅) 0;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public string 딢() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public bool 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땅 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 땓() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public bool 땺() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public DateTime? 땥() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public DateTime? 딝() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 떒 떎() => this.딟;
  }
}
