using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyController
{
    /// <summary>
    /// Пусть даны угол между направлением корабля и направлением на
    /// астероид - α, и угол между направлением на астероид и
    /// направлением движения астероида - β (от 0 до 180 градусов)
    /// Тогда контроллер вычисляет значение угла, на которое должен отклониться корабль (от 0 до 90 градусов)
    /// </summary>
    class Controller
    {
        /// <summary>
        /// Количество входных нечетких множеств
        /// </summary>
        public int inSetsCount = 3;
        /// <summary>
        /// Количество правил
        /// </summary>
        public int rulesCount = 3;
        /// <summary>
        /// Соответствие между входными нечеткими множествами и их функциями принадлежности
        /// </summary>
        Dictionary<InSets, FuncAsses> inSetMap = new Dictionary<InSets, FuncAsses> { { InSets.Acute, AcessFunc.Acute }, { InSets.Obtuse, AcessFunc.Obtuse }, { InSets.Right, AcessFunc.Right } };
        /// <summary>
        /// Соответствие между выходными нечеткими множествами и их функциями принадлежности
        /// </summary>
        Dictionary<OutSets, FuncAsses> outSetMap = new Dictionary<OutSets, FuncAsses> { { OutSets.Slightly, AcessFunc.Sligthly }, { OutSets.Medium, AcessFunc.Medium }, { OutSets.Harsh, AcessFunc.Harsh } };
        /// <summary>
        /// Степени принадлежности величины альфа каждому входному нечеткому множеству
        /// </summary>
        private double[] inAlphaValues;
        /// <summary>
        /// Степени принадлежности величины бета каждому входному нечеткому множеству
        /// </summary>
        private double[] inBetaValues;
        /// <summary>
        /// Степени активации
        /// </summary>
        private double[] rulesValues;
        /// <summary>
        /// Получение степеней принадлежности входной величины
        /// </summary>
        /// <param name="x">Входная величина</param>
        /// <returns>Массив степеней принадлежности, где индекс соответствует номеру множества в перечислении входных множеств</returns>
        private double[] FillInValues(int x)
        {
            double[] vals = new double[inSetsCount];
            foreach (InSets set in Enum.GetValues(typeof(InSets)))
                vals[(int)set] = inSetMap[set](x);
            return vals;
        }
        /// <summary>
        /// Запускает работу контроллера
        /// </summary>
        /// <param name="x">Угол между направлением корабля и направлением на астероид</param>
        /// <param name="y">угол между направлением на астероид и направлением движения астероида</param>
        /// <returns>Угол отклонения</returns>
        public int Start(int x, int y)
        {

            inAlphaValues = FillInValues(x);
            inBetaValues = FillInValues(y);
            rulesValues = CountValues();
            return (int)GetRes(0, 90);
        }
        /// <summary>
        /// Вычисляет степени активации по правилам
        /// </summary>
        /// <returns>Массив степеней активации правила, где индекс соответствует номеру множества в перечислении выходных множеств</returns>
        private double[] CountValues()
        {
            double[] vals = new double[rulesCount];
            vals[(int)OutSets.Slightly] = TNorms.TIntersect(TNorms.TUnion(inAlphaValues[(int)InSets.Obtuse], inAlphaValues[(int)InSets.Right]), TNorms.TUnion(inBetaValues[(int)InSets.Obtuse], inBetaValues[(int)InSets.Right]));
            vals[(int)OutSets.Medium] = TNorms.TUnion(TNorms.TIntersect(TNorms.TUnion(inBetaValues[(int)InSets.Obtuse], inBetaValues[(int)InSets.Right]), inAlphaValues[(int)InSets.Acute]), TNorms.TIntersect(TNorms.TUnion(inAlphaValues[(int)InSets.Obtuse], inAlphaValues[(int)InSets.Right]), inBetaValues[(int)InSets.Acute]));
            vals[(int)OutSets.Harsh] = TNorms.TIntersect(inAlphaValues[(int)InSets.Acute], inBetaValues[(int)InSets.Acute]);
            return vals;
        }
        /// <summary>
        /// Вычисляя выходы отдельных правил, аккумулируя результат и дефаззицифируя его (метод центра тяжести для дискретного случая), вычисляет угол отклонения
        /// </summary>
        /// <param name="a">Левая граница изменения угла отклонения</param>
        /// <param name="b">Правая граница изменения угла отклонения</param>
        /// <returns>Угол отклонения</returns>
        private double GetRes(int a, int b)
        {
            double res = 0, div = 0;
            for (int i = a; i <= b; i++)
            {
                double val = TNorms.TUnion(TNorms.TIntersect(rulesValues[(int)OutSets.Slightly], outSetMap[OutSets.Slightly](i)), TNorms.TIntersect(rulesValues[(int)OutSets.Medium], outSetMap[OutSets.Medium](i)), TNorms.TIntersect(rulesValues[(int)OutSets.Harsh], outSetMap[OutSets.Harsh](i)));
                div += val;
                res += i * val;
            }
            return res / div;
        }
    }
}
