﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PA.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PA.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO t_subject_type
        ///VALUES
        ///	(999, &apos;未知&apos;),
        ///	(1, &apos;一、资产类&apos;),
        ///	(2, &apos;二、负债类&apos;),
        ///	(
        ///		3,
        ///		&apos;三、净资产类&apos;
        ///	),
        ///	(4, &apos;四、收入类&apos;),
        ///	(5, &apos;五、支出类&apos;);
        ///INSERT INTO t_user (
        ///	username,
        ///	password,
        ///	authority
        ///)
        ///VALUES
        ///	(&apos;admin&apos;, &apos;123&apos;, 3);.
        /// </summary>
        internal static string DatabaseData {
            get {
                return ResourceManager.GetString("DatabaseData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE T_BOOKS (									--账套表
        ///    ID                TEXT PRIMARY KEY,					--账套ID
        ///    BOOK_NAME         TEXT,								--账套名称
        ///	COMPANY_NAME	  TEXT,								--单位名称
        ///	MONEY_TYPE		  TEXT,								--本位币
        ///    CREATE_DATE       DATE,								--账套启用日期
        ///    ACCOUNTING_SYSTEM TEXT,								--会计制度
        ///	DELETE_MARK		  INTEGER DEFAULT ( 0 )				--删除标志    -1表示已删除
        ///);
        ///CREATE TABLE T_YEAR_FEE (								--科目年初金额设置表
        ///	SUBJECT_ID   TEXT PRIMARY KEY,						--科目编号
        ///	FEE			 DECIMAL,								--年初金额
        ///	BOOKID		 TEXT									--账套ID	
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DatabaseTable {
            get {
                return ResourceManager.GetString("DatabaseTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE T_VOUCHER (								--凭证表
        ///    ID                INTEGER  PRIMARY KEY,             --凭证ID
        ///    VOUCHER_NO        TEXT,								--凭证号
        ///    OP_TIME           DATETIME,							--制表时间
        ///    WORD              TEXT,								--字
        ///    NUMBER            INTEGER,							--号
        ///    SUBSIDIARY_COUNTS INTEGER,							--附属单证数
        ///    FEE_DEBIT         DECIMAL,							--合计借方总额
        ///    FEE_CREDIT        DECIMAL,							--合计贷方总额
        ///    ACCOUNTANT        TEXT,								--会计主管
        ///    BOOKEEPER         TEXT,								--记账
        ///    REVIEWER    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ReadOnlySQL {
            get {
                return ResourceManager.GetString("ReadOnlySQL", resourceCulture);
            }
        }
    }
}
