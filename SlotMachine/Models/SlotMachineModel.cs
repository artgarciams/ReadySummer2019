using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.Models
{
    public class SlotMachineModel
    {
        public string Slot1Image { get; set; }
        public string Slot2Image { get; set; }
        public string Slot3Image { get; set; }

        public string SpinResult { get; set; }
        public int PlayerBalance { get; set; }

        public int BetAmount { get; set; }

        public int LastBetAmount { get; set; }
        public int WinAmount { get; set; }

        public List<HighScoreModel> AllHighScores { get; set; }
    }
}
