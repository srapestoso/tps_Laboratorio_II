using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operacion correspondiente usando los elementos que recibe como parametro
        /// </summary>
        /// <param name="num1">Dato 1 a operar del tipo OPERANDO</param>
        /// <param name="num2">Dato 2 a operar del tipo OPERANDO</param>
        /// <param name="operador">Dato 3 utilizado para realizar la operacion</param>
        /// <returns>Devuelve la operacion realizada</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {   double operacion = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    operacion = num1 + num2;
                    break;
                case '*':
                    operacion = num1 * num2;
                    break;
                case '-':
                    operacion = num1 - num2;
                    break;
                case '/':
                    operacion = num1 / num2;
                    break;
            }
            return operacion;
        }

        /// <summary>
        /// Valida que el CHAR que recibe como parametro sea un operador valido
        /// </summary>
        /// <param name="operador">Dato a verificar que sea válido</param>
        /// <returns>Retorna el operador válidado, caso contrario devolvera '+' como operador valido</returns>
        private static char ValidarOperador(char operador)
        {
            char opValido;
            switch(operador)
            {
                case '+':
                    opValido = operador;
                    break;
                case '-':
                    opValido = operador;
                    break;
                case '/':
                    opValido = operador;
                    break;
                case '*':
                    opValido = operador;
                    break;
                default:
                    opValido = '+';
                        break;
            }
            return opValido;
        }
    }
}
