using System;
using System.Collections.Generic;
using Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk;
using Com.CodeGame.CodeWars2017.DevKit.CSharpCgdk.Model;

/// <summary>
/// Данные обьекты будут представлять собой ссылки на активные группы.
/// Необходимо реализовать очень удобный доступ ко всевозможным функциям и свойствам, 
/// для удобства микроменеджмента.
/// </summary>
public class Squad
{
	public Squad(MyStrategy strategy, int group_index)
	{
        this.strategyClass = strategy;
        this.group_number = group_index;
	}

    //Ссылка на основной класс(для возможности выполнения комманд отсюда)
    public MyStrategy strategyClass = null;

    /// <summary>
    /// Построение отряда:
    /// </summary>
    public squad_formation formation;
    public enum squad_formation {
        line,
        colonna,
        triangle,
    }

    // Текущее состояние группы:
    public squad_state state;
    public enum squad_state {
        wait,
        move,
        in_conflict,
        roundOnTarget,
    }

    //Индивидуальный номер группы
    public int group_number = 0;

    //Общее число юнитов в группе:
    public int all_vechicle_count = 0;

    //Число активных вертолетов в группе:
    public int helecopter = 0;

    //Число активных самолетов в группе:
    public int air_fighter = 0;

    //Число активных БМП в группе:
    public int bmp = 0;

    // Список техники входящей в данный отряд:
    public List<Vehicle> squadVehicleList = new List<Vehicle>();

    /// <summary>
    /// Метод перемещает отряд к указанной позиции. 
    /// По достижении цели переходит в статус wait. Управление за счет номера группы.
    /// </summary>
    /// <param name="next_Position"></param>
    /// <returns></returns>
    public void squad_move(Vector2D next_Position) {
        
    }

}
