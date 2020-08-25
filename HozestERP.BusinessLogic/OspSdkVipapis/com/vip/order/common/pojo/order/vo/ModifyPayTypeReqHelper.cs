using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class ModifyPayTypeReqHelper : TBeanSerializer<ModifyPayTypeReq>
	{
		
		public static ModifyPayTypeReqHelper OBJ = new ModifyPayTypeReqHelper();
		
		public static ModifyPayTypeReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyPayTypeReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("modifyPayTypeReq".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderInfoForReq> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderInfoForReq>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderInfoForReq elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderInfoForReq();
								com.vip.order.common.pojo.order.vo.OrderInfoForReqHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetModifyPayTypeReq(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
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
		
		
		public void Write(ModifyPayTypeReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetModifyPayTypeReq() != null) {
				
				oprot.WriteFieldBegin("modifyPayTypeReq");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderInfoForReq _item0 in structs.GetModifyPayTypeReq()){
					
					
					com.vip.order.common.pojo.order.vo.OrderInfoForReqHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyPayTypeReq bean){
			
			
		}
		
	}
	
}