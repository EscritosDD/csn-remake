// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireline.ClientDescriptor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

namespace SplashDamage.Mobile.Fireline
{
  public class ClientDescriptor : ScriptableObject
  {
    [SerializeField]
    private string domain = string.Empty;
    [SerializeField]
    private string clientId = string.Empty;
    [SerializeField]
    private string clientSecret = string.Empty;
    [SerializeField]
    private string serviceUrl = string.Empty;

    [SpecialName]
    public string 딟() => this.domain;

    [SpecialName]
    public string 땄() => this.clientId;

    [SpecialName]
    public string 딧() => this.clientSecret;

    [SpecialName]
    public string 딢() => this.serviceUrl;
  }
}
