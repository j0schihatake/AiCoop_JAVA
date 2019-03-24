using System.Collections;
using System.Collections.Generic;

namespace J0schiHatake
{
    /// <summary>
    /// NISample - пример входной набор данных + заданный(известный) результат.
    /// </summary>
    public class NISample
    {
        /// <summary>
        /// Уникальное, смысловое название набора входных + заданных выходных данных(пример).
        /// </summary>
        public string description = "Набор входных данных + заданных выходных данных(пример).";

        /// <summary>
        /// Список входных нейронов со значениями:
        /// </summary>
        public List<NINeuron> input = new List<NINeuron>();

        /// <summary>
        /// Список выходных нейронов со значениями:
        /// </summary>
        public List<NINeuron> output = new List<NINeuron>();
    }
}
