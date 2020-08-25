using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.brand{
	
	
	
	public class MultiGetBrandResponseHelper : TBeanSerializer<MultiGetBrandResponse>
	{
		
		public static MultiGetBrandResponseHelper OBJ = new MultiGetBrandResponseHelper();
		
		public static MultiGetBrandResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MultiGetBrandResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("brands".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.brand.BrandInfo> value;
						
						value = new List<vipapis.brand.BrandInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.brand.BrandInfo elem0;
								
								elem0 = new vipapis.brand.BrandInfo();
								vipapis.brand.BrandInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBrands(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(MultiGetBrandResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBrands() != null) {
				
				oprot.WriteFieldBegin("brands");
				
				oprot.WriteListBegin();
				foreach(vipapis.brand.BrandInfo _item0 in structs.GetBrands()){
					
					
					vipapis.brand.BrandInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MultiGetBrandResponse bean){
			
			
		}
		
	}
	
}