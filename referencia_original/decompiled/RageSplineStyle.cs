// Decompiled with JetBrains decompiler
// Type: RageSplineStyle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class RageSplineStyle : ScriptableObject
{
  public RageSpline.떂 outline = RageSpline.떂.땄;
  public Color outlineColor1 = Color.black;
  public Color outlineColor2 = Color.black;
  public RageSpline.땭 outlineGradient;
  public float outlineNormalOffset = 1f;
  public RageSpline.딦 corners;
  public RageSpline.땤 fill = RageSpline.땤.땄;
  public Color fillColor1 = Color.gray;
  public Color fillColor2 = Color.blue;
  public float landscapeBottomDepth;
  public float landscapeOutlineAlign;
  public RageSpline.땽 UVMapping1 = RageSpline.땽.땄;
  public RageSpline.땽 UVMapping2;
  public Vector2 gradientOffset = new Vector2(0.0f, 0.0f);
  public float gradientAngle;
  public float gradientScale = 10f;
  public Vector2 textureOffset = new Vector2(0.0f, 0.0f);
  public float textureAngle;
  public float textureScale = 10f;
  public Vector2 textureOffset2 = new Vector2(0.0f, 0.0f);
  public float textureAngle2;
  public float textureScale2 = 10f;
  public RageSpline.땋 emboss;
  public Color embossColor1 = Color.white;
  public Color embossColor2 = Color.black;
  public float embossAngle = 180f;
  public float embossOffset = 0.5f;
  public float embossSize = 10f;
  public float embossCurveSmoothness = 3f;
  public RageSpline.땲 physics;
  public bool createPhysicsInEditor;
  public PhysicMaterial physicsMaterial;
  public int vertexCount = 64;
  public int physicsColliderCount = 32;
  public float colliderZDepth = 100f;
  public float colliderNormalOffset;
  public float boxColliderDepth = 1f;
  public bool createConvexMeshCollider;
  public float antiAliasingWidth = 0.5f;
  public float outlineWidth = 1f;
  public bool optimize;
  public float optimizeAngle = 5f;
  public float outlineTexturingScale = 0.1f;

  public void 딟([In] RageSpline obj0)
  {
    this.antiAliasingWidth = obj0.antiAliasingWidth;
    this.colliderZDepth = obj0.colliderZDepth;
    this.createPhysicsInEditor = obj0.createPhysicsInEditor;
    this.emboss = obj0.emboss;
    this.embossAngle = obj0.embossAngle;
    this.embossColor1 = obj0.embossColor1;
    this.embossColor2 = obj0.embossColor2;
    this.embossCurveSmoothness = obj0.embossCurveSmoothness;
    this.embossOffset = obj0.embossOffset;
    this.embossSize = obj0.embossSize;
    this.fill = obj0.fill;
    this.fillColor1 = obj0.fillColor1;
    this.fillColor2 = obj0.fillColor2;
    this.gradientAngle = obj0.gradientAngle;
    this.gradientOffset = obj0.gradientOffset;
    this.gradientScale = obj0.gradientScale;
    this.outline = obj0.outline;
    this.outlineColor1 = obj0.outlineColor1;
    this.outlineColor2 = obj0.outlineColor2;
    this.outlineTexturingScale = obj0.outlineTexturingScale;
    this.outlineWidth = obj0.OutlineWidth;
    this.outlineGradient = obj0.outlineGradient;
    this.outlineNormalOffset = obj0.outlineNormalOffset;
    this.corners = obj0.corners;
    this.physics = obj0.physics;
    this.physicsColliderCount = obj0.physicsColliderCount;
    this.physicsMaterial = obj0.physicsMaterial;
    this.textureAngle = obj0.textureAngle;
    this.textureAngle2 = obj0.textureAngle2;
    this.textureOffset = obj0.textureOffset;
    this.textureOffset2 = obj0.textureOffset2;
    this.textureScale = obj0.textureScale;
    this.textureScale2 = obj0.textureScale2;
    this.UVMapping1 = obj0.UVMapping1;
    this.UVMapping2 = obj0.UVMapping2;
    this.vertexCount = obj0.vertexCount;
  }

  public void 땄([In] RageSpline obj0)
  {
    foreach (RageSpline rageSpline in Object.FindObjectsOfType(typeof (RageSpline)) as RageSpline[])
    {
      if (Object.op_Inequality((Object) rageSpline.style, (Object) null) && ((Object) rageSpline.style).Equals((object) this))
      {
        if (Application.isPlaying)
          rageSpline.RefreshMesh();
        else
          rageSpline.RefreshMeshInEditor(true, true, true);
      }
    }
  }

  public void 딟([In] RageSpline.떂 obj0, [In] RageSpline obj1)
  {
    if (this.outline == obj0)
      return;
    this.outline = obj0;
    this.땄(obj1);
  }

  public RageSpline.떂 딟() => this.outline;

  public void 딟([In] Color obj0, [In] RageSpline obj1)
  {
    if (!Color.op_Inequality(this.outlineColor1, obj0))
      return;
    this.outlineColor1 = obj0;
    this.땄(obj1);
  }

  public Color 땄() => this.outlineColor1;

  public void 땄([In] Color obj0, [In] RageSpline obj1)
  {
    if (!Color.op_Inequality(this.outlineColor2, obj0))
      return;
    this.outlineColor2 = obj0;
    this.땄(obj1);
  }

  public Color 딧() => this.outlineColor2;

  public RageSpline.땭 딢() => this.outlineGradient;

  public void 딟([In] RageSpline.땭 obj0, [In] RageSpline obj1)
  {
    if (this.outlineGradient == obj0)
      return;
    this.outlineGradient = obj0;
    this.땄(obj1);
  }

  public float 땃() => this.outlineNormalOffset;

  public void 딟([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.outlineNormalOffset == (double) obj0)
      return;
    this.outlineNormalOffset = obj0;
    this.땄(obj1);
  }

  public void 딟([In] RageSpline.딦 obj0, [In] RageSpline obj1)
  {
    if (this.corners == obj0)
      return;
    this.corners = obj0;
    this.땄(obj1);
  }

  public RageSpline.딦 딶() => this.corners;

  public void 딟([In] RageSpline.땤 obj0, [In] RageSpline obj1)
  {
    if (this.fill == obj0)
      return;
    this.fill = obj0;
    this.땄(obj1);
  }

  public RageSpline.땤 땓() => this.fill;

  public void 딧([In] Color obj0, [In] RageSpline obj1)
  {
    if (!Color.op_Inequality(this.fillColor1, obj0))
      return;
    this.fillColor1 = obj0;
    this.땄(obj1);
  }

  public Color 땺() => this.fillColor1;

  public void 딢([In] Color obj0, [In] RageSpline obj1)
  {
    if (!Color.op_Inequality(this.fillColor2, obj0))
      return;
    this.fillColor2 = obj0;
    this.땄(obj1);
  }

  public Color 땥() => this.fillColor2;

  public void 땄([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.landscapeBottomDepth == (double) obj0)
      return;
    this.landscapeBottomDepth = obj0;
    this.땄(obj1);
  }

  public float 딝() => this.landscapeBottomDepth;

  public void 딧([In] float obj0, [In] RageSpline obj1)
  {
    obj0 = Mathf.Clamp01(obj0);
    if ((double) this.landscapeOutlineAlign == (double) obj0)
      return;
    this.landscapeOutlineAlign = obj0;
    this.땄(obj1);
  }

  public float 떎() => this.landscapeOutlineAlign;

  public void 딟([In] RageSpline.땽 obj0, [In] RageSpline obj1)
  {
    if (this.UVMapping1 == obj0)
      return;
    this.UVMapping1 = obj0;
    this.땄(obj1);
  }

  public RageSpline.땽 떂() => this.UVMapping1;

  public void 땄([In] RageSpline.땽 obj0, [In] RageSpline obj1)
  {
    if (this.UVMapping2 == obj0)
      return;
    this.UVMapping2 = obj0;
    this.땄(obj1);
  }

  public RageSpline.땽 땭() => this.UVMapping2;

  public void 딟([In] Vector2 obj0, [In] RageSpline obj1)
  {
    if (!Vector2.op_Inequality(this.gradientOffset, obj0))
      return;
    this.gradientOffset = obj0;
    this.땄(obj1);
  }

  public Vector2 딦() => this.gradientOffset;

  public void 딢([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.gradientAngle == (double) obj0)
      return;
    this.gradientAngle = Mathf.Clamp(obj0, 0.0f, 360f);
    this.땄(obj1);
  }

  public float 땤() => this.gradientAngle;

  public void 땃([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.gradientScale == (double) obj0)
      return;
    this.gradientScale = Mathf.Clamp(obj0, 1E-05f, 100f);
    this.땄(obj1);
  }

  public float 땽() => this.gradientScale;

  public void 땄([In] Vector2 obj0, [In] RageSpline obj1)
  {
    if (!Vector2.op_Inequality(this.textureOffset, obj0))
      return;
    this.textureOffset = obj0;
    this.땄(obj1);
  }

  public Vector2 땋() => this.textureOffset;

  public void 딶([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.textureAngle == (double) obj0)
      return;
    this.textureAngle = Mathf.Clamp(obj0, 0.0f, 360f);
    this.땄(obj1);
  }

  public float 땲() => this.textureAngle;

  public void 땓([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.textureScale == (double) obj0)
      return;
    this.textureScale = Mathf.Clamp(obj0, 1E-05f, 100f);
    this.땄(obj1);
  }

  public float 떏() => this.textureScale;

  public void 딧([In] Vector2 obj0, [In] RageSpline obj1)
  {
    if (!Vector2.op_Inequality(this.textureOffset2, obj0))
      return;
    this.textureOffset2 = obj0;
    this.땄(obj1);
  }

  public Vector2 땼() => this.textureOffset2;

  public void 땺([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.textureAngle2 == (double) obj0)
      return;
    this.textureAngle2 = Mathf.Clamp(obj0, 0.0f, 360f);
    this.땄(obj1);
  }

  public float 땢() => this.textureAngle2;

  public void 땥([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.textureScale2 == (double) obj0)
      return;
    this.textureScale2 = Mathf.Clamp(obj0, 1E-05f, 100f);
    this.땄(obj1);
  }

  public float 딷() => this.textureScale2;

  public void 딟([In] RageSpline.땋 obj0, [In] RageSpline obj1)
  {
    if (this.emboss == obj0)
      return;
    this.emboss = obj0;
    this.땄(obj1);
  }

  public RageSpline.땋 떁() => this.emboss;

  public void 땃([In] Color obj0, [In] RageSpline obj1)
  {
    if (!Color.op_Inequality(this.embossColor1, obj0))
      return;
    this.embossColor1 = obj0;
    this.땄(obj1);
  }

  public Color 땟() => this.embossColor1;

  public void 딶([In] Color obj0, [In] RageSpline obj1)
  {
    if (!Color.op_Inequality(this.embossColor2, obj0))
      return;
    this.embossColor2 = obj0;
    this.땄(obj1);
  }

  public Color 땂() => this.embossColor2;

  public void 딝([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.embossAngle == (double) obj0)
      return;
    this.embossAngle = Mathf.Clamp(obj0, 0.0f, 360f);
    this.땄(obj1);
  }

  public float 딱() => this.embossAngle;

  public void 떎([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.embossOffset == (double) obj0)
      return;
    this.embossOffset = obj0;
    this.땄(obj1);
  }

  public float 때() => this.embossOffset;

  public void 떂([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.embossSize == (double) obj0)
      return;
    this.embossSize = Mathf.Clamp(obj0, 0.00061f, 1000f);
    this.땄(obj1);
  }

  public float 땩() => this.embossSize;

  public void 땭([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.embossCurveSmoothness == (double) obj0)
      return;
    this.embossCurveSmoothness = Mathf.Clamp(obj0, 0.0f, 100f);
    this.땄(obj1);
  }

  public float 땠() => this.embossCurveSmoothness;

  public void 딟([In] RageSpline.땲 obj0, [In] RageSpline obj1)
  {
    if (this.physics == obj0)
      return;
    this.physics = obj0;
    this.땄(obj1);
  }

  public RageSpline.땲 땴() => this.physics;

  public void 딟([In] bool obj0, [In] RageSpline obj1)
  {
    if (this.createPhysicsInEditor == obj0)
      return;
    this.createPhysicsInEditor = obj0;
    this.땄(obj1);
  }

  public bool 딗() => this.createPhysicsInEditor;

  public void 딟([In] PhysicMaterial obj0, [In] RageSpline obj1)
  {
    if (!Object.op_Inequality((Object) this.physicsMaterial, (Object) obj0))
      return;
    this.physicsMaterial = obj0;
    this.땄(obj1);
  }

  public PhysicMaterial 땳() => this.physicsMaterial;

  public void 딟([In] int obj0, [In] RageSpline obj1)
  {
    if (this.vertexCount == obj0)
      return;
    this.vertexCount = obj0;
    this.땄(obj1);
  }

  public int 땻() => this.vertexCount;

  public void 땄([In] int obj0, [In] RageSpline obj1)
  {
    if (this.physicsColliderCount == obj0)
      return;
    this.physicsColliderCount = obj0;
    this.땄(obj1);
  }

  public int 딥() => this.physicsColliderCount;

  public void 땄([In] bool obj0, [In] RageSpline obj1)
  {
    if (this.createConvexMeshCollider == obj0)
      return;
    this.createConvexMeshCollider = obj0;
    this.땄(obj1);
  }

  public bool 떓() => this.createConvexMeshCollider;

  public void 딦([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.colliderZDepth == (double) obj0)
      return;
    this.colliderZDepth = obj0;
    this.땄(obj1);
  }

  public float 딛() => this.colliderZDepth;

  public void 땤([In] float obj0, [In] RageSpline obj1) => this.colliderNormalOffset = obj0;

  public float 딣() => this.colliderNormalOffset;

  public void 땽([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.boxColliderDepth == (double) obj0)
      return;
    this.boxColliderDepth = Mathf.Clamp(obj0, 0.1f, 1000f);
    this.땄(obj1);
  }

  public float 땔() => this.boxColliderDepth;

  public void 땋([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.antiAliasingWidth == (double) obj0)
      return;
    this.antiAliasingWidth = Mathf.Clamp(obj0, 0.0f, 1000f);
    this.땄(obj1);
  }

  public float 땁() => this.antiAliasingWidth;

  public void 땲([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.outlineWidth == (double) obj0)
      return;
    this.outlineWidth = Mathf.Clamp(obj0, 0.0001f, 1000f);
    this.땄(obj1);
  }

  public float 땷() => this.outlineWidth;

  public void 떏([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.outlineTexturingScale == (double) obj0)
      return;
    this.outlineTexturingScale = Mathf.Clamp(obj0, 1f / 1000f, 1000f);
    this.땄(obj1);
  }

  public float 딸() => this.outlineTexturingScale;

  public void 땼([In] float obj0, [In] RageSpline obj1)
  {
    if ((double) this.optimizeAngle == (double) obj0)
      return;
    this.optimizeAngle = obj0;
    this.땄(obj1);
  }

  public float 땘() => this.optimizeAngle;

  public void 딧([In] bool obj0, [In] RageSpline obj1)
  {
    if (this.optimize == obj0)
      return;
    this.optimize = obj0;
    this.땄(obj1);
  }

  public bool 떔() => this.optimize;
}
