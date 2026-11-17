// Decompiled with JetBrains decompiler
// Type: GuiTextField3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

[AddComponentMenu("Gui3D/Text Field")]
public class GuiTextField3D : GuiComponent3D
{
  private bool 딟;
  private 땓.땻[] 딟 = new 땓.땻[4];
  private float 딟 = 0.5f;
  private int 딟;
  private 딧.떕 딟;
  private float 땄;
  private bool 땄;
  public GuiText3D TextDisplay;
  public string PlaceholderText;
  public string CursorString = "|";
  public GuiTextField3D.딛 KeyboardType = GuiTextField3D.딛.땄;
  public bool Secure;
  public bool ShowNativeInput;
  public int MaxChars;
  public float MaxWidth;
  public GameObject ActiveBackground;
  public GameObject InactiveBackground;
  public GameObject EmptyText;
  public string OnAcceptCommand;
  public AudioShader2 OnPressSound;
  private GuiTextField3D.딣 딟;

  public GuiTextField3D() => this.set_Text(new StringBuilder());

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public void add_TextChangedEvent(GuiTextField3D.딣 value) => this.딟 += value;

  [SpecialName]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public void remove_TextChangedEvent(GuiTextField3D.딣 value) => this.딟 -= value;

  private void Start()
  {
    this.UpdateBackground(false);
    this.UpdateDisplayText();
    this.딟[0] = new 땓.땻(new 땓.땻.떓(this.RemoveCharacterBeforeCursor));
    this.딟[1] = new 땓.땻(new 땓.땻.딥(this.MoveCursor), -1);
    this.딟[2] = new 땓.땻(new 땓.땻.딥(this.MoveCursor), 1);
    this.딟[3] = new 땓.땻(new 땓.땻.떓(this.RemoveCharacterAfterCursor));
  }

  private void UpdateBackground(bool IsActive)
  {
    if (Object.op_Inequality((Object) this.ActiveBackground, (Object) null))
      this.ActiveBackground.SetActive(IsActive);
    if (!Object.op_Inequality((Object) this.InactiveBackground, (Object) null))
      return;
    this.InactiveBackground.SetActive(!IsActive);
  }

  public override void OnPressed(Vector3 Position)
  {
    if (Object.op_Inequality((Object) GuiComponent3D.땃(), (Object) this) && Object.op_Inequality((Object) this.OnPressSound, (Object) null))
    {
      double num = (double) this.OnPressSound.PlayOneShot(((Component) this).gameObject, 0.0f);
    }
    if (!GuiComponent3D.딧((GuiComponent3D) this))
      return;
    this.PositionCursor(Position);
  }

  public override void OnLostFocus()
  {
    this.UpdateDisplayText();
    this.UpdateBackground(false);
  }

  public override void OnGainedFocus()
  {
    this.UpdateDisplayText();
    this.UpdateBackground(true);
    this.SetCursor(this.get_Text().Length, false);
  }

