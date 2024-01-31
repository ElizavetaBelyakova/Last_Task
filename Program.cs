namespace Tasks
{
    static class Program
    {
        public static void Main (string [] args)
        {
            Console.Clear();
            string stringLoad = "Ввести номер задания (1 или 2) => ";
            Console.Write(stringLoad);
            Tasks(NumberInTerminal(2,stringLoad,1));
        }
        static void Tasks(int num)
        {
            switch (num)
            {
                
                case 1:
                {
                    Console.WriteLine("Задание 1: Написать программу вычисления функции Аккермана с помощью рекурсии.");
                    Console.WriteLine("Даны два неотрицательных числа m и n.");
                    string firstText = "Ввести значение m => ";
                    Console.Write(firstText);
                    int firstNumber = NumberInTerminal(0xFFFFFF,firstText,0);
                    string secondText ="Ввести значение n => ";
                    Console.Write(secondText);
                    int secondNumber = NumberInTerminal(0xFFFFFF,secondText,0);
                    Console.WriteLine($"Значение по фукнкции Аккермана ({firstNumber},{secondNumber}) = {Ack(firstNumber,secondNumber)}");
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Задание 2: Создать произвольный массив. Вывести его элементы,");
                    Console.WriteLine("Начать ввод с конца. Использовать рекурсию без использования цикла.");
                    int [] array = CreateArray(8,8,0);
                    Console.WriteLine($"Произвольный массив => [{PrintArray(array)}]");
                    Console.WriteLine($"Перевернутый массив => [{PrintArray(ArraySwap(array,array.Length-1))}]");
                    break;
                }
            }
        }
        public static int Ack(int m, int n)
        {
            if (m == 0) 
            {
                return n + 1;
            }
            else
            {
                if (n == 0) 
                {
                    return Ack(m - 1, 1);
                }
                else
                {
                    return Ack(m - 1, Ack(m, n - 1));
                } 
            }
        }
        public static int [] CreateArray (int size, int max, int min)
        {
            int [] array  = new int[size];
            Random rand = new();
            for (int i = 0; i < size; i++)
            {
                array [i] = rand.Next(min,max+1);
            }
            return array;
        }
        public static string PrintArray(int [] array)
        {
            return string.Join(", ",array);
        }
        public static int [] ArraySwap(int [] array,int index)
        {

            if (index <= 0)
            {
                return array;
            }
            int temp = array[index];
            array[index] = array[array.Length - index-1];
            array[array.Length - index-1] = temp;
            return ArraySwap(array,index -= 2);
        }
        /*Ввод данных в терминале*/
        public static int NumberInTerminal(int numberDigits, string repeatString, int minValueSet)
        {
            string ? numString = Console.ReadLine();
            int numInt = 0;
            while ((!Int32.TryParse(numString,out numInt)) 
                    || !(numInt >= minValueSet) 
                    || !(numInt <= numberDigits)
                  )
            {
                Console.WriteLine("Повторить ввод");
                Console.Write(repeatString);
                numString = Console.ReadLine(); 
            }
            return numInt;
        }

        public static void PrintArray(char [,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            string output = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    output += array[i,j] + " ";
                }
                Console.WriteLine($"[ {output}]");
                output = "";
            }
        }
    }
}
