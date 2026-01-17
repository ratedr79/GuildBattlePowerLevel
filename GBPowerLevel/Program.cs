var csvPath = @"D:\code\SOLDIER\SOLDIER Guild Battle #19 Preparation (Responses) - Form Responses 1.csv";
var powerLevel = new GBPowerLevel.PowerLevel(csvPath);

powerLevel.GetPowerLevels();

Console.ReadLine();