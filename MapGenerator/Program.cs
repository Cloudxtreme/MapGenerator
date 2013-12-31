using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;

namespace MapGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
            SaveNoiseImage();
        }

        private static void Test()
        {
            List<int> nums = new List<int>();
            var rand = new Random();
            for (var i = 0; i < 1000000; i++)
            {
                var noise = new Noise(128, 128);
                nums.Add((int) noise.Generate(rand.Next(), rand.Next(), 8.0));
            }
            Console.WriteLine(nums.Min());
            Console.WriteLine(nums.Max());
            Console.WriteLine(nums.Average());
            Console.ReadLine();
        }

        private static void SaveNoiseImage()
        {
            var image = new Bitmap(1024, 768);

            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    var noiseGen = new Noise(128, 128);

                    var colorInt = (int)noiseGen.Generate(i, j, 8.0);
                    var color = Color.FromArgb(255, colorInt, colorInt, colorInt);
                    image.SetPixel(i, j, color);
                }
            }

            image.Save(@"C:\tmp\perlin" + ".jpg", ImageFormat.Jpeg);
        }
    }
}
