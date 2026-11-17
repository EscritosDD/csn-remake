// Decompiled with JetBrains decompiler
// Type: BaseHUDScreenHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseHUDScreenHandler : MonoBehaviour
{
  public Camera UICamera;

  public void ActivateMenu()
  {
    this.PositionScreenCameraView();
    this.InitailiseScreenBaseData();
    this.InitailiseScreenData();
  }

  public virtual void PositionScreenCameraView() => ((Component) this.UICamera).transform.position = new Vector3((float) ((Component) this).transform.position.x, (float) ((Component) this.UICamera).transform.position.y, (float) ((Component) this).transform.position.z);

  private void InitailiseScreenBaseData() => this.set_Game(딶.딡.땴());

  public virtual void InitailiseScreenData()
  {
  }

  public 땓.땦 GetCurrentSelectedCharacterUnitContoller(bool ShouldGetFriendly)
  {
    if (this.get_Game() != null)
    {
      딶.땯 땯 = this.get_Game().딷();
      if (땯 != null)
        return ShouldGetFriendly ? 땯.땈() : 땯.땜();
    }
    return (땓.땦) null;
  }

  public int GetCurrentSelectedCharacterGameObjectID(bool ShouldGetFriendly)
  {
    if (this.get_Game() != null)
    {
      딶.땯 땯 = this.get_Game().딷();
      if (땯 != null && 땯.땈() != null)
        return ShouldGetFriendly ? 땯.땈().땔() : 땯.땜().땔();
    }
    return -1;
  }

  public 땓.떀 GetSelectedCharacter(bool ShouldGetFriendly)
  {
    int characterGameObjectId = this.GetCurrentSelectedCharacterGameObjectID(ShouldGetFriendly);
    return characterGameObjectId != -1 ? this.get_Game().땼().땻()[characterGameObjectId] as 땓.떀 : (땓.떀) null;
  }

  [CompilerGenerated]
  [SpecialName]
  public 딶.딡 get_Game() => this.딟;
}
