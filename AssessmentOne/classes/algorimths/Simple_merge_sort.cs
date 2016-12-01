using System;

namespace AssessmentOne
{
    /// <summary>
    /// this class organize a group of values using a sorted algorithm based into the merge logic
    /// </summary>
    class Simple_merge_sort
    {
        public int[] sortElements;
        /// <summary>
        /// main function to call the elements into console
        /// </summary>
        /// <param name="listElements">a list of elementes to be sorted</param>
        public void sort(int[] listElements)
        {
            Console.WriteLine("***** Elements before sort ******");
            foreach (int i in listElements)
            {
                Console.WriteLine("Element: " + i);
            }
            sortMerge(listElements, 0, (listElements.Length-1));
            Console.WriteLine("***** Elements after sort ******");
            foreach (int i in listElements)
            {
                Console.WriteLine("Element: " + i);
            }
           
        }
        /// <summary>
        /// a recursively function to sort values
        /// </summary>
        /// <param name="listElements">a list of values to be sorted</param>
        /// <param name="left">left position to be compared</param>
        /// <param name="right">right position to be compared</param>
        public void sortMerge(int[] listElements, int left, int right) 
        {
            int mid;
            // if right is more than left, begin the game...
            if (right > left)
            {
                // finding the middle of the values 
                mid = (left + right) / 2;
                // a recursibily called to send elements and positions to star
                sortMerge(listElements, left, mid);
                // a recursibily called to send elements and positions to star, again but changing positions
                sortMerge(listElements, (mid + 1), right);
                // a recursibily called to send elements and positions to star and again changing positions
                mainMerge(listElements, left, (mid + 1), right);
            }
        }
        /// <summary>
        /// create the merge between values
        /// </summary>
        /// <param name="numbers">take the number of values to be sorted</param>
        /// <param name="left"> define what position in its left position might be taken</param>
        /// <param name="mid">define what is the middle position of the array of values to be taken</param>
        /// <param name="right">define waht postition in is right position might be taken</param>
        private void mainMerge(int[] numbers, int left, int mid, int right)
        {
            // createa temporaly array of numbers 
            int[] temp = new int[numbers.Length];
            int i, eol, num, pos;
            // change position of middle
            eol = (mid - 1);
            // change position of left
            pos = left;
            
            num = (right - left + 1);
            // this loop compare positions between left and right with center
            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }
            // this loop check values between left and middle
            while (left <= eol)
                temp[pos++] = numbers[left++];
            // this loop check values between right and middle
            while (mid <= right)
                temp[pos++] = numbers[mid++];

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
    }


    /*
     /// code rubbish, dont touch because i like keep my rubbish here, it takes me long time to undestand how #$%#%& a simple mege sort works
    int increase = 0;

            List<int[]> tmpElements = new List<int[]>();

            List<int> tmp = new List<int>();
            int count = 0;
            for (int i = 0; i < listElements.Length; i++)
            {
                tmp.Add(listElements[i]);
                count++;
                if ((count > 1) || ((listElements.Length - 1) == i))
                {
                    tmpElements.Add(tmp.ToArray());
                    increase++;
                    tmp = new List<int>();
                    count = 0;
                }
            }
            List<int[]> tmpValues = new List<int[]>();
            List<int[]> tmpValues2 = new List<int[]>();
            count = 4;
            foreach(int[] elements in tmpElements){
                tmpValues.Add(elements);
                if (tmp.Count != count)
                {
                    tmpValues2 = tmpValues;
                    tmpValues = new List<int[]>();
                }
            }


     int beg = 0;
            int mid = 0;
            int end = listElements.Length;
            int increase = 0;
            mid = (beg + end) / 2;
            List<int[]> tmp = new List<int[]>();
            tmp.Add(listElements);
            
            while (beg < end)
            {
                mid = (beg + end) / 2;
                if (end > 2)
                    mid = mid + 1;
                
                int[] tmpArray = new int[mid];
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    tmpArray[i] = tmp[increase][i];
                }
                increase++;
                tmp.Add(tmpArray);
                end = tmpArray.Length;
            }
     
     */

    /*
            int increase = 1;

            int couples = 0;
            couples = ((listElements.Length / 2) + (listElements.Length % 2));

            int[][] JaggerArray = new int[couples][];
            List<int> tmp = new List<int>();
            int count = 0;
            for(int i = 0; i < listElements.Length; i++)
            {
                tmp.Add(listElements[i]);
                count++;
                if ((count > 1)||((listElements.Length-1)==i))
                {
                    JaggerArray[increase-1] = tmp.ToArray();
                    increase++;
                    tmp = new List<int>();
                    count = 0;
                }
            }
            while (true)
            {
                for (int i = 0; i < JaggerArray.Length; i++)
                {
                    if (JaggerArray[i].Length > 1)
                    {
                        if (JaggerArray[i][0] > JaggerArray[i][1])
                        {
                            int temp = JaggerArray[i][0];
                            JaggerArray[i][0] = JaggerArray[i][1];
                            JaggerArray[i][1] = temp;
                        }
                    }
                }
            }
        */
}
