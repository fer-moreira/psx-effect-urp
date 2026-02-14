using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[VolumeComponentMenu("Post-processing/PSX Pixelization")]
[VolumeRequiresRendererFeatures(typeof(PSXPixelizationFeature))]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
public class PSXPixelizationVolume : VolumeComponent, IPostProcessComponent
{
    [Tooltip("Enable the PSX pixelization effect.")]
    public BoolParameter enabled = new BoolParameter(false, overrideState: true);

    [Tooltip("Render scale factor. Lower values = more pixelated. 0.35 gives a classic PSX look.")]
    public ClampedFloatParameter renderScale = new ClampedFloatParameter(0.35f, 0.05f, 1f);

    [Tooltip("Color depth in bits per channel. Lower = more PSX color banding.")]
    public ClampedIntParameter colorDepth = new ClampedIntParameter(32, 2, 32);

    public bool IsActive() => enabled.value && renderScale.value < 1f;
}
