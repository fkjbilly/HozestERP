using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetRdcInvoiceRespHelper : TBeanSerializer<GetRdcInvoiceResp>
	{
		
		public static GetRdcInvoiceRespHelper OBJ = new GetRdcInvoiceRespHelper();
		
		public static GetRdcInvoiceRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetRdcInvoiceResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("rdcInvoiceVOList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.RdcInvoiceVO> value;
						
						value = new List<com.vip.order.biz.response.RdcInvoiceVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.RdcInvoiceVO elem1;
								
								elem1 = new com.vip.order.biz.response.RdcInvoiceVO();
								com.vip.order.biz.response.RdcInvoiceVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetRdcInvoiceVOList(value);
					}
					
					
					
					
					
					if ("failOrderSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem3;
								elem3 = iprot.ReadString();
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFailOrderSnList(value);
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
		
		
		public void Write(GetRdcInvoiceResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRdcInvoiceVOList() != null) {
				
				oprot.WriteFieldBegin("rdcInvoiceVOList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.RdcInvoiceVO _item0 in structs.GetRdcInvoiceVOList()){
					
					
					com.vip.order.biz.response.RdcInvoiceVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailOrderSnList() != null) {
				
				oprot.WriteFieldBegin("failOrderSnList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetFailOrderSnList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetRdcInvoiceResp bean){
			
			
		}
		
	}
	
}