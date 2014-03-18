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

        private static readonly string insert_T_BOOKS = "insert into T_BOOKS(ID,BOOK_NAME,COMPANY_NAME,CREATE_DATE,ACCOUNTING_SYSTEM,DELETE_MARK) "
            + "values(@ID, @BOOK_NAME,@COMPANY_NAME, @CREATE_DATE, @ACCOUNTING_SYSTEM, @DELETE_MARK)";
        
        private static readonly string insert_T_VOUCHER = "Insert into @T_VOUCHER(VOUCHER_NO,OP_TIME,WORD,NUMBER,SUBSIDIARY_COUNTS,FEE_DEBIT,FEE_CREDIT,ACCOUNTANT,BOOKEEPER,REVIEWER,REVIEW_MARK,DELETE_MARK) "
            + "values(@VOUCHER_NO, @OP_TIME, @WORD, @NUMBER, @SUBSIDIARY_COUNTS, @FEE_DEBIT, @FEE_CREDIT, @ACCOUNTANT, @BOOKEEPER, @REVIEWER, @REVIEW_MARK, @DELETE_MARK)";
        
        private static readonly string insert_T_VOUCHER_DETAIL = "Insert into @T_VOUCHER_DETAIL(VID, PARENTID, ABSTRACT, SUBJECT_ID, DETAIL, BOOKKEEP_MARK, DEBIT, CREDIT) "
            + "values(@VID, @PARENTID, @ABSTRACT, @SUBJECT_ID, @DETAIL, @BOOKKEEP_MARK, @DEBIT, @CREDIT)";
        
        private static readonly string insert_T_SUBJECT = "insert into @T_SUBJECT(SID,SUBJECT_ID,SUBJECT_TYPE,SUBJECT_NAME,FEE,PARENT_ID,USED_MARK) "
            + "values(@SID, @SUBJECT_ID, @SUBJECT_TYPE, @SUBJECT_NAME, @FEE, @PARENT_ID, @USED_MARK)";
        
        private static readonly string insert_T_SUBJECT_TYPE = "insert into T_SUBJECT_TYPE() "
            + "values()";

        private static readonly string insert_T_USER = "insert into @T_USER(USERNAME,REALNAME,PASSWORD,PHONE_NO,AUTHORITY,CREATE_TIME,COMMENTS) "
            + "values(@USERNAME, @REALNAME, @PASSWORD, @PHONE_NO, @AUTHORITY,@CREATE_TIME,@COMMENTS)";

        private static readonly string insert_T_RECORD = "insert into @T_RECORD(OP_TIME,USERNAME,REALNAME,OP_TYPE,LOG) "
            + "values(@OP_TIME, @USERNAME, @REALNAME, @OP_TYPE, @LOG)";

        #region GetSet
        public static string Delete_Sql
        {
            get { return SqlString.delete_Sql; }
        } 

        public static string Insert_T_BOOKS
        {
            get { return SqlString.insert_T_BOOKS; }
        } 

        public static string Insert_T_SUBJECT
        {
            get { return SqlString.insert_T_SUBJECT; }
        } 

        public static string Insert_T_SUBJECT_TYPE
        {
            get { return SqlString.insert_T_SUBJECT_TYPE; }
        } 

        public static string Insert_T_USER
        {
            get { return SqlString.insert_T_USER; }
        } 

        public static string Insert_T_RECORD
        {
            get { return SqlString.insert_T_RECORD; }
        } 

        public static string Update_Sql
        {
            get { return SqlString.update_Sql; }
        } 

        public static string Insert_T_VOUCHER_DETAIL
        {
            get { return SqlString.insert_T_VOUCHER_DETAIL; }
        }

        public static string Insert_T_VOUCHER
        {
            get { return SqlString.insert_T_VOUCHER; }
        }
        #endregion

    }
}
