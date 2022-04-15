using System;
using System.Collections.Generic;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera nikonCamera1 = Camera.GetCamera("Nikon");
            Camera nikonCamera2 = Camera.GetCamera("Nikon");
            Camera canonCamera1 = Camera.GetCamera("Canon");
            Camera canonCamera2 = Camera.GetCamera("Canon");
            Console.WriteLine(canonCamera1.Id);
            Console.WriteLine(canonCamera2.Id);
            Console.WriteLine(nikonCamera1.Id);
            Console.WriteLine(nikonCamera2.Id);
        }
    }
    class Camera
    {
        static Dictionary<string, Camera> _cameras = new();
        static object _lock = new();
        public Guid Id { get; set; }
        private Camera()
        {
            //Test
            Id = Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
