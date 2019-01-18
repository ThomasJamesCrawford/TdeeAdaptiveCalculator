using NUnit.Framework;
using System;
using System.Collections.Generic;
using TDEE;
using System.Linq;
using FluentAssertions;

namespace Tests
{
    public class AverageLineSeriesTests
    {
        AverageLineSeriesList ALSL;
        AverageLineSeriesList ALSL1;

        WeekList WL;

        [SetUp]
        public void Setup()
        {
            List<TodoItem> items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                    // week
                    new TodoItem(92, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(93, 4000, new DateTime(2019, 1, 13)),
                    // week
                    new TodoItem(94, 4000, new DateTime(2019, 1, 15)),
                    new TodoItem(95, 4000, new DateTime(2019, 1, 16)),
});

            
            IntervalList IL = new IntervalList(7, items);
            WL = new WeekList(IL.List);
            ALSL = new AverageLineSeriesList(2, WL.List);
            ALSL1 = new AverageLineSeriesList(1, WL.List);

        }


        [Test]
        public void ShouldWorkWithBasicData()
        {
            List<LineSeriesData> expected = new List<LineSeriesData>(
                new LineSeriesData[]
                {
                    new LineSeriesData()
                    {
                        YNumeric = (int)((WL.List.ElementAt(1).Tdee + WL.List.ElementAt(2).Tdee)/2),
                        XDateTime =  new DateTime(2019, 1, 8),
                    },

                    new LineSeriesData()
                    {
                        YNumeric = (int)((WL.List.ElementAt(1).Tdee + WL.List.ElementAt(2).Tdee)/2),
                        XDateTime =  new DateTime(2019, 1, 22),
                    },
                }
            );

            ALSL.List.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldWorkWithOnePeriod()
        {
            List<LineSeriesData> expected = new List<LineSeriesData>(
                new LineSeriesData[]
                {
                    new LineSeriesData()
                    {
                        YNumeric = (int)(WL.List.ElementAt(2).Tdee),
                        XDateTime =  new DateTime(2019, 1, 15),
                    },

                    new LineSeriesData()
                    {
                        YNumeric = (int)(WL.List.ElementAt(2).Tdee),
                        XDateTime =  new DateTime(2019, 1, 22),
                    },
                }
            );

            ALSL1.List.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ShouldWorkWithNullValues()
        {
            List<TodoItem> items = new List<TodoItem>();

            IntervalList il = new IntervalList(7, items);
            WeekList wl = new WeekList(il.List);
            AverageLineSeriesList alsl = new AverageLineSeriesList(5, wl.List);

            Assert.True(alsl.List.Count == 0);

            alsl = new AverageLineSeriesList(5, null);

            Assert.True(alsl.List.Count == 0);

            alsl = new AverageLineSeriesList(-500, null);

            Assert.True(alsl.List.Count == 0);
        }
    }
}
