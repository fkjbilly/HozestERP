using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetRdcInvoiceReqHelper : TBeanSerializer<GetRdcInvoiceReq>
	{
		
		public static GetRdcInvoiceReqHelper OBJ = new GetRdcInvoiceReqHelper();
		
		public static GetRdcInvoiceReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetRdcInvoiceReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("rdcParamVOList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.RdcParamVO> value;
						
						value = new List<com.vip.order.biz.request.RdcParamVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.RdcParamVO elem0;
								
								elem0 = new com.vip.order.biz.request.RdcParamVO();
								com.vip.order.biz.request.RdcParamVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetRdcParamVOList(value);
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
		
		
		public void Write(GetRdcInvoiceReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRdcParamVOList() != null) {
				
				oprot.WriteFieldBegin("rdcParamVOList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.RdcParamVO _item0 in structs.GetRdcParamVOList()){
					
					
					com.vip.order.biz.request.RdcParamVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetRdcInvoiceReq bean){
			
			
		}
		
	}
	
}