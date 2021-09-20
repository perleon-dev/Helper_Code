using Billing.Api.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilitario
{
    public class Utilitario
    {

        //Redondeo numero mayor
        public static decimal Round(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
	
	    // Valida numeros enteros	
	    public static bool ValidateNumber(dynamic number) 
        {
            bool validate = false;
            int number_;
            if (number != null) 
            {
                if (!int.TryParse(number.ToString(), out number_))
                {
                    validate = false;
                }
                else
                {
                    int num = Int32.Parse(number.ToString());
                    if (num >= 0)
                        validate = true;
                    else
                        validate = false;
                }

            }
            else
                validate = false;

            return validate;
        }
	
	    // Valida numeros decimales
	    public static bool ValidateDecimal(dynamic number)
        {
            bool validate = false;
            decimal number_;
            if (number != null)
            {
                if (!decimal.TryParse(number.ToString(), out number_))
                {
                    validate = false;
                }
                else
                {
                    decimal num = decimal.Parse(number.ToString());
                    if (num >= 0)
                        validate = true;
                    else
                        validate = false;
                }

            }
            else
                validate = false;

            return validate;
        }
    }
}
