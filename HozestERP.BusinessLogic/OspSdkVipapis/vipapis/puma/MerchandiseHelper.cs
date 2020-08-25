using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class MerchandiseHelper : TBeanSerializer<Merchandise>
	{
		
		public static MerchandiseHelper OBJ = new MerchandiseHelper();
		
		public static MerchandiseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Merchandise structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("merchandise_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerchandise_no(value);
					}
					
					
					
					
					
					if ("start_sell_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStart_sell_time(value);
					}
					
					
					
					
					
					if ("end_sell_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEnd_sell_time(value);
					}
					
					
					
					
					
					if ("sales_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSales_no(value);
					}
					
					
					
					
					
					if ("sales_sites".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSales_sites(value);
					}
					
					
					
					
					
					if ("is_on_sale".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs_on_sale(value);
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
		
		
		public void Write(Merchandise structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMerchandise_no() != null) {
				
				oprot.WriteFieldBegin("merchandise_no");
				oprot.WriteI64((long)structs.GetMerchandise_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStart_sell_time() != null) {
				
				oprot.WriteFieldBegin("start_sell_time");
				oprot.WriteI64((long)structs.GetStart_sell_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd_sell_time() != null) {
				
				oprot.WriteFieldBegin("end_sell_time");
				oprot.WriteI64((long)structs.GetEnd_sell_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_no() != null) {
				
				oprot.WriteFieldBegin("sales_no");
				oprot.WriteI64((long)structs.GetSales_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_sites() != null) {
				
				oprot.WriteFieldBegin("sales_sites");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSales_sites()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_on_sale() != null) {
				
				oprot.WriteFieldBegin("is_on_sale");
				oprot.WriteI32((int)structs.GetIs_on_sale()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Merchandise bean){
			
			
		}
		
	}
	
}