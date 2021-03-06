﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PA.Model.DataGrid
{
    public class Model_凭证单 : INotifyPropertyChanged
    {

        private string id;
        private int period;
        private DateTime op_time;
        private int subsidiary_counts;
        private decimal fee_debit;
        private decimal fee_credit;
        private string accountant;
        private string bookkeeper;
        private string reviewer;
        private int review_mark;
        private int delete_mark;

        public int 当前期
        {
            get { return period; }
            set { period = value; }
        }
        public int 删除标志
        {
            get { return delete_mark; }
            set { delete_mark = value; }
        }

        public int 审核标志
        {
            get { return review_mark; }
            set { review_mark = value; }
        }

        public string 复核
        {
            get { return reviewer; }
            set { reviewer = value; }
        }

        public string 制单人
        {
            get { return bookkeeper; }
            set { bookkeeper = value; }
        }

        public string 会计主管
        {
            get { return accountant; }
            set { accountant = value; }
        }

        public decimal 合计贷方金额
        {
            get { return fee_credit; }
            set { fee_credit = value; }
        }

        public decimal 合计借方金额
        {
            get { return fee_debit; }
            set { fee_debit = value; }
        }

        public int 附属单证数
        {
            get { return subsidiary_counts; }
            set { subsidiary_counts = value; }
        }

        public DateTime 制表时间
        {
            get { return op_time; }
            set { op_time = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        /// <summary>
        /// cell内容改变事件
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
