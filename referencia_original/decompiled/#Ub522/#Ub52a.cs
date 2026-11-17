// Decompiled with JetBrains decompiler
// Type: 딢.딪
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 딪
  {
    private bool 딟;
    private GameLimit 딟;
    private EngineVersionChecker 딟;
    private 딪.떕 딟;
    private 딪.떕 땄;

    public void 딟([In] GameLimit obj0, [In] EngineVersionChecker obj1, [In] 딪.떕 obj2, [In] 딪.떕 obj3)
    {
      if (Object.op_Inequality((Object) obj0, (Object) null))
      {
        this.딟 = Object.Instantiate((Object) obj0) as GameLimit;
        this.딟.Init();
      }
      this.딟 = Object.Instantiate((Object) obj1) as EngineVersionChecker;
      this.딟.Init();
      this.딟 = obj2;
      this.땄 = obj3;
    }

    public void 딟()
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null) && this.딟.get_IsDone())
      {
        if (this.딟.get_IsOnLatestVersion())
        {
          this.딟 = true;
          if (Object.op_Equality((Object) this.딟, (Object) null))
            this.땄();
        }
        else
        {
          this.딟 = false;
          if (Object.op_Inequality((Object) this.딟, (Object) null))
          {
            this.딟.Close();
            this.딟 = (GameLimit) null;
          }
          this.딟.DisplayErrorMessage();
          this.딟();
        }
        Object.Destroy((Object) ((Component) this.딟).gameObject);
        this.딟 = (EngineVersionChecker) null;
      }
      if (!this.딟 || !Object.op_Inequality((Object) this.딟, (Object) null) || !this.딟.get_IsDone())
        return;
      if (this.딟.CanStartNewGame())
      {
        this.딟.Close();
        this.땄();
      }
      else
      {
        this.딟.DisplayErrorMessage();
        this.딟.Close();
        this.딟();
      }
      this.딟 = (GameLimit) null;
    }

    public delegate void 떕();
  }
}
