using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchWeb.Helpers
{
    public class ValidarDocumentosDeIdentidad
    {
        protected string NuDocumento; /* Puede ser RUC o DNI */
        protected string NDni;

        protected bool ValidacionDNI()
        {
            /* Juntamos los 8 digitos con el ultimo digito del DNI*/
            var documento = NuDocumento + NDni;
            Console.WriteLine("Documento : {0}", documento);
            if (!string.IsNullOrEmpty(documento))
            {
                int addition = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int DocIdentidadLength = documento.Length;

                string identificationComponent = documento.Substring(0, DocIdentidadLength - 1);

                int identificationComponentLength = identificationComponent.Length;

                int diff = hash.Length - identificationComponentLength;

                for (int i = identificationComponentLength - 1; i >= 0; i--)
                {
                    addition += (identificationComponent[i] - '0') * hash[i + diff];
                }

                addition = 11 - (addition % 11);

                if (addition == 11)
                {
                    addition = 0;
                }

                char last = char.ToUpperInvariant(documento[DocIdentidadLength - 1]);

                if (DocIdentidadLength == 11)
                {
                    // The identification document corresponds to a RUC.
                    return addition.Equals(last - '0');
                }
                else if (char.IsDigit(last))
                {
                    // The identification document corresponds to a DNI with a number as verification digit.
                    char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                    return last.Equals(hashNumbers[addition]);
                }
                else if (char.IsLetter(last))
                {
                    // The identification document corresponds to a DNI with a letter as verification digit.
                    char[] hashLetters = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                    return last.Equals(hashLetters[addition]);
                }
            }

            return false;
        }

        protected bool ValidacionRuc()
        {
            try
            {
                /* Si ingresaron un caracter que no sea numero  */
                if (NuDocumento.Length != 11) return false;
                int dig01 = Convert.ToInt32(NuDocumento.Substring(0, 1)) * 5;
                int dig02 = Convert.ToInt32(NuDocumento.Substring(1, 1)) * 4;
                int dig03 = Convert.ToInt32(NuDocumento.Substring(2, 1)) * 3;
                int dig04 = Convert.ToInt32(NuDocumento.Substring(3, 1)) * 2;
                int dig05 = Convert.ToInt32(NuDocumento.Substring(4, 1)) * 7;
                int dig06 = Convert.ToInt32(NuDocumento.Substring(5, 1)) * 6;
                int dig07 = Convert.ToInt32(NuDocumento.Substring(6, 1)) * 5;
                int dig08 = Convert.ToInt32(NuDocumento.Substring(7, 1)) * 4;
                int dig09 = Convert.ToInt32(NuDocumento.Substring(8, 1)) * 3;
                int dig10 = Convert.ToInt32(NuDocumento.Substring(9, 1)) * 2;
                int dig11 = Convert.ToInt32(NuDocumento.Substring(10, 1));
                int suma = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10;
                int residuo = suma % 11;
                int resta = 11 - residuo;
                int digChk = 0;
                if (resta == 10) { digChk = 0; }
                else if (resta == 11) { digChk = 1; }
                else { digChk = resta; }
                if (dig11 == digChk)
                { return true; }
                else
                { return false; }
            }
            catch (Exception e)
            {
                /* Sobrescribir el documento invalido */
                NuDocumento = "";
                return false;
            }

        }
    }
}
