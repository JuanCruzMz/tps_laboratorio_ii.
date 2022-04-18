using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;


        /// <summary>
        /// Asigna un valor al atributo "numero", previa validación.
        /// </summary>
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }


        public Operando()
        {
            numero = 0;
        }

        public Operando(string strNumero) : this()
        {
            Numero = strNumero;
        }

        public Operando(double numero) : this(numero.ToString())
        {
            
        }


        /// <summary>
        /// comprueba que el valor recibido sea numérico, y lo retorna en formato "double". Caso contrario, retorna "0".
        /// </summary>
        /// <param name="strNumero">Cadena a ser validada y convertida.</param>
        /// <returns>La cadena recibida, en caso de que se haya podido realizar la conversión. Caso contrario, retorna "0".</returns>
        private static double ValidarOperando(string strNumero)
        {
            double strNumeroConvertidoADouble;

            if (double.TryParse(strNumero, out strNumeroConvertidoADouble))
            {
                return strNumeroConvertidoADouble;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// Valida que la cadena recibida esté compuesta solamente por los caracteres "0" o "1".
        /// </summary>
        /// <param name="binario">Cadena a ser validada como binario.</param>
        /// <returns>"true" si la cadena recibida está compuesta solamente por los caracteres "0" o "1". Caso contrario, retorna "false".</returns>
        private static bool EsBinario(string binario)
        {
            foreach (var item in binario)
            {
                if (item != '0' && item != '1')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Valida que la cadena recibida se trate de un binario y convierte ese número binario a decimal, en caso de ser posible. Caso contrario, retorna "Valor inválido".
        /// </summary>
        /// <param name="binario">Cadena a ser validada y convertida.</param>
        /// <returns>La cadena recibida como número decimal, en caso de haber podido realizar la conversión. Caso contrario, retorna "Valor inválido".</returns>
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int potencia = 0;

                double binarioConvertidoADecimal = 0;


                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        binarioConvertidoADecimal += Math.Pow(2, potencia);
                    }

                    potencia++;
                }

                return binarioConvertidoADecimal.ToString();
            }
            else
            {
                return "Valor inválido.";
            }
        }

        /// <summary>
        /// Convierte un número decimal a su equivalente binario.
        /// </summary>
        /// <param name="numero">Número a ser convertido.</param>
        /// <returns>El número recibido como binario.</returns>
        public static string DecimalBinario(double numero)
        {
            double resto = 0;
            string numeroConvertidoABinario = string.Empty;

            numero = Math.Abs(numero);
            numero = Math.Truncate(numero);

            while (numero > 0)
            {
                resto = numero % 2;

                numero /= 2;
                numero = Math.Truncate(numero);

                numeroConvertidoABinario = resto.ToString() + numeroConvertidoABinario;
            }

            return numeroConvertidoABinario;
        }

        /// <summary>
        /// Valida que la cadena recibida se trate de un número y convierte ese número decimal a binario, en caso de ser posible. Caso contrario retornará "Valor inválido".
        /// </summary>
        /// </summary>
        /// <param name="numero">Cadena a ser validada y convertida.</param>
        /// <returns>La cadena recibida como número binario, en caso de haber podido realizar la conversión. Caso contrario retorna "Valor inválido".</returns>
        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double numeroConvertidoADouble))
            {
                return DecimalBinario(numeroConvertidoADouble);
            }
            else
            {
                return "Valor inválido.";
            }
        }


        /// <summary>
        /// Realiza una suma entre los atributos "numero" de dos objetos de tipo "Operando".
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>La suma entre el primer y el segundo operando.</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza una resta entre los atributos "numero" de dos objetos de tipo "Operando".
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>La diferencia entre el primer y el segundo operando.</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza una multiplicación entre los atributos "numero" de dos objetos de tipo "Operando".
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>El producto entre el primer y el segundo operando.</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza una división entre los atributos "numero" de dos objetos de tipo "Operando".
        /// </summary>
        /// <param name="n1">Primer operando.</param>
        /// <param name="n2">Segundo operando.</param>
        /// <returns>El cociente entre el primer y el segundo operando, en caso de que el segundo operando no sea un cero. Caso contrario, retorna "double.MinValue".</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
