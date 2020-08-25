using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class GetOrdersRequestHelper : TBeanSerializer<GetOrdersRequest>
	{
		
		public static GetOrdersRequestHelper OBJ = new GetOrdersRequestHelper();
		
		public static GetOrdersRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrdersRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
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
						
						iprot.ReadSetEnd();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("order_ids".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetOrder_ids(value);
					}
					
					
					
					
					
					if ("is_export".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_export(value);
					}
					
					
					
					
					
					if ("query_start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetQuery_start_time(value);
					}
					
					
					
					
					
					if ("query_end_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetQuery_end_time(value);
					}
					
					
					
					
					
					if ("date_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDate_type(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
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
		
		
		public void Write(GetOrdersRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetStatus()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_ids() != null) {
				
				oprot.WriteFieldBegin("order_ids");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetOrder_ids()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_export() != null) {
				
				oprot.WriteFieldBegin("is_export");
				oprot.WriteString(structs.GetIs_export());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuery_start_time() != null) {
				
				oprot.WriteFieldBegin("query_start_time");
				oprot.WriteString(structs.GetQuery_start_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuery_end_time() != null) {
				
				oprot.WriteFieldBegin("query_end_time");
				oprot.WriteString(structs.GetQuery_end_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDate_type() != null) {
				
				oprot.WriteFieldBegin("date_type");
				oprot.WriteI32((int)structs.GetDate_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrdersRequest bean){
			
			
		}
		
	}
	
}