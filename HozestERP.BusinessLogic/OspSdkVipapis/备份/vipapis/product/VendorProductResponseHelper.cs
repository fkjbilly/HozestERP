using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class VendorProductResponseHelper : BeanSerializer<VendorProductResponse>
	{
		
		public static VendorProductResponseHelper OBJ = new VendorProductResponseHelper();
		
		public static VendorProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSuccess_num(value);
					}
					
					
					
					
					
					if ("success_barcode_list".Equals(schemeField.Trim())){
						
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
						
						structs.SetSuccess_barcode_list(value);
					}
					
					
					
					
					
					if ("fail_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetFail_num(value);
					}
					
					
					
					
					
					if ("fail_item_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.VendorProductFailItem> value;
						
						value = new List<vipapis.product.VendorProductFailItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.VendorProductFailItem elem1;
								
								elem1 = new vipapis.product.VendorProductFailItem();
								vipapis.product.VendorProductFailItemHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_item_list(value);
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
		
		
		public void Write(VendorProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_num() != null) {
				
				oprot.WriteFieldBegin("success_num");
				oprot.WriteI32((int)structs.GetSuccess_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("success_num can not be null!");
			}
			
			
			if(structs.GetSuccess_barcode_list() != null) {
				
				oprot.WriteFieldBegin("success_barcode_list");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSuccess_barcode_list()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_num() != null) {
				
				oprot.WriteFieldBegin("fail_num");
				oprot.WriteI32((int)structs.GetFail_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("fail_num can not be null!");
			}
			
			
			if(structs.GetFail_item_list() != null) {
				
				oprot.WriteFieldBegin("fail_item_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.VendorProductFailItem _item0 in structs.GetFail_item_list()){
					
					
					vipapis.product.VendorProductFailItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorProductResponse bean){
			
			
		}
		
	}
	
}