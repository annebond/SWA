using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example7.ViewModel.Blueprints
{
    public abstract class ContructionDetails
    {
        public ContructionDetails(string completionTime, int amount)
        {
            
            CompletionTime = completionTime;
            Amount = amount;
            Time = DateTime.Now.ToString("hh:mm");
        }

        public string Description { get; set; }
        public string Parts { get; set; }
        public string CompletionTime { get; set; }
        public string Time { get; set; }
        public int Amount { get; set; }
    }
}
