namespace FuzzyController
{
    /// <summary>
    /// Функции принадлежности множествам
    /// </summary>
    public static class AcessFunc
    {
        /// <summary>
        /// Острый угол
        /// </summary>
        /// <param name="x">Целочисленный аргумент</param>
        /// <returns>Степень принадлежности</returns>
        public static double Acute(int x)
        {
            return 90- x > 0 ? (90.0 - x) / 90 : 0;
        }
        /// <summary>
        /// Прямой угол
        /// </summary>
        /// <param name="x">Целочисленный аргумент</param>
        /// <returns>Степень принадлежности</returns>
        public static double Right(int x)
        {
            if (x >= 45 && x < 90)
                return 1.0 + (x - 90.0) / 45;
            if (x >= 90 && x < 135)
                return 1.0 - (x - 90.0) / 45;
            return 0;
        }
        /// <summary>
        /// Тупой угол
        /// </summary>
        /// <param name="x">Целочисленный аргумент</param>
        /// <returns>Степень принадлежности</returns>
        public static double Obtuse(int x)
        {
            return x - 90 > 0 ? (x - 90.0) / 90 : 0;
        }
        /// <summary>
        /// Повернуть слегка
        /// </summary>
        /// <param name="x">Целочисленный аргумент</param>
        /// <returns>Степень принадлежности</returns>
        public static double Sligthly(int x)
        {
            return 45 - x > 0 ? (45.0 - x) / 45 : 0;
        }
        /// <summary>
        /// Повернуть средне
        /// </summary>
        /// <param name="x">Целочисленный аргумент</param>
        /// <returns>Степень принадлежности</returns>
        public static double Medium(int x)
        {
            if (x >= 22 && x < 45)
                return 1.0 + (x - 45.0) / 22;
            if (x >= 45 && x < 67)
                return 1.0 - (x - 45.0) / 22;
            return 0;
        }
        /// <summary>
        /// Повернуть сильно
        /// </summary>
        /// <param name="x">Целочисленный аргумент</param>
        /// <returns>Степень принадлежности</returns>
        public static double Harsh(int x)
        {
            return x - 45 > 0 ? (x - 45.0) / 45 : 0;
        }
    }
}
