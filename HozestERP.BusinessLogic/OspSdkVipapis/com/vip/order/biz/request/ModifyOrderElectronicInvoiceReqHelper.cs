using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ModifyOrderElectronicInvoiceReqHelper : TBeanSerializer<ModifyOrderElectronicInvoiceReq>
	{
		
		public static ModifyOrderElectronicInvoiceReqHelper OBJ = new ModifyOrderElectronicInvoiceReqHelper();
		
		public static ModifyOrderElectronicInvoiceReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyOrderElectronicInvoiceReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderElectronicInvoiceVO".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderElectronicInvoiceVO(value);
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
		
		
		public void Write(ModifyOrderElectronicInvoiceReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderElectronicInvoiceVO() != null) {
				
				oprot.WriteFieldBegin("orderElectronicInvoiceVO");
				
				com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVOHelper.getInstance().Write(structs.GetOrderElectronicInvoiceVO(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyOrderElectronicInvoiceReq bean){
			
			
		}
		
	}
	
}