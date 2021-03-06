﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PA.Helper.DataDefind
{
    class SqlString
    {
        private static readonly string update_Sql = "Update @tableName set @key = @value where @whereParm";
        private static readonly string delete_Sql = "Delete from @tableName where @whereParm";

        private static readonly string insert_T_BOOKS = "insert into @T_BOOKS(ID,BOOK_NAME,COMPANY_NAME,BOOK_TIME,CREATE_DATE,ACCOUNTING_SYSTEM,PERIOD,BOOK_INDEX) "
            + "values (@ID, @BOOK_NAME,@COMPANY_NAME, @BOOK_TIME, @CREATE_DATE, @ACCOUNTING_SYSTEM, @PERIOD ,@BOOK_INDEX)";

        private static readonly string insert_T_VOUCHER = "Insert into @T_VOUCHER(ID,PERIOD,OP_TIME,PERIOD,SUBSIDIARY_COUNTS,FEE_DEBIT,FEE_CREDIT,ACCOUNTANT,BOOKEEPER,REVIEWER,REVIEW_MARK,DELETE_MARK) "
            + "values(@ID, @PERIOD, @OP_TIME, @PERIOD, @SUBSIDIARY_COUNTS, @FEE_DEBIT, @FEE_CREDIT, @ACCOUNTANT, @BOOKEEPER, @REVIEWER, @REVIEW_MARK, @DELETE_MARK)";

        private static readonly string insert_T_VOUCHER_DETAIL = "Insert into @T_VOUCHER_DETAIL(VID, PARENTID, WORD, VOUCHER_NO, ABSTRACT, SUBJECT_ID, DETAIL, BOOKKEEP_MARK, DEBIT, CREDIT) "
            + "values(@VID, @PARENTID, @WORD, @VOUCHER_NO, @ABSTRACT, @SUBJECT_ID, @DETAIL, @BOOKKEEP_MARK, @DEBIT, @CREDIT)";

        private static readonly string insert_T_SUBJECT = "insert into @T_SUBJECT(SUBJECT_ID,SUBJECT_TYPE,SUBJECT_NAME,PARENT_ID,USED_MARK,Borrow_Mark) "
            + "values(@SUBJECT_ID, @SUBJECT_TYPE, @SUBJECT_NAME, @PARENT_ID, @USED_MARK, @Borrow_Mark)";
        
        private static readonly string insert_T_SUBJECT_TYPE = "insert into @T_SUBJECT_TYPE() "
            + "values()";

        private static readonly string insert_T_USER = "insert into @T_USER(USERNAME,REALNAME,PASSWORD,PHONE_NO,AUTHORITY,CREATE_TIME,COMMENTS) "
            + "values(@USERNAME, @REALNAME, @PASSWORD, @PHONE_NO, @AUTHORITY,@CREATE_TIME,@COMMENTS)";

        private static readonly string insert_T_RECORD = "insert into @T_RECORD(OP_TIME,USERNAME,REALNAME,LOG) "
            + "values(@OP_TIME, @USERNAME, @REALNAME, @LOG)";

        private static readonly string insert_T_YEAR_FEE = "insert into T_YEAR_FEE(SUBJECT_ID,FEE,BOOKID) "
            + "values(@SUBJECT_ID, @FEE, @BOOKID)";

        private static readonly string insert_T_FIXEDASSETS = "insert into @T_FIXEDASSETS(ID,NAME,UNIT,AMOUNT,PRICE,USED_YEAR,BUY_DATE,DEPARMENT,CLEAR_DATE,VOUCHER_NO,COMMENTS) "
            + "values(@ID, @NAME, @UNIT, @AMOUNT, @PRICE, @USED_YEAR, @BUY_DATE, @DEPARMENT, @CLEAR_DATE, @VOUCHER_NO, @COMMENTS)";

        #region GetSet
        public static string Insert_T_YEAR_FEE
        {
            get { return SqlString.insert_T_YEAR_FEE; }
        } 

        public static string Delete_Sql
        {
            get { return SqlString.delete_Sql; }
        } 

        public static string Insert_T_BOOKS
        {
            get { return SqlString.insert_T_BOOKS.Replace("@T_BOOKS", DBTablesName.T_BOOKS); }
        } 

        public static string Insert_T_SUBJECT
        {
            get { return SqlString.insert_T_SUBJECT.Replace("@T_SUBJECT", DBTablesName.T_SUBJECT); }
        } 

        public static string Insert_T_SUBJECT_TYPE
        {
            get { return SqlString.insert_T_SUBJECT_TYPE.Replace("@T_SUBJECT_TYPE", DBTablesName.T_SUBJECT_TYPE); }
        } 

        public static string Insert_T_USER
        {
            get { return SqlString.insert_T_USER.Replace("@T_USER", DBTablesName.T_USER); }
        } 

        public static string Insert_T_RECORD
        {
            get { return SqlString.insert_T_RECORD.Replace("@T_RECORD", DBTablesName.T_RECORD); }
        } 

        public static string Update_Sql
        {
            get { return SqlString.update_Sql; }
        } 

        public static string Insert_T_VOUCHER_DETAIL
        {
            get { return SqlString.insert_T_VOUCHER_DETAIL.Replace("@T_VOUCHER_DETAIL", DBTablesName.T_VOUCHER_DETAIL); }
        }

        public static string Insert_T_VOUCHER
        {
            get { return SqlString.insert_T_VOUCHER.Replace("@T_VOUCHER", DBTablesName.T_VOUCHER); }
        }

        public static string Insert_T_FIXEDASSETS
        {
            get { return SqlString.insert_T_FIXEDASSETS.Replace("@T_FIXEDASSETS", DBTablesName.T_FIXEDASSETS); }
        }
        #endregion

    }
}
