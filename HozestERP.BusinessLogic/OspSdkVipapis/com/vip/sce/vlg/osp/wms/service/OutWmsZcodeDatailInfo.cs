using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsZcodeDatailInfo {
		
		///<summary>
		/// 序号
		///</summary>
		
		private string ID_;
		
		///<summary>
		/// 商品货号
		///</summary>
		
		private string Z_CODE_;
		
		///<summary>
		/// 真知码串
		///</summary>
		
		private string Z_IMAGE_;
		
		public string GetID(){
			return this.ID_;
		}
		
		public void SetID(string value){
			this.ID_ = value;
		}
		public string GetZ_CODE(){
			return this.Z_CODE_;
		}
		
		public void SetZ_CODE(string value){
			this.Z_CODE_ = value;
		}
		public string GetZ_IMAGE(){
			return this.Z_IMAGE_;
		}
		
		public void SetZ_IMAGE(string value){
			this.Z_IMAGE_ = value;
		}
		
	}
	
}