  private void PositionCursor(Vector3 Position)
  {
    if (this.딟 == null)
      return;
    Ray ray = Camera.main.ScreenPointToRay(Position);
    if (((Bounds) ref this.딟.딟).IntersectRay(ray))
    {
      for (int index = 0; index < this.딟.딟.Count; ++index)
      {
        Bounds bounds = this.딟.딟[index];
        if (((Bounds) ref bounds).IntersectRay(ray))
        {
          Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Position);
          float num1 = (float) (((Bounds) ref bounds).center.x - ((Bounds) ref bounds).extents.x);
          float num2 = (float) (((Bounds) ref bounds).center.x + ((Bounds) ref bounds).extents.x) - num1;
          float num3 = ((float) worldPoint.x - num1) / num2;
          int pos = index;
          if (this.땄 && index > this.딟)
            pos = index - 1;
          if ((double) num3 <= 0.5)
          {
            this.SetCursor(pos, true);
            break;
          }
          this.SetCursor(pos + 1, true);
          break;
        }
      }
    }
    else
      this.SetCursor(this.get_Text().Length, false);
  }

  private bool MoveCursor(int offset)
  {
    this.SetCursor(this.딟 + offset, true);
    return true;
  }

  private void SetCursor(int pos, bool updateMoveTime)
  {
    this.딟 = Mathf.Clamp(pos, 0, this.get_Text().Length);
    if (!updateMoveTime)
      return;
    this.땄 = Time.realtimeSinceStartup;
  }

  private void Update() => this.UpdateDesktopInput();

  private void UpdateDesktopInput()
  {
    bool flag = false;
    if (Object.op_Equality((Object) GuiComponent3D.땃(), (Object) this))
    {
      if (Input.GetKeyDown((KeyCode) 13) && !string.IsNullOrEmpty(this.OnAcceptCommand))
        ((Component) this).SendMessageUpwards("OnButtonPressed", (object) this.OnAcceptCommand);
      flag = this.UpdateBrowserInput();
      this.딟 = true;
    }
    if (flag)
    {
      this.UpdateEmptyText();
      if (this.딟 != null)
        this.딟();
    }
    if (this.딟)
      this.UpdateDisplayText();
    if (!Object.op_Inequality((Object) GuiComponent3D.땃(), (Object) this))
      return;
    this.딟 = false;
  }

  private void UpdateCommonInput()
  {
    if (Input.GetKeyDown((KeyCode) 275))
      this.딟[2].딟(this.딟);
    if (Input.GetKeyUp((KeyCode) 275))
      this.딟[2].딟();
    if (Input.GetKeyDown((KeyCode) 276))
      this.딟[1].딟(this.딟);
    if (Input.GetKeyUp((KeyCode) 276))
      this.딟[1].딟();
    if (Input.GetKeyDown((KeyCode) (int) sbyte.MaxValue))
      this.딟[3].딟(this.딟);
    if (!Input.GetKeyUp((KeyCode) (int) sbyte.MaxValue))
      return;
    this.딟[3].딟();
  }

  private bool UpdateInput()
  {
    bool flag = false;
    this.UpdateKeyStates();
    this.UpdateCommonInput();
    foreach (char ch in Input.inputString)
    {
      switch (ch)
      {
        case '\b':
          flag = this.RemoveCharacterBeforeCursor();
          continue;
        case '\n':
        case '\r':
          continue;
        default:
          if (this.get_HasSpace())
          {
            if (this.딟 >= this.get_Text().Length)
            {
              // ISSUE: reference to a compiler-generated method
              this.set_Text(this.get_Text().Append(ch));
            }
            else
            {
              // ISSUE: reference to a compiler-generated method
              this.set_Text(this.get_Text().Insert(this.딟, ch));
            }
            this.MoveCursor(1);
            flag = true;
            continue;
          }
          continue;
      }
    }
    return flag;
  }

  private bool UpdateBrowserInput()
  {
    bool flag = false;
    this.UpdateKeyStates();
    this.UpdateCommonInput();
    if (Input.GetKeyDown((KeyCode) 8))
      flag = this.딟[0].딟(this.딟);
    if (Input.GetKeyUp((KeyCode) 8))
      this.딟[0].딟();
    foreach (char ch in Input.inputString)
    {
      switch (ch)
      {
        case '\b':
        case '\t':
        case '\n':
        case '\r':
          continue;
        default:
          if (this.get_HasSpace())
          {
            if (this.딟 >= this.get_Text().Length)
            {
              // ISSUE: reference to a compiler-generated method
              this.set_Text(this.get_Text().Append(ch));
            }
            else
            {
              // ISSUE: reference to a compiler-generated method
              this.set_Text(this.get_Text().Insert(this.딟, ch));
            }
            this.MoveCursor(1);
            flag = true;
            continue;
          }
          continue;
      }
    }
    return flag;
  }

  private bool UpdateKeyStates()
  {
    bool flag = false;
    for (int index = 0; index < this.딟.Length; ++index)
    {
      if (this.딟[index] != null)
        flag = this.딟[index].땄(this.딟 * 0.1f);
    }
    return flag;
  }

  private bool RemoveCharacterBeforeCursor()
  {
    if (!this.CanRemoveCharacter(false))
      return false;
    if (this.딟 < this.get_Text().Length)
    {
      // ISSUE: reference to a compiler-generated method
      this.set_Text(this.get_Text().Remove(this.딟 - 1, 1));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      this.set_Text(this.get_Text().Remove(this.get_Text().Length - 1, 1));
    }
    this.MoveCursor(-1);
    return true;
  }

  private bool RemoveCharacterAfterCursor()
  {
    if (!this.CanRemoveCharacter(true))
      return false;
    if (this.딟 < this.get_Text().Length)
    {
      // ISSUE: reference to a compiler-generated method
      this.set_Text(this.get_Text().Remove(this.딟, 1));
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      this.set_Text(this.get_Text().Remove(this.get_Text().Length - 1, 1));
    }
    return true;
  }

  private bool CanRemoveCharacter(bool allowZeroCursor) => this.get_Text().Length != 0 && (allowZeroCursor || this.딟 != 0);

  private void UpdateEmptyText()
  {
    if (!Object.op_Inequality((Object) this.EmptyText, (Object) null))
      return;
    this.EmptyText.SetActive(this.get_Text().Length == 0);
  }

  [SpecialName]
  private bool get_HasSpace() => this.MaxChars == 0 || this.get_Text().Length < this.MaxChars;

  private string GetVisualText() => this.Secure ? new string('*', this.get_Text().Length) : this.get_Text().ToString();

  public void UpdateDisplayText()
  {
    string str = this.CompressText(this.GetVisualText());
    if (Object.op_Equality((Object) GuiComponent3D.땃(), (Object) this) && ((double) Mathf.Round(Time.time * 1000f) % 2000.0 >= 1000.0 || (double) this.땄 + 0.5 > (double) Time.realtimeSinceStartup))
    {
      str = this.딟 >= str.Length ? str + this.CursorString : str.Insert(this.딟, this.CursorString);
      this.땄 = true;
    }
    else
      this.땄 = false;
    if (!Object.op_Inequality((Object) this.TextDisplay, (Object) null) || !(this.TextDisplay.Text != str))
      return;
    this.TextDisplay.Text = str;
    this.딟 = new 딧.떕();
    this.TextDisplay.UpdateMesh(this.딟);
  }

  private string CompressText(string DisplayText)
  {
    if ((double) this.MaxWidth == 0.0)
      return DisplayText;
    float num1 = this.MaxWidth - (float) this.TextDisplay.Font.딟(this.CursorString, true, this.TextDisplay.Size).x;
    Vector2 vector2 = this.TextDisplay.Font.딟(DisplayText, true, this.TextDisplay.Size);
    if (vector2.x <= (double) num1)
      return DisplayText;
    int num2 = 0;
    int startIndex1 = DisplayText.Length;
    while (startIndex1 - num2 > 1)
    {
      int startIndex2 = (startIndex1 + num2) / 2;
      vector2 = this.TextDisplay.Font.딟("..." + DisplayText.Substring(startIndex2, DisplayText.Length - startIndex2), true, this.TextDisplay.Size);
      if (vector2.x <= (double) num1)
        startIndex1 = startIndex2;
      else
        num2 = startIndex2;
    }
    return "..." + DisplayText.Substring(startIndex1, DisplayText.Length - startIndex1);
  }

  [SpecialName]
  public bool get_IsOnScreenKeyboardActive() => false;

  [SpecialName]
  public static bool 딟() => false;

  public void Clear()
  {
    this.get_Text().Length = 0;
    this.UpdateDisplayText();
    if (this.딟 != null)
      this.딟();
    this.UpdateEmptyText();
  }

  public void SetText(string OriginalCharacterName)
  {
    // ISSUE: reference to a compiler-generated method
    this.set_Text(new StringBuilder(OriginalCharacterName));
    this.UpdateEmptyText();
    this.UpdateDisplayText();
  }

  [CompilerGenerated]
  [SpecialName]
  public StringBuilder get_Text() => this.딟;

  public enum 딛
  {
    딟,
    땄,
    딧,
    딢,
    땃,
    딶,
    땓,
    땺,
  }

  public delegate void 딣();
}
