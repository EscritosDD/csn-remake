// Decompiled with JetBrains decompiler
// Type: UnitIconBank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Gui3D/Controls/Unit Icon Bank")]
public class UnitIconBank : MonoBehaviour
{
  private 땓.떀[] 딟;
  private bool[] 딟;
  private Material 딟;
  public UnitIconBankEntry[] Entries;
  public bool CharactersLoaded;
  public Material BlankBackground;
  public Material RedTeamBackground;
  public Material BlueTeamBackground;
  public Shader ClippingShader;
  public Shader ClippingShaderBackground;
  public Shader GrayscaleClippedShader;

  public void Init(땓.떀 Char, int TeamIndex)
  {
    this.딟 = new 땓.떀[1];
    this.딟 = new bool[1];
    if (Char != null)
    {
      this.딟[0] = Char.땳();
      GlobalAppData.땼().딟((땓.딲) this.딟[0], (땓.땾) 0);
    }
    else
      this.딟[0] = (땓.떀) null;
    this.딟 = TeamIndex != 0 ? this.RedTeamBackground : this.BlueTeamBackground;
  }

  public void Init(딶.땖 GameState, int TeamIndex, 딶.땙 Turn)
  {
    if (Turn == null)
      Turn = GameState.떂();
    this.딟 = new 땓.떀[this.Entries.Length];
    this.딟 = new bool[this.Entries.Length];
    int index1 = 0;
    foreach (int index2 in GameState.딧(TeamIndex))
    {
      if (index1 != this.딟.Length)
      {
        땓.떀 떀 = GameState.땻()[index2] as 땓.떀;
        땓.땊 땊 = Turn.땺()[index2];
        this.딟[index1] = 떀.땳();
        this.딟[index1] = 땊.땺() && 땊.땓();
        GlobalAppData.땼().딟((땓.딲) this.딟[index1], (땓.땾) 0);
        ++index1;
      }
      else
        break;
    }
    this.딟 = TeamIndex != 0 ? this.RedTeamBackground : this.BlueTeamBackground;
    foreach (UnitIconBankEntry entry in this.Entries)
    {
      if (Object.op_Inequality((Object) entry.Icon, (Object) null))
        entry.Icon.SetActive(false);
      if (Object.op_Inequality((Object) entry.DeadIcon, (Object) null))
        entry.DeadIcon.SetActive(false);
      if (Object.op_Inequality((Object) entry.ClassIcon, (Object) null))
        entry.ClassIcon.SetActive(false);
    }
  }

  public void Init(딶.땖 GameState, int TeamIndex) => this.Init(GameState, TeamIndex, GameState.떂());

  public void Update()
  {
    if (this.딟 == null || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    for (int index = 0; index < this.딟.Length; ++index)
    {
      Material material;
      if (this.딟[index] != null)
      {
        this.딟[index].땠();
        if (Object.op_Inequality((Object) this.Entries[index].Icon, (Object) null))
        {
          this.Entries[index].Icon.SetActive(true);
          this.Entries[index].Icon.renderer.material = GlobalAppData.땲().딟(this.딟[index].땁().CharacterIcon, this.ClippingShader);
        }
        material = this.딟;
        if (Object.op_Inequality((Object) this.Entries[index].ClassIcon, (Object) null))
        {
          this.Entries[index].ClassIcon.SetActive(true);
          this.Entries[index].ClassIcon.renderer.material = this.딟[index].땁().GUIIcon;
        }
        if (Object.op_Inequality((Object) this.Entries[index].Button, (Object) null))
        {
          this.Entries[index].Button.set_CustomPressFunc("OnCharacterSelected");
          this.Entries[index].Button.set_CustomPressValue((object) this.딟[index].떔());
        }
        if (Object.op_Inequality((Object) this.Entries[index].DeadIcon, (Object) null))
        {
          if (!this.딟[index])
          {
            this.Entries[index].DeadIcon.SetActive(false);
          }
          else
          {
            this.Entries[index].DeadIcon.SetActive(true);
            this.Entries[index].Icon.renderer.sharedMaterial = GlobalAppData.땲().딟(this.Entries[index].Icon.renderer.material, this.GrayscaleClippedShader);
            material = this.BlankBackground;
          }
        }
      }
      else
      {
        if (Object.op_Inequality((Object) this.Entries[index].Icon, (Object) null))
          this.Entries[index].Icon.SetActive(false);
        material = this.BlankBackground;
        if (Object.op_Inequality((Object) this.Entries[index].ClassIcon, (Object) null))
          this.Entries[index].ClassIcon.SetActive(false);
        if (Object.op_Inequality((Object) this.Entries[index].Button, (Object) null))
          this.Entries[index].Button.Disabled = true;
        if (Object.op_Inequality((Object) this.Entries[index].DeadIcon, (Object) null))
          this.Entries[index].DeadIcon.SetActive(false);
      }
      this.Entries[index].Background.renderer.material = GlobalAppData.땲().딟(material, this.ClippingShaderBackground);
    }
    this.딟 = (땓.떀[]) null;
    this.CharactersLoaded = true;
  }

  private void OnDestroy()
  {
    if (this.딟 == null || ((딟.딗) GlobalAppData.땼()).땽())
      return;
    for (int index = 0; index < this.딟.Length; ++index)
    {
      if (this.딟[index] != null && Object.op_Inequality((Object) this.Entries[index].Icon, (Object) null))
      {
        this.Entries[index].Icon.SetActive(true);
        this.Entries[index].Icon.renderer.material = GlobalAppData.땲().딟(this.딟[index].땁().CharacterIcon, this.ClippingShader);
      }
    }
  }
}
