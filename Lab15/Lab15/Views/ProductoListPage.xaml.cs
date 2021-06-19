﻿using Lab15.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoListPage : ContentPage
    {
        public ProductoListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ProductoManager.GetTaskAsync();
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoPage()
            { 
                BindingContext = new Producto
                { 
                    codigo = Guid.NewGuid().ToString()
                }
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ProductoPage
            {
                BindingContext = e.SelectedItem as Producto
            });
        }
    }
}