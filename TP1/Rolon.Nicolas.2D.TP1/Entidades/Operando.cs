using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto de la clase, inicializa el valor del atributo numero en 0
        /// </summary>
        public Operando(): this(0)
        {            
        }

        /// <summary>
        /// Propiedad de la clase para el atributo numero que a su vez tambien valida el valor ingresado
        /// </summary>
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Valida que lo recibido por párametro sea del tipo númerico.
        /// </summary>
        /// <param name="strNumero">Dato a validar</param>
        /// <returns>Devuelve el dato DOUBLE en caso de que sea númerico sino retorna 0</returns>
        private static double ValidarOperando(string strNumero)
        {
            if(double.TryParse(strNumero, out double dNumero))
            {
                return dNumero;
            }
            return 0;
        }

        /// <summary>
        /// Inicializa el valor con el nro que recibe por parametro
        /// </summary>
        /// <param name="numero">Dato a inicializar</param>
        public Operando(double numero)
        {
            Numero = numero.ToString();
        }

        /// <summary>
        /// Inicializa el valor del dato que recibe como parametro
        /// </summary>
        /// <param name="strNumero">Dato a inicializar</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }
        /// <summary>
        /// Operador de resta
        /// </summary>
        /// <param name="n1">Dato numerico 1 del tipo OPERANDO</param>
        /// <param name="n2">Dato numerico 2 del tipo OPERANDO</param>
        /// <returns>Devuelve la resta de los 2 operandos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Operador de suma
        /// </summary>
        /// <param name="n1">Dato numerico 1 del tipo OPERANDO</param>
        /// <param name="n2">Dato numerico 2 del tipo OPERANDO</param>
        /// <returns>Devuelve la suma entre los 2 operandos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Operador de division
        /// </summary>
        /// <param name="n1">Dato numerico 1 del tipo OPERANDO</param>
        /// <param name="n2">Dato numerico 2 del tipo OPERANDO</param>
        /// <returns>Devuelve la division entre los 2 operandos siempre y cuando el dato numerico 2 no sea 0, de ser asi devuelve un DOUBLE.MINVALUE</returns>
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
        /// <summary>
        /// Operador de multiplicacion
        /// </summary>
        /// <param name="n1">Dato numerico 1 del tipo OPERANDO</param>
        /// <param name="n2">Dato numerico 2 del tipo OPERANDO</param>
        /// <returns>Devuelve la multiplicacion entre los 2 operandos</returns>
        public static double operator *(Operando n1 , Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Convierte el STRING que recibe como parametro en otro STRING
        /// </summary>
        /// <param name="numero">Dato a convertir</param>
        /// <returns>Devuelve el STRING convertido a BINARIO de no ser posible devuelve "Valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            string binario = "Valor invalido";
            double numeroD = double.Parse(numero);         
            binario = DecimalBinario(numeroD);
            return binario;

        }

        /// <summary>
        /// Convierte el DOUBLE que recibe como parametro en un STRING binario
        /// </summary>
        /// <param name="numero">Dato a convertir</param>
        /// <returns>Retorna el equivalente a binario en STRING de ser posible, sino devuelve "Valor invalido"</returns>
        public static string DecimalBinario(double numero)
        {
            string decimalConvertido = "";
            int numeroAbs = (int)Math.Abs(numero);
            int residuo;

            if(numeroAbs >= 0)
            {
                do
                {
                    residuo = numeroAbs % 2;
                    numeroAbs = numeroAbs / 2;
                    decimalConvertido = residuo + decimalConvertido;

                } while (numeroAbs > 0);
            }
            else
            {
                decimalConvertido = "Valor Invalido";
            }
            return decimalConvertido; 
        }

        /// <summary>
        /// Convierte el DOUBLE que recibe como parametro en un STRING
        /// </summary>
        /// <param name="numeroB">Dato a convertir</param>
        /// <returns>Devuelve el valor convertido a DECIMAL en STRING caso contrario "Valor Invalido" si no pudo realizar la conversion</returns>
        public static string BinarioDecimal(string numeroB)
        {
            string decimalConvertido = "Valor inválido";
            int cantNumeros = numeroB.Length;
            double numeroD = 0;
            if(EsBinario(numeroB))
            {
                foreach(char n in numeroB)
                {
                    cantNumeros--;
                    if(n == '1')
                    {
                        numeroD = numeroD + Math.Pow(2, cantNumeros);
                    }
                }
                decimalConvertido = numeroD.ToString();
            }            
            return decimalConvertido;
        }



        
        /// <summary>
        /// Valida que el STRING que recibe sea un numero binario
        /// </summary>
        /// <param name="binario">Dato a validar</param>
        /// <returns>Retorna TRUE si se trata de un numero BINARIO, caso contrario devuelve FALSE</returns>
        private static bool EsBinario(string binario)
        {
            bool esBinario = true;
            foreach(char i in binario)
            {
                if(i!= '0' && i!= '1')
                {
                    esBinario = false;
                    break;
                }
            }
            return esBinario;
        }
    }
}
