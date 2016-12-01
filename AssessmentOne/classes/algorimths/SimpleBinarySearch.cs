using System;

namespace AssessmentOne
{
    class SimpleBinarySearch
    {
        /// <summary>
        /// this function find elements and show in console
        /// </summary>
        /// <param name="listElements"></param>
        /// <param name="elementFind"></param>
        public void search(int[] listElements, int elementFind)
        {
            int position = BinarySearchIterative(listElements, elementFind, 0,(listElements.Length-1));
            if (position > 0)
            {
                Console.WriteLine("Element found: "+ listElements[position]);
            }
            else
            {
                Console.WriteLine("Element Not Found");
            }
        }

        /// <summary>
        /// this function find elements and return true if found somenthing, otherwise is false
        /// </summary>
        /// <param name="listElements"></param>
        /// <param name="elementFind"></param>
        /// <returns></returns>
        public bool find(int[] listElements, int elementFind)
        {
            int position = BinarySearchIterative(listElements, elementFind, 0, (listElements.Length - 1));
            if (position > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// search into an array of elements if any key are or not into the min and max of those values
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="key"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int BinarySearchIterative(int[] inputArray, int key, int min, int max)
        {
            //change position between ther maximun value found and the minimal
            while (min <= max)
            {
                int mid = (min + max) / 2;
                // if the value key is different of the value to be compared into the array, return the position where you found it
                //else, ask if key value is more than value of imputvalue if is true, increase mid
                // if both conditions are negative, just save min into mid
                if (key == inputArray[mid])
                {
                    return mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// search into an array of elements if any key are or not into the min and max of those values, but recursively
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="key"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static object BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            //if min are big than max.... well must be oposite, that is why these variables are named, so return nill
            if (min > max)
            {
                return "Nil";
            }
            else
            {
                //change position of middle position using values of min and max value and divide by 2
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, max);
                }
            }
        }
    }
}
