using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class CancelOrderPrivilegeReqHelper : TBeanSerializer<CancelOrderPrivilegeReq>
	{
		
		public static CancelOrderPrivilegeReqHelper OBJ = new CancelOrderPrivilegeReqHelper();
		
		public static CancelOrderPrivilegeReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelOrderPrivilegeReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("cancelSuppliersOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCancelSuppliersOrder(value);
					}
					
					
					
					
					
					if ("cancelSpecilizePreSaleOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCancelSpecilizePreSaleOrder(value);
					}
					
					
					
					
					
					if ("cancelPackagedOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCancelPackagedOrder(value);
					}
					
					
					
					
					
					if ("cancelOverseasSaleOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCancelOverseasSaleOrder(value);
					}
					
					
					
					
					
					if ("cancelOutOfWarehouseOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCancelOutOfWarehouseOrder(value);
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
		
		
		public void Write(CancelOrderPrivilegeReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCancelSuppliersOrder() != null) {
				
				oprot.WriteFieldBegin("cancelSuppliersOrder");
				oprot.WriteI32((int)structs.GetCancelSuppliersOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCancelSpecilizePreSaleOrder() != null) {
				
				oprot.WriteFieldBegin("cancelSpecilizePreSaleOrder");
				oprot.WriteI32((int)structs.GetCancelSpecilizePreSaleOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCancelPackagedOrder() != null) {
				
				oprot.WriteFieldBegin("cancelPackagedOrder");
				oprot.WriteI32((int)structs.GetCancelPackagedOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCancelOverseasSaleOrder() != null) {
				
				oprot.WriteFieldBegin("cancelOverseasSaleOrder");
				oprot.WriteI32((int)structs.GetCancelOverseasSaleOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCancelOutOfWarehouseOrder() != null) {
				
				oprot.WriteFieldBegin("cancelOutOfWarehouseOrder");
				oprot.WriteI32((int)structs.GetCancelOutOfWarehouseOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelOrderPrivilegeReq bean){
			
			
		}
		
	}
	
}