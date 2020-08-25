using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.sales{
	
	
	
	public class GetSalesListResultHelper : TBeanSerializer<GetSalesListResult>
	{
		
		public static GetSalesListResultHelper OBJ = new GetSalesListResultHelper();
		
		public static GetSalesListResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSalesListResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("salesList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.sales.Sales> value;
						
						value = new List<vipapis.sales.Sales>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.sales.Sales elem0;
								
								elem0 = new vipapis.sales.Sales();
								vipapis.sales.SalesHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSalesList(value);
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
		
		
		public void Write(GetSalesListResult structs, Protocol oprot){
			
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
			
			
			if(structs.GetSalesList() != null) {
				
				oprot.WriteFieldBegin("salesList");
				
				oprot.WriteListBegin();
				foreach(vipapis.sales.Sales _item0 in structs.GetSalesList()){
					
					
					vipapis.sales.SalesHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("salesList can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSalesListResult bean){
			
			
		}
		
	}
	
}