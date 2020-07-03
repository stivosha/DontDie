using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Die.Enums;
using Don_t_Die.Models.Levels;

namespace Don_t_Die.Models.Time
{
    public class DayTime
    {
        public int Circle_time { get; set; }
        public int CurrentTime { get; set; }
        public double ChangeTime { get; set; }
        public int CurrentLightLevel { get; set; }
        public TimeOfDay CurrentTimeOfDay { get; set; }

        public int PeriodTime { get; set; }
        public DayTime()
        {
            Circle_time = 3200;
            PeriodTime = Circle_time / 4;
            CurrentTime = 0;
            CurrentLightLevel = 8;
            CurrentTimeOfDay = TimeOfDay.Afternoon;
        }

        public void Update()
        {
            CurrentTime = (CurrentTime + 1) % Circle_time;
            int currTime = CurrentTime / PeriodTime;
            if (currTime == 0)
            {
                CurrentLightLevel = 8;
                CurrentTimeOfDay = TimeOfDay.Afternoon;
            }
            else if (currTime == 1)
            {
                var c = CurrentTime % PeriodTime;
                var delt = Circle_time / 32;
                CurrentLightLevel = 8 - c / delt;
                CurrentTimeOfDay = TimeOfDay.Evening;
            }
            else if (currTime == 2)
            {
                CurrentLightLevel = 0;
                CurrentTimeOfDay = TimeOfDay.Night;
            }
            else if (currTime == 3)
            {
                var c = CurrentTime % PeriodTime;
                var delt = Circle_time / 32;
                CurrentLightLevel = c / delt;
                CurrentTimeOfDay = TimeOfDay.Morning;
            }
        }
    }
}
