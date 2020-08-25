using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsZcodeApplyInfo {
		
		///<summary>
		/// 申请单号
		///</summary>
		
		private string APP_NUM_;
		
		///<summary>
		/// 申请数量
		///</summary>
		
		private int? AMOUNT_;
		
		///<summary>
		/// 申请时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string APP_TIME_;
		
		///<summary>
		/// 平台代码
		///</summary>
		
		private string CODE_;
		
		public string GetAPP_NUM(){
			return this.APP_NUM_;
		}
		
		public void SetAPP_NUM(string value){
			this.APP_NUM_ = value;
		}
		public int? GetAMOUNT(){
			return this.AMOUNT_;
		}
		
		public void SetAMOUNT(int? value){
			this.AMOUNT_ = value;
		}
		public string GetAPP_TIME(){
			return this.APP_TIME_;
		}
		
		public void SetAPP_TIME(string value){
			this.APP_TIME_ = value;
		}
		public string GetCODE(){
			return this.CODE_;
		}
		
		public void SetCODE(string value){
			this.CODE_ = value;
		}
		
	}
	
}