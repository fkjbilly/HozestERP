using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsOrderGetBodyResponseHelper : TBeanSerializer<OutWmsOrderGetBodyResponse>
	{
		
		public static OutWmsOrderGetBodyResponseHelper OBJ = new OutWmsOrderGetBodyResponseHelper();
		
		public static OutWmsOrderGetBodyResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsOrderGetBodyResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo();
								com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnList(value);
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
		
		
		public void Write(OutWmsOrderGetBodyResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnList() != null) {
				
				oprot.WriteFieldBegin("returnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfo _item0 in structs.GetReturnList()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutWmsOrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsOrderGetBodyResponse bean){
			
			
		}
		
	}
	
}