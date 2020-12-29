using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FileInfo output = new FileInfo("out.txt");
            StreamWriter fs = output.CreateText();
            int kol = 0;
            for(int x1 = 1; x1 <= 8; x1++) //x1<=8
            {

                for(int x3=1; x3 <= 7; x3++) //x3<=7
                {

                    for(int x5 = 1; x5 <= 6; x5++)// x5 <= 6
                    {

                        for(int x7 = 1; x7 <= 5; x7++)//x7 <= 5
                        { 

                            for (int x2 = 100-11-12-12-x1-x3-x5-x7; x2 >=9; x2--)
                            {

                                for (int x4 = 100-x2-x1-x3-x5-x7; x4 >10; x4--)
                                {

                                    for(int x6 = 100 - x2 - x1 - x3 - x5 - x7-x4; x6 >11; x6--)
                                    {

                                        int x8 = 100 - x2 - x1 - x3 - x5 - x7 - x4 - x6;
                                        if (x8 >= 12)
                                        {

                                            int sum = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8;

                                            fs.WriteLine(x1 + " + " + x2 + " + " + x3 + " + " + x4 + " + " + x5 + " + " + x6 + " + " + x7 + " + " + x8 + " = " + sum);
                                            kol++;

                                        }
                                        
                                       
                                    }

                                }

                            }
                            

                        }

                    }

                }

            }
            fs.WriteLine("\n" + kol);
            fs.Close();
            Console.WriteLine("Программа завершена");
            Console.ReadKey();
        }
    }
}
