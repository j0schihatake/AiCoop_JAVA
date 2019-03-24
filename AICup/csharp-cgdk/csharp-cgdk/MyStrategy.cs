using Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk.Model;
using System;
using System.Threading;
using System.Collections.Generic;
using J0schiHatake;

namespace Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk {
    public sealed class MyStrategy : IStrategy {

        //����� ��������������� � �������� �����������:
        private TerrainType[][] terrainTypeByCellXY;
        private WeatherType[][] weatherTypeByCellXY;

        public Player me;
        public World world;
        public Game game;
        public Move move;

        // ���� vechicleByID - ���� id/ ������� ��� ��������� ���� ������� �� �����. 
        private Dictionary<long, Vehicle> vehicleById = new Dictionary<long, Vehicle>();
        private Dictionary<long, int> updateTickByVehicleId = new Dictionary<long, int>();

        //������� �������������� ������ �������:
        private List<Vehicle> allVechileList = new List<Vehicle>();

        //----------------------------������ �� �����������:
        public Map map = null;

        // ���� ������ ����� ���������, ����� ������ Unity3D.Update():
        public void Move(Player me, World world, Game game, Move move) {

            // ��������� �������������(���� ��� �� ������ :) Unity3D.Start()):
            if (world.TickIndex == 0)
            {
                initializeStrategy(world, game);
                //move.Action = ActionType.ClearAndSelect;
                //move.Right = 200;
                //move.Bottom = 200;
                return;
            }

            // ��������� ���������� �� ������� ���:
            initializeTick(me, world, game, move);

            start_sansbox();

            if (world.TickIndex == 3)
            {
                //������ ���������� .������ �� �������� ��������� �� �����:
                move.Action = ActionType.Move;
                move.X = world.Width / 2.0D;
                move.Y = world.Height / 2.0D;
            }

            // ��������� �������� �� �������� � ������� ���:
            if (me.RemainingActionCooldownTicks > 0)
            {
                return;
            }

            //move();
        }

        /**
        * ������������� ���������.
        * ��� ���� ��������� ����� "�����������", � ����� �� ��� ������,
        * �������������� ����� �� ����������� ��� ������ ���������������� ���������.
        */
        private void initializeStrategy(World world, Game game)
        {
            //�������� �������� �� �������� � �������������� � ������������:
            terrainTypeByCellXY = world.TerrainByCellXY;
            weatherTypeByCellXY = world.WeatherByCellXY;

            //����, ��� ����� ��������� ������� ��� ������� ������ ��������, ������� �������� CW
            /*
             * � ������� ���������:
             * */
            officer_Start();
        }

        /**
        * ��������� ��� ������� ������ � ����� ������ ��� ��������� ������� � ���, � ����� ������������� �������� � ������
        * ������� � ������� ���������� ��������� � ���������.
        */
        private void initializeTick(Player me, World world, Game game, Move move)
        {
            this.me = me;
            this.world = world;
            this.game = game;
            this.move = move;

            //�������� ��� "�����" ��� "������������ �������"
            foreach (Vehicle vehicle in world.NewVehicles)
            {
                vehicleById.Add(vehicle.Id, vehicle);
                updateTickByVehicleId.Add(vehicle.Id, world.TickIndex);
            }

            //��������� ��� ��������� � ������ ������� �������(������������ � ���������� ����)
            foreach (VehicleUpdate vehicleUpdate in world.VehicleUpdates)
            {
                long vehicleId = vehicleUpdate.Id;

                //���� ��������� ������� ������� ����� 0:
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
        /// �������� ��������(���������������� ��������� ����):
        /// </summary>
        void officer_Start() {
        }

        /// <summary>
        /// ����� ��� �������������:
        /// </summary>
        void start_sansbox() {

            //���������� ��� �������� ����������:
            int selectedCount = 0;

            //Squad squad_0 = new Squad(this);

            //���� �������� ����� �� ����������������� ��� �������� ��� ���������:
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

        //����� ��������� "���������" ��������� Unit-�(0 - CLEAR_AND_DESELECT, 1 - ADD_TO_SELECTION)
        void selectUnit(Vehicle vehicle, int select_type) {
            switch (select_type) {
                //������� ���������� � ��������� ����� ���������:
                case 0:
                    move.Action = ActionType.ClearAndSelect;
                    move.Right = vehicle.X-1;
                    move.Bottom = vehicle.Y+1;
                    break;
                //�������� � ��������� ����� ���� � ������� ����������:
                case 1:
                    move.Action = ActionType.AddToSelection;
                    move.Right = vehicle.X-1;
                    move.Bottom = vehicle.Y+1;
                    break;
            }
        }
    }
}
