using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : Singleton<ManagerLevel>
{
    [SerializeField] private DataLevel[] levels;

    private DataRecipe currentRecipe;
    private int currentNumberLevel = 0;
    private DataNeedFruit dataNeedFruit;

    /// <summary>
    /// Init Следующего level
    /// </summary>
    public void NextLevel()
    {
        StartRecipe();
        SetSpawnData();
    }

    private void StartRecipe()
    {
        dataNeedFruit = null;
        List<DataPartNeedFruit> partsNeed = new List<DataPartNeedFruit>();

        currentRecipe = levels[currentNumberLevel].DataRecipe;

        foreach (var partRecipe in currentRecipe.PartsRecipe)
        {
            DataPartNeedFruit dataPart = new DataPartNeedFruit(partRecipe.TypeFruit, partRecipe.CountFruit);
            partsNeed.Add(dataPart);
        }

        dataNeedFruit = new DataNeedFruit(partsNeed);

        ShowRecipe();
    }

    private void SetSpawnData()
    {
        ManagerSpawner.Instance.SetDataSpawn(levels[currentNumberLevel].DataSpawnObjects);
    }

    /// <summary>
    /// Проверка Fruit, который попал в блендер, подходит ли он в часть рецепта
    /// </summary>
    /// <param name="fruit"></param>
    public void CheckFruit(Fruit fruit)
    {
        dataNeedFruit.ReduceFruit(fruit.GetTypeFruit);

        ShowRecipe();

        if (!dataNeedFruit.CheckHaveNeedFruit())
        {
            RecipeCollected();
        }
    }

    private void ShowRecipe()
    {
        ManagerCanvaces.Instance.ShowRecipe(dataNeedFruit);
    }

    private void RecipeCollected()
    {
        ManagerCanvaces.Instance.ShowWinLevel();
        currentNumberLevel++;
        ManagerMain.Instance.LevelWin();
    }

    public void CheckDamager(Damager damager)
    {
        if (damager.GetTypeDamager == TypeDamager.Tree)
        {
            ManagerMain.Instance.LevelLose();
        }
        else if (damager.GetTypeDamager == TypeDamager.Ice)
        {
            ManagerFreeze.Instance.FreezeBlender();
        }
    }
}
