using System.Collections;
using System.Collections.Generic;

namespace J0schiHatake
{
    /// <summary>
    /// NINeuron - нейрон. Представляет собой входной, выходной или скрытый кластер информации.
    /// </summary>
    public class NINeuron
    {

        /// <summary>
        /// Тип информации которую подразумевает под собой нейрон.
        /// </summary>
        public type_Info type;
        public enum type_Info
        {
            /// <summary>
            /// Тип данного нейрона "Целочисленный"
            /// </summary>
            int_,

            /// <summary>
            /// Тип данного нейрона "Число с плавающей точкой"
            /// </summary>
            float_,

            /// <summary>
            /// Тип данного нейрона "Булевый"
            /// </summary>
            bool_,
        }

        /// <summary>
        /// Понятное пояснение что обозначает данный нейрон.
        /// </summary>
        public string description = "Новый нейрон";

        /// <summary>
        ///  В случае если данный нейрон несет в себе "целочисленный" смысл, хранит текущее значение.
        /// </summary>
        public int intCount = 0;

        /// <summary>
        /// В случае если данный нейрон несет в себе смысл "числа с плавающей точкой", хранит текущее значение.
        /// </summary>
        public float floatCount = 0.0f;

        /// <summary>
        /// В случае если данный нейрон несет в себе "булевый" смысл, хранит текущее значение. 
        /// </summary>
        public bool boolCount = false;
    }
}
