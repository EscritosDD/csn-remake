// Decompiled with JetBrains decompiler
// Type: EngineVersionChecker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class EngineVersionChecker : MonoBehaviour
{
  private 땓.떄 딟;
  private int 딟;
  private GameUpdateConfirmPrompt 딟;
  private LoadingScreenOverlayHandler 딟;
  private ErrorMessagehandler 딟;
  private bool 딟;
  private MenuOverlayHandler 딟;
  public LoadingScreenOverlayHandler CheckingEngineVersionOverlayPrefab;
  public GameUpdateConfirmPrompt PromptPrefab;
  public ErrorMessagehandler ErrorMessagePrefab;
  public MenuOverlayHandler MenuOverlayPrefab;

  public void Init()
  {
    this.딟 = GlobalAppData.떏().땓();
    this.딟 = -1;
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.CheckingEngineVersionOverlayPrefab, new Vector3(0.0f, 2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
  }

  private void Update()
  {
    if (this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
      this.딟 = this.딟.딟;
    else if (this.딟.딟())
      this.딟 = true;
    this.Finished();
  }

  private void Finished()
  {
    this.딟 = (땓.떄) null;
    if (!Object.op_Inequality((Object) this.딟, (Object) null))
      return;
    this.딟.Close();
  }

  private void DisplayErrorMessage(ErrorMessagehandler.땶 ErrorType)
  {
    if (!Object.op_Equality((Object) this.딟, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.ErrorMessagePrefab) as ErrorMessagehandler;
    this.딟.Init(ErrorType, 딟.땑.딟);
  }

  public void DisplayErrorMessage()
  {
    if (this.딟)
      this.DisplayErrorMessage(ErrorMessagehandler.땶.땽);
    else if (this.딟 == -1)
    {
      this.DisplayErrorMessage(ErrorMessagehandler.땶.딟);
    }
    else
    {
      if (!Object.op_Equality((Object) this.딟, (Object) null))
        return;
      this.딟 = Object.Instantiate((Object) this.PromptPrefab) as GameUpdateConfirmPrompt;
      this.딟.Init(new GameUpdateConfirmPrompt.땎(this.UpdateConfirmed), new GameUpdateConfirmPrompt.땎(this.UpdateCancelled));
      this.딟 = Object.Instantiate((Object) this.MenuOverlayPrefab, Vector3.op_Subtraction(((Component) this.딟).transform.position, new Vector3(0.0f, 0.1f, 0.0f)), Quaternion.identity) as MenuOverlayHandler;
    }
  }

  public void UpdateConfirmed()
  {
    GlobalAppData.딶(GlobalAppData.땼().떁());
    this.딟.Close();
  }

  public void UpdateCancelled()
  {
    this.Finished();
    this.딟.Close();
  }

  [SpecialName]
  public bool get_IsDone() => this.딟 == null;

  [SpecialName]
  public bool get_IsOnLatestVersion() => this.딟 == 10;
}
