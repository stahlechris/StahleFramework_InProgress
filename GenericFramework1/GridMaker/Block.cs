using UnityEngine;

namespace Stahle.GridMaker
{
    public enum ColorType
    {
        White = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
    }
    [RequireComponent(typeof(BoxCollider2D))]
    public class Block : MonoBehaviour
    {
        private BoxCollider2D boxCollider;
        public ColorType BlockColor;
    }
}