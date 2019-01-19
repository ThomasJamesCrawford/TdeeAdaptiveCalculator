﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDEE.Views;
using Xamarin.Forms;

namespace TDEE
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get; }

        public MasterPageCS()
        {
            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Add Weight/Cal",
                IconSource = "contacts.png",
                TargetType = typeof(AddData)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Set your goal",
                IconSource = "contacts.png",
                TargetType = typeof(Goal)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Tdee Graph",
                IconSource = "todo.png",
                TargetType = typeof(TdeeGraph)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Weight Graph",
                IconSource = "todo.png",
                TargetType = typeof(WeightGraph)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Clear Data",
                IconSource = "todo.png",
                TargetType = typeof(DeleteAll)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Add Bulk Data",
                IconSource = "todo.png",
                TargetType = typeof(BulkDataEntry)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "todo.png",
                TargetType = typeof(Settings)
            });


            ListView = new ListView
            {
                ItemsSource = masterPageItems,

                ItemTemplate = new DataTemplate(() => {
                    var grid = new Grid { Padding = new Thickness(5, 10) };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "IconSource");
                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
                    label.SetBinding(Label.TextProperty, "Title");

                    grid.Children.Add(image);
                    grid.Children.Add(label, 1, 0);

                    return new ViewCell { View = grid };
                }),

                SeparatorVisibility = SeparatorVisibility.None
            };

            Icon = "hamburger.png";
            Title = "List";
            Content = new StackLayout
            {
                Children = { ListView }
            };
        }
    }
}