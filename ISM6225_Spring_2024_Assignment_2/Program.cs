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
            int[] nums2 = { 3, 1, 2, 4 };
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
				List<int> newList = new List<int>();
                Dictionary<int,int> newDict = new Dictionary<int,int>();
                for(int i = 0; i < nums.Length; i++){
					if (!newDict.ContainsKey(nums[i])){
						newDict.Add(nums[i],1);
					}
				}
				for(int i = 1; i<=nums.Length; i++){
					if(!newDict.ContainsKey(i)){
						newList.Add(i);
					}
				}
                return newList; // Placeholder
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
				int i = 0;
				int j = 0;
				while(i < nums.Length){
					if(nums[i]%2==0){
						if(i!=j){
							int temp = 0;
							temp = nums[i];
							nums[i] = nums[j];
							nums[j] = temp;
							i++;
							j++;
						}
						else{
							i++;
							j++;
						}
					}
					else{
						i++;
					}
				}
                return nums; // Placeholder
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
				List<int> resList = new List<int>();
				Dictionary<int, int> newDict = new Dictionary<int,int>();
				for(int i = 0; i < nums.Length; i++){
					if(!newDict.ContainsKey(target - nums[i])){
						newDict.Add(nums[i],i);
					}
					else{
						Console.WriteLine(newDict[target-nums[i]]);
						resList.Add(newDict[target-nums[i]]);
						resList.Add(i);
						return resList.ToArray();
					}
				}
				return resList.ToArray();
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
				int lowest = int.MaxValue;
				int second_lowest = int.MaxValue;
				int highest = int.MinValue;
				int second_highest = int.MinValue;
				int third_highest = int.MinValue;
				for(int i = 0; i < nums.Length; i++){
					if(nums[i] <= lowest){
						second_lowest = lowest;
						lowest = nums[i];
					}
					else{
						if(nums[i] <= second_lowest){
							second_lowest = nums[i];
						}
					}
					
					if(nums[i] >= highest){
						third_highest = second_highest;
						second_highest = highest;
						highest = nums[i];
					}
					else{
						if(nums[i] >= second_highest){
							third_highest = second_highest;
							second_highest = nums[i];
						}
						else{
							if(nums[i] >= third_highest){
								third_highest = nums[i];
							}
						}
					}
				}
				if(lowest*second_lowest*highest > highest*second_highest*third_highest){
					return lowest*second_lowest*highest;
				}
				else{
                return highest*second_highest*third_highest;
				} // Placeholder
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
                string res = string.Empty;
				while(decimalNumber > 0){
					res = decimalNumber%2 + res;
					decimalNumber = decimalNumber/2;
				}
                return res; // Placeholder
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
				int min = int.MaxValue;
				for(int i = 0; i < nums.Length; i++){
					if(nums[i] < min){
						min = nums[i];
					}
				}
				
                return min; // Placeholder
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
				if(x==0){
					return true;
				}
				int org = x;
				string res = string.Empty;
				while(org>0){
					res += org%10;
					org/=10;
				}
                return (res == Convert.ToString(x)); // Placeholder
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
                if(n<=1){
					return n;
				}
				else{
                return Fibonacci(n-1) + Fibonacci(n-2);
				}; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
