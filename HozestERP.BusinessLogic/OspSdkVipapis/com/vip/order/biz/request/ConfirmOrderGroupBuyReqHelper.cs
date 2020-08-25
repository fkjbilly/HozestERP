using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ConfirmOrderGroupBuyReqHelper : TBeanSerializer<ConfirmOrderGroupBuyReq>
	{
		
		public static ConfirmOrderGroupBuyReqHelper OBJ = new ConfirmOrderGroupBuyReqHelper();
		
		public static ConfirmOrderGroupBuyReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ConfirmOrderGroupBuyReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnUserIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnUserIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnUserIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnUserIdVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderSnUserIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnUserIdVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnUserIdList(value);
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
		
		
		public void Write(ConfirmOrderGroupBuyReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnUserIdList() != null) {
				
				oprot.WriteFieldBegin("orderSnUserIdList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnUserIdVO _item0 in structs.GetOrderSnUserIdList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnUserIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ConfirmOrderGroupBuyReq bean){
			
			
		}
		
	}
	
}