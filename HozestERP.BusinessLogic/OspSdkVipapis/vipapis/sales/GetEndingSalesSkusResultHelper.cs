using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.sales{
	
	
	
	public class GetEndingSalesSkusResultHelper : TBeanSerializer<GetEndingSalesSkusResult>
	{
		
		public static GetEndingSalesSkusResultHelper OBJ = new GetEndingSalesSkusResultHelper();
		
		public static GetEndingSalesSkusResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetEndingSalesSkusResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("endingSalesSkus".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.sales.EndingSalesSku> value;
						
						value = new List<vipapis.sales.EndingSalesSku>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.sales.EndingSalesSku elem0;
								
								elem0 = new vipapis.sales.EndingSalesSku();
								vipapis.sales.EndingSalesSkuHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetEndingSalesSkus(value);
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
		
		
		public void Write(GetEndingSalesSkusResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetEndingSalesSkus() != null) {
				
				oprot.WriteFieldBegin("endingSalesSkus");
				
				oprot.WriteListBegin();
				foreach(vipapis.sales.EndingSalesSku _item0 in structs.GetEndingSalesSkus()){
					
					
					vipapis.sales.EndingSalesSkuHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetEndingSalesSkusResult bean){
			
			
		}
		
	}
	
}