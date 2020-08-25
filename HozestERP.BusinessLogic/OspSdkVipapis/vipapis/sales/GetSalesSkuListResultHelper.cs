using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.sales{
	
	
	
	public class GetSalesSkuListResultHelper : TBeanSerializer<GetSalesSkuListResult>
	{
		
		public static GetSalesSkuListResultHelper OBJ = new GetSalesSkuListResultHelper();
		
		public static GetSalesSkuListResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSalesSkuListResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("skuList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.sales.SalesSku> value;
						
						value = new List<vipapis.sales.SalesSku>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.sales.SalesSku elem0;
								
								elem0 = new vipapis.sales.SalesSku();
								vipapis.sales.SalesSkuHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSkuList(value);
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
		
		
		public void Write(GetSalesSkuListResult structs, Protocol oprot){
			
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
			
			
			if(structs.GetSkuList() != null) {
				
				oprot.WriteFieldBegin("skuList");
				
				oprot.WriteListBegin();
				foreach(vipapis.sales.SalesSku _item0 in structs.GetSkuList()){
					
					
					vipapis.sales.SalesSkuHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("skuList can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSalesSkuListResult bean){
			
			
		}
		
	}
	
}