// Decompiled with JetBrains decompiler
// Type: UnlockedNewTierHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

public class UnlockedNewTierHandler : MonoBehaviour
{
  private bool 딟;
  private MenuOverlayHandler 딟;
  public MenuOverlayHandler OverlayPrefab;
  public GuiMultiLineText3D UnlockTextBody;
  public GameObject CongratulationsHeader;
  public GameObject MediumChapterIcon;
  public GameObject HardChapterIcon;
  public LocalisationEntry MediumChapterUnlockText;
  public LocalisationEntry HardChapterUnlockText;
  public ParticleSystem StarburstFX;
  public AudioShader2 UnlockAudio;

  private void Awake()
  {
    ((Component) this.UnlockTextBody).gameObject.SetActive(false);
    this.CongratulationsHeader.SetActive(false);
    this.MediumChapterIcon.SetActive(false);
    this.HardChapterIcon.SetActive(false);
  }

  public void Init(UnlockedNewTierHandler.땩 Chapter)
  {
    Vector3 position = ((Component) this).gameObject.transform.position;
    ref Vector3 local = ref position;
    local.y = (__Null) (local.y - 0.0149999996647239);
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, position, Quaternion.identity) as MenuOverlayHandler;
    switch (Chapter)
    {
      case UnlockedNewTierHandler.땩.딟:
        this.MediumChapterIcon.SetActive(true);
        this.HardChapterIcon.SetActive(false);
        this.UnlockTextBody.LocText = this.MediumChapterUnlockText;
        break;
      case UnlockedNewTierHandler.땩.땄:
        this.MediumChapterIcon.SetActive(false);
        this.HardChapterIcon.SetActive(true);
        this.UnlockTextBody.LocText = this.HardChapterUnlockText;
        break;
    }
    this.UnlockTextBody.UpdateMesh();
  }

  public void Close()
  {
    this.딟.Close();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    if (this.딟 || ((Component) this).animation.isPlaying)
      return;
    ((Component) this.UnlockTextBody).gameObject.SetActive(true);
    this.CongratulationsHeader.SetActive(true);
    this.StarburstFX.Play();
    double num = (double) this.UnlockAudio.PlayOneShot(((Component) this).gameObject, 0.0f);
    this.딟 = true;
  }

  public enum 땩
  {
    딟,
    땄,
  }
}
