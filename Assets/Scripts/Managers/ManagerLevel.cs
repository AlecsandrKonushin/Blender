﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : Singleton<ManagerLevel>
{
    [SerializeField] private DataLevel[] levels;
    [SerializeField] private int currentNumberLevel = 0;

    private DataRecipe currentRecipe;
    private DataNeedFruit dataNeedFruit;

    private float timeWaitNameLevel = 1.5f;

    public int SetCurrentNumberLevel { set => currentNumberLevel = value; }

    private bool canCheckFruit = true;
    public bool SetCanCheckFruit { set => canCheckFruit = value; }

    /// <summary>
    /// Init Следующего level
    /// </summary>
    public void NextLevel()
    {
        ManagerTutorial.Instance.CheckLevel(currentNumberLevel);
        ManagerCanvaces.Instance.ShowLevelText(currentNumberLevel + 1);
        StartCoroutine(CoWaitShowNameLevel());
    }

    private IEnumerator CoWaitShowNameLevel()
    {
        yield return new WaitForSeconds(timeWaitNameLevel);

        ManagerTime.Instance.StartNextLevel(levels[currentNumberLevel].TimeLevel);
        ManagerAudio.Instance.PlayMusicLevel();

        StartRecipe();
        SetSpawnData();

        ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
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
        CheckDragLevel(levels[currentNumberLevel]);
        ManagerSpawner.Instance.SetDataSpawn(levels[currentNumberLevel]);
    }

    private void CheckDragLevel(DataLevel level)
    {
        foreach (var spawnObject in level.DataSpawnObjects.DataSpawn)
        {
            if (spawnObject.DragObject == 0)
            {
                if (spawnObject.TypeObject == TypeObject.Damager)
                {
                    DataSpawnDamager spawnDamager = spawnObject as DataSpawnDamager;

                    if (spawnDamager.TypeDamager == TypeDamager.Ice)
                    {
                        spawnDamager.DragObject = 2f;
                    }
                    else if (spawnDamager.TypeDamager == TypeDamager.Tree)
                    {
                        spawnObject.DragObject = 3f;
                    }
                }
                else
                {
                    spawnObject.DragObject = 2;
                }
            }
        }
    }

    /// <summary>
    /// Проверка Fruit, который попал в блендер, подходит ли он в часть рецепта
    /// </summary>
    /// <param name="fruit"></param>
    public void CheckFruit(Fruit fruit)
    {
        if (canCheckFruit)
        {
            dataNeedFruit.ReduceFruit(fruit.GetTypeFruit);

            ShowRecipe();

            if (!dataNeedFruit.CheckHaveNeedFruit())
            {
                RecipeCollected();
            }
        }
    }

    public void ShowRecipe()
    {
        ManagerCanvaces.Instance.ShowRecipe(dataNeedFruit);
    }

    private void RecipeCollected()
    {
        ManagerCanvaces.Instance.ShowWinLevel();
        currentNumberLevel++;

        if (currentNumberLevel >= levels.Length)
        {
            ManagerMain.Instance.EndLevels();
        }
        else
        {
            ManagerSaveLoad.Instance.SaveLevel(currentNumberLevel);

            ManagerMain.Instance.LevelWin();
        }
    }

    public void CheckDamager(Damager damager)
    {
        if (damager.GetTypeDamager == TypeDamager.Tree)
        {
            ManagerMain.Instance.LevelLose(TypeLoseLevel.DamagerTree);
        }
        else if (damager.GetTypeDamager == TypeDamager.Ice)
        {
            ManagerFreeze.Instance.FreezeBlender();
        }
    }
}
