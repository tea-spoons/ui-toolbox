
namespace UnityEngine.UI
{
    using UnityEngine;

    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("UI/Gradient", 12)]
    public class Gradient : MaskableGraphic
    {
        public enum Direction
        {
            Up = 1,
            Down = 3,
            Left = 2,
            Right = 0
        }

        public Color colorB = Color.gray;

        public Direction direction = Direction.Down;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            var r = GetPixelAdjustedRect();

            var colorIndex = (int)direction;
            Color32 getColor() => (colorIndex / 2) == 0 ? color : colorB;
            void increment() => colorIndex = (colorIndex + 1) % 4;

            vh.Clear();
            vh.AddVert(new Vector3(r.xMin, r.yMin), getColor(), new Vector2(0f, 0f));
            increment();
            vh.AddVert(new Vector3(r.xMin, r.yMax), getColor(), new Vector2(0f, 1f));
            increment();
            vh.AddVert(new Vector3(r.xMax, r.yMax), getColor(), new Vector2(1f, 1f));
            increment();
            vh.AddVert(new Vector3(r.xMax, r.yMin), getColor(), new Vector2(1f, 0f));

            vh.AddTriangle(0, 1, 2);
            vh.AddTriangle(2, 3, 0);
        }
    }
}
