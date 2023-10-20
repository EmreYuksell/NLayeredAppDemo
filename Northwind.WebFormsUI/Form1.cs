using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAcces.Concrete.EntityFramework;
using Northwind.DataAcces.Concrete.EntıtyFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             _productService  = new ProductManager(new EfProductDal());
             _categoryService = new CategoryManager(new EfCategoryDal());
        }
        private IProductService _productService; 
        private ICategoryService _categoryService;
        private void LoadProducts()
        {

            dgwProduct.DataSource = _productService.GetAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategoryName.DataSource = _categoryService.GetAll();
            cbxCategoryName.DisplayMember = "CategoryName";
            cbxCategoryName.ValueMember = "CategoryId";
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategoryName.SelectedValue));
            }
            catch 
            {

                
            }
           
        }
    }
}
