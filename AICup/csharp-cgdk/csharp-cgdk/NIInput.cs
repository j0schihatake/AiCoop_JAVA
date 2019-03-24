using System.Collections;
using System.Collections.Generic;

namespace J0schiHatake
{
    /// <summary>
    /// NIInput - данный обьект формирует некоторый набор входных данных.
    /// </summary>
    public class NIInput
    {
        /// <summary>
        /// Уникальное, смысловое название набора входных данных(input).
        /// </summary>
        public string description = "Набор входных данных.";

        /// <summary>
        /// Список входных нейронов со значениями:
        /// </summary>
        public List<NINeuron> input = new List<NINeuron>();
    }
}
