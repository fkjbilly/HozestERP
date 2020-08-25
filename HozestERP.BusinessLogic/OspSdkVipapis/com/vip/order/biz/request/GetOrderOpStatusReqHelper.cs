using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetOrderOpStatusReqHelper : TBeanSerializer<GetOrderOpStatusReq>
	{
		
		public static GetOrderOpStatusReqHelper OBJ = new GetOrderOpStatusReqHelper();
		
		public static GetOrderOpStatusReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderOpStatusReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderOpStatusVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderOpStatusVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderOpStatusVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderOpStatusVO();
								com.vip.order.common.pojo.order.vo.OrderOpStatusVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderList(value);
					}
					
					
					
					
					
					if ("opList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOpList(value);
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
		
		
		public void Write(GetOrderOpStatusReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderList() != null) {
				
				oprot.WriteFieldBegin("orderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderOpStatusVO _item0 in structs.GetOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderOpStatusVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpList() != null) {
				
				oprot.WriteFieldBegin("opList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetOpList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderOpStatusReq bean){
			
			
		}
		
	}
	
}