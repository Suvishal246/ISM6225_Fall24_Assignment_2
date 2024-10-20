using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 2 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> result = new List<int>();
                int n = nums.Length;
                // Mark present numbers using index manipulation
                for (int i = 0; i < n; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }
                // Find missing numbers (positive indices + 1)
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    // Find first odd number from left
                    while (left < right && nums[left] % 2 == 0)
                        left++;
                    // Find first even number from right
                    while (left < right && nums[right] % 2 == 1)
                        right--;
                    // Swap odd and even numbers
                    if (left < right)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                }
                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    if (!map.ContainsKey(nums[i]))
                    {
                        map.Add(nums[i], i);
                    }
                }
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;
               
                return Math.Max(
                    nums[n - 1] * nums[n - 2] * nums[n - 3],
                    nums[0] * nums[1] * nums[n - 1]
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                    return "0";

                List<int> binary = new List<int>();
                while (decimalNumber > 0)
                {
                    binary.Add(decimalNumber % 2);
                    decimalNumber /= 2;
                }
                binary.Reverse();
                return string.Join("", binary);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0)
                    return false;

                // Single digit numbers are palindromes
                if (x < 10)
                    return true;

                int original = x;
                int reversed = 0;
                while (x > 0)
                {
                    reversed = reversed * 10 + x % 10;
                    x /= 10;
                }
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 1)
                    return n;

                int prev = 0, current = 1;
                for (int i = 2; i <= n; i++)
                {
                    int next = prev + current;
                    prev = current;
                    current = next;
                }
                return current;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
