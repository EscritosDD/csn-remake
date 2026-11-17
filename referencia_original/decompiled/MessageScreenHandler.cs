// Decompiled with JetBrains decompiler
// Type: MessageScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageScreenHandler : BaseMenuHandler
{
  private MainScreenHandler 딟;
  private 땓.땒 딟;
  private bool 딟;
  private LoadingScreenOverlayHandler 딟;
  public GuiScrollList3D MessageScroller;
  public Transform NewsDivider;
  public Transform StoreItemsDivider;
  public Transform UpdateDivider;
  public float Buffer;
  public float DividerSpacing;
  public NewsEntryHandler NewsEntryPrefab;
  public LoadingScreenOverlayHandler LoadingOverlayPrefab;
  public ErrorMessagehandler ErrorMessage;

  private void Start() => base.딟 = ((Component) this).transform.position;

  private void OnErrorClosing(object Sender, EventArgs Args)
  {
    (Sender as ErrorMessagehandler).OnClosing -= new EventHandler(this.OnErrorClosing);
    this.DeactivateMenu();
    this.딟.ActivateMenu();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (MessageScreenHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      MessageScreenHandler.딟 = new Dictionary<string, int>(3)
      {
        {
          "Back",
          0
        },
        {
          "Facebook",
          1
        },
        {
          "Twitter",
          2
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!MessageScreenHandler.딟.TryGetValue(key, out num))
      return;
    switch (num)
    {
      case 0:
        this.DeactivateMenu();
        this.딟.ActivateMenu();
        break;
      case 1:
        this.AccessFacbookPage();
        break;
      case 2:
        this.AccessTwitterPage();
        break;
    }
  }

  public override void ActivateMenu() => base.ActivateMenu();

  public void ActivateMenu(MainScreenHandler MainScreen, 땓.땒 NewsResponse)
  {
    this.ActivateMenu();
    this.딟 = MainScreen;
    this.딟 = Object.Instantiate((Object) this.LoadingOverlayPrefab, new Vector3(0.0f, 2f, 0.0f), Quaternion.identity) as LoadingScreenOverlayHandler;
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(false);
    this.딟 = true;
    this.딟 = NewsResponse;
    PlayerPrefs.SetString("MessageScreenAccessTime", Convert.ToString(DateTime.Now));
  }

  public override void DeactivateMenu()
  {
    base.DeactivateMenu();
    ((Component) FrontendHub.딟.MoneyDisplay).gameObject.SetActive(true);
    this.MessageScroller.Reset();
    this.딟 = false;
  }

  private void DisplayErrorMessage(딟.땑 ErrorCode, ErrorMessagehandler.땶 ErrorType)
  {
    ErrorMessagehandler errorMessagehandler = Object.Instantiate((Object) this.ErrorMessage) as ErrorMessagehandler;
    errorMessagehandler.Init(ErrorType, ErrorCode);
    errorMessagehandler.OnClosing += new EventHandler(this.OnErrorClosing);
  }

  public void Update()
  {
    if (!this.딟 || this.딟 == null || !this.딟.땄())
      return;
    if (this.딟.딧())
    {
      foreach (땓.땵 땵 in this.딟.딟.딟())
      {
        if (땵.딧() == 땓.땛.땄)
        {
          this.MessageScroller.AddItem(Object.Instantiate((Object) this.NewsDivider) as Transform, (float) ((double) this.DividerSpacing * 0.5 / 320.0));
          NewsEntryHandler newsEntryHandler = Object.Instantiate((Object) this.NewsEntryPrefab) as NewsEntryHandler;
          newsEntryHandler.NewsItemText.Text = 땵.딟();
          newsEntryHandler.NewsItemText.UpdateMesh();
          float num = newsEntryHandler.NewsItemText.MeasureHeight();
          newsEntryHandler.Init(num / 2f);
          this.MessageScroller.AddItem(((Component) newsEntryHandler).gameObject.transform, (float) (((double) num + (double) this.Buffer / 320.0) * 0.5));
        }
      }
      foreach (땓.땵 땵 in this.딟.딟.딟())
      {
        if (땵.딧() == 땓.땛.딧)
        {
          this.MessageScroller.AddItem(Object.Instantiate((Object) this.StoreItemsDivider) as Transform, (float) ((double) this.DividerSpacing * 0.5 / 320.0));
          NewsEntryHandler newsEntryHandler = Object.Instantiate((Object) this.NewsEntryPrefab) as NewsEntryHandler;
          newsEntryHandler.NewsItemText.Text = 땵.딟();
          newsEntryHandler.NewsItemText.UpdateMesh();
          float num = newsEntryHandler.NewsItemText.MeasureHeight();
          newsEntryHandler.Init(num / 2f);
          this.MessageScroller.AddItem(((Component) newsEntryHandler).gameObject.transform, (float) (((double) num + (double) this.Buffer / 320.0) * 0.5));
        }
      }
      foreach (땓.땵 땵 in this.딟.딟.딟())
      {
        if (땵.딧() == 땓.땛.딢)
        {
          this.MessageScroller.AddItem(Object.Instantiate((Object) this.UpdateDivider) as Transform, (float) ((double) this.DividerSpacing * 0.5 / 320.0));
          NewsEntryHandler newsEntryHandler = Object.Instantiate((Object) this.NewsEntryPrefab) as NewsEntryHandler;
          newsEntryHandler.NewsItemText.Text = 땵.딟();
          newsEntryHandler.NewsItemText.UpdateMesh();
          float num = newsEntryHandler.NewsItemText.MeasureHeight();
          newsEntryHandler.Init(num / 2f);
          this.MessageScroller.AddItem(((Component) newsEntryHandler).gameObject.transform, (float) (((double) num + (double) this.Buffer / 320.0) * 0.5));
        }
      }
    }
    else if (this.딟.딟())
      this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.땽);
    else
      this.DisplayErrorMessage(((땄.땘) this.딟).딟, ErrorMessagehandler.땶.딟);
    if (Object.op_Inequality((Object) this.딟, (Object) null))
      this.딟.Close();
    this.딟 = (땓.땒) null;
  }

  private void AccessFacbookPage() => GlobalAppData.딶("http://www.facebook.com/WarChestGames");

  private void AccessTwitterPage() => GlobalAppData.딶("http://twitter.com/warchestgames");
}
