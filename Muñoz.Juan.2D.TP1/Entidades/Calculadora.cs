using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida, tanto número como operador, y realiza la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1">Primer operando,</param>
        /// <param name="num2">Segundo operando.</param>
        /// <param name="operador">Operador.</param>
        /// <returns>La operación pedida entre el primer y el segundo operando.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case '-':
                    return num1 - num2;

                case '*':
                    return num1 * num2;

                case '/':
                    return num1 / num2;

                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// Valida que el operador recibido sea "+", "-", "/" o "*". Caso contrario, retorna "+".
        /// </summary>
        /// <param name="operador">Char a ser validado.</param>
        /// <returns>El operador recibido, en caso de que sea "+", "-", "/" o "*". De lo contrario, retorna "+"</returns>
        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '-':
                    return operador;

                case '*':
                    return operador;

                case '/':
                    return operador;

                default:
                    return '+';
            }
        }
    }
}
