using System;

namespace Don_t_Die.Algorithm.PerlinNoise
{
    static class PerlinNoise
    {
        public static int PerlinNoise_2D(float x, float y, float factor)
        {
            float total = 0;
            float persistence = 0.5f;
            float frequency = 0.25f;
            float amplitude = 1;
            x += (factor);
            y += (factor);
            var NUM_OCTAVES = 10;
            for (int i = 0; i < NUM_OCTAVES; i++)
            {
                total += CompileNoise(x * frequency, y * frequency) * amplitude;
                amplitude *= persistence;
                frequency *= 2;
            }

            total *= 2;
            var res = (int)Math.Abs(Math.Floor(total * 255.0f));
            return res <= 255 ? res : 255;
        }

        private static float Noise2D(int x, int y)
        {
            var n = x + y * 57;
            n = (n << 13) ^ n;
            return 1.0f - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0f;
        }

        private static float SmoothedNoise2D(int x, int y)
        {
            float corners = (Noise2D(x - 1, y - 1) + Noise2D(x + 1, y - 1) +
                             Noise2D(x - 1, y + 1) + Noise2D(x + 1, y + 1)) / 16;
            float sides = (Noise2D(x - 1, y) + Noise2D(x + 1, y) +
                           Noise2D(x, y - 1) + Noise2D(x, y + 1)) / 8;
            float center = Noise2D(x, y) / 4;
            return corners + sides + center;
        }

        private static float CompileNoise(float x, float y)
        {
            var int_X = (int)Math.Floor(x);
            var fractional_X = x - int_X;
            var int_Y = (int)Math.Floor(y);
            var fractional_Y = y - int_Y;
            float v1 = SmoothedNoise2D(int_X, int_Y);
            float v2 = SmoothedNoise2D(int_X + 1, int_Y);
            float v3 = SmoothedNoise2D(int_X, int_Y + 1);
            float v4 = SmoothedNoise2D(int_X + 1, int_Y + 1);
            var i1 = CosineInterpolate(v1, v2, fractional_X);
            var i2 = CosineInterpolate(v3, v4, fractional_X);
            return CosineInterpolate(i1, i2, fractional_Y);
        }

        private static float CosineInterpolate(float a, float b, float x)
        {
            var ft = x * Math.PI;
            var f = (1 - Math.Cos(ft)) * .5;
            return (float)(a * (1 - f) + b * f);
        }
    }
}
