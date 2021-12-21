using System;

namespace Matveev_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int k = 4, n = 7, l = 7, r = 3;
            int m = 0b110;
            int a = 0,b = 0, o = 0, g = 0, e = 0;
            string read, two; // для считывания

            Console.WriteLine("Введите g (пример-(1011))");
            read = Console.ReadLine();
            for (int i = 0; i< read.Length; i++)
            {
                g  = g | (Convert.ToInt32(read[i]) - 48);
                g = g << 1;

            }
            g = g >> 1;
            
            Console.WriteLine("Введите e (пример-(0001100))");
            read = Console.ReadLine();
       
            for (int i = 0; i < read.Length; i++)
            {
                e = e | (Convert.ToInt32(read[i]) - 48);
                e = e << 1;

            }
            e = e >> 1;
            
            a = Coder(m,r,g,n);

            b = a ^ e;
            two=Twocod(b);
            Console.WriteLine($"b = {two}");
            o = remains(n, b, g);
            two=Twocod(o);
            Console.WriteLine($"E = {two}");

            answer(e,o);
        }
        static int Coder(int m, int r, int g, int n)
        {
            int c,a;
            string two;

            c = m << r;
            c = remains(n,c,g);
            a = (m << r) + c;
            two = Twocod(a);
            Console.WriteLine($"a = {two}");
            two = Twocod(c);
            Console.WriteLine($"c = {two}");

            return a;
        }

        static void answer(int e, int o)  // вердикт декодера
        {  
            if (e == 0 && o == 0)
            {
                Console.WriteLine("Вердикт декодера:'Верно'");
            }
            else if (e == 0 && o != 0)
            {
                Console.WriteLine("Вердикт декодера:'Неверно'");
            }
            else if (e != 0 && o != 0)
            {
                Console.WriteLine("Вердикт декодера:'Верно'");
            }
            else 
            {
                Console.WriteLine("Вердикт декодера:'Неверно'");
            }
        }

        static int remains(int n, int a, int b) //нахождение остатка
        {
            int counta = 1, countb = 0, mask = 1, shiftb, cop_b = 0;
            cop_b = b;
            while (counta > countb)
            {
                b = cop_b;
                for (int i = 0; i != n; i++)
                {
                    if ((a & mask) != 0)
                    {
                        counta = i;
                    }

                    if ((b & mask) != 0)
                    {
                        countb = i;
                    }

                    mask = mask << 1;
                }
                mask = 1;
                counta++;
                countb++;
                shiftb = counta - countb;
                if (shiftb < 0)
                {
                    return a;
                }
                b = b << shiftb;
                a = a ^ b;
            }
            return a;

        }
        static string Twocod(int z)
        {
            string r = "", k = "";
            while (z > 2)
            {
                r += Convert.ToString(z % 2);
                z = z / 2;
            }
            r += Convert.ToString(z % 2);

            for (int s =r.Length-1; s>=0; s--)
            {
                k += r[s];
            }

            
            return k;
        }
        

    }
}
