using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class GetScheduleSkuListCriteria {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 查询时间段的开始时间，返回商品信息同步到VOP数据库的时间在此时间段的结果（Epoch 格式）
		///</summary>
		
		private long? start_query_;
		
		///<summary>
		/// 查询时间段的结束时间，返回商品信息同步到VOP数据库的时间在此时间段的结果（Epoch 格式）
		///</summary>
		
		private long? end_query_;
		
		///<summary>
		/// 业务模式，1：oxo-jit， 2：仓中仓，3：oxo直发，4：JIT分销，5：供应商直发货，6：JIT，7：JIT（3PL），8：3PL，9：海淘JIT，不传则返回OXO（1,2,3）以外的其他业务模式商品
		///</summary>
		
		private int? business_type_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public long? GetStart_query(){
			return this.start_query_;
		}
		
		public void SetStart_query(long? value){
			this.start_query_ = value;
		}
		public long? GetEnd_query(){
			return this.end_query_;
		}
		
		public void SetEnd_query(long? value){
			this.end_query_ = value;
		}
		public int? GetBusiness_type(){
			return this.business_type_;
		}
		
		public void SetBusiness_type(int? value){
			this.business_type_ = value;
		}
		
	}
	
}