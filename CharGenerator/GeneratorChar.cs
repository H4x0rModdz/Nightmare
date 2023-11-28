using System;

namespace Nightmare
{
    public class GeneratorChar
    {
        public static string gen(int size)
        {
            Random rand;
            rand = new Random();

            string rnd_char = "☼◙♂♀♪♫►◄↕¶▬☺☻♥♦♣♠•◘○▲▼žřčéíÿïäöóšě╚╔╩╠╬╧╤╥↑■±123456789œŸ¼½¾ń£¤¥Â¢ÆÇ«¬®åßøõ×ñæ√ε₧Σσµ█▄▌▐▀∞π≈φ²∩—™";
            string rnd_name;
            string rnd_str = "";

            for (int num = 0; num < size; num++)
            {
                rnd_name = rnd_char[rand.Next(rnd_char.Length)].ToString();
                rnd_str = rnd_str + rnd_name;
            }
            return rnd_str;
        }
    }
}