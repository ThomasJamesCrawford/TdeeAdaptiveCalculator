using NUnit.Framework;
using System;
using System.Collections.Generic;
using TDEE;
using System.Linq;

namespace Tests
{
    public class WeightChangeListTests
    {
        LineSeriesData w0;
        LineSeriesData w1;
        LineSeriesData w2;
        LineSeriesData w3;

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
            WeekList WL = new WeekList(IL.List);
            WeightChangeList WCL = new WeightChangeList(WL.List);

            w0 = WCL.List.ElementAt(0);
            w1 = WCL.List.ElementAt(1);
            w2 = WCL.List.ElementAt(2);
            w3 = WCL.List.ElementAt(3);
        }

        [Test]
        public void ShouldHaveRightWeightChange()
        {
            Assert.AreEqual(0, w0.YNumeric);
            Assert.AreEqual(0.5, w1.YNumeric);
            Assert.AreEqual(2, w2.YNumeric);
            Assert.AreEqual(2, w3.YNumeric);
        }

        [Test]
        public void ShouldHaveRightDate()
        {
            Assert.AreEqual(new DateTime(2019, 1, 1), w0.XDateTime);
            Assert.AreEqual(new DateTime(2019, 1, 8), w1.XDateTime);
            Assert.AreEqual(new DateTime(2019, 1, 15), w2.XDateTime);
            Assert.AreEqual(new DateTime(2019, 1, 22), w3.XDateTime);
        }
    }
}