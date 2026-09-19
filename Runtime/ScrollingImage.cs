
namespace UnityEngine.UI
{
    using UnityEngine;

    /// <summary>
    /// Scrolls the texture of a <see cref="RawImage"/> with the given <see cref="Speed"/>.
    /// </summary>
    [AddComponentMenu("UI/Scrolling Image")]
    [RequireComponent(typeof(CanvasRenderer))]
    public sealed class ScrollingImage : MaskableGraphic
    {
        [SerializeField]
        private Texture _texture;

        [Min(0.001f)]
        public float pixelsPerUnit = 1f;
        [Tooltip("Scroll speed in units per second.\nExample: If the image's width is 200, a speed of 200 means the texture will loop exactly once per second.")]
        public Vector2 scrollSpeed;

        private Vector2 offset;

        /// <summary>
        /// Returns the texture used to draw this Graphic.
        /// </summary>
        public override Texture mainTexture
        {
            get
            {
                if (_texture == null)
                {
                    if (material != null && material.mainTexture != null)
                    {
                        return material.mainTexture;
                    }
                    return s_WhiteTexture;
                }

                return _texture;
            }
        }

        public Texture texture
        {
            get => _texture;
            set
            {
                if (_texture == value) return;

                _texture = value;
                SetVerticesDirty();
                SetMaterialDirty();
            }
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) return;
#endif
            offset.x = Mathf.Repeat(offset.x - scrollSpeed.x * pixelsPerUnit * Time.unscaledDeltaTime * 0.001f, 1f);
            offset.y = Mathf.Repeat(offset.y - scrollSpeed.y * pixelsPerUnit * Time.unscaledDeltaTime * 0.001f, 1f);
            SetVerticesDirty();
        }

        /// <summary>
        /// Adjust the scale of the Graphic to make it pixel-perfect.
        /// </summary>
        /// <remarks>
        /// This means setting the RawImage's RectTransform.sizeDelta  to be equal to the Texture dimensions.
        /// </remarks>
        public override void SetNativeSize()
        {
            var texture = mainTexture;
            if (texture != null)
            {
                var width = Mathf.RoundToInt(texture.width);
                var height = Mathf.RoundToInt(texture.height);
                rectTransform.anchorMax = rectTransform.anchorMin;
                rectTransform.sizeDelta = new Vector2(width, height);
            }
        }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            var texture = mainTexture;
            vh.Clear();
            if (texture != null)
            {
                var r = GetPixelAdjustedRect();
                var v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
                var scaleX = texture.texelSize.x * pixelsPerUnit;
                var scaleY = texture.texelSize.y * pixelsPerUnit;
                {
                    var color32 = (Color32)color;
                    var uvRect = new Rect(0, 0, r.width, r.height);
                    vh.AddVert(new Vector3(v.x, v.y), color32, new Vector2(uvRect.xMin * scaleX + offset.x, uvRect.yMin * scaleY + offset.y));
                    vh.AddVert(new Vector3(v.x, v.w), color32, new Vector2(uvRect.xMin * scaleX + offset.x, uvRect.yMax * scaleY + offset.y));
                    vh.AddVert(new Vector3(v.z, v.w), color32, new Vector2(uvRect.xMax * scaleX + offset.x, uvRect.yMax * scaleY + offset.y));
                    vh.AddVert(new Vector3(v.z, v.y), color32, new Vector2(uvRect.xMax * scaleX + offset.x, uvRect.yMin * scaleY + offset.y));

                    vh.AddTriangle(0, 1, 2);
                    vh.AddTriangle(2, 3, 0);
                }
            }
        }

        protected override void OnDidApplyAnimationProperties()
        {
            SetMaterialDirty();
            SetVerticesDirty();
            SetRaycastDirty();
        }
    }
}
