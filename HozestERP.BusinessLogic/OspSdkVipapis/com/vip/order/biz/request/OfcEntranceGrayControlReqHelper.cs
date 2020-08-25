using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class OfcEntranceGrayControlReqHelper : TBeanSerializer<OfcEntranceGrayControlReq>
	{
		
		public static OfcEntranceGrayControlReqHelper OBJ = new OfcEntranceGrayControlReqHelper();
		
		public static OfcEntranceGrayControlReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OfcEntranceGrayControlReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnAndIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnAndIdList(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("snType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSnType(value);
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
		
		
		public void Write(OfcEntranceGrayControlReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnAndIdList() != null) {
				
				oprot.WriteFieldBegin("orderSnAndIdList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetOrderSnAndIdList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSnType() != null) {
				
				oprot.WriteFieldBegin("snType");
				oprot.WriteString(structs.GetSnType());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OfcEntranceGrayControlReq bean){
			
			
		}
		
	}
	
}