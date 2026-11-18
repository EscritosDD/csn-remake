// Decompiled with JetBrains decompiler
// Type: ProfileLevelUpPanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class ProfileLevelUpPanelHandler : MonoBehaviour
{
  private ProfileLevelUpPanelHandler.땦 딟;
  private float 딟;
  public GuiText3D LevelText;
  public GuiText3D PlayerLevelNumber;
  public GuiText3D UnlockedText;
  public GameObject LevelUpRays;
  public float AnimLength;
  public float LevelTextStartScale;
  public float LevelTextTargetScale;
  public float PlayerLevelNumberStartScale;
  public float PlayerLevelNumberTargetScale;
  public float UnlockedTextStartScale;
  public float UnlockedTextTargetScale;
  public ParticleSystem Stars;

  private void Start()
  {
    ((Component) this.LevelText).gameObject.SetActive(false);
    ((Component) this.PlayerLevelNumber).gameObject.SetActive(false);
    ((Component) this.UnlockedText).gameObject.SetActive(false);
    this.LevelUpRays.SetActive(false);
  }

  public void Init(string Level)
  {
    this.PlayerLevelNumber.Text = Level;
    this.PlayerLevelNumber.UpdateMesh();
    this.딟 = ProfileLevelUpPanelHandler.땦.딟;
  }

  private void Update()
  {
    this.딟 += Time.deltaTime / this.AnimLength;
    this.딟 = Mathf.Clamp01(this.딟);
    switch (this.딟)
    {
      case ProfileLevelUpPanelHandler.땦.딟:
        ((Component) this.LevelText).gameObject.SetActive(true);
        this.ScaleText(((Component) this.LevelText).gameObject, this.LevelTextStartScale, this.LevelTextTargetScale);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟 = ProfileLevelUpPanelHandler.땦.땄;
        break;
      case ProfileLevelUpPanelHandler.땦.땄:
        ((Component) this.PlayerLevelNumber).gameObject.SetActive(true);
        this.ScaleText(((Component) this.PlayerLevelNumber).gameObject, this.PlayerLevelNumberStartScale, this.PlayerLevelNumberTargetScale);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟 = ProfileLevelUpPanelHandler.땦.딧;
        break;
      case ProfileLevelUpPanelHandler.땦.딧:
        ((Component) this.UnlockedText).gameObject.SetActive(true);
        this.ScaleText(((Component) this.UnlockedText).gameObject, this.UnlockedTextStartScale, this.UnlockedTextTargetScale);
        if ((double) this.딟 != 1.0)
          break;
        this.딟 = 0.0f;
        this.딟 = ProfileLevelUpPanelHandler.땦.딢;
        break;
      case ProfileLevelUpPanelHandler.땦.딢:
        this.LevelUpRays.SetActive(true);
        this.Stars.Play();
        this.딟 = ProfileLevelUpPanelHandler.땦.땃;
        break;
    }
  }

  private void ScaleText(GameObject TargetObject, float StartScale, float EndScale)
  {
    float num = Mathf.Lerp(StartScale, EndScale, this.딟);
    Vector3 localScale = TargetObject.transform.localScale;
    localScale.x = (__Null) (double) num;
    localScale.z = (__Null) (double) num;
    TargetObject.transform.localScale = localScale;
  }

  public void Close() => Object.Destroy((Object) ((Component) this).gameObject);

  private enum 땦
  {
    딟,
    땄,
    딧,
    딢,
    땃,
  }
}
