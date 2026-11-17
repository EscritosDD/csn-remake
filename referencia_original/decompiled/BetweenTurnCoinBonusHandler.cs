// Decompiled with JetBrains decompiler
// Type: BetweenTurnCoinBonusHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class BetweenTurnCoinBonusHandler : MonoBehaviour
{
  private bool 딟;
  public GuiButton3D AcceptButton;
  public GameObject CoinIcon;
  public GuiText3D HeaderText;
  public GuiText3D ValueText;
  public AudioShader2 Boing;

  private void Start()
  {
    ((Component) this.AcceptButton).gameObject.SetActive(false);
    this.CoinIcon.gameObject.SetActive(false);
    ((Component) this.HeaderText).gameObject.SetActive(false);
    ((Component) this.ValueText).gameObject.SetActive(false);
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.AcceptButton).gameObject.SetActive(true);
    this.CoinIcon.gameObject.SetActive(true);
    ((Component) this.HeaderText).gameObject.SetActive(true);
    ((Component) this.ValueText).gameObject.SetActive(true);
    if (Object.op_Inequality((Object) this.Boing, (Object) null))
    {
      double num = (double) this.Boing.PlayOneShot(((Component) this).gameObject);
    }
    this.딟 = true;
  }

  private void OnDestroy() => GlobalAppData.땽().딶(false);
}
