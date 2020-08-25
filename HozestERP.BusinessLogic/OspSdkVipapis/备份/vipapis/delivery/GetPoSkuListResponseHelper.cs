using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetPoSkuListResponseHelper : BeanSerializer<GetPoSkuListResponse>
	{
		
		public static GetPoSkuListResponseHelper OBJ = new GetPoSkuListResponseHelper();
		
		public static GetPoSkuListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPoSkuListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("purchase_order_sku_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.PurchaseOrderSku> value;
						
						value = new List<vipapis.delivery.PurchaseOrderSku>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.PurchaseOrderSku elem0;
								
								elem0 = new vipapis.delivery.PurchaseOrderSku();
								vipapis.delivery.PurchaseOrderSkuHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPurchase_order_sku_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(GetPoSkuListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPurchase_order_sku_list() != null) {
				
				oprot.WriteFieldBegin("purchase_order_sku_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.PurchaseOrderSku _item0 in structs.GetPurchase_order_sku_list()){
					
					
					vipapis.delivery.PurchaseOrderSkuHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPoSkuListResponse bean){
			
			
		}
		
	}
	
}