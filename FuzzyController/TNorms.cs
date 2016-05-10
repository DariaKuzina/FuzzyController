using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyController
{
    /// <summary>
    /// Предоставляет функции T норм
    /// </summary>
    public static class TNorms
    {
       
        /// <summary>
        /// Максимум из двух элементов
        /// </summary>
        /// <param name="a">Первое вещественное число</param>
        /// <param name="b">Второе вещественное число</param>
        /// <returns>Максимум</returns>
        private static double Max(double a, double b)
        {
            return a > b ? a : b;
        }
        /// <summary>
        /// Минимум из двух элементов
        /// </summary>
        /// <param name="a">Первое вещественное число</param>
        /// <param name="b">Второе вещественное число</param>
        /// <returns>Минимум</returns>
        private static double Min(double a, double b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// T-норма для объединения - максимум
        /// </summary>
        ///<param name="values">Значения функция принадлежности</param>
        /// <returns>Максимум из значений функций принадлежности</returns>
        public static double TUnion(params double[]values)
        {
            double max = values[0];
            for (int i = 1; i < values.Length; i++)
                max = Max(max, values[i]);
            return max;
        }
        /// <summary>
        /// T-норма для пересечения - минимум
        /// </summary>
        ///<param name="values">Значения функция принадлежности</param>
        /// <returns>Минимум из значений функций принадлежности</returns>
        public static double TIntersect(params double[] values)
        {
            double min = values[0];
            for (int i = 1; i < values.Length; i++)
                min = Min(min, values[i]);
            return min;
        }
        /// <summary>
        /// T-норма для импликации - минимкм
        /// </summary>
        ///<param name="values">Значения функция принадлежности</param>
        /// <returns>Минимум из значений функций принадлежности</returns>
        public static double TImplication(params double[] values)
        {
            double min = values[0];
            for (int i = 1; i < values.Length; i++)
                min = Min(min, values[i]);
            return min;
        }
    }
}
