using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User04Lib
{
    public class Calculations
    {
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations,
            TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consulationTime)
        {
            TimeSpan currentTime = beginWorkingTime;
            int i = 0;
            int count = 100;

            var list = new string[100];

            for (currentTime = beginWorkingTime; currentTime < endWorkingTime; currentTime = currentTime.Add(new TimeSpan(0, consulationTime, 0)))
            {
                if (currentTime <= startTimes[i] && currentTime.Add(new TimeSpan(0, consulationTime, 0)) <= startTimes[i])
                {
                    currentTime = startTimes[i].Add(new TimeSpan(0, durations[i], 0));
                    i++;
                    continue;
                }

                list.Append(currentTime.ToString());
            }



            


            return list;
        }
    }
}
