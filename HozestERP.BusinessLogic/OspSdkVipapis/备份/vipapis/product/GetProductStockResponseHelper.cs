using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class GetProductStockResponseHelper : BeanSerializer<GetProductStockResponse>
	{
		
		public static GetProductStockResponseHelper OBJ = new GetProductStockResponseHelper();
		
		public static GetProductStockResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetProductStockResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("products".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ProductStock> value;
						
						value = new List<vipapis.product.ProductStock>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ProductStock elem0;
								
								elem0 = new vipapis.product.ProductStock();
								vipapis.product.ProductStockHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProducts(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("nextCursorMark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNextCursorMark(value);
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
		
		
		public void Write(GetProductStockResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProducts() != null) {
				
				oprot.WriteFieldBegin("products");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ProductStock _item0 in structs.GetProducts()){
					
					
					vipapis.product.ProductStockHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("products can not be null!");
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetNextCursorMark() != null) {
				
				oprot.WriteFieldBegin("nextCursorMark");
				oprot.WriteString(structs.GetNextCursorMark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetProductStockResponse bean){
			
			
		}
		
	}
	
}