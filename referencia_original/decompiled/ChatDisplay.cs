// Decompiled with JetBrains decompiler
// Type: ChatDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class ChatDisplay : MonoBehaviour
{
  public const string 딟 = "::all.muted";
  public ChatMessageDisplay chatMessageDisplayLeft;
  public ChatMessageDisplay chatMessageDisplayRight;
  public ChatMessageDisplay chatMessageEmpty;
  public ChatMessageDisplay chatMessageLastTurn;
  public GameObject muteButton;
  public GameObject unmuteButton;
  public GuiScrollList3D messageScroller;
  public float buttonSpacing;
  public float bottomPadding;
  public float topPadding;
  public Material[] teamBackgrounds;
  public Color[] teamTextColors;
  private ChatMessageDisplay 딟;
  private GameObject 딟;
  private 딶.땖 딟;
  private bool 딟;
  private int 딟;

  private void Awake()
  {
    if (!Object.op_Inequality((Object) this.chatMessageLastTurn, (Object) null))
      return;
    ((Component) this.chatMessageLastTurn).gameObject.SetActive(false);
  }

  private void Update()
  {
    if (!Object.op_Inequality((Object) this.딟, (Object) null) || !Object.op_Inequality((Object) this.딟.textField, (Object) null))
      return;
    if (!this.딟 && this.딟.textField.get_IsOnScreenKeyboardActive())
    {
      this.딟 = true;
      this.OnOpenKeyBoard();
    }
    if (!this.딟 || this.딟.textField.get_IsOnScreenKeyboardActive())
      return;
    this.딟 = false;
    this.OnCloseKeyboard();
  }

  public bool Init(딶.땖 gameState, 땓.땝 chatScreen)
  {
    this.딟 = gameState;
    this.messageScroller.Reset();
    if (!ChatDisplay.땄())
    {
      this.Hide();
      return false;
    }
    switch (chatScreen)
    {
      case 땓.땝.딟:
        this.InitTurnTitleChat();
        break;
      case 땓.땝.땄:
        this.InitEndTurnChat();
        break;
    }
    return true;
  }

  private bool SetMuteButtonStates(string playerId)
  {
    if (Object.op_Inequality((Object) this.unmuteButton, (Object) null))
      this.unmuteButton.SetActive(false);
    if (Object.op_Inequality((Object) this.muteButton, (Object) null))
      this.muteButton.SetActive(false);
    if (this.IsUserMuted(this.GetOpponentUserId()))
    {
      if (Object.op_Inequality((Object) this.unmuteButton, (Object) null))
        this.unmuteButton.SetActive(true);
      return true;
    }
    if (playerId != null && Object.op_Inequality((Object) this.muteButton, (Object) null))
      this.muteButton.SetActive(true);
    return false;
  }

  private bool LastTurnHasChatMessage() => this.딟.땭() != null && !string.IsNullOrEmpty(this.딟.땭().딟);

  public string GetLineFromNewChat()
  {
    if (Object.op_Inequality((Object) this.딟, (Object) null) && Object.op_Inequality((Object) this.딟.textField, (Object) null))
    {
      string chatLine = this.딟.textField.get_Text().ToString();
      if (this.IsValidChatLine(chatLine))
        return chatLine;
    }
    return (string) null;
  }

  private bool IsValidChatLine(string chatLine)
  {
    for (int index = 0; index < chatLine.Length; ++index)
    {
      if (chatLine[index].CompareTo(' ') != 0)
        return true;
    }
    return false;
  }

  private void InitEndTurnChat()
  {
    if (this.IsUserMuted(this.GetOpponentUserId()))
      return;
    this.messageScroller.AddItem(new GameObject().transform, this.buttonSpacing * this.topPadding);
    this.딟 = 1;
    for (int index = 0; index < this.딟.딥().Count - 1; ++index)
    {
      if (!string.IsNullOrEmpty(this.딟.딥()[index].딟))
      {
        bool isLeft = this.딟.떂().땃() == this.딟.딥()[index].땃();
        ChatMessageDisplay chatMessageDisplay;
        if (isLeft)
        {
          chatMessageDisplay = Object.Instantiate((Object) this.chatMessageDisplayLeft) as ChatMessageDisplay;
          ((Component) chatMessageDisplay).transform.position = new Vector3((float) ((Component) this.chatMessageDisplayLeft).transform.position.x, (float) ((Component) chatMessageDisplay).transform.position.y, (float) ((Component) chatMessageDisplay).transform.position.z);
        }
        else
        {
          chatMessageDisplay = Object.Instantiate((Object) this.chatMessageDisplayRight) as ChatMessageDisplay;
          ((Component) chatMessageDisplay).transform.position = new Vector3((float) ((Component) this.chatMessageDisplayRight).transform.position.x, (float) ((Component) chatMessageDisplay).transform.position.y, (float) ((Component) chatMessageDisplay).transform.position.z);
        }
        string userId = this.딟.딟.땄[this.딟.딥()[index].땃()];
        chatMessageDisplay.Init(this.딟.딥()[index].딟, userId, this.teamBackgrounds[this.딟.딥()[index].땃()], this.teamTextColors[this.딟.딥()[index].땃()], this.딟.딥()[index].땃(), isLeft);
        this.messageScroller.AddItem(((Component) chatMessageDisplay).transform, this.buttonSpacing * 0.6f);
        ++this.딟;
      }
    }
    this.딟 = Object.Instantiate((Object) this.chatMessageEmpty) as ChatMessageDisplay;
    this.딟.Init(this.딟.떂().딟, GlobalAppData.땽().떔(), this.teamBackgrounds[this.딟.떂().땃()], Color.black, this.딟.딝(), false);
    this.messageScroller.AddItem(((Component) this.딟).transform, this.buttonSpacing);
    this.messageScroller.AddItem(new GameObject().transform, this.buttonSpacing * this.bottomPadding);
    this.messageScroller.PositionToElement(this.딟 + 1);
  }

  private void InitTurnTitleChat()
  {
    this.Hide();
    string str = (string) null;
    if (this.딟.땭() != null)
      str = this.딟.딟.땄[this.딟.땭().땃()];
    bool flag = this.SetMuteButtonStates(str);
    if (str == null)
      return;
    if (flag)
    {
      if (this.LastTurnHasChatMessage())
      {
        this.chatMessageLastTurn.ShowAll();
        this.chatMessageLastTurn.HideTextComponents();
        this.chatMessageLastTurn.Init((string) null, str, this.teamBackgrounds[this.딟.땭().땃()], this.teamTextColors[this.딟.땭().땃()], this.딟.땭().땃(), false);
      }
      else
        this.Hide();
    }
    else if (this.LastTurnHasChatMessage())
    {
      this.chatMessageLastTurn.ShowAll();
      this.chatMessageLastTurn.Init(this.딟.땭().딟, str, this.teamBackgrounds[this.딟.땭().땃()], this.teamTextColors[this.딟.땭().땃()], this.딟.땭().땃(), false);
    }
    else
      this.Hide();
  }

  private void OnButtonPressed(string Command)
  {
    string key = Command;
    if (key == null)
      return;
    // ISSUE: reference to a compiler-generated field
    if (ChatDisplay.딟 == null)
    {
      // ISSUE: reference to a compiler-generated field
      ChatDisplay.딟 = new Dictionary<string, int>(2)
      {
        {
          "Mute",
          0
        },
        {
          "Unmute",
          1
        }
      };
    }
    int num;
    // ISSUE: reference to a compiler-generated field
    if (!ChatDisplay.딟.TryGetValue(key, out num))
      return;
    if (num != 0)
    {
      if (num != 1)
        return;
      this.UnmuteUser(this.GetOpponentUserId());
      this.InitTurnTitleChat();
      딟.딦.딟("Chat_UnmuteUser");
    }
    else
    {
      this.MuteUser(this.GetOpponentUserId());
      this.InitTurnTitleChat();
      딟.딦.딟("Chat_MuteUser");
    }
  }

  private bool IsUserMuted(string userId)
  {
    if (ChatDisplay.딟())
      return true;
    return !string.IsNullOrEmpty(userId) && PlayerPrefs.GetInt(userId + ".muted", -1) != -1;
  }

  public static bool 딟() => PlayerPrefs.GetInt("::all.muted", -1) != -1;

  private void MuteUser(string userId)
  {
    if (string.IsNullOrEmpty(userId))
      return;
    PlayerPrefs.SetInt(userId + ".muted", 1);
  }

  private void UnmuteUser(string userId)
  {
    if (string.IsNullOrEmpty(userId))
      return;
    PlayerPrefs.DeleteKey(userId + ".muted");
  }

  private string GetOpponentUserId()
  {
    if (this.딟.딟 == null || this.딟.딟.땄 == null)
      return (string) null;
    for (int index = 0; index < this.딟.딟.땄.Length; ++index)
    {
      string str = this.딟.딟.땄[index];
      if (!GlobalAppData.떏().딢(str))
        return str;
    }
    return (string) null;
  }

  public static bool 땄() => 딶.딡.땴().땼() != null && 딶.딡.땴().땼().떓() == 딶.딹.딧 && !ChatDisplay.딟();

  private void Hide()
  {
    if (Object.op_Inequality((Object) this.unmuteButton, (Object) null))
      this.unmuteButton.SetActive(false);
    if (Object.op_Inequality((Object) this.muteButton, (Object) null))
      this.muteButton.SetActive(false);
    if (!Object.op_Inequality((Object) this.chatMessageLastTurn, (Object) null))
      return;
    ((Component) this.chatMessageLastTurn).gameObject.SetActive(false);
  }

  private void OnOpenKeyBoard()
  {
    if (Object.op_Equality((Object) this.딟, (Object) null))
      this.딟 = new GameObject();
    this.messageScroller.AddItem(this.딟.transform, this.buttonSpacing * this.bottomPadding);
    this.messageScroller.ScrollToElement(this.딟 + 1);
  }

  private void OnCloseKeyboard()
  {
    this.messageScroller.RemoveItem(this.딟.transform);
    this.messageScroller.ScrollToElement(this.딟 + 1);
  }
}
