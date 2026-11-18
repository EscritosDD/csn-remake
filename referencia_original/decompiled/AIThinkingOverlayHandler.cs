// Decompiled with JetBrains decompiler
// Type: AIThinkingOverlayHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class AIThinkingOverlayHandler : MonoBehaviour
{
  public GameObject Overlay;
  private GameObject 딟;
  private bool 딟;
  public GameObject Left;
  public GameObject Middle;
  public GameObject Right;
  public Shader UnClippedShader;

  public void Init()
  {
    this.딟 = false;
    this.InstantiateOverlay();
    this.Left.renderer.sharedMaterial = GlobalAppData.땲().딟(this.Left.renderer.material, this.UnClippedShader);
    this.Middle.renderer.sharedMaterial = GlobalAppData.땲().딟(this.Middle.renderer.material, this.UnClippedShader);
    this.Right.renderer.sharedMaterial = GlobalAppData.땲().딟(this.Right.renderer.material, this.UnClippedShader);
  }

  private void InstantiateOverlay()
  {
    GameplayHUDHandler gameplayHudHandler = 딶.딡.땴().땢();
    if (Object.op_Inequality((Object) gameplayHudHandler, (Object) null))
      gameplayHudHandler.CloseAnyOpenPanelInstancesOnExit(true);
    if (!Object.op_Inequality((Object) this.Overlay, (Object) null))
      return;
    this.딟 = Object.Instantiate((Object) this.Overlay, ((Component) this).transform.position, Quaternion.identity) as GameObject;
  }

  public void Update()
  {
    if (!this.딟)
      return;
    Object.Destroy((Object) this.딟);
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void Close() => this.딟 = true;
}
