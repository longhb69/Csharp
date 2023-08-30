using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Numerics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections;
using System.ComponentModel.Design;

namespace ConsoleApp1
{
    class Class1
    {
        private string name;

        [DefaultValue("")]
        private string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string getType()
        {
            return $"type of name {GetType().Name}";
        }
        public void getName()
        {
            Console.WriteLine("Name: " + Name);
        }
    }
    public static class DifferenceOfSquares
    {
        public static int CalculateSquareOfSum(int max)
        {
            var num = Enumerable.Range(1, max);
            return num.Sum() * num.Sum();
        }

        public static int CalculateSumOfSquares(int max)
        {
            var num = Enumerable.Range(1, max).Select(i => i * i);
            return num.Sum();
        }

        public static int CalculateDifferenceOfSquares(int max)
        {
            return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);  
        }
    }
    static class SavingsAccount
    {
        public static float InterestRate(decimal balance)
        {
            if (balance < 0)
            {
                return 3.213f;
            }
            else if (balance < 1000)
            {
                return 0.5f;
            }
            else if (balance >= 1000 && balance < 5000)
            {
                return 1.621f;
            }
            else if (balance >= 5000)
            {
                return 2.475f;
            }
            return 0;
        }
        public static decimal Interest(decimal balance)
        {
            return balance * ((decimal)InterestRate(balance) / 100);
        }
        public static decimal AnnualBalanceUpdate(decimal balance)
        {
            return balance + Interest(balance);
        }
        public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
        {
            decimal newBalance = balance;
            int count = 0;
            while (newBalance < targetBalance)
            {
                newBalance = AnnualBalanceUpdate(newBalance);
                count++;
            }
            return count;
        }
    }
    static class LogLine
    {
        public static string Message(string logLine)
        {
            string pattern = @"\[(INFO|WARNING|ERROR)\]:(.+)";
            Match match = Regex.Match(logLine, pattern);
            return match.Groups[2].Captures[0].Value.Trim();
        }
        public static string LogLevel(string logLine)
        {
            string pattern = @"\[(INFO|WARNING|ERROR)\]:(.+)";
            Match match = Regex.Match(logLine, pattern);
            return match.Groups[1].Captures[0].Value.ToLower();
        }
        public static string Reformat(string logLine)
        {
            return $"{Message(logLine)} ({LogLevel(logLine)})";
        }
    }
    public static class Bob
    {
        public static string Response(string statement)
        {
            bool isEmtyOrWhiteSpace = string.IsNullOrWhiteSpace(statement);
            bool endWithQuestionMark = !string.IsNullOrWhiteSpace(statement) && statement.Trim().Substring(statement.Trim().Length - 1) == "?";
            bool allCap = statement == statement.ToUpper() && statement != statement.ToLower();
            if (allCap && endWithQuestionMark)
            {
                return "Calm down, I know what I'm doing!";
            }
            else if (!isEmtyOrWhiteSpace && allCap)
            {
                return "Whoa, chill out!";
            }
            else if (endWithQuestionMark)
            {
                return "Sure.";
            }
            else if (isEmtyOrWhiteSpace)
            {
                return "Fine. Be that way!";
            }
            else
            {
                return "Whatever.";
            }
        }
    }
    public static class Dominoes
    {
        public static bool CanChain(IEnumerable<(int, int)> dominoes)
        {
            List<(int, int)> domino_list = new List<(int, int)>();
            if(dominoes == null) 
            {
                return true;
            }
            var enumerator = dominoes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                domino_list.Add(enumerator.Current);
            }
            foreach (var domino in domino_list)
            {
                Console.WriteLine($"({domino.Item1}, {domino.Item2})");
            }
            if(domino_list.Count == 1)
            {
                return domino_list[0].Item1 == domino_list[0].Item2 ? true : false;
            }
            
            int loopbreak = 0;
            while (loopbreak < domino_list.Count && !isChain(domino_list))
            {
                var firstdomino = domino_list[loopbreak];
                SwapElements(domino_list, 0, loopbreak);
                Console.WriteLine("loopbreak: " + loopbreak);
                Console.WriteLine("First: " + firstdomino);
                for (int i = 1; i < domino_list.Count; i++)
                {
                    if(i == loopbreak) 
                    {
                        continue;
                    }
                    if (domino_list[i].Item2 == firstdomino.Item1)
                    {
                        var lastdomino = domino_list[i];
                        Console.WriteLine("Last " + lastdomino);
                        SwapElements(domino_list, i, domino_list.Count - 1);
                    }
                    else if (domino_list[i].Item1 == firstdomino.Item1)
                    {
                        swapItems(domino_list, i);
                        var lastdomino = domino_list[i];
                        Console.WriteLine("Last " + lastdomino);
                        SwapElements(domino_list, i, domino_list.Count - 1);
                    }
                }
                Console.WriteLine("after swap last and fisrt");
                foreach (var domino in domino_list)
                {
                    Console.WriteLine($"({domino.Item1}, {domino.Item2})");
                }
                Console.WriteLine("--------------------------");

                for (int i=1; i < domino_list.Count - 1;i++)
                {
                    int pre = i - 1;
                    int next = i + 1;
                    Console.WriteLine(domino_list[i]);
                    Console.WriteLine(domino_list[next]);
                    if (domino_list[i].Item2 != domino_list[next].Item1)
                    {
                        Console.WriteLine("Not Equal");
                        if (domino_list[pre].Item2 == domino_list[next].Item2)
                        {
                            Console.WriteLine("Reverse" + domino_list[next] + " to match " + domino_list[pre]);
                            swapItems(domino_list, next);
                            SwapElements(domino_list, i, next);
                        }
                        else if (domino_list[next].Item1 == domino_list[pre].Item2)
                        {
                            SwapElements(domino_list, i, next);
                        }     
                    }
                    else
                    {
                        Console.WriteLine("Equal");
                    } 
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"after {i} loop");
                    foreach (var domino in domino_list)
                    {
                        Console.WriteLine($"({domino.Item1}, {domino.Item2})");
                    }
                    Console.WriteLine("--------------------------");
                }
                Console.WriteLine($"chain of {loopbreak+1} loop: " + isChain(domino_list));
                loopbreak++;
            }
            
            return isChain(domino_list);
        }
        static bool isChain(List<(int, int)> list)
        {
            for(int i = 0; i < list.Count-1; i++) 
            {
                int next = (i + 1) % list.Count;
                if (list[i].Item2 != list[next].Item1 || list[0].Item1 != list[list.Count-1].Item2)
                {
                    return false;
                }
            }
            return true;
        }
        static void SwapElements<T>(List<T> list, int index1, int index2)
        {
            if (index1 >= 0 && index1 < list.Count &&
                index2 >= 0 && index2 < list.Count)
            {
                T temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
                Console.WriteLine("Swap list");
            }
            else
            {
                Console.WriteLine("Invalid indices. in swap elment");
            }
        }
        static void swapItems(List<(int, int)> list, int idx)
        {
            if(idx >= 0 && idx < list.Count)
            {
                int tempItem1 = list[idx].Item1;
                int newItem1 = list[idx].Item2;
                int newItem2 = tempItem1;
                (int, int) newtuple = (newItem1, newItem2);
                list.RemoveAt(idx);
                list.Insert(idx, newtuple);
                Console.WriteLine("Swap tuple");
            }
            else
            {
                Console.WriteLine("Invalid indices. in swap item");
            }
        }

    }
    public static class PythagoreanTriplet
    {
        public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
        {
            for (int a = 1; a < sum / 3; a++)
            {
                for (int b = a + 1, c = sum-a-b; b < c; b++, c--)
                {
                    if (a * a + b * b == c * c)
                    {
                        yield return (a, b, c);
                    }
                }
            }
        }
    }
    public static class SaddlePoints
    {
        public static IEnumerable<(int, int)> Calculate(int[,] matrix)
        {
            int rowlength = matrix.GetLength(0);
            int collength = matrix.GetLength(1);
            var Rows = Enumerable.Repeat(0, rowlength).ToArray();
            var Columns = Enumerable.Repeat(int.MaxValue, collength).ToArray();

            Console.WriteLine(rowlength);
            Console.WriteLine(collength);

            for(int i= 0;i< rowlength; i++)
            {
                for (int j= 0;j < collength ;j++)
                {
                    Rows[i] = Math.Max(matrix[i,j], Rows[i]);
                    Columns[j] = Math.Min(matrix[i, j], Columns[j]);
                }
            }
            Console.WriteLine("Row");
            foreach (var row in Rows) 
            {
                Console.WriteLine(row);
            }
            Console.WriteLine("-----------");
            Console.WriteLine("Column");
            foreach (var col in Columns)
            {
                Console.WriteLine(col);
            }
            for(int i=0;i< rowlength;i++)
            {
                for(int j=0;j< collength;j++)
                {
                    if (matrix[i,j] == Columns[j] && matrix[i,j] == Rows[i])
                    {
                        yield return (i+1, j+1);
                    }
                }
            }
        }
    }
  
    public static class ProteinTranslation
    {
        private static string[] protein = new String[] { "Methionine", "Phenylalanine", "Leucine", "Serine", "Tyrosine", "Cysteine", "Tryptophan", "STOP" };
        public static string[] Proteins(string strand)
        {
            string[] codons = SplitString(strand, 3);
            string[] amino = new string[codons.Length];
            for (int i=0;i<codons.Length;i++) 
            {
                if (codons[i] == "AUG")
                {
                    amino[i] = protein[0];
                }
                else if (codons[i] == "UUU" || codons[i] == "UUC")
                {
                    amino[i] = protein[1];
                }
                else if(codons[i] == "UUA" || codons[i] == "UUG")
                {
                    amino[i] = protein[2];
                }
                else if (codons[i] == "UCU" || codons[i] == "UCC" || codons[i] == "UCA" || codons[i] == "UCG")
                {
                    amino[i] = protein[3];
                }
                else if (codons[i] == "UAU" || codons[i] == "UAC")
                {
                    amino[i] = protein[4];
                }
                else if (codons[i] == "UGU" || codons[i] == "UGC")
                {
                    amino[i] = protein[5];
                }
                else if (codons[i] == "UGG")
                {
                    amino[i] = protein[6];
                }
                else
                {
                    //from [Methionine, null. null] to [Methionine]
                    return Enumerable.Range(0, codons.Length).Select(i => amino[i]).TakeWhile(i => i != null).ToArray();
                }
            }
            return amino;
        }
        public static string[] SplitString(string strand, int length) 
        {
            int count = strand.Length / length;
            string[] substrings = new string[count];
            for(int i = 0; i < count;i++)
            {
                int startIndex = i * length;
                int endIndex = startIndex + length;
                substrings[i] = strand.Substring(startIndex, length);
            }
            return substrings;
        }
    }
    public class Anagram
    {
        private string baseWord;
       
        public static string SortString(string input) => new String(input.OrderBy(x => x).ToArray());

        public Anagram(string baseWord)
        {
            this.baseWord = baseWord;
        }
        private static bool IsAnagram(string a, string b)
        {
            return a.ToLower() != b.ToLower() && a.ToUpper() != b.ToUpper() && SortString(a.ToLower()) == SortString(b.ToLower());
        }
        public string[] FindAnagrams(string[] potentialMatches)
        {
            return potentialMatches.Where(ch => IsAnagram(ch, baseWord)).ToArray();
        }
    }
    public static class RunLengthEncoding
    {
        public static string Encode(string input)
        {
            char[] chars = input.ToCharArray();
            List<char> CharList = new List<char>();
            List<string> numberList = new List<string>();
            int count = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 0)
                {
                    count++;
                    CharList.Add(chars[i]);
                }
                else if (chars[i] != chars[i - 1])
                {
                    CharList.Add(chars[i]);
                    if (count > 1)
                    {
                        numberList.Add(count.ToString());
                    }
                    else
                    {
                        numberList.Add("");
                    }
                    count = 1;
                }
                else
                {
                    count++;
                }
                if (i == chars.Length - 1)
                {
                    if (count > 1)
                    {
                        numberList.Add(count.ToString());
                    }
                    else
                    {
                        numberList.Add("");
                    }
                }
            }

            var numberAndWord = CharList.Zip(numberList, (word, numbers) => $"{numbers}{word}").ToArray();
            return new string(string.Join("", numberAndWord));
            //string pattern = @"(\D)\1+";
            //return Regex.Replace(input, pattern, c => c.Length.ToString() + c.Value[0]);
        }

        public static string Decode(string input)
        {
            string pattern = @"(\d+)(\D)";
           
            return Regex.Replace(input, pattern, c => new String(c.Groups[2].Value[0], int.Parse(c.Groups[1].Value)));
          
        }
    }
    public static class RomanNumeralExtension
    {
        public static char[] key = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        public static string ToRoman(this int value)
        {
            string stringValue = value.ToString(); 
            int lastdigit = int.Parse(stringValue[stringValue.Length - 1] + "");
            int? twoDigits = stringValue.Length - 2 < 0 ? null : int.Parse(stringValue[stringValue.Length - 2] + "0");
            int? threeDigits = stringValue.Length - 3 < 0 ? null : int.Parse(stringValue[stringValue.Length - 3] + "00");
            int? fourDigits = stringValue.Length - 4 < 0 ? null : int.Parse(stringValue[stringValue.Length-4] + "000");   
            Console.WriteLine(lastdigit);  
            
            return FourDigits(fourDigits) + ThreeDigits(threeDigits) + TwoDigits(twoDigits) + LastDigit(lastdigit);
        }
        public static string FourDigits(int? value)
        {
            string roman = "";
            for(int i = 1; i <= value/1000;i++)
            {
                roman += key[6].ToString();
            }
            return roman;
        }
        public static string ThreeDigits(int? value)
        {
            string roman = "";
            for(int i = 1; i <= value/100;i++)
            {
                if (i == 5 )
                {
                    roman = key[5].ToString();
                }
                else if( i == 4)
                {
                    roman = key[4].ToString() + key[5].ToString();
                }
                else if( i == 9)
                {
                    roman = key[4].ToString() + key[6].ToString();
                }
                else
                {
                    roman += key[4].ToString();
                }
            }
            return roman;
        }
        public static string TwoDigits(int? value)
        {
            string roman = "";
            for(int i=1;i<=value/10;i++) 
            {
                if(i == 5)
                {
                    roman = key[3].ToString();
                }
                else if(i == 4)
                {
                    roman = key[2].ToString() + key[3].ToString();
                }
                else if(i == 9)
                {
                    roman = key[2].ToString() + key[4].ToString();
                }
                else
                {
                    roman += key[2].ToString();
                }
            }
            return roman;
        }
        public static string LastDigit(int value)
        {
            string roman = "";
            int count = 0;
            int keyIndex = 0;
            for (int i = 1; i <= value; i++)
            {
                if(i == 5)
                {
                    roman = key[1].ToString();
                    continue;
                }
                if (count != 3)
                {
                    roman += key.First();
                    count++;
                }
                else 
                {
                    string pattern = @"(VIII|III)";
                    roman = Regex.Replace(roman, pattern, $"{key[0]}{key[keyIndex + 1]}");
                    count = 0;
                    keyIndex++;
                }     
            }
            return roman;
        }
    }
    public static class SumOfMultiples
    {
        public static int Sum(IEnumerable<int> multiples, int max)
        {
            return Enumerable.Range(0, max).Where(n => multiples.Any(m => m > 0 && n % m ==0)).Sum();
        }
    }
    public class SpiralMatrix
    {
        public static int[,] GetMatrix(int size)
        {
            int[,] array = new int[size, size];
            int rowLength = array.GetLength(0) - 1;
            int colLength = array.GetLength(1) - 1;

            int rowloop = 0;
            int startcol = 1;
            int reverselooprow = rowLength - 1;

            int row = 0;
            int col = colLength;

            int rowbond = rowLength; 
            int colbond = colLength;
            int reversebond = 0;
            int reversebondcol = 1;

            int count = 1;

            for (int i = 0; i <= size/2; i++)
            {
                Console.WriteLine(i);

                for (int j = rowloop; j <= rowbond; j++)
                {
                    Console.WriteLine("row " + row + " " + j);
                    array[row,j] = count;
                    count++;
                }
                Console.WriteLine();
                for(int j = startcol; j <= colbond; j++)
                {
                    Console.WriteLine("col " + j + " " + col);
                    array[j, col] = count;
                    count++;
                }
                int temp = row;
                row = col;
                col = temp;

                
                Console.WriteLine();
                Console.WriteLine("Reverse");
                for (int j = reverselooprow; j >= reversebond; j--)
                {
                    Console.WriteLine("row " + row + " " + j);
                    array[row, j] = count;
                    count++;
                }
                Console.WriteLine();
                for(int j = reverselooprow; j >= reversebondcol; j--)
                {
                    Console.WriteLine("col " + j + " " + col);
                    array[j, col] = count;
                    count++;
                }
                reverselooprow--;
                reversebond++;
                reversebondcol++;

                temp = row;
                row = col;
                col = temp;

                row++;
                rowbond--;
                rowloop++;
                col--;
                startcol++;
                colbond--;
            }
            Console.WriteLine();
            return array;
        }
    }
    public static class BookStore
    {
        static double[] groupMultiplier = new double[] { 0, 8, 15.2, 21.6, 25.6, 30 };
        public static decimal Total(IEnumerable<int> books)
        {
            List<int> bookList = books.GroupBy(s => s).Select(x => x.Count()).ToList();
            foreach(int book in bookList) { Console.Write(book + " "); }
            Console.WriteLine();
            List<double> prices = new List<double>();
            if (bookList.Count == 1) return (decimal)(bookList[0] * 8);
            while (bookList.Count > 1)
            {
                double total = 0, amount = 0;
                bookList.Sort();
                foreach (int book in bookList) { Console.Write(book + " "); }
                Console.WriteLine();
                for (int j = 0; j < bookList.Count; j++)
                {
                    total += (bookList[j] - amount) * groupMultiplier[bookList.Count - j];
                    Console.WriteLine(total + "+=" +  (bookList[j] - amount) * groupMultiplier[bookList.Count - j] + " = " + bookList[j] + "-" + amount + "*" + groupMultiplier[bookList.Count - j]);

                    if (bookList[j] > amount) amount = bookList[j];
                }
                Console.WriteLine();
                prices.Add(total);
                bookList[0]--;
                bookList[1]++;
                bookList.Remove(0);
                foreach (int book in bookList) { Console.Write(book + " "); }
                Console.WriteLine();

            }
            return prices.Count > 0 ? (decimal)prices.Min() : 0m;
        }
    }
    public static class ResistorColor
    {
        private static Dictionary<string, int> colorCode = new Dictionary<string, int>
        {
            {"black", 0},
            {"brown", 1 },
            {"red", 2},
            {"orange", 3},
            {"yellow", 4 },
            {"green", 5},
            {"blue", 6 },
            {"violet", 7},
            {"grey", 8},
            {"white", 9 },
        };
        public static int? ColorCode(string color)
        {
            if(colorCode.TryGetValue(color, out int result)) return result;
            return null;
        }

        public static string[] Colors()
        {
            return colorCode.Keys.ToArray();
        }
        public static int Value(string[] colors)
        {
            var encoding = Enumerable.Range(0, 2).Select(i => colorCode[colors[i]]);
            return encoding.First()*10 + encoding.Last();

        }
    }
    public static class ScaleGenerator
    {
        private static string[] sharp = { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" }; 
        private static string[] flat = { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };
        public static string[] Chromatic(string tonic)
        {
            char[] chars = tonic.ToCharArray();
            if (chars.Length > 1 && chars[1] == 'b' || chars[0] == 'F' || chars[0] == 'g' || chars[0] == 'd' || chars[0] == 'c')
            {
                string upperTonic = string.Concat(char.ToUpper(chars[0]), chars.Length > 1 ? chars[1] : "");
                int index = Array.IndexOf(flat, upperTonic);
                return Enumerable.Range(0, 12).Select(i => flat[(i + index) % 12]).ToArray();
            }
            else
            {
                int index = Array.IndexOf(sharp, tonic.ToUpper());
                return Enumerable.Range(0, 12).Select(i => sharp[(i + index) % 12]).ToArray();
            }
        }
        public static string[] Interval(string tonic, string pattern)
        {
            char[] interval = pattern.ToCharArray();
            List<string> scale = Chromatic(tonic).ToList();
            List<string> result = new List<string>();
            result.Add(scale[0]);
            for (int i=0;i<interval.Length+1;i++) 
            {
                if(i ==  interval.Length)
                {
                    continue;
                }
                if (interval[i] == 'M')
                {
                    scale.RemoveAt(i+1);
                    result.Add(scale[(i+1)%scale.Count]);
                }
                else if (interval[i] == 'A')
                {
                    scale.RemoveAt(i + 1);
                    scale.RemoveAt(i + 1);
                    result.Add(scale[(i+1)%scale.Count]);
                }
                else
                {
                    result.Add(scale[(i+1)%scale.Count]);
                }
            }
            Console.WriteLine();
            foreach(string s in result) { Console.WriteLine(s); }
            return result.ToArray();
        }
    }
    public static class BinarySearch
    {
        public static int Find(int[] input, int value)
        {
            return BsSearch(value, 0, input.Length-1);

            int BsSearch(int value, int min, int max)
            {
                int index = (min+max)/2;
                if (min > max)
                    return -1;
                if (input[index] < value) 
                    return BsSearch(value, index+1, max);
                if (input[index] > value)
                    return BsSearch(value, 0, index - 1);   
                return index;
            }
        }
    }
    public static class FlattenArray
    {
        public static IEnumerable Flatten(IEnumerable input)
        {
            foreach(var i in input) 
            {
                if(i != null && i is not System.Object[]) yield return i;
                else if (i is System.Object[])
                {
                    IEnumerable<object> array = ((IEnumerable)i).Cast<object>();
                    foreach(var o in Flatten(array)) yield return o;
                }
            }
        }
    }
    public static class Transpose
    {
        public static string String(string input)
        {
            string[] array = input.Split('\n');
            var maxRow = array.OrderByDescending(row => row.Length).First();
            var maxLength = maxRow.Length;
            string[] transposed = new string[maxLength];
            for (int i = 0; i < array.Length;i++)
            {
                for(int j=0; j < array[i].Length;j++)
                {
                    transposed[j] += array[i][j];
                }
                var maxspace = array.Skip(i).Max(row => row.Length);
                for(int k = array[i].Length; k < maxspace; k++)
                {
                    transposed[k] += " ";
                }
            }
            return string.Join("\n", transposed).TrimEnd();
        }
    }
    public static class Rectangles
    {
        public static int Count(string[] rows)
        {
            if (rows == null || rows.Length == 1 || rows.Length == 0) return 0;
            int strLen = rows[0].Length;
            int recCount = 0;
            for (int i = 0; i < rows.Length - 1; i++)
            {
                for (int k = 0; k < strLen - 1; k++)
                {
                    if (rows[i][k] == '+')
                    {
                        for (int m = k + 1; m < strLen; m++)
                        {
                            if (rows[i][m] == '+')
                            {
                                bool isContinue1 = true;
                                for (int x = k + 1; x < m; x++)
                                {
                                    if (rows[i][x] == ' ' || rows[i][x] == '|')
                                        isContinue1 = false;
                                }
                                if (!isContinue1) break;

                                for (int j = i + 1; j < rows.Length; j++)
                                {
                                    if (rows[j][k] == ' ' || rows[j][k] == '-' || rows[j][m] == ' ' || rows[j][m] == '-')
                                        break;
                                    if (rows[j][k] == '+' && rows[j][m] == '+')
                                    {
                                        bool isContinue2 = true;
                                        for (int x = k + 1; x < m; x++)
                                        {
                                            if (rows[j][x] == ' ' || rows[j][x] == '|')
                                                isContinue2 = false;
                                        }
                                        if (!isContinue2) break;
                                        recCount++;
                                    }

                                }
                            }
                        }
                    }

                }
            }
            return recCount;
        }
    }
        class Program
    {
        static public void Main(string[] args)
        {
            
                var strings = new[]
            {
            "  +-+",
            "  | |",
            "+-+-+",
            "| | |",
            "+-+-+"
        };

                Console.WriteLine(Rectangles.Count(strings));

        }
    }
}
