using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDEE
{
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static double GoalWeight
        {
            get => AppSettings.GetValueOrDefault(nameof(GoalWeight), 0.0);
            set => AppSettings.AddOrUpdateValue(nameof(GoalWeight), value);
        }

        public static double GoalRate
        {
            get => AppSettings.GetValueOrDefault(nameof(GoalRate), 0.0);
            set => AppSettings.AddOrUpdateValue(nameof(GoalRate), value);
        }

        public static double CalSurplus
        {
            get => GoalRate * CaloriesPerUnit / 7.0;
            set => GoalRate = value * 7.0 / CaloriesPerUnit;
        }

        public static int WeeksInAvg
        {
            get => AppSettings.GetValueOrDefault(nameof(WeeksInAvg), 6);
            set => AppSettings.AddOrUpdateValue(nameof(WeeksInAvg), value);
        }

        public static bool Metric
        {
            get => AppSettings.GetValueOrDefault(nameof(Metric), true);
            set => AppSettings.AddOrUpdateValue(nameof(Metric), value);
        }

        public static double CaloriesPerUnit
        {
            get => Metric ? CaloriesPerKg : CaloriesPerLb;
            set
            {
                if(Metric)
                {
                    CaloriesPerKg = value;
                }
                else
                {
                    CaloriesPerLb = value;
                }
            }
         }

        public static double CaloriesPerKg
        {
            get => AppSettings.GetValueOrDefault(nameof(CaloriesPerKg), 7700.0);
            set => AppSettings.AddOrUpdateValue(nameof(CaloriesPerKg), value);
        }

        public static double CaloriesPerLb
        {
            get => AppSettings.GetValueOrDefault(nameof(CaloriesPerLb), 3500.0);
            set => AppSettings.AddOrUpdateValue(nameof(CaloriesPerLb), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }
    }
}
