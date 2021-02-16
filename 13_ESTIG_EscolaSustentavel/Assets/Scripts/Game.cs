﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Timers;
using Database;
using Database.Model;
using Mono.Data.Sqlite;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private string _name = "";
    private int _budget = 65000;
    private int _score = 0;
    private int _pickedLamps = 0;
    private int _pickedPanels = 0;
    private int _sensors = 0;
    private int _timepassed = 0;
    public DatabaseManager databaseManager;
    private GameObject _parkingSolarPanels;
    private GameObject _roofSolarPanels;

    public string Name => _name;

    public int Budget => _budget;

    public int Score => _score;

    public int PickedLamps => _pickedLamps;

    public int PickedPanels => _pickedPanels;

    public int Sensors => _sensors;

    public int Timepassed => _timepassed;

    public Text scoreUntilNow;
    public Text cashRemaining;
    
    //Lamps
    public Text energyBeforeLamps;
    public Text energyAfterLamps;
    public Text savingsEnergyLamps;
    public Text savingsPriceLamps;
    public Text lamp1Quantity;
    public Text lamp2Quantity;
    public Text lamp3Quantity;
    public Text lamp1Price;
    public Text lamp2Price;
    public Text lamp3Price;
    
    //Panels
    public Text panel1Quantity;
    public Text panel2Quantity;
    public Text panel3Quantity;
    public Text panel1Price;
    public Text panel2Price;
    public Text panel3Price;
    public Text panelEnergyProduction;
    public Text panelSavingsMoney;
    
    //Sensors
    public Text sensor1Quantity;
    public Text sensor2Quantity;
    public Text sensor1Price;
    public Text sensor2Price;
    public Text sensorsEnergyBefore;
    public Text sensorsEnergyAfter;
    public Text sensorsSavingsEnergy;
    public Text sensorsSavingsMoney;
    
    private void Start()
    {
        SetupPrefabs();
        HidePrefabs();

        databaseManager = gameObject.AddComponent<DatabaseManager>();
        var timer = new System.Timers.Timer(1000);
        timer.Elapsed += HandleTimerElapsed;
        timer.Enabled = true;
        cashRemaining.text = _budget.ToString() + " €";
        scoreUntilNow.text = _score.ToString() + " Pts";


    }
    
    public void LoadLamps()
    {
        //Lamps Load
        energyBeforeLamps.text = "0 kWh";
        energyAfterLamps.text = "0 kWh";;
        savingsEnergyLamps.text = "0 kWh";
        savingsPriceLamps.text = "0 €" ;
        Lamp lamp1 = databaseManager.GetLamps(1);
        lamp1Quantity.text = lamp1.UnitCount.ToString();
        lamp1Price.text = (lamp1.UnitPrice * lamp1.UnitCount).ToString() + "€";
        Lamp lamp2 = databaseManager.GetLamps(2);
        lamp2Quantity.text = lamp2.UnitCount.ToString();
        lamp2Price.text = (lamp2.UnitPrice* lamp1.UnitCount).ToString() + "€";
        Lamp lamp3 = databaseManager.GetLamps(3);
        lamp3Quantity.text = lamp3.UnitCount.ToString();
        lamp3Price.text = (lamp3.UnitPrice* lamp1.UnitCount).ToString() + "€";

    }

    public void LoadPanels()
    {
        panelEnergyProduction.text = "0 kWh";
        panelSavingsMoney.text = "0 €";  
        Panel panel1 = databaseManager.GetPanels(1);
        panel1Quantity.text = panel1.UnitCount.ToString();
        panel1Price.text = (panel1.UnitPrice * panel1.UnitCount).ToString() + "€";
        Panel panel2 = databaseManager.GetPanels(2);
        panel2Quantity.text = panel2.UnitCount.ToString();
        panel2Price.text = (panel2.UnitPrice * panel1.UnitCount).ToString() + "€";
        Panel panel3 = databaseManager.GetPanels(3);
        panel3Quantity.text = panel3.UnitCount.ToString();
        panel3Price.text = (panel3.UnitPrice * panel1.UnitCount).ToString() + "€";
    }

    public void LoadSensors()
    {
        sensorsEnergyBefore.text = "0 kWh";
        sensorsEnergyAfter.text = "0 kWh";
        sensorsSavingsEnergy.text = "0 kWh";
        sensorsSavingsMoney.text = "0 €";
        Sensor sensor1 = databaseManager.GetSensors(1);
        sensor1Quantity.text = sensor1.UnitCount.ToString();
        sensor1Price.text = (sensor1.UnitPrice * sensor1.UnitCount).ToString() + "€";
        Sensor sensor2 = databaseManager.GetSensors(2);
        sensor2Quantity.text = sensor2.UnitCount.ToString();
        sensor2Price.text = (sensor2.UnitPrice * sensor2.UnitCount).ToString() + "€";
    }

    /**
     * Faz setup dos prefabs
     */
    private void SetupPrefabs()
    {
        _parkingSolarPanels = GameObject.FindGameObjectWithTag("ParkingLotSolarPanels");
        _roofSolarPanels = GameObject.FindGameObjectWithTag("RoofSolarPanels");
    }

    /**
     * Esconde todos os prefabs das implementações
     */
    private void HidePrefabs()
    {
        _parkingSolarPanels.SetActive(false);
        _roofSolarPanels.SetActive(false);
    }

    //*****Botões dos Menus*****//

    //*****Paineis*****//
    //Seleciona a opção de implementação dos paineis solares
    public void OptionPanel(int option)
    {
        _pickedPanels = option;
        Panel panel = databaseManager.GetPanels(_pickedPanels);
        panelEnergyProduction.text = (panel.EnergyBefore - panel.EnergyAfter).ToString() + " kWh";
        panelSavingsMoney.text = ((panel.EnergyBefore - panel.EnergyAfter) * 0.14256).ToString() + " €";
        print(panel.Name);
        
    }

    //*****Lampadas*****//
    //Seleciona a opção de implementação das Lampadas
    public void OptionLamp(int option)
    {
        _pickedLamps = option;
        Lamp lamps = databaseManager.GetLamps(_pickedLamps);
        energyBeforeLamps.text = (lamps.EnergyBefore).ToString() + " kWh";
        energyAfterLamps.text = (lamps.EnergyAfter).ToString() + " kWh";;
        savingsEnergyLamps.text = (lamps.EnergyBefore - lamps.EnergyAfter).ToString() + " kWh";
        savingsPriceLamps.text = ((lamps.EnergyBefore - lamps.EnergyAfter) * 0.14256).ToString() + " €" ;
        print(lamps.Name);
        
    }

    //*****Sensores*****//
    //Seleciona a opção de implementação 1 dos paineis solares
    public void OptionSensors(int option)
    {
        _sensors = option;
        Sensor sensor = databaseManager.GetSensors(_sensors);
        sensorsEnergyBefore.text = sensor.EnergyBefore.ToString() + " kWh";
        sensorsEnergyAfter.text = sensor.EnergyAfter.ToString() + " kWh";
        sensorsSavingsEnergy.text = (sensor.EnergyBefore - sensor.EnergyAfter).ToString() + " kWh";
        sensorsSavingsMoney.text = ((sensor.EnergyBefore - sensor.EnergyAfter) * 0.14256).ToString() + " €";
        print(sensor.Name);
    }


    //*****Confirmar Implementações*****//

    //*****Paineis*****//

    //Confirma a opção de paineis selecionada e faz aparecer paineis
    public void ImplementPanels(int panelsType)
    {
        if (_pickedPanels == 1)
        {
            _parkingSolarPanels.SetActive(true);
        }
        else if (_pickedPanels == 2)
        {
            _roofSolarPanels.SetActive(true);
        }
        else if (_pickedPanels == 3)
        {
            if (panelsType == 1)
            {
                _parkingSolarPanels.SetActive(true);
            }
            else
            {
                _roofSolarPanels.SetActive(true);
            }
        }
    }

    //*****Lampadas*****//

    //Confirma a opção de lampadas selecionada e faz aparecer lampadas
    public void ImplementLamps()
    {
        if (_pickedLamps == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_pickedLamps == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_pickedLamps == 3)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }

    //*****Sensores*****//

    //Confirma a opção de sensores selecionada e faz aparecer os sensores
    public void ImplementSensors()
    {
        if (_sensors == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_sensors == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }


    //*****Terminar Implementação*****//

    //*****Paineis*****//
    //Constroi os Paineis
    public void ConstruirPainel()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _sensors != 0)
        {
            AcabarJogo();
        }
    }

    //*****Lampadas*****//
    //Constroi as Lampadas
    public void ConstruirLampadas()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _sensors != 0)
        {
            AcabarJogo();
        }
    }

    //*****Sensores*****//
    //Constroi as Lampadas
    public void ConstruirSensores()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _sensors != 0)
        {
            AcabarJogo();
        }
    }


    //Termina o jogo e pede o nome ao jogador enquanto mostra um resumo do que fez
    public void AcabarJogo()
    {
        //TODO Mostrar o resumo ao jogador consoante o que escolheu (Ir buscar á BD consoante os IDS)
        //TODO Pedir o Nome do jogador (Meter Input com texto debaixo)
        //TODO Inserir Tudo na BD (Correr Script para adicionar tudo á tabela)
        Score score = new Score(0, _name, _score, _timepassed, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
            _pickedLamps, _pickedPanels, _sensors);
        databaseManager.InsertScoreIntoDB(score);
        //TODO Voltar para o MENU Principal (Trocar a scene para 0)
        _name = "";
        _pickedLamps = 0;
        _pickedPanels = 0;
        _sensors = 0;
        _timepassed = 0;
    }

    public void coisas()
    {
        print("Hello!");
    }

    public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // do whatever it is that you need to do on a timer
        _timepassed++;
    }
    
}