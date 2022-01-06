using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        Customer_BUS cusBUS = new Customer_BUS();
        public Form1()
        {
            InitializeComponent();
        }

        private void From1_Load(object sender, EventArgs e)
        {
            List<Customer_DTO> lstCus = cusBUS.ReadCustomer();
            foreach (Customer_DTO cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Name);
            }
                
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
                MessageBox.Show("mã sinh viên không được để trống", "Cảnh Báo");
            else if (tbName.Text == "")
                MessageBox.Show("Tên sinh viên không được để trống", "Cảnh Báo");
            else
            {
                Customer_DTO cus = new Customer_DTO();
                cus.Id = tbId.Text;
                cus.Name = tbName.Text;

                cusBUS.NewCustomer(cus);

                dgvCustomer.Rows.Add(cus.Id, cus.Name);

                tbId.Text = null;
                tbName.Text = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?",
                                     "Cảnh Báo!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Customer_DTO cus = new Customer_DTO();
                cus.Id = tbId.Text;
                cus.Name = tbName.Text;

                cusBUS.DeleteCustomer(cus);

                int idx = dgvCustomer.CurrentCell.RowIndex;
                dgvCustomer.Rows.RemoveAt(idx);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
                MessageBox.Show("mã sinh viên không được để trống", "Cảnh Báo");
            else if (tbName.Text == "")
                MessageBox.Show("Tên sinh viên không được để trống", "Cảnh Báo");
            else
            {
                Customer_DTO cus = new Customer_DTO();
                cus.Id = tbId.Text;
                cus.Name = tbName.Text;

                cusBUS.EditCustomer(cus);

                DataGridViewRow row = dgvCustomer.CurrentRow;
                row.Cells[0].Value = cus.Id;
                row.Cells[1].Value = cus.Name;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CustomerGUI_Load(object sender, EventArgs e)
        {
            List<Customer_DTO> lstCus = cusBUS.ReadCustomer();
            foreach (Customer_DTO cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Name);
            }

        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbId.Text = dgvCustomer.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dgvCustomer.Rows[idx].Cells[1].Value.ToString();

        }
    }
}
