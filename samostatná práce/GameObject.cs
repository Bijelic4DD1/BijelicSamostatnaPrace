using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BijelicSamPr
{
    abstract class GameObject : IDrawable, IMoveable
    {
        private Vector _position;
        public Vector MinBounds;
        public Vector MaxBounds;
        public Collider Collider;
        public Image Image;
        public Action OnDestroy;

        public Vector Position { get { return _position; } set { _position.X = value.X; _position.Y = value.Y; } }
        public Vector Speed { get; set; }

        public void Draw(string[,] scene)
        {
            Image.Draw(scene);
        }
        virtual public void Move()
        {
            _position.Add(Speed);
        }
        public GameObject(Vector postion)
        {
            _position = postion;
            Speed = new Vector(0, 0);
            MinBounds = new Vector(int.MinValue, int.MinValue);
            MaxBounds = new Vector(int.MaxValue, int.MaxValue);
        }

        public bool CollideWith(GameObject other)
        {
            return Collider.CollideWith(other.Collider);
        }
    }
}
