using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TDEE;
using FluentAssertions;

namespace Tests
{
    public class WeekListTests
    {
        List<TodoItem> Items;
        Week w1;
        Week w2;
        Week w3;
        WeekList wl;

        [SetUp]
        public void Setup()
        {
            Items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(90.1, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 3)),
                    // week
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(90.4, 4000, new DateTime(2019, 1, 9)),         
                    new TodoItem(90.3, 4000, new DateTime(2019, 1, 13)),
                    new TodoItem(90.5, 4000, new DateTime(2019, 1, 14)),
                    // week
                    new TodoItem(90.5, 4000, new DateTime(2019, 1, 15)),
                    new TodoItem(90.6, 4000, new DateTime(2019, 1, 16)),

                });

            wl = new WeekList(new IntervalList(7, Items).List);

            w1 = wl.List.ElementAt(0);
            w2 = wl.List.ElementAt(1);
            w3 = wl.List.ElementAt(2);
        }

        [Test]
        public void ShouldUseFirstWeightAsLastWeeks()
        {
            Assert.AreEqual(w1.LastWeekWeight, 90);
        }

        [Test]
        public void ShouldGetCorrectTDEE()
        {
            Assert.AreEqual(w1.Tdee, 3890);
            Assert.AreEqual(w2.Tdee, 3725);
            Assert.AreEqual(w3.Tdee, 3780);
        }

        [Test]
        public void ShouldUseCorrectDate()
        {
            Assert.AreEqual(w1.Start, new DateTime(2019, 1, 1));
        }

        [Test]
        public void ShouldCropDateCorrectly()
        {
            List<TodoItem> items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(90.1, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 3)),
                    // week
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(90.4, 4000, new DateTime(2019, 1, 9)),
                    new TodoItem(90.3, 4000, new DateTime(2019, 1, 13)),
                    new TodoItem(90.5, 4000, new DateTime(2019, 1, 14)),
                });

            WeekList expected = new WeekList(new IntervalList(7, items).List);

            wl.CropRange(2);
            wl.List.Should().BeEquivalentTo(expected.List);
            Assert.True(wl.List.Count == 2);
        }

        [Test]
        public void ShouldCropDateCorrectly1()
        {
            List<TodoItem> items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(90.1, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 3)),
                });

            WeekList expected = new WeekList(new IntervalList(7, items).List);

            wl.CropRange(1);
            wl.List.Should().BeEquivalentTo(expected.List);
            Assert.True(wl.List.Count == 1);
        }

        [Test]
        public void ShouldCropDateCorrectly3()
        {
            List<TodoItem> items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(90.1, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 3)),
                    // week
                    new TodoItem(90.2, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(90.4, 4000, new DateTime(2019, 1, 9)),
                    new TodoItem(90.3, 4000, new DateTime(2019, 1, 13)),
                    new TodoItem(90.5, 4000, new DateTime(2019, 1, 14)),
                    // week
                    new TodoItem(90.5, 4000, new DateTime(2019, 1, 15)),
                    new TodoItem(90.6, 4000, new DateTime(2019, 1, 16)),
                });

            WeekList expected = new WeekList(new IntervalList(7, items).List);

            wl.CropRange(3);
            wl.List.Should().BeEquivalentTo(expected.List);
            Assert.True(wl.List.Count == 3);
        }

        [Test]
        public void ShouldWorkWithNullValues()
        {
            List<TodoItem> items = new List<TodoItem>();

            IntervalList il = new IntervalList(7, items);

            WeekList wl = new WeekList(il.List);

            Assert.True(wl.List.Count == 0);

            wl = new WeekList(null);

            Assert.True(il.List.Count == 0);
        }
    }
}