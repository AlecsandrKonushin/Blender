using System.Collections.Generic;
using UnityEngine;

public class ManagerObjects : Singleton<ManagerObjects>
{
    private List<Fruit> fruits = new List<Fruit>();
    private List<Damager> damagers = new List<Damager>();

    public void AddFruit(Fruit fruit)
    {
        fruits.Add(fruit);
    }

    public void AddDamager(Damager damager)
    {
        damagers.Add(damager);
    }

    /// <summary>
    /// Останавливает движение Fruit на время паузы
    /// </summary>
    public void StopFallObjects()
    {
        if(fruits.Count > 0)
        {
            foreach (var fruit in fruits)
            {
                fruit.StopObject();
            }
        }

        if (damagers.Count > 0)
        {
            foreach (var damager in damagers)
            {
                damager.StopObject();
            }
        }
    }

    public void GoFruits()
    {
        if(fruits.Count > 0)
        {
            foreach (var fruit in fruits)
            {
                fruit.GoObject();
            }
        }

        if (damagers.Count > 0)
        {
            foreach (var damager in damagers)
            {
                damager.GoObject();
            }
        }
    }

    /// <summary>
    /// Удалить из списка и уничтожить Fruit
    /// </summary>
    /// <param name="fruit"></param>
    public void DestroyFruit(Fruit fruit)
    {
        fruits.Remove(fruit);
        fruit.DestoyMe();
    }

    public void DestroyDamager(Damager damager)
    {
        damagers.Remove(damager);
        damager.DestoyMe();
    }

    /// <summary>
    /// Уничтожить Fruit после завершение уровня
    /// </summary>
    public void DestroyAllObjects()
    {
        if(fruits.Count > 0)
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                Fruit fruit = fruits[i];
                fruits[i] = null;
                fruit.DestoyMe();
            }
        }

        fruits.Clear();

        if (damagers.Count > 0)
        {
            for (int i = 0; i < damagers.Count; i++)
            {
                Damager damager = damagers[i];
                damagers[i] = null;
                damager.DestoyMe();
            }
        }

        damagers.Clear();
    }
}
