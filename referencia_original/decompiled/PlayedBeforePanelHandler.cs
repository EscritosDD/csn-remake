// Decompiled with JetBrains decompiler
// Type: PlayedBeforePanelHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class PlayedBeforePanelHandler : MonoBehaviour
{
  private MenuAnimatorHandler 딟;
  private GameObject 딟;
  public GameObject OverlayPrefab;

  private void Start()
  {
  }

  public void Init(Transform StartPoint, Transform EndPoint)
  {
    this.딟 = ((Component) this).GetComponent<MenuAnimatorHandler>();
    this.딟.StartPoint = StartPoint;
    this.딟.EndPoint = EndPoint;
    this.딟 = Object.Instantiate((Object) this.OverlayPrefab, new Vector3(0.0f, (float) (((Component) this).transform.position.y - 0.100000001490116), 0.0f), Quaternion.identity) as GameObject;
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (PlayedBeforePanelHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      PlayedBeforePanelHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "ClosePanel",
          0
        },
        {
          "Yes",
          1
        },
        {
          "No",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!PlayedBeforePanelHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.Close();
        break;
      case 1:
        딟.딦.딟("NUF_Tutorial_Started");
        Application.LoadLevelAsync(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땃());
        break;
      case 2:
        if (GlobalAppData.땽().딢())
        {
          FrontendHub.딟.SplashScreen.DeactivateMenu();
          FrontendHub.딟.MainScreen.ActivateMenu();
          this.Close();
          break;
        }
        this.Close();
        FrontendHub.딟.LoginHandler.LoginAttempt(false);
        break;
    }
  }

  public void Close()
  {
    this.딟.GetComponent<MenuOverlayHandler>().Close();
    this.딟.Close();
  }
}
