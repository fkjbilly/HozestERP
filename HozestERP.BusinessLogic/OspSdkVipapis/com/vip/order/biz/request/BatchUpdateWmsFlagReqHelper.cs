using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class BatchUpdateWmsFlagReqHelper : TBeanSerializer<BatchUpdateWmsFlagReq>
	{
		
		public static BatchUpdateWmsFlagReqHelper OBJ = new BatchUpdateWmsFlagReqHelper();
		
		public static BatchUpdateWmsFlagReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchUpdateWmsFlagReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnAndIdVOList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderSnAndIdVO();
								com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnAndIdVOList(value);
					}
					
					
					
					
					
					if ("flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFlag(value);
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
		
		
		public void Write(BatchUpdateWmsFlagReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnAndIdVOList() != null) {
				
				oprot.WriteFieldBegin("orderSnAndIdVOList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO _item0 in structs.GetOrderSnAndIdVOList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderSnAndIdVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFlag() != null) {
				
				oprot.WriteFieldBegin("flag");
				oprot.WriteI32((int)structs.GetFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchUpdateWmsFlagReq bean){
			
			
		}
		
	}
	
}