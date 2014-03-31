﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PA.Model.DataGrid;
using PA.Helper.DataBase;
using PA.ViewModel;
using PA.Helper.DataDefind;

namespace PA.Model.ComboBox
{
    class ComboBox_Common
    {
        private string sql = string.Empty;
        private DataSet ds = new DataSet();
        private DataBase db = new DataBase();
        private ViewModel_Books vmb = new ViewModel_Books();

        public List<Model_账套> GetComboBox_账套()
        {
            List<Model_账套> list = new List<Model_账套>();
            Model_账套 def = new Model_账套();
            def.ID = "0";
            def.账套名称 = "新建账套";
            list.Add(def);
            sql = "select id,book_name from t_books where delete_mark=0 order by create_date desc";
            ds = db.Query(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    Model_账套 m = new Model_账套();
                    m.ID = dr[0].ToString();
                    m.账套名称 = dr[1].ToString();
                    list.Add(m);
                }
            }
            return list;
        }
        public List<string> GetComboBox_会计制度()
        {
            List<string> list = new List<string>();
            list.Add("《行政单位会计制度》财预字[1998]49号");
            //list.Add("事业单位会计制度(2013年)");
            return list;
        }

        public List<string> GetComboBox_审核()
        {
            List<string> list = new List<string>();
            list.Add("全部");
            list.Add("已审核");
            list.Add("未审核");
            return list;
        }

        public List<string> GetComboBox_期数()
        {
            List<string> list = new List<string>();
            list.Add("全部");
            string str = vmb.GetValue();
            string value = str.Split('\t')[0].Split(',')[0].Split('年')[0];
            int count = CommonInfo.当前期;
            for (int i = 1; i <= count; i++)
            {
                string s = value + "年" + i + "期";
                list.Add(s);
            }
            return list;
        }
    }
}
