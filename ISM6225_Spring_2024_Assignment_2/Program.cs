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
            /* 
            --LOGIC
            
            Traverse the elements in the array and if the element is not present
            in an intially empty dictionary, the element will be added as a key to the dictionary

            Once all the elements are traversed in the input array a loop starting from 1 to n 
            will check if any number is missing from the Dictionary. The missing numbers will
            then be appended to a list and at the end of the program, this list is returned. 

            Self reflection: I've done this in Python already but this helped understand C# syntax

            Time Complexity: O(n)
            */
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
            /* 
            --LOGIC

            Two pointer is used to sort the elements in place hence the space complexity is O(1).
            Two indices i and j will be used to iterate through the array. If the element is an
            odd number, then the i will go to the next element, keeping j the same. If the element in the
            array is an even number but i and j are same, then that element is skipped, meaning 
            it's already sorted. If the element is an even number but i and j are not the same, then
            the elements at the position i and j are swapped.

            Self Reflection: If visualization in your mind is not good, especially for two pointers, then
            draw it on notebook and then try.

            Time Complexity: O(n)
            */
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
            /*
            --LOGIC

            Iterate through the elements of the array and check if the difference between the
            target and the current element exists in the declared dictionary. If the difference
            doesn't exist, <k,v> = <element, index> is added to the dictionary. If the difference
            does exist in the dictionary, index(v) for difference(k) is appended to a list and then
            the current index of the element is also added to the list which is then returned.

            Self reflection: Always use a dictionary to keep track of elements.

            Time Complexity: O(n)
            */
            try
            {	
				List<int> resList = new List<int>();
				Dictionary<int, int> newDict = new Dictionary<int,int>();
				for(int i = 0; i < nums.Length; i++){
					if(!newDict.ContainsKey(target - nums[i])){
						newDict.Add(nums[i],i);
					}
					else{
						//Console.WriteLine(newDict[target-nums[i]]);
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
            /*
            --LOGIC

            So for a 3 number to yield a maximum product, we need to find out the lowest, the second
            lowest, the highest, the second highest and the third highest. The lowest and the second
            lowest numbers could be negative and the product of two negatives is always positive. Hence,
            we need to check the product of lowest, second lowest and the highest and compare it with
            the product of highest, second highest and third highest. Whichever produces the higher result
            will then be returned.

            Self reflection: The initial logic of sorting is good but will take more time complexity. Hence,
            this approach of finding the min and max of elements is much more optimized. Again, if confused use
            a notebook to figure out the logic.

            Time Complexity: O(n)
            */
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
            /*
            --LOGIC

            The logic is simple, find the remainder of the number and append the remainder
            to a string, then divide the number by 2. Keep on doing this until the number is
            greater than 0. Then return the number.

            Self reflection: This was an easy one, just remember we can use res = num%2 + res, whereas
            what I usually do is res+=num%2 and then reverse the entire string.

            Time Complexity: O(n)
            */
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
            /* 
            --LOGIC

            I know the original question on leetcode says to achieve this in O(log n) time complexity
            but I'm still working on that logic. For now, I'm just finding the minimum element in the list.

            Self reflection: I need to figure out how to solve it using O(log n) time complexity. I know
            where to start, all I need to find is the point where there's a variation in number sorting in
            the list and then divide the list to find the min.

            Time Complexity: O(n)
            */
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
            /*
            --LOGIC

            Similar logic as the binary number problem, find the remainder and store it in an
            empty string. Then divide the number by 10. Basically reversing the number
            . One thing is to store the initial number to a variable for comparison. Then 
            compare the result and the initial number, return True if matches, else False. 

            Self reflection: Same as the binary one.

            Time Complexity: O(n)
            */
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
            /*
            -- LOGIC

            Used recursion for solving this problem. The program will recursively call the 
            function to calculate the fibonacci number. When the number is 1, the value of
            the Fibonacci is returned.

            Self reflection: Recursion is confusing. You need to have a good understanding of your logic and the
            problem. I need to solve a lot more questions on recursion.

            Time Complexity: O(2^n).
            */
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
