using System;
using System.Collections.Generic;
using DrawablesUI;

namespace GraphicsEditor
{
    public class Picture : IDrawable
    {
        private readonly List<IShape> shapes = new List<IShape>();
        private readonly object lockObject = new object();

        public event Action Changed;

        public void Remove(IShape shape)
        {
            lock (lockObject)
            {
                shapes.Remove(shape);
            }
        }

        public void RemoveAt(int index)
        {
            lock (lockObject)
            {
                shapes.RemoveAt(index);
                if (Changed != null)
                    Changed();
            }
        }

        public void Add(IShape shape)
        {
            lock (lockObject)
            {
                shapes.Add(shape);
                if (Changed != null)
                    Changed();
            }
        }

        public void Add(int index, IShape shape)
        {
            lock (lockObject)
            {
                shapes.Insert(index, shape);
                if (Changed != null)
                    Changed();
            }
        }

        public void Draw(IDrawer drawer)
        {
            lock (lockObject)
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(drawer);
                }
            }
        }

        public void Information()
        {
            lock (lockObject)
            {
                int index = 0;
                foreach (var shape in shapes)
                {
                    Console.Write("[{0}] ", index);
                    Console.WriteLine(shape.ToString());
                    index++;
                }
            }
        }

        public IShape GetShape(int index)
        {
            lock (lockObject)
            {
                return shapes[index];
            }
        }
    }
}
