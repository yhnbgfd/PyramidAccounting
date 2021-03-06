﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using PA.Model.DataGrid;
using PA.Model.CustomEventArgs;
using PA.View.ResourceDictionarys.MessageBox;
using PA.Helper.DataDefind;

namespace PA.View.Windows
{
    public delegate void Win_记账凭证_Submit(object sender, MyEventArgs e);

    public partial class Win_记账凭证 : Window
    {
        public static event Win_记账凭证_Submit ESubmit;
        Model_凭证单 Voucher = new Model_凭证单();
        private ViewModel.ViewModel_凭证管理 vmp = new ViewModel.ViewModel_凭证管理();
        List<Model_凭证明细> VoucherDetails = new List<Model_凭证明细>();//所有DataGrid数据集合
        List<Model_凭证明细> VoucherDetailsNow = new List<Model_凭证明细>();//当前DataGrid的数据
        private List<object> DataGridContextMenu = new List<object>();
        private int CellId;

        private int PageNow = 1;//当前页面
        private int PageAll = 1;//所有页面

        private bool isNew = true;
        private Guid guid = Guid.NewGuid();

        public Win_记账凭证()
        {
            InitializeComponent();
            this.Button_打印.Visibility = System.Windows.Visibility.Collapsed;
            InitData(true);
            Voucher.当前期 = PA.Helper.DataDefind.CommonInfo.当前期;
            InitializeDataGridContextMenu();
        }
      
        public Win_记账凭证(Guid guid)
        {
            InitializeComponent();
            this.guid = guid;
            FillData(guid);
            this.Button_保存并新增.Visibility = System.Windows.Visibility.Collapsed;
            isNew = false;
            InitializeDataGridContextMenu();
        }

        private void InitializeDataGridContextMenu()
        {
            MenuItem b = new MenuItem();
            b.Header = "删除行";
            b.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
            b.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            b.Click += MenuItem_Click;
            DataGridContextMenu.Add(b);
            this.DataGrid_凭证明细.ContextMenu.ItemsSource = DataGridContextMenu;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            #region 删除方法
            if (DataGrid_凭证明细.SelectedCells.Count != 0)
            {
                Model_凭证明细 m = DataGrid_凭证明细.SelectedCells[0].Item as Model_凭证明细;
                if (m.ID != 0) 
                {
                    bool flag = vmp.DeleteDetail(m.ID);
                    if (!flag)
                    {
                        MessageBoxCommon.Show("删除不成功！未找到对应数据！");
                    }
                }
                m.摘要 = "";
                m.主科目名 = "";
                m.子细目 = "";
                m.借方 = 0;
                m.贷方 = 0;
                Count合计();
            }
            #endregion 
        }

        #region 自定义事件
        private void OnSubmit()
        {
            if (ESubmit != null)
            {
                ESubmit(this, new MyEventArgs());
            }
        }
        private void DoFillData(object sender, MyEventArgs e)
        {
            this.Popup_科目子细目.IsOpen = false;
            this.Window_记账凭证.IsEnabled = true;
            if (typeof(PA.View.Pages.Pop.凭证录入.Page_凭证录入_科目).IsInstanceOfType(sender))
            {
                VoucherDetailsNow[CellId].科目编号 = e.Str.Split('\t')[0];
                VoucherDetailsNow[CellId].主科目名 = e.Str.Split('\t')[0] + " " + e.Str.Split('\t')[1];
            }
            else if (typeof(PA.View.Pages.Pop.凭证录入.Page_凭证录入_子细目).IsInstanceOfType(sender))
            {
                if (e.Str.IndexOf('\t') > 0)
                {
                    if ((e.Str.Split('\t')).Length >= 3)
                    {
                        if (e.Str.Split('\t')[2] != e.Str.Split('\t')[0])
                        {
                            VoucherDetailsNow[CellId].子细目ID = e.Str.Split('\t')[0];
                            VoucherDetailsNow[CellId].子细目 = e.Str.Split('\t')[0] + " " + e.Str.Split('\t')[1];
                            VoucherDetailsNow[CellId].科目编号 = e.Str.Split('\t')[2];
                            VoucherDetailsNow[CellId].主科目名 = e.Str.Split('\t')[2] + " " + e.Str.Split('\t')[3];
                        }
                        else
                        {
                            VoucherDetailsNow[CellId].子细目ID = null;
                            VoucherDetailsNow[CellId].子细目 = null;
                            VoucherDetailsNow[CellId].科目编号 = e.Str.Split('\t')[0];
                            VoucherDetailsNow[CellId].主科目名 = e.Str.Split('\t')[0] + " " + e.Str.Split('\t')[1];
                        }
                    }
                    else
                    {
                        VoucherDetailsNow[CellId].子细目ID = e.Str.Split('\t')[0];
                        VoucherDetailsNow[CellId].子细目 = e.Str.Split('\t')[0] + " " + e.Str.Split('\t')[1];
                    }
                }
            }
        }
        #endregion

