using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class VendorSalesResHelper : TBeanSerializer<VendorSalesRes>
	{
		
		public static VendorSalesResHelper OBJ = new VendorSalesResHelper();
		
		public static VendorSalesResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorSalesRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorSalesDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.VendorSalesDo> value;
						
						value = new List<com.vip.isv.tools.VendorSalesDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.VendorSalesDo elem0;
								
								elem0 = new com.vip.isv.tools.VendorSalesDo();
								com.vip.isv.tools.VendorSalesDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetVendorSalesDos(value);
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
		
		
		public void Write(VendorSalesRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorSalesDos() != null) {
				
				oprot.WriteFieldBegin("vendorSalesDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.VendorSalesDo _item0 in structs.GetVendorSalesDos()){
					
					
					com.vip.isv.tools.VendorSalesDoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(VendorSalesRes bean){
			
			
		}
		
	}
	
}