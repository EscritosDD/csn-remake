// Decompiled with JetBrains decompiler
// Type: SelectLanguageHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Gui3D/Screens/Splash Screen")]
public class SelectLanguageHandler : BaseMenuHandler
{
  private float 딟;
  private 딢.땿 딟 = new 딢.땿();
  private Material 딟;
  public GameObject RadTacticsLogo;
  public GameObject LoadingSpinner;
  public AnimationCurve CurveData;
  public float AnimationStartDelay = 1.5f;
  public float AnimationLength = 1f;
  public float LogoStartScale = 4f;
  public GameObject ButtonEnglish;
  public GameObject ButtonFrench;
  public GameObject ButtonItalian;
  public GameObject ButtonGerman;
  public GameObject ButtonSpanish;
  public GameObject ButtonRussian;
  public GameObject ButtonPortuguese;

  private void Start()
  {
    this.딟 = this.RadTacticsLogo.renderer.material;
    base.딟 = ((Component) this).transform.position;
    this.ActivateMenu();
  }

  private void OpenMainMenuWithSpecificLanguage(딧.땗 Language)
  {
    딧.딪.땄(Language);
    GlobalAppData.딟.딟(GlobalAppState.땊.딟);
    Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SelectLanguageHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SelectLanguageHandler.딟 = new Dictionary<string, int>(7)
      {
        {
          "English",
          0
        },
        {
          "French",
          1
        },
        {
          "Italian",
          2
        },
        {
          "German",
          3
        },
        {
          "Spanish",
          4
        },
        {
          "Russian",
          5
        },
        {
          "Portuguese",
          6
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SelectLanguageHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.딟);
        break;
      case 1:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.땄);
        break;
      case 2:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.딢);
        break;
      case 3:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.딧);
        break;
      case 4:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.땃);
        break;
      case 5:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.딶);
        break;
      case 6:
        this.OpenMainMenuWithSpecificLanguage(딧.땗.땓);
        break;
    }
  }

  private void ActivateFlags(bool State)
  {
    this.ButtonEnglish.gameObject.SetActive(State);
    this.ButtonFrench.gameObject.SetActive(State);
    this.ButtonItalian.gameObject.SetActive(State);
    this.ButtonGerman.gameObject.SetActive(State);
    this.ButtonSpanish.gameObject.SetActive(State);
    this.ButtonRussian.gameObject.SetActive(State);
    this.ButtonPortuguese.gameObject.SetActive(State);
  }

  public override void ActivateMenu()
  {
    base.ActivateMenu();
    if (!GlobalAppData.딝() && GlobalAppData.딟)
    {
      GlobalAppData.딶();
      GlobalAppData.딟 = false;
    }
    this.RadTacticsLogo.SetActive(false);
    this.ActivateFlags(false);
    this.딟.딟(this.AnimationStartDelay);
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    this.RadTacticsLogo.SetActive(false);
    this.ActivateFlags(false);
    this.딟.color = Color.op_Implicit(new Vector4(1f, 1f, 1f, 0.0f));
  }

  public void Update()
  {
    this.딟.딟();
    if (this.딟.땄())
    {
      this.딟 += Time.deltaTime / this.AnimationLength;
      this.딟 = Mathf.Clamp01(this.딟);
      if (!this.RadTacticsLogo.activeInHierarchy)
        this.RadTacticsLogo.SetActive(true);
      Vector3 localScale = this.RadTacticsLogo.transform.localScale;
      float num = Mathf.Lerp(this.LogoStartScale, 0.8f, this.CurveData.Evaluate(this.딟));
      localScale.x = (__Null) (double) num;
      localScale.z = (__Null) (double) num;
      this.RadTacticsLogo.transform.localScale = localScale;
      this.딟.color = Color.op_Implicit(new Vector4(1f, 1f, 1f, this.딟));
      if ((double) this.딟 == 1.0 && !this.ButtonEnglish.gameObject.activeInHierarchy)
        this.ActivateFlags(true);
    }
    if (GlobalAppData.딝() || GlobalAppData.떎())
      return;
    GlobalAppData.땓();
  }
}
