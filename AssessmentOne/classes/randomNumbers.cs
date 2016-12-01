using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOne.classes
{
    class randomNumbers
    {

        private IEnumerable<int> createRandomElements(int maxInclusive)
        {
            Random rdn = new Random();
            List<int> candidates = new List<int>();
            
            for (int i = 1; i <= maxInclusive; i++)
            {
                candidates.Add(i);
            }
            while (candidates.Count > 0)
            {
                int index = rdn.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }

        public int[] arrayElements()
        {

            List<int> candidates = new List<int>();
            foreach (int i in createRandomElements(100))
            {
                candidates.Add(i);
            }
            return candidates.ToArray();
        }
        public int[] arrayElements(int maxInclusive)
        {

            List<int> candidates = new List<int>();
            foreach (int i in createRandomElements(maxInclusive))
            {
                candidates.Add(i);
            }
            return candidates.ToArray();
        }

        public List<int> listElements()
        {

            List<int> candidates = new List<int>();
            foreach (int i in createRandomElements(100))
            {
                candidates.Add(i);
            }
            return candidates;
        }

        public List<int> listElements(int maxInclusive)
        {

            List<int> candidates = new List<int>();
            foreach (int i in createRandomElements(maxInclusive))
            {
                candidates.Add(i);
            }
            return candidates;
        }
    }



}
