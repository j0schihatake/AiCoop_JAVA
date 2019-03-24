using System;
using System.Collections.Generic;
using Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk.Model;

namespace J0schiHatake
{
    /// <summary>
    /// Итак данный класс будет подразделять мировое пространство на более мелкие 
    /// участки для удобства распознования.
    /// </summary>
    public class Map
    {

        /// <summary>
        /// Список всех секторов карты(именно с ним будет работать глобальный стратег):
        /// </summary>
        public List<Sector> allSector = new List<Sector>();
    }
}
