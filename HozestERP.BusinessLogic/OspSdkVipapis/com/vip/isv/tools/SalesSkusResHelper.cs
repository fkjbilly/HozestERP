using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class SalesSkusResHelper : TBeanSerializer<SalesSkusRes>
	{
		
		public static SalesSkusResHelper OBJ = new SalesSkusResHelper();
		
		public static SalesSkusResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SalesSkusRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("salesSkusDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.SalesSkusDo> value;
						
						value = new List<com.vip.isv.tools.SalesSkusDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.SalesSkusDo elem0;
								
								elem0 = new com.vip.isv.tools.SalesSkusDo();
								com.vip.isv.tools.SalesSkusDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSalesSkusDos(value);
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
		
		
		public void Write(SalesSkusRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSalesSkusDos() != null) {
				
				oprot.WriteFieldBegin("salesSkusDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.SalesSkusDo _item0 in structs.GetSalesSkusDos()){
					
					
					com.vip.isv.tools.SalesSkusDoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(SalesSkusRes bean){
			
			
		}
		
	}
	
}