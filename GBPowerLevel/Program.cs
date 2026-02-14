using GBPowerLevel.GuildBattles;

//var csvPath = @"D:\code\SOLDIER\SOLDIER Guild Battle #19 Preparation (Responses) - Form Responses 1.csv";
//var powerLevel = new GBPowerLevel.PowerLevel(csvPath);
//powerLevel.GetPowerLevels(new GuildBattle19());

var csvPath = @"D:\code\SOLDIER\gb20.csv";
var powerLevel = new GBPowerLevel.PowerLevel(csvPath);
powerLevel.GetPowerLevels(new GuildBattle20());

Console.ReadLine();