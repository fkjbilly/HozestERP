using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutShipContainer {
		
		///<summary>
		/// 消息编号
		///</summary>
		
		private string MSG_ID_;
		
		///<summary>
		/// 仓库代码
		///</summary>
		
		private string WHSE_;
		
		///<summary>
		/// 消息类型
		///</summary>
		
		private string MSG_TYPE_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string PRCL_NBR_;
		
		///<summary>
		/// 目的站点
		///</summary>
		
		private string DEST_LOCN_;
		
		public string GetMSG_ID(){
			return this.MSG_ID_;
		}
		
		public void SetMSG_ID(string value){
			this.MSG_ID_ = value;
		}
		public string GetWHSE(){
			return this.WHSE_;
		}
		
		public void SetWHSE(string value){
			this.WHSE_ = value;
		}
		public string GetMSG_TYPE(){
			return this.MSG_TYPE_;
		}
		
		public void SetMSG_TYPE(string value){
			this.MSG_TYPE_ = value;
		}
		public string GetPRCL_NBR(){
			return this.PRCL_NBR_;
		}
		
		public void SetPRCL_NBR(string value){
			this.PRCL_NBR_ = value;
		}
		public string GetDEST_LOCN(){
			return this.DEST_LOCN_;
		}
		
		public void SetDEST_LOCN(string value){
			this.DEST_LOCN_ = value;
		}
		
	}
	
}