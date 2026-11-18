// Decompiled with JetBrains decompiler
// Type: ChallengePackFriendLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using 딢;

public class ChallengePackFriendLabel : MonoBehaviour
{
  private int 딟;
  private 떌[] 딟;
  private ChallengePackFriendLabel.땛 딟;
  private DateTime 딟;
  private DateTime 땄;
  public float FadeInSeconds = 1f;
  public float WaitSeconds = 5f;
  public float FadeOutSeconds = 1f;
  public float MaxTextWidth = 1f;
  public GuiText3D LabelText;
  public GuiText3D ScoreText;
  public GameObject AvatarDisplay;

  public void Init(떌[] Friends)
  {
    this.딟 = Friends;
    this.딟 = 0;
    this.StartState(ChallengePackFriendLabel.땛.땄);
    this.InitActiveFriend();
  }

  private void OnDestroy()
  {
    foreach (떌 떌 in this.딟)
      떌.Dispose();
  }

  private void OnStateFinished()
  {
    switch (this.딟)
    {
      case ChallengePackFriendLabel.땛.딟:
        this.StartState(ChallengePackFriendLabel.땛.땄);
        break;
      case ChallengePackFriendLabel.땛.땄:
        if (this.딟.Length <= 1)
          break;
        this.StartState(ChallengePackFriendLabel.땛.딧);
        break;
      case ChallengePackFriendLabel.땛.딧:
        this.SelectNextFriend();
        this.StartState(ChallengePackFriendLabel.땛.딟);
        break;
    }
  }

  private void SelectNextFriend()
  {
    this.딟 = (this.딟 + 1) % this.딟.Length;
    this.InitActiveFriend();
  }

  private void InitActiveFriend()
  {
    this.LabelText.Text = this.LabelText.ShortenText(this.get_ActiveFriend().딧().땄(), this.MaxTextWidth);
    this.LabelText.UpdateMesh();
    this.ScoreText.Text = this.ScoreText.ShortenText(this.get_ActiveFriend().딢().Score.ToString(), this.MaxTextWidth);
    this.ScoreText.UpdateMesh();
    if (Object.op_Inequality((Object) this.get_ActiveFriend().땄(), (Object) null))
    {
      this.AvatarDisplay.renderer.sharedMaterial = this.get_ActiveFriend().땄();
      this.AvatarDisplay.SetActive(true);
    }
    else
      this.AvatarDisplay.SetActive(false);
  }

  private void StartState(ChallengePackFriendLabel.땛 NewState)
  {
    this.딟 = NewState;
    switch (NewState)
    {
      case ChallengePackFriendLabel.땛.딟:
        this.딟 = DateTime.Now.AddSeconds((double) this.FadeInSeconds);
        break;
      case ChallengePackFriendLabel.땛.땄:
        this.딟 = DateTime.Now.AddSeconds((double) this.WaitSeconds);
        break;
      case ChallengePackFriendLabel.땛.딧:
        this.딟 = DateTime.Now.AddSeconds((double) this.FadeOutSeconds);
        break;
    }
  }

  private void Update()
  {
    foreach (떌 떌 in this.딟)
    {
      if (떌.딟() && 떌 == this.get_ActiveFriend())
      {
        this.AvatarDisplay.renderer.sharedMaterial = 떌.땄();
        this.AvatarDisplay.SetActive(true);
      }
    }
    if (DateTime.Now > this.딟)
    {
      this.땄 = this.딟;
      this.딟 = DateTime.MaxValue;
      this.OnStateFinished();
    }
    this.UpdateActiveState();
  }

  private void UpdateActiveState()
  {
    switch (this.딟)
    {
      case ChallengePackFriendLabel.땛.딟:
        this.UpdateFade(0.0f, 1f);
        break;
      case ChallengePackFriendLabel.땛.딧:
        this.UpdateFade(1f, 0.0f);
        break;
    }
  }

  private void UpdateFade(float Min, float Max)
  {
    float num = Mathf.Clamp01((float) ((DateTime.Now - this.땄).TotalSeconds / (this.딟 - this.땄).TotalSeconds));
    float Alpha = Mathf.Lerp(Min, Max, num);
    Material sharedMaterial = this.AvatarDisplay.renderer.sharedMaterial;
    Color color = sharedMaterial.color;
    color.a = (__Null) (double) Alpha;
    this.LabelText.SetTextAlpha(Alpha);
    this.ScoreText.SetTextAlpha(Alpha);
    sharedMaterial.color = color;
  }

  [SpecialName]
  private 떌 get_ActiveFriend() => this.딟[this.딟];

  private enum 땛
  {
    딟,
    땄,
    딧,
  }
}
