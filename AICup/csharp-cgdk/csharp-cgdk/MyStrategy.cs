using Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk.Model;
using System;
using System.Threading;
using System.Collections.Generic;
using J0schiHatake;

namespace Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk {
    public sealed class MyStrategy : IStrategy {

        //Карты территориальных и погодных преимуществ:
        private TerrainType[][] terrainTypeByCellXY;
        private WeatherType[][] weatherTypeByCellXY;

        public Player me;
        public World world;
        public Game game;
        public Move move;

        // Итак vechicleByID - мапа id/ техника для получения всей техники на карте. 
        private Dictionary<long, Vehicle> vehicleById = new Dictionary<long, Vehicle>();
        private Dictionary<long, int> updateTickByVehicleId = new Dictionary<long, int>();

        //Обычные индесированные списки техники:
        private List<Vehicle> allVechileList = new List<Vehicle>();

        //----------------------------ссылки на Инструменты:
        public Map map = null;

        // Итак запуск самой стратегии, грубо говоря Unity3D.Update():
        public void Move(Player me, World world, Game game, Move move) {

            // Выполняем инициализацию(один раз на старте :) Unity3D.Start()):
            if (world.TickIndex == 0)
            {
                initializeStrategy(world, game);
                //move.Action = ActionType.ClearAndSelect;
                //move.Right = 200;
                //move.Bottom = 200;
                return;
            }

            // Обновляем информацию за текущий тик:
            initializeTick(me, world, game, move);

            start_sansbox();

            if (world.TickIndex == 3)
            {
                //Теперь отправляем .юнитов из текущего выделения на врага:
                move.Action = ActionType.Move;
                move.X = world.Width / 2.0D;
                move.Y = world.Height / 2.0D;
            }

            // Проверяем возможны ли действия в текущий тик:
            if (me.RemainingActionCooldownTicks > 0)
            {
                return;
            }

            //move();
        }

        /**
        * Инциализируем стратегию.
        * Тут буду поднимать наших "полководцев", и учить их уму разуму,
        * соответственно сдесь же выполняются все первые подготовительные настройки.
        */
        private void initializeStrategy(World world, Game game)
        {
            //Получаем сведения об участках с преимуществами и недостатками:
            terrainTypeByCellXY = world.TerrainByCellXY;
            weatherTypeByCellXY = world.WeatherByCellXY;

            //Итак, кто будет принимать участие при анализе боевых действий, конечно коммитет CW
            /*
             * В составе коммитета:
             * */
            officer_Start();
        }

        /**
        * Сохраняем все входные данные в полях класса для упрощения доступа к ним, а также актуализируем сведения о каждой
        * технике и времени последнего изменения её состояния.
        */
        private void initializeTick(Player me, World world, Game game, Move move)
        {
            this.me = me;
            this.world = world;
            this.game = game;
            this.move = move;

            //Получаем всю "Новую" или "Обнаруженную технику"
            foreach (Vehicle vehicle in world.NewVehicles)
            {
                vehicleById.Add(vehicle.Id, vehicle);
                updateTickByVehicleId.Add(vehicle.Id, world.TickIndex);
            }

            //Обновляем все изменения в каждой еденице техники(произошедшие с последнего тика)
            foreach (VehicleUpdate vehicleUpdate in world.VehicleUpdates)
            {
                long vehicleId = vehicleUpdate.Id;

                //Если Прочность текущей техники равна 0:
                if (vehicleUpdate.Durability == 0)
                {
                    vehicleById.Remove(vehicleId);
                    updateTickByVehicleId.Remove(vehicleId);
                }
                else
                {
                    if (vehicleById.ContainsKey(vehicleId)) {
                        vehicleById[vehicleId] = new Vehicle(vehicleById[vehicleId], vehicleUpdate);
                    }
                    if (updateTickByVehicleId.ContainsKey(vehicleId)) {
                        updateTickByVehicleId[vehicleId] = world.TickIndex;
                    }
                }
            }
            return;
        }

        /// <summary>
        /// Создание офицеров(узконаправленные нейронные сети):
        /// </summary>
        void officer_Start() {
        }

        /// <summary>
        /// Место для экспериментов:
        /// </summary>
        void start_sansbox() {

            //Переменная для подсчета отобранных:
            int selectedCount = 0;

            //Squad squad_0 = new Squad(this);

            //итак формирую отряд из вертолетовпопутно ищу значения для выделения:
            for (int i = 0; i < allVechileList.Count; i++) {
                Vehicle selected = allVechileList[i];
                if (selectedCount < 1000 & selected.Type == VehicleType.Helicopter) {
                    //squad_0.squadVehicleList.Add(selected);
                    selectedCount += 1;
                    if (i == 0)
                    {
                        selectUnit(selected, 0);
                    }
                    else {
                        selectUnit(selected, 1);
                    }
                }
            }
        }

        //Метод выполняет "выделение" указаного Unit-а(0 - CLEAR_AND_DESELECT, 1 - ADD_TO_SELECTION)
        void selectUnit(Vehicle vehicle, int select_type) {
            switch (select_type) {
                //Очищаем предыдущее и выполняем новое выделение:
                case 0:
                    move.Action = ActionType.ClearAndSelect;
                    move.Right = vehicle.X-1;
                    move.Bottom = vehicle.Y+1;
                    break;
                //Выделяем и добавляем новый юнит к текущим выделенным:
                case 1:
                    move.Action = ActionType.AddToSelection;
                    move.Right = vehicle.X-1;
                    move.Bottom = vehicle.Y+1;
                    break;
            }
        }
    }
}
