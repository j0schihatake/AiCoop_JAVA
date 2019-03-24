using System.Collections;
using System.Collections.Generic;

namespace J0schiHatake
{
    /// <summary>
    /// Данный класс представляет собой некий результирующий 
    /// набор данных, которые были получены в результате работы N-мерной системы.
    /// </summary>
    public class NIResult
    {
        /// <summary>
        /// Уникальное, смысловое название выходных данных(обычно это результат работы сети).
        /// </summary>
        public string description = "Набор выходных данных(обычно это результат работы сети).";

        /// <summary>
        /// Список выходных нейронов со значениями:
        /// </summary>
        public List<NINeuron> output = new List<NINeuron>();
    }
}
