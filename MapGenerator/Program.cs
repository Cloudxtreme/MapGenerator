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
                nums.Add((int) SimplexNoise.Generate2D(rand.Next(), rand.Next()));
            }
            Console.WriteLine(nums.Min());
            Console.WriteLine(nums.Max());
            Console.WriteLine(nums.Average());
            Console.ReadLine();
        }

        private static void SaveNoiseImage()
        {
            var image = new Bitmap(1028, 1028);
            var noiseResults = new List<double>();

            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    var colorInt = (int)(Noise.Turbulence(i, j, 9)*128)+128; //scale from [-1,1] to [0,255]
                    noiseResults.Add(colorInt);
                    var color = Color.FromArgb(255, colorInt, colorInt, colorInt);
                    image.SetPixel(i, j, color);
                }
            }

            image.Save(@"C:\tmp\perlin" + ".jpg", ImageFormat.Jpeg);

            Console.WriteLine(noiseResults.Min());
            Console.WriteLine(noiseResults.Max());
            Console.WriteLine(noiseResults.Average());

            Console.ReadLine();
        }
    }
}
