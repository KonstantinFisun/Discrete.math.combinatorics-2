using System;
using System.IO;


class Program
{

	static bool nextCombobj(int[] razP, int k, int n)
	{
		int count ;
		do
		{
			int j = k - 1;
			while (j >= 0 && razP[j] == n - 1) j--;

			if (j == -1) return false;

			razP[j]++;


			for (int i = j + 1; i < k; i++)
			{
				razP[i] = 0;
			}

			count = 0;

			for (int i = 0; i < k; ++i)
			{
				int g;
				for (g = i + 1; g < k && razP[g] != razP[i]; ++g);
				if(g==k) count ++;
			}

		} while (count != 3);

		return true;
	}


	static void Main()
	{
		int n = 10;//размер алфавита
		char[] arr = new char[10] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k' };

		int N;
		
		Console.WriteLine("Длина слова 9  ");
		N =9;
			
		int[] razP = new int[N+1];
    	for (int i = 0; i < N; i++)
		{
			razP[i] = 0;
		}
		FileInfo output = new FileInfo("out.txt");
		StreamWriter fs = output.CreateText();

		int kol = 0;
		while (nextCombobj(razP, N, n))
		{
			
			for (int i = 0; i < N; i++)
			{
				fs.Write(arr[razP[i]]);
			}
			fs.WriteLine();
			kol++;
			

		}
		fs.WriteLine("Количество - " + kol);
		Console.WriteLine("Количество - " + kol);
		Console.WriteLine("Программа завершена");
		fs.Close();
		Console.ReadKey();
	}
}

