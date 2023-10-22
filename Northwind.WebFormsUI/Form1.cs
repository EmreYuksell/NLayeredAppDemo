using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAcces.Concrete.EntityFramework;
using Northwind.DataAcces.Concrete.EntıtyFramework;
using Northwind.Entities.Concrete;
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

            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxUpdateCategory.DataSource = _categoryService.GetAll();
            cbxUpdateCategory.DisplayMember = "CategoryName";
            cbxUpdateCategory.ValueMember = "CategoryId";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProdcuctName(tbxProductName.Text);
            }
            else
            {
                LoadProducts();
            }
        
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryId = Convert.ToInt32(cbxCategory.SelectedValue),
                ProductName = tbxProductName2.Text,
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxStock.Text)
            }); ;
            LoadProducts(); 
            MessageBox.Show("Urun Eklendi:");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName=tbxUpdateProductName.Text,
                CategoryId = Convert.ToInt32(cbxUpdateCategory.SelectedValue),
                QuantityPerUnit=tbxUpdateQuantityPerUnıt.Text,
                UnitPrice=Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                UnitsInStock=Convert.ToInt16(tbxUpdateUnıtInStock.Text),


            }); 
            MessageBox.Show("Ürün Güncellendi");
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxUpdateProductName.Text = row.Cells[1].Value.ToString();
            cbxUpdateCategory.SelectedValue = row.Cells[2].Value;
            tbxUpdateUnitPrice.Text = row.Cells[3].Value.ToString();
            tbxUpdateQuantityPerUnıt.Text=row.Cells[4].Value.ToString();
            tbxUpdateUnıtInStock.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)

                    });
                    MessageBox.Show("Urun Silindi");
                    LoadProducts();
                }
                catch(Exception exception)
                {

                    MessageBox.Show(exception.Message);            
                }
              


            };
          
        }
    }
}
