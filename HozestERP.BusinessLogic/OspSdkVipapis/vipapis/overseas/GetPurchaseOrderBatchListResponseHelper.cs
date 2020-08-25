using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class GetPurchaseOrderBatchListResponseHelper : TBeanSerializer<GetPurchaseOrderBatchListResponse>
	{
		
		public static GetPurchaseOrderBatchListResponseHelper OBJ = new GetPurchaseOrderBatchListResponseHelper();
		
		public static GetPurchaseOrderBatchListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPurchaseOrderBatchListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("po_batch_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.PurchaseOrderBatchInfo> value;
						
						value = new List<vipapis.overseas.PurchaseOrderBatchInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.PurchaseOrderBatchInfo elem0;
								
								elem0 = new vipapis.overseas.PurchaseOrderBatchInfo();
								vipapis.overseas.PurchaseOrderBatchInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPo_batch_list(value);
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
		
		
		public void Write(GetPurchaseOrderBatchListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_batch_list() != null) {
				
				oprot.WriteFieldBegin("po_batch_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.PurchaseOrderBatchInfo _item0 in structs.GetPo_batch_list()){
					
					
					vipapis.overseas.PurchaseOrderBatchInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPurchaseOrderBatchListResponse bean){
			
			
		}
		
	}
	
}