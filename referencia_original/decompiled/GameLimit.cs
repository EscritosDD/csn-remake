// Decompiled with JetBrains decompiler
// Type: GameLimit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using 땄;

public class GameLimit : MonoBehaviour
{
  private 땄.땕 딟;
  private LoadingScreenOverlayHandler 딟;
  private ErrorMessagehandler 딟;
  private int 딟;
  public LoadingScreenOverlayHandler CheckingGamesPrefab;
  public ErrorMessagehandler ErrorMessagePrefab;

  public void Close()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null))
    {
      this.딟.Close();
      this.딟 = (LoadingScreenOverlayHandler) null;
    }
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void Init()
  {
    this.딟 = GlobalAppData.떏().딱();
    this.딟 = int.MaxValue;
    this.딟 = Object.Instantiate((Object) this.CheckingGamesPrefab, new Vector3(0.0f, 2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
  }

  public bool CanStartNewGame() => this.딟 < GlobalAppData.땼().땂();

  public void Update()
  {
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
      this.딟 = ((IEnumerable<땞>) this.딟.딟).Count<땞>((Func<땞, bool>) (s => this.ShouldShowSession(s)));
    this.딟 = (땄.땕) null;
  }

  private bool ShouldShowSession(땞 Session) => Session.딟 != 딟.딺.딶 && Session.딟 != 딟.딺.땃;

  public void DisplayErrorMessage()
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.ErrorMessagePrefab) as ErrorMessagehandler;
    this.딟.Init(this.딟 != int.MaxValue ? ErrorMessagehandler.땶.떂 : ErrorMessagehandler.땶.딟, 딟.땑.딟);
  }

  [SpecialName]
  public bool get_IsDone() => this.딟 == null;

  [SpecialName]
  private void set_IsDone(bool value)
  {
  }
}
