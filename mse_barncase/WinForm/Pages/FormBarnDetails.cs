﻿using Bussiness.Abstract;
using Bussiness.DependencyResolvers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Pages
{
    public partial class FormBarnDetails : Form
    {
        private IBarnService _barnService;
        private IAnimalService _animalService;
        private IProductService _productService;
        private IAnimalTypesService _animalTypesService;
        private IAnimalGendersService _animalGendersService;
        private IProductTypesService _productTypesService;
        private IAnimalViewService _animalsViewService;
        private IProductsViewService _productsViewService;
        public FormBarnDetails()
        {
            InitializeComponent();

            _barnService = DependencyInjection.ConfigureServices().GetRequiredService<IBarnService>();
            _animalService = DependencyInjection.ConfigureServices().GetRequiredService<IAnimalService>();
            _productService = DependencyInjection.ConfigureServices().GetRequiredService<IProductService>();
            _animalTypesService = DependencyInjection.ConfigureServices().GetRequiredService<IAnimalTypesService>();
            _animalGendersService = DependencyInjection.ConfigureServices().GetRequiredService<IAnimalGendersService>();
            _productTypesService = DependencyInjection.ConfigureServices().GetRequiredService<IProductTypesService>();
            _animalsViewService = DependencyInjection.ConfigureServices().GetRequiredService<IAnimalViewService>();
            _productsViewService = DependencyInjection.ConfigureServices().GetRequiredService<IProductsViewService>();

            FormLoad();
        }

        private void FormLoad()
        {
            //grids
            var animalGrid = _animalsViewService.GetListAll();
            dataGridAnimalList.DataSource = animalGrid.Data;
            var productGrid = _productsViewService.GetListAll();
            dataGridProductList.DataSource = productGrid.Data;

            var animals = _animalService.GetList();
            var products = _productService.GetList();

            //charts
            int soldAnimalsCount = _animalsViewService.GetListSold().Data.Count;
            int notSoldAnimalsCount = _animalsViewService.GetListNotSold().Data.Count;

            chartAnimal.Series.Clear();
            chartAnimal.Series.Add("Animals Is Sold");
            chartAnimal.Series["Animals Is Sold"].Points.AddXY("Sold",soldAnimalsCount);
            chartAnimal.Series["Animals Is Sold"].Points.AddXY("NotSold",notSoldAnimalsCount);
            chartAnimal.Series["Animals Is Sold"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            int soldProductsCount = _productsViewService.GetListSold().Data.Count;
            int notSoldProductsCount = _productsViewService.GetListNotSold().Data.Count;

            chartProduct.Series.Clear();
            chartProduct.Series.Add("Products Is Sold");
            chartProduct.Series["Products Is Sold"].Points.AddXY("Sold", soldProductsCount);
            chartProduct.Series["Products Is Sold"].Points.AddXY("NotSold", notSoldProductsCount);
            chartProduct.Series["Products Is Sold"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            //txts
            var barnAmount = _barnService.GetAmount();
            txtCurrent.Text = barnAmount.Data.FarmAmount.ToString();
            
            decimal animalWorth = 0;

            foreach (var animal in animals.Data)
            {
                var type = _animalTypesService.GetById(animal.AnimalTypeID);
                animalWorth = animalWorth + type.Data.TypePrice;

            }
            txtAnimalWorth.Text = animalWorth.ToString();

            decimal productWorth = 0;

            foreach (var product in products.Data)
            {
                var type = _productTypesService.GetById(product.ProductTypeID);
                productWorth = productWorth + type.Data.ProductTypePrice;

            }
            txtProductWorth.Text = productWorth.ToString();


        }

        private void picRefresh_Click(object sender, EventArgs e)
        {
            FormLoad();
        }
    }
}
