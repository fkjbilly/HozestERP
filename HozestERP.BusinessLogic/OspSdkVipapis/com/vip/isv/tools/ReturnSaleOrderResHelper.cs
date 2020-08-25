using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class ReturnSaleOrderResHelper : TBeanSerializer<ReturnSaleOrderRes>
	{
		
		public static ReturnSaleOrderResHelper OBJ = new ReturnSaleOrderResHelper();
		
		public static ReturnSaleOrderResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnSaleOrderRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnSaleOrderDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.ReturnSaleOrderDo> value;
						
						value = new List<com.vip.isv.tools.ReturnSaleOrderDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.ReturnSaleOrderDo elem0;
								
								elem0 = new com.vip.isv.tools.ReturnSaleOrderDo();
								com.vip.isv.tools.ReturnSaleOrderDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnSaleOrderDos(value);
					}
					
					
					
					
					
					if ("totalCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalCount(value);
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
		
		
		public void Write(ReturnSaleOrderRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnSaleOrderDos() != null) {
				
				oprot.WriteFieldBegin("returnSaleOrderDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.ReturnSaleOrderDo _item0 in structs.GetReturnSaleOrderDos()){
					
					
					com.vip.isv.tools.ReturnSaleOrderDoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalCount() != null) {
				
				oprot.WriteFieldBegin("totalCount");
				oprot.WriteI32((int)structs.GetTotalCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("totalCount can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnSaleOrderRes bean){
			
			
		}
		
	}
	
}