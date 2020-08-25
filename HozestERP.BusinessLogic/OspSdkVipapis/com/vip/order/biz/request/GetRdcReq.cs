using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetRdcReq {
		
		///<summary>
		/// 站点warehouse
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品SIZE ID 列表
		///</summary>
		
		private List<long?> merItemNoList_;
		
		///<summary>
		/// 商品对应的warehouse，参数格式：sizeWarehouse={"123":["VIP_NH"],"456":["VIP_NH","VIP_BJ"]}
		///</summary>
		
		private Dictionary<long?, List<string>> merItemNoWarehouseMap_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public List<long?> GetMerItemNoList(){
			return this.merItemNoList_;
		}
		
		public void SetMerItemNoList(List<long?> value){
			this.merItemNoList_ = value;
		}
		public Dictionary<long?, List<string>> GetMerItemNoWarehouseMap(){
			return this.merItemNoWarehouseMap_;
		}
		
		public void SetMerItemNoWarehouseMap(Dictionary<long?, List<string>> value){
			this.merItemNoWarehouseMap_ = value;
		}
		
	}
	
}