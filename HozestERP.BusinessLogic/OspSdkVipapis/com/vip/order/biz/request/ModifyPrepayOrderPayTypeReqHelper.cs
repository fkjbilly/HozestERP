using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ModifyPrepayOrderPayTypeReqHelper : TBeanSerializer<ModifyPrepayOrderPayTypeReq>
	{
		
		public static ModifyPrepayOrderPayTypeReqHelper OBJ = new ModifyPrepayOrderPayTypeReqHelper();
		
		public static ModifyPrepayOrderPayTypeReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyPrepayOrderPayTypeReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("prepayOrderInfoForReqList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.PrepayOrderInfoForReq> value;
						
						value = new List<com.vip.order.biz.request.PrepayOrderInfoForReq>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.PrepayOrderInfoForReq elem1;
								
								elem1 = new com.vip.order.biz.request.PrepayOrderInfoForReq();
								com.vip.order.biz.request.PrepayOrderInfoForReqHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrepayOrderInfoForReqList(value);
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
		
		
		public void Write(ModifyPrepayOrderPayTypeReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPrepayOrderInfoForReqList() != null) {
				
				oprot.WriteFieldBegin("prepayOrderInfoForReqList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.PrepayOrderInfoForReq _item0 in structs.GetPrepayOrderInfoForReqList()){
					
					
					com.vip.order.biz.request.PrepayOrderInfoForReqHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyPrepayOrderPayTypeReq bean){
			
			
		}
		
	}
	
}