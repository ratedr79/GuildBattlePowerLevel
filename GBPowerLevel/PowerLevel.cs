using CsvHelper;
using CsvHelper.Configuration;
using GBPowerLevel.GuildBattles;
using GBPowerLevel.Interfaces;
using System.Globalization;
using System.Text;

namespace GBPowerLevel
{
    public class PowerLevel
    {
        private string _csvPath { get; set; }

        public PowerLevel(string csvPath)
        {
            _csvPath = csvPath;
        }

        public void GetPowerLevels(IGuildBattle gb)
        {
            gb.GetOutput(_csvPath);
        }
    }
}