        #region 非事件
        /// <summary>
        /// 初始化数据(空)
        /// </summary>
        private void InitData(bool isFirstInit)
        {
            VoucherDetailsNow = new List<Model_凭证明细>();
            for (int i = 0; i < 6; i++)
            {
                Model_凭证明细 a = new Model_凭证明细();
                a.序号 = i;
                VoucherDetailsNow.Add(a);
            }
            if (isFirstInit)
            {
                ViewModel.ViewModel_用户 vu = new ViewModel.ViewModel_用户();
                this.DatePicker_Date.SelectedDate = DateTime.Now;
                this.Label_制单人.Content = vu.GetUserName((int)ENUM.EM_AUTHORIY.记账员);
                this.Label_会计主管.Content = vu.GetUserName((int)ENUM.EM_AUTHORIY.会计主管);
            }
            this.DataGrid_凭证明细.ItemsSource = VoucherDetailsNow;
            VoucherDetails.Clear();
            for (int i = 0; i < 6; i++)
            {
                VoucherDetails.Add(VoucherDetailsNow[i]);
            }
            Count合计();
            this.TextBox_号.Text = "";
        }
        /// <summary>
        /// 填充数据(查看修改)
        /// </summary>
        private void FillData(Guid guid)
        {
            Voucher = new PA.ViewModel.ViewModel_凭证管理().GetVoucher(guid);
            VoucherDetails = new PA.ViewModel.ViewModel_凭证管理().GetVoucherDetails(guid);
            this.DatePicker_Date.SelectedDate = Voucher.制表时间;
            this.TextBox_附属单证.Text = Voucher.附属单证数.ToString();
            this.Label_借方合计.Content = Voucher.合计借方金额.ToString().Contains(".") ? Voucher.合计借方金额.ToString("f2") : Voucher.合计借方金额.ToString();
            this.Label_贷方合计.Content = Voucher.合计贷方金额.ToString().Contains(".") ? Voucher.合计贷方金额.ToString("f2") : Voucher.合计贷方金额.ToString();
            for (int i = 0; i < 6; i++)
            {
                Model_凭证明细 a = new Model_凭证明细();
                a.序号 = i;
                VoucherDetailsNow.Add(a);
            }
            for (int i = 0; i < VoucherDetails.Count; i++)
            {
                if (i < 6)
                {
                    VoucherDetailsNow[i] = VoucherDetails[i];
                }
            }
            this.TextBox_号.Text = VoucherDetailsNow[0].凭证号;
            this.DataGrid_凭证明细.ItemsSource = VoucherDetailsNow;
            PageAll = new PA.ViewModel.ViewModel_凭证管理().GetPageNum(guid);
            this.TextBlock_PageNum.Text = "1/" + PageAll;
            if (Voucher.审核标志 == 1)
            {
                this.Label_审核状态.Content = "已审核";
                this.Label_审核状态.Foreground = Brushes.Green;
            }
            else
            {
                this.Label_审核状态.Content = "未审核";
                this.Label_审核状态.Foreground = Brushes.Red;
            }
            //已审核，不能编辑修改
            if (Voucher.审核标志 == 1)
            {
                this.Button_保存.Visibility = System.Windows.Visibility.Collapsed;
                this.Button_NewDataGrid.Visibility = System.Windows.Visibility.Collapsed;
                this.TextBox_号.IsReadOnly = true;
                this.TextBox_附属单证.IsReadOnly = true;
                this.DataGrid_凭证明细.IsReadOnly = true;
                this.DatePicker_Date.IsEnabled = false;
            }
            this.Label_会计主管.Content = Voucher.会计主管;
            this.Label_制单人.Content = Voucher.制单人;
            this.Label_复核.Content = Voucher.复核;
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        private Model_凭证单 GetData()
        {
            SaveVoucherDetails();
            Voucher.ID = Guid.NewGuid().ToString();
            if ((DateTime)this.DatePicker_Date.SelectedDate != Voucher.制表时间.Date)
            {
                Voucher.制表时间 = (DateTime)this.DatePicker_Date.SelectedDate + DateTime.Now.TimeOfDay;
            }
            Voucher.附属单证数 = int.Parse(this.TextBox_附属单证.Text.Trim());
            Voucher.合计借方金额 = decimal.Parse(this.Label_借方合计.Content.ToString());
            Voucher.合计贷方金额 = decimal.Parse(this.Label_贷方合计.Content.ToString());
            Voucher.会计主管 = this.Label_会计主管.Content.ToString();
            Voucher.制单人 = this.Label_制单人.Content.ToString();
            Voucher.复核 = this.Label_复核.Content.ToString();
            foreach (Model_凭证明细 Detail in VoucherDetails)
            {
                Detail.父节点ID = Voucher.ID;
            }
            return Voucher;
        }
        private bool CheckData()
        {
            if (this.Label_借方合计.Content.ToString() != this.Label_贷方合计.Content.ToString())
            {
                MessageBoxCommon.Show("借贷不平衡");
                return false;
            }
            List<string> VoucherNum = new List<string>();
            for (int i = 0; i < PageAll; i++)
            {
                if (VoucherDetails[i * 6].凭证号 == "")
                {
                    MessageBoxCommon.Show("凭证号不能为空");
                    return false;
                }
                else
                {
                    if (!VoucherNum.Contains(VoucherDetails[i * 6].凭证号))
                    {
                        VoucherNum.Add(VoucherDetails[i * 6].凭证号);
                    }
                    else
                    {
                        MessageBoxCommon.Show("凭证号不能相同");
                        return false;
                    }
                    if (!vmp.IsVOUCHER_NOExist(VoucherDetails[i * 6].凭证号) && isNew)
                    {
                        MessageBoxCommon.Show("凭证号已存在,请勿重复添加！");
                        return false;
                    }
                }
            }
            int temp;
            if (!int.TryParse(this.TextBox_附属单证.Text.Trim(), out temp))
            {
                MessageBoxCommon.Show("附属单证必须为数字");
                return false;
            }
            return true;
        }
        private void Count合计()
        {
            decimal count借方 = 0m;
            decimal count贷方 = 0m;
            for (int i = 0; i < VoucherDetails.Count; i++)
            {
                count借方 += VoucherDetails[i].借方;
                count贷方 += VoucherDetails[i].贷方;
            }
            this.Label_借方合计.Content = count借方.ToString().Contains(".") ? count借方.ToString("f2") : count借方.ToString();
            this.Label_贷方合计.Content = count贷方.ToString().Contains(".") ? count贷方.ToString("f2") : count贷方.ToString();
        }

        /// <summary>
        /// 保存当前DataGrid(VoucherDetailsNow)到总List(VoucherDetails)
        /// </summary>
        private void SaveVoucherDetails()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i < VoucherDetails.Count - ((PageNow - 1) * 6))
                {
                    VoucherDetailsNow[i].凭证号 = this.TextBox_号.Text;
                    VoucherDetails[(PageNow - 1) * 6 + i] = VoucherDetailsNow[i];
                }
            }
        }
        #endregion

        #region 控件事件
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_凭证输入_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.Popup_科目子细目.IsOpen && e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_保存_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            if (!CheckData())
            {
                return;
            }
            if (new PA.ViewModel.ViewModel_凭证管理().InsertData(Voucher, VoucherDetails))
            {
                if (!isNew)
                {
                    new PA.ViewModel.ViewModel_凭证管理().DeleteAsModify(guid);
                }
                OnSubmit();
                Button_Close_Click(null, null);
            }
            else
            {
                MessageBoxCommon.Show("数据有误");
                return;
            }
        }

        private void Button_保存并新增_Click(object sender, RoutedEventArgs e)
        {
            GetData();
            if (!CheckData())
            {
                return;
            }
            if (new PA.ViewModel.ViewModel_凭证管理().InsertData(Voucher, VoucherDetails))
            {
                OnSubmit();
                InitData(false);
            }
            else
            {
                MessageBoxCommon.Show("数据有误");
            }
        }

        private void Button_打印_Click(object sender, RoutedEventArgs e)
        {
            new PA.Helper.ExcelHelper.ExcelWriter().ExportVouchers(guid);
        }

        private void DataGrid_凭证明细_Cell_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (Voucher.审核标志 == 1)
            {
                return;
            }
            Model_凭证明细 SelectedRow = this.DataGrid_凭证明细.SelectedCells[0].Item as Model_凭证明细;
            DataGridCellInfo DoubleClickCell = this.DataGrid_凭证明细.CurrentCell;
            CellId = SelectedRow.序号;
            if (DoubleClickCell.Column.Header.ToString() == "科目" || DoubleClickCell.Column.Header.ToString() == "子细目")
            {
                PA.View.Pages.Pop.凭证录入.Page_凭证录入_子细目 page;
                page = new PA.View.Pages.Pop.凭证录入.Page_凭证录入_子细目();
                page.FillDate += new Pages.Pop.凭证录入.Page_凭证录入_子细目_FillDateEventHandle(DoFillData);
                this.Frame_科目子细目.Content = page;
                this.Popup_科目子细目.IsOpen = true;
                this.Window_记账凭证.IsEnabled = false;
            }
            else if (DoubleClickCell.Column.Header.ToString() == "记账")
            {
                if (VoucherDetails[CellId].记账 == 0)
                {
                    VoucherDetails[CellId].记账 = 1;
                }
                else
                {
                    VoucherDetails[CellId].记账 = 0;
                }
            }
        }

        private void Button_PopupClose_Click(object sender, RoutedEventArgs e)
        {
            this.Popup_科目子细目.IsOpen = false;
            this.Window_记账凭证.IsEnabled = true;
        }

        private void DataGrid_凭证明细_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Model_凭证明细 SelectedRow = this.DataGrid_凭证明细.SelectedCells[0].Item as Model_凭证明细;
            string newValue = (e.EditingElement as TextBox).Text.Trim();
            string Header = e.Column.Header.ToString();
            decimal result = 0m;
            if (Header == "借方金额")
            {
                if (!decimal.TryParse(newValue, out result))
                {
                    MessageBoxCommon.Show("请输入数字。");
                }
                VoucherDetailsNow[SelectedRow.序号].借方 = result;
                VoucherDetailsNow[SelectedRow.序号].贷方 = 0m;
                Count合计();
            }
            else if (Header == "贷方金额")
            {
                if (!decimal.TryParse(newValue, out result))
                {
                    MessageBoxCommon.Show("请输入数字。");
                }
                VoucherDetailsNow[SelectedRow.序号].贷方 = result;
                VoucherDetailsNow[SelectedRow.序号].借方 = 0m;
                Count合计();
            }
        }

        private void TextBox_附属单证_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Voucher.审核标志 == 1)
            {
                return;
            }
            int result = 0;
            int.TryParse(this.TextBox_附属单证.Text.Trim(), out result);
            if (e.Delta > 0)
            {
                this.TextBox_附属单证.Text = (result + 1).ToString();
            }
            else if (e.Delta < 0)
            {
                if (result > 0)
                {
                    this.TextBox_附属单证.Text = (result - 1).ToString();
                }
            }
        }

        private void TextBox_号_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Voucher.审核标志 == 1)
            {
                return;
            }
            int result = 0;
            int.TryParse(this.TextBox_号.Text.Trim(), out result);
            if (e.Delta > 0)
            {
                this.TextBox_号.Text = (result + 1).ToString();
            }
            else if (e.Delta < 0)
            {
                if (result > 0)
                {
                    this.TextBox_号.Text = (result - 1).ToString();
                }
            }
        }

        private void Button_NewDataGrid_Click(object sender, RoutedEventArgs e)
        {
            SaveVoucherDetails();
            VoucherDetailsNow = new List<Model_凭证明细>();
            for (int i = 0; i < 6; i++)
            {
                Model_凭证明细 a = new Model_凭证明细();
                a.序号 = i;
                VoucherDetailsNow.Add(a);
            }
            for (int i = 0; i < 6; i++)
            {
                VoucherDetails.Add(VoucherDetailsNow[i]);
            }
            this.DataGrid_凭证明细.ItemsSource = VoucherDetailsNow;
            PageAll++;
            PageNow = PageAll;
            this.TextBlock_PageNum.Text = PageNow + "/" + PageAll;
        }

        private void Button_Previous_Click(object sender, RoutedEventArgs e)
        {
            if (PageNow > 1)
            {
                SaveVoucherDetails();
                PageNow--;
                this.TextBlock_PageNum.Text = PageNow + "/" + PageAll;
                VoucherDetailsNow = new List<Model_凭证明细>();
                for (int i = 0; i < 6; i++)
                {
                    VoucherDetailsNow.Add(VoucherDetails[(PageNow - 1) * 6 + i]);
                }
                this.DataGrid_凭证明细.ItemsSource = VoucherDetailsNow;
                this.TextBox_号.Text = VoucherDetailsNow[0].凭证号;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            if (PageNow < PageAll)
            {
                SaveVoucherDetails();
                PageNow++;
                this.TextBlock_PageNum.Text = PageNow + "/" + PageAll;
                VoucherDetailsNow = new List<Model_凭证明细>();
                for (int i = 0; i < 6; i++)
                {
                    VoucherDetailsNow.Add(VoucherDetails[(PageNow - 1) * 6 + i]);
                }
                this.DataGrid_凭证明细.ItemsSource = VoucherDetailsNow;
                this.TextBox_号.Text = VoucherDetailsNow[0].凭证号;
            }
        }

        private void TextBlock_PageNum_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                Button_Next_Click(null, null);
            }
            else if (e.Delta > 0)
            {
                Button_Previous_Click(null, null);
            }
        }
        #endregion
    }
}
