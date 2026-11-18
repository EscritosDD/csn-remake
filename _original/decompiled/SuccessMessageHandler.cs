// Decompiled with JetBrains decompiler
// Type: SuccessMessageHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class SuccessMessageHandler : MonoBehaviour
{
  private MenuOverlayHandler 딟;
  private bool 딟;
  private Vector3 딟;
  public MenuOverlayHandler Overlay;
  public GuiButton3D ConfirmButton;
  public GuiMultiLineText3D SuccessDescriptionText;
  public EventHandler OnClosing;
  public LocalisationEntry PurchaseSuccessful;
  public LocalisationEntry CharacterUnlocked;
  public LocalisationEntry RestoreTransactionsFailed;
  public LocalisationEntry RestoreTransactionsItemsAdded;
  public LocalisationEntry RestoreTransactionsNoItemsAdded;

  private void Start()
  {
    ((Component) this.ConfirmButton).gameObject.SetActive(false);
    ((Component) this.SuccessDescriptionText).gameObject.SetActive(false);
    this.딟 = Vector3.op_Subtraction(((Component) this).transform.position, new Vector3(0.0f, 0.1f, 0.0f));
    this.딟 = Object.Instantiate((Object) this.Overlay, this.딟, Quaternion.identity) as MenuOverlayHandler;
  }

  public void Init(SuccessMessageHandler.땂 Success)
  {
    switch (Success)
    {
      case SuccessMessageHandler.땂.딟:
        this.SuccessDescriptionText.LocText = this.PurchaseSuccessful;
        break;
      case SuccessMessageHandler.땂.땄:
        this.SuccessDescriptionText.LocText = this.CharacterUnlocked;
        break;
      case SuccessMessageHandler.땂.딧:
        this.SuccessDescriptionText.LocText = this.RestoreTransactionsFailed;
        break;
      case SuccessMessageHandler.땂.딢:
        this.SuccessDescriptionText.LocText = this.RestoreTransactionsItemsAdded;
        break;
      case SuccessMessageHandler.땂.땃:
        this.SuccessDescriptionText.LocText = this.RestoreTransactionsNoItemsAdded;
        break;
    }
    this.SuccessDescriptionText.UpdateMesh();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (SuccessMessageHandler.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      SuccessMessageHandler.딟 = new Dictionary<string, int>(1)
      {
        {
          "Close",
          0
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!SuccessMessageHandler.딟.TryGetValue(key, out num) || num != 0)
      return;
    this.딟.Close();
    if (this.OnClosing != null)
      this.OnClosing((object) this, EventArgs.Empty);
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void Update()
  {
    if (((Component) this).animation.isPlaying || this.딟)
      return;
    ((Component) this.ConfirmButton).gameObject.SetActive(true);
    ((Component) this.SuccessDescriptionText).gameObject.SetActive(true);
    this.딟 = true;
  }

  public enum 땂
  {
    딟,
    땄,
    딧,
    딢,
    땃,
  }
}
