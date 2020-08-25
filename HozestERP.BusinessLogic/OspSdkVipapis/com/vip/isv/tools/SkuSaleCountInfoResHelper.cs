using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class SkuSaleCountInfoResHelper : TBeanSerializer<SkuSaleCountInfoRes>
	{
		
		public static SkuSaleCountInfoResHelper OBJ = new SkuSaleCountInfoResHelper();
		
		public static SkuSaleCountInfoResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SkuSaleCountInfoRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("skuSaleCountInfoDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.SkuSaleCountInfoDo> value;
						
						value = new List<com.vip.isv.tools.SkuSaleCountInfoDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.SkuSaleCountInfoDo elem0;
								
								elem0 = new com.vip.isv.tools.SkuSaleCountInfoDo();
								com.vip.isv.tools.SkuSaleCountInfoDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSkuSaleCountInfoDos(value);
					}
					
					
					
					
					
					if ("totalCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
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
		
		
		public void Write(SkuSaleCountInfoRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSkuSaleCountInfoDos() != null) {
				
				oprot.WriteFieldBegin("skuSaleCountInfoDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.SkuSaleCountInfoDo _item0 in structs.GetSkuSaleCountInfoDos()){
					
					
					com.vip.isv.tools.SkuSaleCountInfoDoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalCount() != null) {
				
				oprot.WriteFieldBegin("totalCount");
				oprot.WriteI32((int)structs.GetTotalCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SkuSaleCountInfoRes bean){
			
			
		}
		
	}
	
}