using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentOne.classes
{
    public class validations
    {
        public bool intValidation(String valueToText)
        {

            int convertResult;
            int.TryParse(valueToText, out convertResult);
            if (convertResult == 0)
            {
                if (valueToText == convertResult.ToString())
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
    }
}
