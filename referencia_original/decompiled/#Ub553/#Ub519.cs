// Decompiled with JetBrains decompiler
// Type: 땓.딙
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  public class 딙
  {
    private 딟.땯 딟;
    private 땄.딹 딟;
    private 땄.땆 딟;
    private 딟.딬 딟;
    private 땄.딵 딟;
    private 딟.땵 딟;
    private 떈 딟;

    public void 딟()
    {
      if (this.딟 != 떈.딟)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(딹.딟);
      this.딟 = 떈.땄;
      this.딟 = ((딟.땇) GlobalAppData.떏()).땃();
    }

    public void 땄()
    {
      switch (this.딟)
      {
        case 떈.땄:
          if (this.딟 == null)
          {
            this.딟(딹.딧, ((땄.땘) this.딟).딟);
            break;
          }
          if (!this.딟.땄())
            break;
          if (!this.딟.딧())
          {
            if (this.딟.딟)
            {
              this.딟(딹.땄, ((땄.땘) this.딟).딟);
              break;
            }
            if (this.딟.딟())
            {
              this.딟(딹.딢, ((땄.땘) this.딟).딟);
              break;
            }
            this.딟(딹.딧, ((땄.땘) this.딟).딟);
            break;
          }
          딟.땇.딧(this.딟.딟, this.딟.땄);
          this.딢();
          break;
        case 떈.딧:
          if (!this.딟.땄())
            break;
          if (!this.딟.딧())
          {
            if (this.딟.딟())
            {
              this.딟(딹.딢, ((땄.땘) this.딟).딟);
              break;
            }
            this.딟(딹.딧, ((땄.땘) this.딟).딟);
            break;
          }
          딢.떇.딟(딢.떇.떂(), 딢.떇.땭(), this.딟.딟.땄());
          GlobalAppData.딷().딟(false);
          this.딟 = (땄.딵) null;
          this.딟 = 떈.딢;
          this.딟 = GlobalAppData.떏().땴();
          break;
        case 떈.딢:
          if (!this.딟.땄())
            break;
          if (this.딟.딟)
          {
            if (GlobalAppData.땽().떔() != null)
            {
              딢.떇 떇 = new 딢.떇(true);
              떇.땥();
              GlobalAppData.딟(떇);
            }
            else
              GlobalAppData.땽().땥();
          }
          else
          {
            if (!this.딟.딧())
            {
              if (this.딟.딟())
              {
                this.딟(딹.딢, ((땄.땘) this.딟).딟);
                break;
              }
              this.딟(딹.딧, ((땄.땘) this.딟).딟);
              break;
            }
            ClientProfileData clientProfileData = 딧.땾.딟<ClientProfileData>(this.딟.딟);
            if (clientProfileData != null)
            {
              딢.떇 떇 = new 딢.떇(clientProfileData);
              if (떇.딟(GlobalAppData.땽()))
              {
                GlobalAppData.딟(떇);
                떇.땄(false);
              }
              else
                떇.Dispose();
            }
          }
          this.딟 = (땄.땆) null;
          this.딟 = 떈.땃;
          this.딟 = GlobalAppData.떏().땟();
          break;
        case 떈.땃:
          if (this.딟.땄() && !this.딟.딧())
          {
            if (this.딟.딟())
            {
              this.딟(딹.딢, this.딟.딟);
              break;
            }
            this.딟(딹.딧, this.딟.딟);
            break;
          }
          if (!this.딟.땄())
            break;
          this.딟 = (딟.딬) null;
          this.딟 = 떈.딶;
          this.딟 = GlobalAppData.떏().땩();
          break;
        case 떈.딶:
          if (!this.딟.땄())
            break;
          if (this.딟.딧())
          {
            this.딟 = 떈.땓;
            this.딟 = (땄.딹) null;
            break;
          }
          if (this.딟.딟())
          {
            this.딟(딹.딢, ((땄.땘) this.딟).딟);
            break;
          }
          this.딟(딹.딧, ((땄.땘) this.딟).딟);
          break;
        case 떈.땓:
          if (((딟.딗) GlobalAppData.땼()).땽())
            break;
          this.땃();
          break;
        case 떈.땺:
          if (!this.딟.땄())
            break;
          if (!this.딟.딧())
          {
            this.딟(!this.딟.딟() ? 딹.딧 : 딹.딢, ((땄.땘) this.딟).딟);
            break;
          }
          if (!this.딟.딟.AccountHasAccess)
          {
            this.딟(딹.땃, 딟.땑.딟);
            break;
          }
          this.딧();
          break;
      }
    }

    private void 딧()
    {
      this.딟 = 떈.딧;
      this.딟 = GlobalAppData.떏().땠();
    }

    private void 딢()
    {
      this.딟 = 떈.땺;
      this.딟 = GlobalAppData.떏().딷();
    }

    private void 딟([In] 딹 obj0, [In] 딟.땑 obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
      // ISSUE: reference to a compiler-generated method
      this.땄(false);
      this.딟 = 떈.딟;
      this.딟 = (땄.땆) null;
      this.딟 = (딟.딬) null;
      this.딟 = (땄.딵) null;
      this.딟 = (딟.땵) null;
      GlobalAppData.떏().딟(false);
    }

    private void 딟([In] object obj0)
    {
      NaClPushChannelData clPushChannelData = 딧.땾.딟<NaClPushChannelData>(obj0);
      if (string.IsNullOrEmpty(clPushChannelData.ChannelId))
        return;
      GlobalAppData.떏().떁(clPushChannelData.ChannelId);
    }

    private void 땃()
    {
      this.딟 = 떈.딟;
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
      // ISSUE: reference to a compiler-generated method
      this.땄(true);
      GlobalAppData.떏().딟(true);
      GlobalAppData.딟("unity_request_push_channel", string.Empty, new Action<object>(this.딟));
      this.딶();
      GlobalAppData.땽().딗();
    }

    private void 딶() => 딟.딦.딟("EngineVersion." + 10.ToString());

    [CompilerGenerated]
    [SpecialName]
    public bool 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public bool 땺() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 딹 땥() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 딟.땑 딝() => this.딟;
  }
}
