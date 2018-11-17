using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise2
{
    class Zookeper
    {
        public void TierCageZuordnen(Tier tier, List<Cage> cages)
        {
            foreach (var currentCage in cages)
            {
                if (currentCage.Umweltzonen.Count < tier.RequiredUmweltzonen.Count)
                {
                    continue;
                }

                int count = 0;
                foreach (var currentReqUmweltuonen in tier.RequiredUmweltzonen)
                {
                    foreach (var currentUmweltzone in currentCage.Umweltzonen)
                    {
                        if (currentUmweltzone.Equals(currentReqUmweltuonen.GetType()))
                        {
                            count++;
                            if (count == tier.RequiredUmweltzonen.Count && currentCage.Tier == null)
                            {
                                tier.Cage = currentCage;
                                currentCage.Tier = tier;
                                return;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
