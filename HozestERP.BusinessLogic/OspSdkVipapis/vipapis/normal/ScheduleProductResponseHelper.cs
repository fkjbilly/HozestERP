using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class ScheduleProductResponseHelper : TBeanSerializer<ScheduleProductResponse>
	{
		
		public static ScheduleProductResponseHelper OBJ = new ScheduleProductResponseHelper();
		
		public static ScheduleProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ScheduleProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("productList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.Product> value;
						
						value = new List<vipapis.normal.Product>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.Product elem1;
								
								elem1 = new vipapis.normal.Product();
								vipapis.normal.ProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProductList(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
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
		
		
		public void Write(ScheduleProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProductList() != null) {
				
				oprot.WriteFieldBegin("productList");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.Product _item0 in structs.GetProductList()){
					
					
					vipapis.normal.ProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ScheduleProductResponse bean){
			
			
		}
		
	}
	
}